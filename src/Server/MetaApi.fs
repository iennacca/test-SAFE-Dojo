module MetaApi

open Shared
open Extensions

let TestMe = "TEST"


let metaApi: IMetaApi = {
    GetVersion = fun _ -> async { return "0.01" }
    GetEnvironment = fun _ -> async { return if isDevelopment then "DEV" else "PRD" }
    GetEnvironmentVariables = fun _ -> async { return "Not yet implemented" }
}