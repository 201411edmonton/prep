require 'rake'
require 'rake/clean'
require 'fileutils'

require_relative 'init'
require 'legacy_tasks'

[settings.artifacts_dir, 
 settings.specs.dir].each do |item|
  CLEAN.include(item)
end

task :default => ["specs:run"]

task :init  => :clean do
  [
    settings.artifacts_dir,
    settings.specs.dir,
    settings.specs.report_dir,
  ].each do |folder| 
    FileUtils.mkdir_p folder if ! File.exists?(folder)
  end
end
