namespace Polyglot

module Common =
    type TraceLevel =
        | Verbose
        | Debug
        | Info
        | Warning
        | Critical

    let _locals () = ""

    let trace (_level : TraceLevel) (_fn : unit -> string) (_locals : unit -> string) = ()
