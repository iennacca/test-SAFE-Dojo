[<AutoOpen>]
module Extensions

open Elmish

let isDevelopment =
#if DEBUG
    true
#else
    false
#endif

module Log =
    /// Logs error to the console during development
    let developmentError (error: exn) =
        if isDevelopment then
            Browser.Dom.console.error (error)

[<RequireQualifiedAccess>]
module Config =
    open System
    open Fable.Core

    /// Returns the value of a configured variable using its key.
    /// Retursn empty string when the value does not exist
    [<Emit("process.env[$0] ? process.env[$0] : ''")>]
    let variable (key: string) : string = jsNative

    /// Tries to find the value of the configured variable if it is defined or returns a given default value otherwise.
    let variableOrDefault (key: string) (defaultValue: string) =
        let foundValue = variable key

        if String.IsNullOrWhiteSpace foundValue then
            defaultValue
        else
            foundValue

    let environment =
        match isDevelopment with
        | true -> "DEV"
        | _ -> "PRD"