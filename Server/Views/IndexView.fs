module Views.IndexView

open Microsoft.AspNetCore.Http
open Falco.Markup
open Falco.Markup.Components
open Falco.Datastar
open Views.Shared
open Routes

let todos =
    seq {
        for i in 1..10 do
            yield
                _div
                    []
                    [ _wc<TodoItem> ([ _label_ $"I am styled {i}" ] @ (if i % 2 = 0 then [ _completed_ ] else [])) [] ]
    }
    |> Seq.toList

let page = Layout.template todos
