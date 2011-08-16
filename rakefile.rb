require 'albacore'
require 'rake/clean'

MSBUILD_EXE 			= "#{ENV['WINDIR']}/Microsoft.NET/Framework64/v4.0.30319/msbuild.exe"
BUILD_LOG_FILE 			= "build"
BUILD_REPORTS 			= './BuildReports'
REFERENCE_DIRECTORY 	= "Packages"
NUNIT_CONSOLE_EXE		= "./Tools/nunit/nunit-console.exe"

task :default => [:clean, :get_packages, :compile, :unit_tests] #, :integration_tests]

CLEAN.include [BUILD_REPORTS + "/*",
		 Dir.glob(File.join("src/**", "bin/*")),
		 Dir.glob(File.join("src/**", "obj/*")),
		 Dir.glob(File.join("tests/**", "bin/*")),
		 Dir.glob(File.join("tests/**", "obj/*"))]
		 
desc "Compile"
msbuild :compile =>  [:get_packages, BUILD_REPORTS] do |msb|
	label "Compiling Reactive.Mvc!"
	msb.properties :configuration => :Debug
	msb.command = MSBUILD_EXE
	msb.targets :Clean, :Build
	msb.solution = "Reactive.Mvc.sln"
	msb.parameters "/l:FileLogger,Microsoft.Build;logfile=" + log_file(BUILD_LOG_FILE) + " /consoleloggerparameters:NoSummary;Verbosity=minimal"
end

task :get_packages => :clean do
	label "Retrieving package binaries"
	package_files = Dir.glob(File.join("**", "packages.config"))
	package_files.each do |file|
		cmd = "tools\\nuget.exe install #{file.gsub('/','\\')} -o #{REFERENCE_DIRECTORY.gsub('/','\\')}"
		system cmd
	end
end

nunit :unit_tests do |nunit|
	label "Running unit tests in Domain.Tests & Web.Tests"
	results_file_name 	= test_results_file("UnitTests")
    log_file_name 		= nunit_log_file("UnitTests")
    nunit.options		  results_file_name, log_file_name
    nunit.command 		= NUNIT_CONSOLE_EXE
	nunit.assemblies	  "tests/Reactive.Mvc.Test/bin/Debug/Reactive.Mvc.Test.dll"
end

#create directories
Module.constants.grep(/^BUILD_REPORTS$|^REFERENCE_DIRECTORY/).each do |dir_name|
	directory "#{Module.const_get(dir_name)}"
end

def label(taskname); 		     puts "\n\n *****\n ***** #{taskname} \n *****\n"; 				end
def log_file(log_file_name); 	     "#{BUILD_REPORTS}/#{log_file_name}.log";					end
def test_results_file(test_project); "/xml:\"#{BUILD_REPORTS}/#{test_project}-results.xml\""; 	end
def nunit_log_file(log_file_name);   "/out:#{log_file(log_file_name)}";							end