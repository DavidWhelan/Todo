module Falco.Markup.Components

open Interop

module Elem =
    let wc<'T> (attrs: XmlAttribute list) (children: XmlNode list) : XmlNode =
        let tagName = createTagName<'T> ()
        Elem.create tagName attrs children

module Attr =
    let completed value = Attr.create "completed" value

[<AutoOpen>]
module Html =
    let inline _wc<'T> (attrs: XmlAttribute list) (children: XmlNode list) : XmlNode = Elem.wc<'T> attrs children
    let inline _completed_ value = Attr.completed value
