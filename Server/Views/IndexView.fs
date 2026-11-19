module Views.IndexView

open Microsoft.AspNetCore.Http
open Falco.Markup
open Falco.Markup.Components
open Falco.Datastar
open Views.Shared
open Routes

let page =
    Layout.template [ _wc<TodoItem> [ _label_ "I am styled"; _completed_ "true" ] [] ]
