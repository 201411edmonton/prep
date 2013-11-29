configs ={
  :git => {
    :provider => missing("provider",__FILE__),
    :user => missing("user",__FILE__),
    :remotes => potentially_change("remotes",__FILE__),
    :repo => 'prep' 
  }
}
configatron.configure_from_hash(configs)
