open Fable.Remoting.Giraffe
open Fable.Remoting.Server
open Saturn
open Shared
open Giraffe

let dojoApiRouter =
    Remoting.createApi ()
    |> Remoting.withRouteBuilder Route.builder
    |> Remoting.fromValue Api.dojoApi
    |> Remoting.buildHttpHandler

let metaApiRouter =
    Remoting.createApi ()
    |> Remoting.withRouteBuilder Route.builder
    |> Remoting.fromValue MetaApi.metaApi
    |> Remoting.buildHttpHandler

// let metaApiRouter =
//     Remoting.createApi ()
//     |> Remoting.fromValue MetaApi.metaApi
//     |> Remoting.buildHttpHandler

let completeRouter = choose [ metaApiRouter; dojoApiRouter ]

let app = application {
    url "http://0.0.0.0:8085"
    use_router completeRouter
    use_static "public"
    use_gzip
}

run app