require 'expansions'

class Task < Thor
  namespace 'setup'
    
  default_task :scaffold

  desc 'expand', 'expands all templates'
  def expand
    Expansions::CLIInterface.run('ExpansionFile')
  end

  desc 'scaffold', 'scaffold a new repo'
  def scaffold(user_name, repo)
    configure({
      git_user_name: user_name,
      repo: repo
    })
    expand
    purge_old_repo_items
    rename_student_files
    initialize_repo(user_name, repo)
  end

  desc 'rename_student_files', 'rename the student specific files'
  def rename_student_files
    pattern = /^student_/

    Dir.glob("**/student_*").each do |file|
      folder = File.dirname(file) 
      filename = File.basename(file)
      regular_name = filename.gsub(pattern, '')

      new_name = File.join(folder, regular_name)
      `mv #{file} #{new_name}`
    end
  end

  no_commands do
    def initialize_repo(user_name, repo)
      `git init`
      `git add -A`
      `git commit -m "Initial commit"`
      `git remote add origin training:#{user_name}/#{repo}`
    end

    def purge_old_repo_items
      %w[.git .gitignore ExpansionFile Thorfile README.md.erb settings.rb].each do|item|
        `rm -rf #{item}`
      end
    end
  end
end
