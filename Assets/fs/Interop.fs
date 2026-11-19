module Interop

open System.Text.RegularExpressions

let inline createTagName<'T> () =
    let typeName = typeof<'T>.Name

    let name =
        Regex.Replace(typeName, "(((?<!^)[A-Z](?=[a-z]))|((?<=[a-z])[A-Z]))", " $1")

    "al-" + name.ToLower().Trim().Replace(" ", "-")
