config = 
{
  :course_name => missing("course_name",__FILE__),
  :project => missing("project",__FILE),
  :target => "Debug",
  :source_dir => "source",
  :artifacts_dir => "artifacts",
  :config_dir => "source/config",
  :app_dir => delayed{"source/#{configatron.project}"},
  :log_file_name => delayed{"#{configatron.project}_log.txt"},
  :log_level => "DEBUG"
}
configatron.configure_from_hash config