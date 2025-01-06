module TrackEmergencies.Api.Endpoints

open System.Threading.Tasks
open Giraffe
open Microsoft.AspNetCore.Http

let getCurrentEarthquakes (fetchData: unit -> Task<string>) = 
    fun (next: HttpFunc) (ctx: HttpContext) -> task {
        let! data = fetchData()
        return! json data next ctx
    }

let predictEarthquakes (predict: unit -> Task<string>) = 
    fun (next: HttpFunc) (ctx: HttpContext) -> task {
        let! prediction = predict()
        return! json prediction next ctx
    }