module Views.Shared.Layout

open Falco.Markup

let debugScript = []

let styles = [ _link [ _href_ "assets/app.css"; _rel_ "stylesheet" ] ]

let scripts =
    [ _script [ _type_ "module"; _src_ "js/datastar.js" ] []
      _script [ _type_ "module"; _src_ "fs/AutoLoader.fs?import" ] [] ]
    @ debugScript

let template (content: XmlNode list) =
    let body = [ _div [] content ] @ scripts

    _html [ _lang_ "en" ] [ _head [] styles; _body [] body ]
