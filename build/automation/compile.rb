module Automation
  class Compile < Thor
    namespace :compile

    desc 'rebuild', 'rebuilds the project'
    def rebuild
      require_rake
      Rake::Task['build:compile'].invoke
    end

    no_commands do
      def require_rake
        require 'rake'
        require 'albacore'
        require_relative '../legacy_tasks/build'
      end
    end
  end
end
