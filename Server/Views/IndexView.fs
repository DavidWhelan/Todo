module Views.IndexView

open Microsoft.AspNetCore.Http
open Falco.Markup
open Falco.Markup.Components
open Falco.Datastar
open Views.Shared
open Routes

let todos =
    [ for i in 1..10 do
          if i % 2 = 0 then
              yield (_wc<TodoItem> [ _label_ $"Todo {i}"; _completed_ ] [])
          else
              yield (_wc<TodoItem> [ _label_ $"Todo {i}" ] []) ]

let page = Layout.template todos
