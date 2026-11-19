module Controllers.IndexController

open Views.IndexView
open Routes.IndexRoutes
open Falco
open Falco.Routing

let pageHandler = Response.ofHtml page

let endpoints = [ get pageRoute pageHandler ]
