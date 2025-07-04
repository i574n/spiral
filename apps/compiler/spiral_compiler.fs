#nowarn 40

#if !INTERACTIVE
namespace Polyglot
#endif

module spiral_compiler =

    /// ## spiral_compiler
    open FSharp.Core

    // #!import '../../../polyglot/deps/The-Spiral-Language/The Spiral Language 2/Supervisor.fs'

    // #if !INTERACTIVE
    // open Polyglot
    open Common
    // open Lib
    // #endif

    /// ## PersistentVectorExtensions
    // #!import '../../../polyglot/deps/The-Spiral-Language/The Spiral Language 2/PersistentVectorExtensions.fs'

    // #if !INTERACTIVE
    //     open Polyglot
    //     open Common
    //     open Lib
    // #endif

    open System
    open FSharpx.Collections

    /// ### range_checks
    let range_checks from near_to vec =
        if from <= near_to = false then
            Common.trace Common.Critical (fun () -> $"PersistentVectorExtensions.range_checks / `from` must be less or equal to `near_to`. / from: {from} / near_to: {near_to} / vec: {vec}") Common._locals
            // raise (ArgumentException("`from` must be less or equal to `near_to`."))
        if from < 0 then raise (ArgumentException("`from` must not be negative."))
        if PersistentVector.length vec < near_to then raise (ArgumentException("`near_to` must not be beyond the length of the vector."))

    /// ### replace
    /// O(n+m). Replace the specified range in a vector with the sequence.
    let replace from near_to seq vec =
        range_checks from near_to vec
        let rec rest s =
            if from < PersistentVector.length s then
                PersistentVector.unconj s |> fst |> rest
            else
                Seq.fold (fun s x -> PersistentVector.conj x s) s seq
        let rec init s =
            if near_to < PersistentVector.length s then
                let s',x = PersistentVector.unconj s
                PersistentVector.conj x (init s')
            else
                rest s
        init vec

    /// ### mapi
    /// O(n). Returns a vector of the supplied length using the supplied function operating on the index.
    let mapi f vec = PersistentVector.init (PersistentVector.length vec) (fun i -> f i vec.[i])

    /// ### iter
    /// O(n). Iterates over a vector using the supplied function operating on the index.
    let iter f vec = 
        let rec loop i = if i < PersistentVector.length vec then f vec.[i]
        loop 0

    /// ### unzip
    /// O(n). Unzips a vector of pairs into pairs of vectors.
    let unzip vec = 
        let mutable a = PersistentVector.empty
        let mutable b = PersistentVector.empty
        iter (fun (a',b') -> a <- PersistentVector.conj a' a; b <- PersistentVector.conj b' b) vec
        a,b

    /// ### concat
    /// O(n). Concatenates a vector of vectors.
    let concat vec = PersistentVector.fold (PersistentVector.append) PersistentVector.empty vec

    /// ### rangePersistentVector
    /// O(near_to-from). Get the vector at a range.
    let persistentVectorRange from near_to vec =
        range_checks from near_to vec
        PersistentVector.init (near_to-from) (fun i -> vec.[i+from])

    /// ### tryFindBack
    /// O(~n). Returns the last element for which a given function returns true. None if such an element does not exist.
    let tryFindBack f vec =
        let rec loop i =
            if 0 <= i then 
                let x = PersistentVector.nth i vec
                if f x then Some x else loop (i-1)
            else
                None
        loop (PersistentVector.length vec - 1)

    /// ## HashConsing
    // Adapted from: https://github.com/backtracking/ocaml-hashcons
    // Type-Safe Modular Hash-Consing: https://www.lri.fr/~filliatr/ftp/publis/hash-consing2.pdf

    // open System
    open System.Runtime.InteropServices

    /// ### ConsedNode<'a>
    [<CustomComparison;CustomEquality;StructuredFormatDisplay("{AsString}")>]
    type ConsedNode<'a> =
        {
        node: 'a
        tag: int
        hkey: int
        }

        override x.ToString() = sprintf "<tag %i>" x.tag
        member x.AsString = x.ToString()
        override x.GetHashCode() = x.hkey
        override x.Equals(y) = 
            match y with 
            | :? ConsedNode<'a> as y -> x.tag = y.tag
            | _ -> false

        interface IComparable with
            member x.CompareTo(y) = 
                match y with
                | :? ConsedNode<'a> as y -> compare x.tag y.tag
                | _ -> raise <| ArgumentException "Invalid comparison for HashConsed."

    /// ### HashConsTable
    type HashConsTable() =
        let mutable table: ResizeArray<GCHandle> [] = Array.init 7 (fun _ -> ResizeArray(0))
        let mutable total_size: int = 0
        let mutable limit: int = 3
        let mutable is_finalized: bool = false
        let mutable counter: int = 0

        member private t.Resize() =
            let next_table_length x = x*3/2+3

            let table_length' = next_table_length table.Length
            if table_length' <= table.Length then failwith "The hash consing table cannot be grown anymore."
            let table' = Array.init table_length' (fun i -> ResizeArray())
            let limit' = limit+2
            let total_size' = 
                let mutable total_size=0
                for i=0 to table.Length-1 do
                    let table = table.[i]
                    for i=0 to table.Count-1 do
                        let x = table.[i]
                        total_size <-
                            match x.Target with
                            | null -> 
                                x.Free()
                                total_size
                            | a -> 
                                let bucket = table'.[(hash a &&& Int32.MaxValue) % table_length']
                                bucket.Add x
                                total_size+1
                total_size
            table <- table'
            limit <- limit'
            total_size <- total_size'

        member t.Add(x: 'a): ConsedNode<'a> =
            let hkey = hash x
            let table = table
            let bucket = table.[(hkey &&& Int32.MaxValue) % Array.length table]
            let sz = bucket.Count

            let rec loop empty_pos i =
                if i < sz then
                    match bucket.[i].Target with
                    | null -> loop i (i+1)
                    | :? ConsedNode<'a> as y when hkey = y.hkey && x = y.node -> y
                    | _ -> loop empty_pos (i+1)
                else
                    let node = {node=x; hkey=hkey; tag=counter}
                    counter <- counter+1
                    if empty_pos <> -1 then
                        let mutable m = bucket.[empty_pos]
                        m.Target <- node
                    else
                        bucket.Add (GCHandle.Alloc(node,GCHandleType.Weak))
                        total_size <- total_size+1
                        if total_size > limit * Array.length table then t.Resize()
                    node

            loop -1 0 // `-1` indicates the state of no empty bucket

        override __.Finalize() =
            if is_finalized = false then
                table |> (Array.iter << Seq.iter) (fun x -> x.Free())
                is_finalized <- true

    /// ## Startup
    open Argu

    /// ### PrimitiveType
    type PrimitiveType =
        | UInt8T | UInt16T | UInt32T | UInt64T
        | Int8T | Int16T | Int32T | Int64T
        | Float32T | Float64T
        | BoolT | StringT | CharT

    /// ### DefaultEnv
    type DefaultEnv = {
        port : int
        default_int : PrimitiveType
        default_uint : PrimitiveType
        default_float : PrimitiveType
        }

    /// ### CliArguments
    type CliArguments =
        | [<Mandatory;Unique>] Port of int
        | [<Unique>] Default_Int of string
        | [<Unique>] Default_Float of string

        interface IArgParserTemplate with
            member s.Usage =
                match s with
                | Port _ -> "specify a primary port."
                | Default_Int _ -> "specify the default int: i8, i16, i32, i64, u8, u16, u32, u64"
                | Default_Float _ -> "specify the default float: f32, f64"

    /// ### parseStartup
    let startupParse args =
        let parser = ArgumentParser.Create<CliArguments>(programName = "spiral.exe")
        let results = parser.ParseCommandLine(args)
        let int = 
            match results.GetResult(Default_Int,"i32") with
            | "i8" -> Int8T
            | "i16" -> Int16T
            | "i32" -> Int32T
            | "i64" -> Int64T
            | "u8" -> UInt8T
            | "u16" -> UInt16T
            | "u32" -> UInt32T
            | "u64" -> UInt64T
            | x -> failwith $"Invalid default int.\nGot: %s{x}\nExpected one of: i8, i16, i32, i64, u8, u16, u32, u64"

        let uint =
            match int with
            | Int8T -> UInt8T
            | Int16T -> UInt16T
            | Int32T -> UInt32T
            | Int64T -> UInt64T
            | x -> x // If the int is unsigned then make them the same type.
        {
        port = results.GetResult(Port)
        default_int = int
        default_uint = uint
        default_float = 
            match results.GetResult(Default_Float,"f64") with
            | "f32" -> Float32T
            | "f64" -> Float64T
            | x -> failwith $"Invalid default float.\nGot: %s{x}\nExpected one of: f32, f64"
        }

    /// ## Utils
    open System.Collections.Generic
    open System.Runtime.CompilerServices
    // open Common
#if !INTERACTIVE
    open Lib
#endif

    /// ### list_try_zip
    let list_try_zip a b = try Some (List.zip a b) with _ -> None

    /// ### get_default
    let inline get_default (memo_dict: Dictionary<_,_>) k def =
        match memo_dict.TryGetValue k with
        | true, v -> v
        | false, _ -> def()

    /// ### memoize'
    let inline memoize' (memo_dict: ConditionalWeakTable<_,_>) f k =
        match memo_dict.TryGetValue k with
        | true, v -> v
        | false, _ -> let v = f k in memo_dict.Add(k,v); v

    /// ### memoize
    let inline memoize (memo_dict: Dictionary<_,_>) f k =
        match memo_dict.TryGetValue k with
        | true, v -> v
        | false, _ -> let v = f k in memo_dict.Add(k,v); v

    /// ### lines
    let lines (str : string) = str.Split([|"\r\n";"\r";"\n"|],System.StringSplitOptions.None)

    /// ### remove
    let inline remove (dict : Dictionary<_,_>) x on_succ on_fail =
        let mutable q = Unchecked.defaultof<_>
        if dict.Remove(x, &q) then on_succ q else on_fail ()

    /// ### file_uri
    let file_uri (x : string) =
        let result = x |> SpiralFileSystem.standardize_path |> SpiralFileSystem.new_file_uri
        trace Verbose (fun () -> $"Utils.file_uri / x: {x} / result: {result}") _locals
        result

    //open Hopac
    //open Hopac.Infixes
    //open Hopac.Extensions
    //open Hopac.Stream

    //let print_ch = Ch<string>()
    //let pr x = Hopac.run (Ch.send print_ch (x.ToString()))

    module Utils =
        let memoize x =
            memoize x

        let get_default x =
            get_default x

        let list_try_zip x =
            list_try_zip x

    /// ## ParserCombinators

    /// ### index
    let inline index d = (^a : (member Index: ^b) d)

    /// ### index_set
    let inline index_set i d = (^a : (member set_Index: ^b -> unit) (d,i))

    /// ### (.>>.)
    let inline (.>>.) a b d =
        match a d with
        | Ok a ->
            match b d with
            | Ok b -> Ok (a,b)
            | Error x -> Error x
        | Error x -> Error x

    /// ### tuple3
    let inline tuple3 a b c d =
        match a d with
        | Ok a ->
            match b d with
            | Ok b -> 
                match c d with
                | Ok c -> Ok (a, b, c)
                | Error x -> Error x
            | Error x -> Error x
        | Error x -> Error x

    /// ### tuple4
    let inline tuple4 a b c d' d =
        match a d with
        | Ok a ->
            match b d with
            | Ok b -> 
                match c d with
                | Ok c -> 
                    match d' d with
                    | Ok d' -> Ok (a, b, c, d')
                    | Error x -> Error x
                | Error x -> Error x
            | Error x -> Error x
        | Error x -> Error x

    /// ### tuple5
    let inline tuple5 a b c d' e d =
        match a d with
        | Ok a ->
            match b d with
            | Ok b -> 
                match c d with
                | Ok c -> 
                    match d' d with
                    | Ok d' -> 
                        match e d with
                        | Ok e -> Ok (a, b, c, d', e)
                        | Error x -> Error x
                    | Error x -> Error x
                | Error x -> Error x
            | Error x -> Error x
        | Error x -> Error x

    /// ### tuple6
    let inline tuple6 a b c d' e f d =
        match a d with
        | Ok a ->
            match b d with
            | Ok b -> 
                match c d with
                | Ok c -> 
                    match d' d with
                    | Ok d' -> 
                        match e d with
                        | Ok e -> 
                            match f d with
                            | Ok f -> Ok (a, b, c, d', e, f)
                            | Error x -> Error x
                        | Error x -> Error x
                    | Error x -> Error x
                | Error x -> Error x
            | Error x -> Error x
        | Error x -> Error x

    /// ### tuple7
    let inline tuple7 a b c d' e f g d =
        match a d with
        | Ok a ->
            match b d with
            | Ok b -> 
                match c d with
                | Ok c -> 
                    match d' d with
                    | Ok d' -> 
                        match e d with
                        | Ok e -> 
                            match f d with
                            | Ok f ->
                                match g d with
                                | Ok g -> Ok (a, b, c, d', e, f, g)
                                | Error x -> Error x
                            | Error x -> Error x
                        | Error x -> Error x
                    | Error x -> Error x
                | Error x -> Error x
            | Error x -> Error x
        | Error x -> Error x

    /// ### pipe2
    let inline pipe2 a b f d =
        match a d with
        | Ok a ->
            match b d with
            | Ok b -> Ok (f a b)
            | Error x -> Error x
        | Error x -> Error x

    /// ### pipe3
    let inline pipe3 a b c f d =
        match a d with
        | Ok a ->
            match b d with
            | Ok b -> 
                match c d with
                | Ok c -> Ok (f a b c)
                | Error x -> Error x
            | Error x -> Error x
        | Error x -> Error x

    /// ### pipe4
    let inline pipe4 a b c d' f d =
        match a d with
        | Ok a ->
            match b d with
            | Ok b -> 
                match c d with
                | Ok c -> 
                    match d' d with
                    | Ok d' -> Ok (f a b c d')
                    | Error x -> Error x
                | Error x -> Error x
            | Error x -> Error x
        | Error x -> Error x

    /// ### pipe5
    let inline pipe5 a b c d' e f d =
        match a d with
        | Ok a ->
            match b d with
            | Ok b -> 
                match c d with
                | Ok c -> 
                    match d' d with
                    | Ok d' -> 
                        match e d with
                        | Ok e -> Ok (f a b c d' e)
                        | Error x -> Error x
                    | Error x -> Error x
                | Error x -> Error x
            | Error x -> Error x
        | Error x -> Error x

    /// ### (.>>)
    let inline (.>>) a b d =
        match a d with
        | Ok a ->
            match b d with
            | Ok b -> Ok a
            | Error x -> Error x
        | Error x -> Error x

    /// ### (>>.)
    let inline (>>.) a b d =
        match a d with
        | Ok a ->
            match b d with
            | Ok b -> Ok b
            | Error x -> Error x
        | Error x -> Error x

    /// ### opt
    let inline opt a d =
        let s = index d
        match a d with
        | Ok a -> Ok(Some a)
        | Error x -> 
            if s = index d then Ok(None)
            else Error x

    /// ### optional
    let inline optional a d = 
        let s = index d
        match a d with
        | Ok a -> Ok()
        | Error x -> 
            if s = index d then Ok()
            else Error x

    /// ### (|>>)
    let inline (|>>) a b d =
        match a d with
        | Ok a -> Ok(b a)
        | Error x -> Error x

    /// ### (>>%)
    let inline (>>%) a b d =
        match a d with
        | Ok a -> Ok(b)
        | Error x -> Error x

    /// ### (>>=)
    let inline (>>=) a b d =
        match a d with
        | Ok a -> b a d
        | Error x -> Error x

    /// ### (>>=?)
    let inline (>>=?) a b d =
        let i = index d
        match a d with
        | Ok a -> 
            let i' = index d
            match b a d with
            | Ok _ as x -> x
            | Error _ as x -> (if i' = index d then index_set i d); x // Backtracks to the beginning if the parser state has not changed.
        | Error x -> Error x

    /// ### many_iter
    let inline many_iter f a d =
        let rec loop () =
            let s = index d
            match a d with
            | Ok _ when s = index d -> failwith "The parser succeeded without changing the parser index in `many`. Had an exception not been raised the parser would have diverged."
            | Ok x -> f x; loop()
            | Error er -> if s = index d then Ok() else Error er
        loop ()

    /// ### many_resize_array
    let inline many_resize_array a d =
        let ar = ResizeArray()
        match many_iter ar.Add a d with
        | Ok() -> Ok(ar)
        | Error er -> Error er

    /// ### many_array
    let inline many_array a d = many_resize_array a d |> Result.map (fun x -> x.ToArray())

    /// ### many
    let inline many a d = many_resize_array a d |> Result.map Seq.toList

    /// ### sepBy
    let inline sepBy a b d =
        let s = index d
        match a d with
        | Ok a' -> (many (b >>. a) |>> fun b -> a' :: b) d
        | Error x -> if s = index d then Ok [] else Error x

    /// ### sepBy1
    let inline sepBy1 a b d =
        match a d with
        | Ok a' -> (many (b >>. a) |>> fun b -> a' :: b) d
        | Error x -> Error x

    /// ### many1
    let inline many1 a d =
        match a d with
        | Ok a' -> (many a |>> fun b -> a' :: b) d
        | Error x -> Error x

    /// ### attempt
    let inline attempt a d =
        let s = index d
        match a d with
        | Ok x -> Ok x
        | Error a as a' -> index_set s d; a'

    /// ### restore
    /// Restores the index on an error if at least i tokens have been consumed.
    let inline restore i a d =
        let s = index d
        match a d with
        | Ok x -> Ok x
        | Error _ as er -> (if index d <= s + i then index_set s d); er

    /// ### alt
    let inline alt s a b d =
        match a d with
        | Ok x -> Ok x
        | Error a as a' -> 
            if s = index d then
                match b d with
                | Ok x -> Ok x
                | Error b -> if s = index d then Error(List.append a b) else Error b
            else
                a'

    /// ### (<|>)
    let inline (<|>) a b d = let s = index d in alt s a b d

    /// ### (<|>%)
    let inline (<|>%) a b d =
        let s = index d
        match a d with
        | Ok x -> Ok x
        | Error _ as a' -> if s = index d then Ok b else a'

    /// ### choice
    let inline choice ar d =
        let s = index d
        let rec loop i =
            if i < Array.length ar then
                match ar.[i] d with
                | Ok x -> Ok x
                | Error a as a' -> 
                    if s = index d then
                        match loop (i+1) with
                        | Ok x -> Ok x
                        | Error b -> Error(List.append a b)
                    else
                        a'
            else
                Error []
        loop 0

    /// ### between
    let inline between a b c = a >>. c .>> b

    /// ## LineParsers
    // open System
    open System.Text

    open Microsoft.FSharp.Core

    /// ### TokenizerRange
    type TokenizerRange = {from : int; nearTo : int}

    /// ### TokenizerError
    type TokenizerError = string

    /// ### Tokenizer
    type Tokenizer = {
        text : string // A single line.
        mutable from : int
        } with

        member t.Index with get() = t.from and set i = t.from <- i

    /// ### range_char
    let range_char i = {from=i; nearTo=i+1}

    /// ### error_char
    let error_char i er = Error [range_char i, er]

    /// ### inc'
    let inc' i (s : Tokenizer) = s.from <- s.from+i

    /// ### inc
    let inc (s : Tokenizer) = inc' 1 s

    /// ### lineParsersEol
    /// End Of Line character
    let lineParsersEol = Char.MaxValue

    /// ### peek'
    let peek' (s : Tokenizer) i =
        let i = s.from + i
        if 0 <= i && i < s.text.Length then s.text.[i]
        else lineParsersEol

    /// ### peek
    let peek (s : Tokenizer) = peek' s 0

    /// ### many1Satisfy2L
    let inline many1Satisfy2L init body label (s : Tokenizer) = 
        let x = peek s
        if init x && x <> lineParsersEol then
            inc s
            let rec loop (b : StringBuilder) = 
                let x = peek s
                if body x && x <> lineParsersEol then inc s; b.Append(x) |> loop
                else b.ToString()
            Ok(loop (StringBuilder().Append(x)))
        else
            let i = s.from
            error_char i label

    /// ### many1SatisfyL
    let inline many1SatisfyL body label (s : Tokenizer) = many1Satisfy2L body body label s

    /// ### skip
    let inline skip c (s : Tokenizer) = let b = peek s = c in (if b then inc s); b

    /// ### spaces'
    let rec spaces' (s : Tokenizer) = if peek s = ' ' then inc s; spaces' s

    /// ### spaces
    let spaces s = spaces' s |> Ok

    /// ### spaces1
    let spaces1 (s : Tokenizer) =
        if peek s = ' ' then inc s; spaces s else error_char s.from "space"

    /// ### skip_char
    let skip_char c (s : Tokenizer) =
        let from = s.from
        if skip c s then Ok() else error_char from (sprintf "'%c'" c)

    /// ### skip_string
    let skip_string x (s : Tokenizer) =
        if String.Compare(s.text,s.from,x,0,x.Length) = 0 then inc' x.Length s; Ok()
        else error_char s.from x

    /// ### anyOf
    let anyOf (l : char list) (s : Tokenizer) =
        let c = peek s
        if Seq.contains c l then 
            inc s; Ok(c)
        else
            let i = s.from
            Error (List.map (fun c -> range_char i, string c) l)

    /// ### chars_till_string
    let chars_till_string close (s : Tokenizer) =
        assert (close <> "")
        let rec loop (b : StringBuilder) =
            let x = peek s
            if x = close.[0] && String.Compare(s.text,s.from,close,1,close.Length-1) = 0 then inc' close.Length s; Ok(b.ToString())
            else 
                if x <> lineParsersEol then inc s; b.Append(x) |> loop
                else error_char s.from close
        loop(StringBuilder())

    /// ### lineParsersNumber
    /// Parses a number as a sequence of digits and optionally underscores. Filters out the underscores from the result.
    let lineParsersNumber (s : Tokenizer) = 
        let x = peek s
        if Char.IsDigit x then
            inc s
            let rec loop (b : StringBuilder) = 
                let x = peek s
                if x = '_' then inc s; loop b
                elif Char.IsDigit x then inc s; loop(b.Append(x))
                else Ok(b.ToString())
            loop (StringBuilder().Append(x))
        else
            let i = s.from
            error_char i "number"

    /// ### number_fractional
    let number_fractional s = (lineParsersNumber .>>. (opt (skip_char '.' >>. lineParsersNumber))) s

    /// ## VSCTypes

    /// ### VSCPos
    type VSCPos = {|line : int; character : int|}

    /// ### VSCRange
    type VSCRange = VSCPos * VSCPos

    /// ### RString
    type RString = VSCRange * string

    /// ### PackageId
    type PackageId = int

    /// ### ModuleId
    type ModuleId = int

    /// ### DirId
    type DirId = int

    /// ### GlobalId
    type GlobalId = { package_id : PackageId; module_id : ModuleId; tag : int }

    /// ### RGlobalId
    type RGlobalId = VSCRange * GlobalId

    /// ### SpiEdit
    type SpiEdit = {|from: int; nearTo: int; lines: string []|}

    /// ## Tokenize
    // open System
    // open System.Text
    // open FSharpx.Collections

    /// ### TokenKeyword
    type TokenKeyword =
        | SpecIn
        | SpecAnd
        | SpecFun
        | SpecMatch
        | SpecTypecase
        | SpecFunction
        | SpecWith
        | SpecWithout
        | SpecAs
        | SpecWhen
        | SpecInl
        | SpecForall
        | SpecExists
        | SpecLet
        | SpecInm
        | SpecInb
        | SpecRec
        | SpecIf
        | SpecThen
        | SpecElif
        | SpecElse
        | SpecJoin
        | SpecJoinBackend
        | SpecType
        | SpecNominal
        | SpecReal
        | SpecUnion
        | SpecOpen
        | SpecWildcard
        | SpecPrototype
        | SpecInstance

    /// ### ParenthesisState
    type ParenthesisState = Open | Close

    /// ### Parenthesis
    type Parenthesis = Round | Square | Curly

    /// ### MacroEnum
    type MacroEnum = MTerm | MType | MTypeLit | MTermInline

    /// ### Literal
    type Literal = 
        | LitUInt8 of uint8
        | LitUInt16 of uint16
        | LitUInt32 of uint32
        | LitUInt64 of uint64
        | LitInt8 of int8
        | LitInt16 of int16
        | LitInt32 of int32
        | LitInt64 of int64
        | LitFloat32 of float32
        | LitFloat64 of float
        | LitBool of bool
        | LitString of string
        | LitChar of char

        // Converts the literal back to their string representation. Doesn't override the default printer.
        member l.LitToString() =
            match l with
            | LitUInt8 x -> x.ToString("R")
            | LitUInt16 x -> x.ToString("R")
            | LitUInt32 x -> x.ToString("R")
            | LitUInt64 x -> x.ToString("R")
            | LitInt8 x -> x.ToString("R")
            | LitInt16 x -> x.ToString("R")
            | LitInt32 x -> x.ToString("R")
            | LitInt64 x -> x.ToString("R")
            | LitFloat32 x -> x.ToString("R")
            | LitFloat64 x -> x.ToString("R")
            | LitBool x -> x.ToString()
            | LitString x -> x
            | LitChar x -> x.ToString()

    /// ### SemanticTokenLegend
    type SemanticTokenLegend =
        | variable = 0
        | symbol = 1
        | string = 2
        | number = 3
        | operator = 4
        | unary_operator = 5
        | comment = 6
        | keyword = 7
        | parenthesis = 8
        | type_variable = 9
        | escaped_char = 10
        | unescaped_char = 11
        | number_suffix = 12
        | escaped_var = 13

    /// ### SpiralToken
    type SpiralToken =
        | TokVar of string * SemanticTokenLegend
        | TokSymbol of string * SemanticTokenLegend
        | TokOperator of string * SemanticTokenLegend
        | TokUnaryOperator of string * SemanticTokenLegend
        | TokValue of Literal
        | TokValueSuffix
        | TokDefaultValue of string
        | TokComment of string
        | TokKeyword of TokenKeyword
        | TokParenthesis of Parenthesis * ParenthesisState
        | TokStringOpen | TokStringClose
        | TokText of string
        | TokEscapedChar of char
        | TokEscapedVar
        | TokUnescapedChar of char
        | TokMacroOpen | TokMacroClose
        | TokMacroTermVar of string * is_inline : bool
        | TokMacroTypeVar of string
        | TokMacroTypeLitVar of string
        | TokMacroExpression of MacroEnum * ParenthesisState

    /// ### token_groups
    let token_groups = function
        | TokUnaryOperator(_,r) | TokOperator(_,r) | TokVar(_,r) | TokSymbol(_,r) -> r
        | TokValue (LitChar _) | TokStringOpen | TokStringClose | TokText _ | TokMacroOpen | TokMacroClose | TokValue(LitString _) -> SemanticTokenLegend.string
        | TokComment _ -> SemanticTokenLegend.comment
        | TokKeyword _ -> SemanticTokenLegend.keyword
        | TokParenthesis _ -> SemanticTokenLegend.parenthesis
        | TokMacroTypeVar _ -> SemanticTokenLegend.type_variable
        | TokMacroTypeLitVar _ -> SemanticTokenLegend.type_variable
        | TokMacroTermVar _ -> SemanticTokenLegend.variable
        | TokMacroExpression _ -> SemanticTokenLegend.parenthesis
        | TokEscapedChar _ -> SemanticTokenLegend.escaped_char
        | TokEscapedVar -> SemanticTokenLegend.escaped_var
        | TokUnescapedChar _ -> SemanticTokenLegend.unescaped_char
        | TokValue _ | TokDefaultValue _ -> SemanticTokenLegend.number
        | TokValueSuffix -> SemanticTokenLegend.number_suffix

    /// ### show_lit
    let show_lit = function
        | LitUInt8 x -> sprintf "%iu8" x
        | LitUInt16 x -> sprintf "%iu16" x
        | LitUInt32 x -> sprintf "%iu32" x
        | LitUInt64 x -> sprintf "%iu64" x
        | LitInt8 x -> sprintf "%ii8" x
        | LitInt16 x -> sprintf "%ii16" x
        | LitInt32 x -> sprintf "%ii32" x
        | LitInt64 x -> sprintf "%ii64" x
        | LitFloat32 x -> sprintf "%ff32" x
        | LitFloat64 x -> sprintf "%ff64" x
        | LitBool x -> sprintf "%b" x
        | LitString x -> sprintf "%s" x
        | LitChar x -> sprintf "%c" x

    /// ### is_small_var_char_starting
    let is_small_var_char_starting c = Char.IsLower c || c = '_'

    /// ### is_var_char
    let is_var_char c = Char.IsLetterOrDigit c || c = '_' || c = '''

    /// ### is_big_var_char_starting
    let is_big_var_char_starting c = Char.IsUpper c

    /// ### is_parenth_open
    let is_var_char_starting c = Char.IsLetter c || c = '_'

    /// ### is_parenth_open
    let is_parenth_open c = 
        let f x = c = x
        f '(' || f '[' || f '{'

    /// ### is_parenth_close
    let is_parenth_close c = 
        let f x = c = x
        f ')' || f ']' || f '}'

    /// ### is_operator_char
    // http://www.asciitable.com/
    let is_operator_char c =
        let f x = c = x
        '!' <= c && c <= '~' && (is_var_char c || f '"' || is_parenth_open c || is_parenth_close c) = false

    /// ### is_prefix_separator_char
    let is_prefix_separator_char c = 
        let f x = c = x
        f ' ' || f lineParsersEol || is_parenth_open c

    /// ### is_postfix_separator_char
    let is_postfix_separator_char c = 
        let f x = c = x
        f ' ' || f lineParsersEol || is_parenth_close c

    /// ### is_separator_char
    let is_separator_char c = is_prefix_separator_char c || is_parenth_close c

    /// ### var
    let var (s: Tokenizer) = 
        let from = s.from
        let ok x = Ok ({from=from; nearTo=s.from}, x)
        let body x _ = 
            if skip ':' s then error_char from ": is not allowed directly after a var."
            else
                let f x = TokKeyword(x)
                match x with
                | "in" -> f SpecIn
                | "and" -> f SpecAnd | "fun" -> f SpecFun
                | "match" -> f SpecMatch | "typecase" -> f SpecTypecase
                | "function" -> f SpecFunction
                | "with" -> f SpecWith | "without" -> f SpecWithout
                | "as" -> f SpecAs | "when" -> f SpecWhen
                | "inl" -> f SpecInl | "forall" -> f SpecForall
                | "let" -> f SpecLet | "inm" -> f SpecInm
                | "inb" -> f SpecInb | "rec" -> f SpecRec
                | "if" -> f SpecIf | "then" -> f SpecThen
                | "elif" -> f SpecElif | "else" -> f SpecElse
                | "join" -> f SpecJoin | "join_backend" -> f SpecJoinBackend
                | "type" -> f SpecType | "nominal" -> f SpecNominal 
                | "real" -> f SpecReal | "union" -> f SpecUnion
                | "open" -> f SpecOpen | "_" -> f SpecWildcard
                | "prototype" -> f SpecPrototype | "instance" -> f SpecInstance
                | "true" -> TokValue(LitBool true) | "false" -> TokValue(LitBool false)
                | "exists" -> f SpecExists
                | x -> TokVar(x,SemanticTokenLegend.variable)
                |> ok

        (many1Satisfy2L is_var_char_starting is_var_char "variable" >>= body .>> spaces) s

    /// ### isHexDigit
    let isHexDigit c =
        ('0' <= c && c <= '9') || ('a' <= c && c <= 'f') || ('A' <= c && c <= 'F')

    /// ### hexNumberLineParser
    let hexNumberLineParser (s : Tokenizer) =
        let from = s.from
        if peek s = '0' && (let x = peek' s 1 in x = 'x' || x = 'X') then
            inc' 2 s
            let res = many1SatisfyL isHexDigit "hexadecimal digit" s
            if Result.isError res then error_char from "hexadecimal digit"
            else res
        else
            let i = s.from
            error_char i "0x prefix"

    /// ### hexNumber
    let hexNumber (s: Tokenizer) : Result<_,_> =
        let from = s.from
        let p s =
            match hexNumberLineParser s with
            | Ok hexStr ->
                let value = System.Convert.ToInt32(hexStr, 16)
                Ok ([{from=from; nearTo=s.from}, TokValue(LitInt32 value)])
            | Error e -> Error e

        (p .>> spaces) s

    /// ### tokenizeNumber
    let tokenizeNumber (s: Tokenizer) = 
        let from = s.from

        let parser (s: Tokenizer) = 
            if peek s = '-' && Char.IsDigit (peek' s 1) && is_prefix_separator_char (peek' s -1) then 
                inc s
                number_fractional s |> Result.map (function 
                    | (a,Some b) -> sprintf "-%s.%s" a b
                    | (a,None) -> "-"+a)
            else number_fractional s |> Result.map (function 
                    | (a,Some b) -> sprintf "%s.%s" a b
                    | (a,None) -> a)

        let followedBySuffix x (s: Tokenizer) =
            let from' = s.from
            let inline safe_parse string_to_val val_to_lit val_dsc =
                if (let x = peek s in is_separator_char x || is_operator_char x) then
                    match string_to_val x with
                    | true, x -> Ok [{from=from; nearTo=from'}, TokValue(val_to_lit x); {from=from'; nearTo=s.from}, TokValueSuffix]
                    | false, _ -> Error [{from=from; nearTo=s.from}, (sprintf "The string %s cannot be safely parsed as %s." x val_dsc)]
                else error_char s.from "separator"
            let skip c = skip c s
            if skip 'i' then
                if skip '8' then safe_parse SByte.TryParse LitInt8 "i8"
                elif skip '1' && skip '6' then safe_parse Int16.TryParse LitInt16 "i16"
                elif skip '3' && skip '2' then safe_parse Int32.TryParse LitInt32 "i32"
                elif skip '6' && skip '4' then safe_parse Int64.TryParse LitInt64 "i64"
                else error_char s.from "8,16,32 or 64"
            elif skip 'u' then
                if skip '8' then safe_parse Byte.TryParse LitUInt8 "uint8"
                elif skip '1' && skip '6' then safe_parse UInt16.TryParse LitUInt16 "u16"
                elif skip '3' && skip '2' then safe_parse UInt32.TryParse LitUInt32 "u32"
                elif skip '6' && skip '4' then safe_parse UInt64.TryParse LitUInt64 "u64"
                else error_char s.from "8,16,32 or 64"
            elif skip 'f' then
                if skip '3' && skip '2' then safe_parse Single.TryParse LitFloat32 "f32"
                elif skip '6' && skip '4' then safe_parse Double.TryParse LitFloat64 "f64"
                else error_char s.from "32 or 64"
            else Ok [{from=from; nearTo=s.from}, TokDefaultValue x]

        (parser >>= followedBySuffix .>> spaces) s

    /// ### symbol
    let symbol s =
        let from = s.from
        let f x = ({from=from; nearTo=s.from}, x)

        let symbol x = TokSymbol(x,SemanticTokenLegend.symbol)
        let x = peek s
        let x' = peek' s 1
        if x = '.' && x' = '(' then inc' 2 s; ((many1SatisfyL is_operator_char "operator") .>> skip_char ')' |>> (symbol >> f) .>> spaces) s
        elif x = '.' && is_var_char_starting x' then inc s; ((many1SatisfyL is_var_char "variable") |>> (symbol >> f) .>> spaces) s
        else error_char from "symbol"

    /// ### comment
    let comment (s : Tokenizer) =
        if peek s = '/' && peek' s 1 = '/' then 
            let from = s.from
            inc' 2 s
            while peek s = '/' || (peek s = '!' && peek' s 1 = ' ') do
                inc s
            if skip ' ' s then
                let com = s.text.[s.from..]
                s.from <- s.text.Length
                Ok ({from=from; nearTo=s.from}, TokComment com)
            else error_char s.from "whitespace"
        else
            error_char s.from "comment"

    /// ### operator
    let operator (s : Tokenizer) = 
        let from = s.from
        let ok x = ({from=from; nearTo=s.from}, x) |> Ok
        let is_separator_prev = is_prefix_separator_char (peek' s -1)
        let f name (s: Tokenizer) = 
            if is_separator_prev && (is_postfix_separator_char (peek s) = false) then TokUnaryOperator(name,SemanticTokenLegend.unary_operator) |> ok
            else TokOperator(name,SemanticTokenLegend.operator) |> ok
        (many1SatisfyL is_operator_char "operator"  >>= f .>> spaces) s

    /// ### string_raw
    let string_raw s =
        let from = s.from
        let f x = {from=from; nearTo=s.from}, TokValue(LitString x)
        (skip_string "@\"" >>. chars_till_string "\"" |>> f .>> spaces) s

    /// ### char_quoted
    let char_quoted s = 
        let char_quoted_body (s: Tokenizer) =
            let inline read on_succ =
                let x = peek s
                if x <> lineParsersEol then inc s; on_succ x
                else error_char s.from "character or '"
            read (function
                | '\\' -> 
                    read (Ok << function
                        | 'n' -> '\n' | 'r' -> '\r' | 't' -> '\t' | 'b' -> '\b'
                        | x -> x
                        )
                | x -> Ok x
                )
        let from = s.from
        let f _ x _ = {from=from; nearTo=s.from}, TokValue(LitChar x)
        (pipe3 (skip_char '\'') char_quoted_body (skip_char '\'') f .>> spaces) s

    /// ### special_char
    let inline special_char l text s =
        let inline f from x = {from=from; nearTo=s.from}, x
        let f = f s.from
        inc s
        let esc x = inc s; text (f (TokEscapedChar x) :: l)
        let unesc x = inc s; text (f (TokUnescapedChar x) :: l)
        match peek s with 
        | x when x = lineParsersEol -> error_char s.from "character"
        | 'n' -> esc '\n' | 'r' -> esc '\r'  | 't' -> esc '\t'  | 'b' -> esc '\b' 
        | x -> unesc x

    /// ### string_quoted'
    let string_quoted' s =
        let inline f from x = {from=from; nearTo=s.from}, x
        let close l = let f = f s.from in inc s; List.rev (f TokStringClose :: l) |> Ok
        let rec text l =
            let f = f s.from
            let rec loop (str : StringBuilder) =
                let l () = if 0 < str.Length then f (TokText(str.ToString())) :: l else l
                match peek s with
                | x when x = lineParsersEol -> error_char s.from "character or \""
                | '\\' -> special_char (l ()) text s
                | '"' -> close (l ())
                | x -> inc s; loop (str.Append(x))
            loop (StringBuilder())

        match peek s with
        | '"' -> let f = f s.from in inc s; text [f TokStringOpen]
        | _ -> error_char s.from "\""

    /// ### string_quoted
    let string_quoted s = (string_quoted' .>> spaces) s

    /// ### TokenizerMacro
    type TokenizerMacro =
        | Text of TokenizerRange * string
        | EscapedChar of TokenizerRange * char
        | EscapedVar of TokenizerRange
        | UnescapedChar of TokenizerRange * char
        | Expression of TokenizerRange * string * MacroEnum
        | Var of TokenizerRange * string * MacroEnum

    /// ### range
    let inline range p s = 
        let from = s.from
        match p s with
        | Ok x -> Ok({from=from; nearTo=s.from}, x)
        | Error l -> Error l

    /// ### brackets
    let brackets s =
        let from = s.from
        let f spec = inc s; (spaces >>% ({from=from; nearTo=s.from}, TokParenthesis(spec))) s
        match peek s with
        | '(' -> f (Round,Open) | '[' -> f (Square,Open) | '{' -> f (Curly,Open)
        | ')' -> f (Round,Close) | ']' -> f (Square,Close) | '}' -> f (Curly,Close)
        | _ -> error_char s.from "`(`,`[`,`{`,`}`,`]` or `)`"

    /// ### tab
    let tab s = if peek s = '\t' then Error [range_char (index s), "Tabs are not allowed."] else Error []

    /// ### tokenizeEol
    let tokenizeEol s = if peek s = lineParsersEol then Ok [] else Error [range_char (index s), "end of line"]

    /// ### token
    let rec token s =
        let i = s.from
        let inline (+) a b = alt i a b
        let individual_tokens = string_quoted + hexNumber + tokenizeNumber + ((var + symbol + string_raw + char_quoted + brackets + comment + operator) |>> fun x -> [x]) |>> fun x -> x, []
        (macro + individual_tokens) s
    and tokenize text =
        let mutable ar = PersistentVector.empty
        let mutable er = []
        let tokens =
            many_iter (fun (x : (TokenizerRange * SpiralToken) list,er' : (TokenizerRange * string) list) ->
                List.iter (fun x -> ar <- PersistentVector.conj x ar) x
                er <- List.append er' er
                ) token
        let er = match (spaces >>. tokens .>> (tokenizeEol <|> tab)) {from=0; text=text} with Ok() -> er | Error er' -> List.append er' er
        ar, er
    and macro s =
        let char_to_macro_expr = function
            | '`' -> MType
            | '!' -> MTerm
            | '@' -> MTypeLit
            | '#' -> MTermInline
            | _ -> failwith "Compiler error: Unknown char in the tokenizer."

        let p_special_char s =
            match peek' s 0, peek' s 1 with
            | '\\', ('n' | 'r' | 't' | 'b' as c) -> 
                let r = {from=s.from; nearTo=s.from+2}
                inc' 2 s
                Ok(EscapedChar(r, c))
            | '\\', ('v' as c) -> 
                let r = {from=s.from; nearTo=s.from+2}
                inc' 2 s
                Ok(EscapedVar(r))
            | '\\', c ->
                let r = {from=s.from; nearTo=s.from+2}
                inc' 2 s 
                Ok(UnescapedChar(r, c))
            | _ -> error_char s.from "\\"

        let p_var s = (many1Satisfy2L is_var_char_starting is_var_char "variable") s
        let p_text closing_char s = (range (many1SatisfyL (fun c -> c <> closing_char && c <> '`' && c <> '!' && c <> '@' && c <> '#' && c <> '\\') "macro text") |>> Text) s
        let p_expr s = 
            let start = anyOf ['`'; '!'; '@'; '#']
            let case_paren start_char = 
                let mutable c = 1 // number of open parens.
                between (skip_char '(') (skip_char ')') (many1SatisfyL (fun x -> // Stops when the number of open parens is 0.
                    c <- c + (match x with '(' -> 1 | ')' -> -1 | _ -> 0)
                    c > 0
                    ) "not )") 
                |>> fun (body) range -> Expression(range,body,char_to_macro_expr start_char)
            let case_var start_char =
                (skip_char start_char |>> fun () range -> UnescapedChar(range,start_char))
                <|> (p_var |>> fun body range -> Var(range,body,char_to_macro_expr start_char))
            (range (start >>= fun start_char -> (case_paren start_char <|> case_var start_char))
            |>> fun (range, f) -> f range) s
        let p_macro_inner closing_char s = (many (p_special_char <|> p_text closing_char <|> p_expr) <|>% []) s
        let p_macro s =
            let body a b = range (between (skip_string a) (skip_char b) (p_macro_inner b))
            (body "$\"" '"' <|> body "$'" ''') s

        match (p_macro .>> spaces) s with
        | Ok(r, x) -> 
            let start = 
                let r = {from=r.from; nearTo=r.from+2}
                r, TokMacroOpen
            let end_ = 
                let r = {from=r.nearTo-1; nearTo=r.nearTo}
                r, TokMacroClose

            let mutable er = []
            x |> List.collect (function
                | Text(r,x) -> [r, TokText x]
                | EscapedChar(r,x) ->
                    let x = match x with 'n' -> '\n' | 'r' -> '\r' | 't' -> '\t' | 'b' -> '\b' | x -> x
                    [r, TokEscapedChar x]
                | EscapedVar(r) -> [r, TokEscapedVar]
                | UnescapedChar(r,x) -> [r, TokUnescapedChar x]
                | Var(r,x,MType) -> [r, TokMacroTypeVar x]
                | Var(r,x,MTypeLit) -> [r, TokMacroTypeLitVar x]
                | Var(r,x,(MTerm | MTermInline as u)) -> [r, TokMacroTermVar(x, u = MTermInline)]
                | Expression(r,x,t) -> 
                    let start = 
                        let r = {from=r.from; nearTo=r.from+2}
                        r, TokMacroExpression(t,Open)
                    let end_ = 
                        let r = {from=r.nearTo-1; nearTo=r.nearTo}
                        r, TokMacroExpression(t,Close)
                    let middle,er' =
                        let adjust_range (r : TokenizerRange,x) = {from=r.from + (fst start).nearTo; nearTo=r.nearTo + (fst start).nearTo}, x
                        let middle,er' = tokenize x
                        PersistentVector.map adjust_range middle,
                        List.map adjust_range er'
                    er <- List.append er' er
                    List.concat [[start]; List.ofSeq middle; [end_]]
                )
            |> fun l -> Ok(List.concat [[start]; l; [end_]], er)
        | Error er -> Error er

    /// ### LineToken
    type LineToken = TokenizerRange * SpiralToken

    /// ### LineComment
    type LineComment = TokenizerRange * string

    /// ### LineTokenErrors
    type LineTokenErrors = (TokenizerRange * TokenizerError) list

    /// ### vscode_tokens
    let vscode_tokens ((a,b) : VSCRange) (lines : LineToken PersistentVector PersistentVector) =
        let in_range x = min lines.Length x
        let from, near_to = in_range a.line, in_range (b.line+1)
        let toks = ResizeArray()
        let rec loop i line_delta =
            if i < near_to then
                lines.[i] |> PersistentVector.fold (fun (line_delta,from_prev) (r,x) ->
                    toks.AddRange [|line_delta; r.from-from_prev; r.nearTo-r.from; int (token_groups x); 0|]
                    0, r.from
                    ) (line_delta, 0)
                |> fst |> ((+) 1) |> loop (i+1)

        loop from from
        toks.ToArray()

    module Tokenize =
        let show_lit x =
            show_lit x

    /// ## BlockSplitting
    // open FSharpx.Collections

    /// ### LineTokens
    type LineTokens = LineToken PersistentVector PersistentVector

    /// ### Block<'a>
    type Block<'a> = {block: 'a; offset: int}

    /// ### block_at
    /// Reads the comments up to a statement, and then reads the statement body. Leaves any errors for the parsing stage.
    let block_at (lines : LineTokens) i =
        let mutable block = PersistentVector.empty
        let add x = block <- PersistentVector.conj x block
        let rec loop_initial i =
            if i < lines.Length then
                let x = lines.[i]
                add x
                if 0 < x.Length then
                    let r,t = x.[0]
                    if r.from = 0 then
                        match t with
                        | TokComment _ -> loop_initial (i+1)
                        | _ -> loop_body (i+1)
                    else loop_initial (i+1) // This branch will be an error in the parsing stage unless the token is a comment.
                else loop_initial (i+1)
        and loop_body i =
            if i < lines.Length then
                let x = lines.[i]
                if 0 < x.Length then
                    let r,_ = x.[0]
                    if r.from <> 0 then add x; loop_body (i+1)
                else add x; loop_body (i+1)
        loop_initial i
        {block = block; offset = i}

    /// ### block_all
    // Parses all the blocks.
    let rec block_all lines i = 
        if i < PersistentVector.length lines then 
            let x = block_at lines i
            x :: block_all lines (i+x.block.Length) else []

    /// ### wdiff_block_all
    // Parses all the blocks with diffing. Only parses those blocks which are dirty based of the edit range. Preserves ref equality and saves work.
    // Without considering ref preservation, it is functionally equivalent to just call `block_all` on just `lines`.
    // This function is difficult to read as it is several operations fused into one loop.
    let wdiff_block_all (blocks : LineTokens Block list) (lines : LineTokens, lines_added, from, nearTo) =
        // Lines added minus lines removed.
        let line_adjustment = lines_added - (nearTo - from)
        // The dirty block boundary needs to be more conservative when a separator is added in the first position of block.
        // Imagine adding a newline right on a block start. This would extend the previous block, but the naive check would not react to it.
        // The same goes for pasting an indented piece of text.
        let dirty_from = let x = lines.[from] in from - (if x.Length = 0 || 0 < (fst x.[0]).from then 1 else 0)
        let is_dirty (x : LineTokens Block) = (dirty_from <= x.offset && x.offset < nearTo) || (x.offset <= dirty_from && dirty_from < x.offset + x.block.Length)
        let rec loop blocks i =
            if i < lines.Length then
                match blocks with
                | x :: xs ->
                    // If the block is dirty, forget it.
                    if is_dirty x then loop xs i else 
                        // If the block is past the removal range, adjust its line offset.
                        let x = {x with offset=if nearTo <= x.offset then x.offset + line_adjustment else x.offset}
                        // The block can't be dirty here. Hence if the offsets are the same, so are the blocks. Take it.
                        if x.offset = i then x :: loop xs (i + x.block.Length)
                        // Else if the block has been skipped over, forget it.
                        elif x.offset < i then loop xs i
                        // Else the block has been dirty filtered, recalculate it.
                        else let x = block_at lines i in x :: loop blocks (i + x.block.Length)
                | [] -> block_all lines i
            else []
        loop blocks 0

    /// ## BlockParsing
    // open System
    // open FParsec
    // open FSharp.Core

    /// ### SymbolString
    type SymbolString = string

    /// ### VarString
    type VarString = string

    /// ### NominalString
    type NominalString = string

    /// ### Layout
    type Layout = Heap | HeapMutable | StackMutable

    /// ### FunType
    type FunType = FT_Vanilla | FT_Pointer | FT_Closure // The closure and the pointer are specific to the C++ backend.

    /// ### Op
    type Op =
        // Converts the function to a specialized type specific to the C++ backend.
        | ToFunPtr
        | ToFunClosure

        // Compile time hash set
        | HashSetCreate
        | HashSetAdd
        | HashSetContains
        | HashSetRemove
        | HashSetCount

        // Compile time hash map
        | HashMapCreate
        | HashMapSetImmutable
        | HashMapSet
        | HashMapAdd
        | HashMapTryAdd
        | HashMapContains
        | HashMapRemove
        | HashMapCount
        | HashMapTryGet

        // Pragma
        | PragmaUnrollPush
        | PragmaUnrollPop

        // Backend branching
        | UnsafeBackendSwitch
        | BackendSwitch

        // Reordering check
        | UsesOriginalTermVars
        | UsesOriginalNominals

        // Imports
        | Global

        // Python
        | ToPythonRecord
        | ToPythonNamedTuple

        // Branching
        | While
        | Do
        | Indent

        // Layout
        | LayoutToHeap
        | LayoutToHeapMutable
        | LayoutToStackMutable
        | LayoutIndex

        // Type
        | TypeToVar
        | TypeToSymbol
        | TypeLitToLit
        | LitToTypeLit
        | LitToSymbol

        // Closure conversion
        | Dyn

        // Nominal 
        | NominalCreate // In addition to regular nominals, it can also creates unions
        | NominalStrip
        | NominalTypeApply

        // Union
        | Unbox
        | Unbox2
        | UnionTag
        | UnionUntag
        | UnionToRecord

        // String
        | StringLength
        | StringIndex
        | StringSlice
        | StaticStringConcat
        | Printf // Cuda specific

        // Array
        | ArrayCreate
        | ArrayLength
        | ArrayIndex
        | ArrayIndexSet

        // Record
        | RecordMap
        | RecordIter
        | RecordFilter
        | RecordFold
        | RecordFoldBack
        | RecordLength

        // Record Type
        | RecordTypeMap
        | RecordTypeIter
        | RecordTypeFold
        | RecordTypeFoldBack
        | RecordTypeLength
        | RecordTypeTryFind

        // BinOps
        | Add
        | Sub
        | Mult 
        | Div 
        | Mod 
        | Pow
        | LTE
        | LT
        | EQ
        | TypeEq
        | NEQ
        | GT
        | GTE 
        | BoolAnd
        | BoolOr
        | BitwiseAnd
        | BitwiseOr
        | BitwiseXor
        | BitwiseComplement
        | ShiftLeft
        | ShiftRight

        // Unary math ops
        | Neg
        | Tanh
        | Log
        | Exp
        | Sin
        | Cos
        | Sqrt
        | NanIs
        | Conv

        // Infinity
        | Infinity
        | Pi

        // Static Is
        | LitIs
        | PrimIs
        | SymbolIs
        | VarIs
        | UnionIs
        | HeapUnionIs
        | LayoutIs
        | NominalIs
        | FunctionIs
        | ExistsIs
        | PrototypeHas

        // Static Type Is
        | PrimTypeIs
        | SymbolTypeIs
        | UnionTypeIs
        | HeapUnionTypeIs
        | LayoutTypeIs
        | ExistsTypeIs
        | NominalTypeIs

        // Panic
        | FailWith

        // Static unary operations
        | PrintStatic
        | PrintRaw
        | ErrorType
        | ExistsStrip
        | StringLitToSymbol
        | SymbolToString

        // Serialization helpers
        | VarTag
        | TagToSymbol
        | FunctionTermSlotsGet
        | FunctionTermSlotsSet
        | FreeVars
        | FreeVarsReplace
        | SizeOf

    /// ### PatternCompilationErrors
    type PatternCompilationErrors =
        | DisjointOrPatternVar
        | DuplicateTermVar
        | DuplicateTypeVar
        | ShadowedVar
        | DuplicateRecordSymbol
        | DuplicateRecordInjection

    /// ### ParserErrors
    type ParserErrors =
        | TypeVarsNeedToBeExplicitForExists
        | InvalidPattern of PatternCompilationErrors
        | ExpectedKeyword of TokenKeyword
        | ExpectedStringOpen | ExpectedStringClose
        | ExpectedMacroOpen | ExpectedMacroClose
        | ExpectedMacroVar | ExpectedMacroTypeVar | ExpectedMacroTypeLitVar 
        | ExpectedEscapedChar of is_term_macro : bool
        | ExpectedText | ExpectedUnescapedChar
        | ExpectedOperator'
        | ExpectedOperator of string
        | ExpectedUnaryOperator'
        | ExpectedUnaryOperator of string
        | ExpectedUnit
        | ExpectedVar
        | ExpectedVarOrOpAsNameOfRecStatement
        | ExpectedVarOrOpAsNameOfGlobalStatement
        | ExpectedSmallVar
        | ExpectedBigVar
        | ExpectedLit
        | ExpectedSymbolPaired
        | SymbolPairedShouldStartWithUppercaseInTypeScope
        | ExpectedSymbol
        | ExpectedParenthesis of Parenthesis * ParenthesisState
        | ExpectedMacroExpression of MacroEnum * ParenthesisState
        | ExpectedOpenParenthesis
        | ExpectedStatement
        | ExpectedEob
        | ExpectedFunctionAsBodyOfRecStatement
        | ExpectedSinglePatternWhenStatementNameIsNorVarOrOp
        | ExpectedGlobalFunction
        | ExpectedExpression
        | InbuiltOpNotFound
        | UnknownOperator
        | UnexpectedEob
        | UnexpectedAndInlRec
        | ForallNotAllowed
        | TypecaseNotAllowed
        | MetavarNotAllowed
        | TermNotAllowed
        | UnknownError
        | DuplicateRecordTypeVar
        | DuplicateForallVar
        | DuplicateExistsVar
        | DuplicateConstraint
        | DuplicateTermRecordSymbol
        | DuplicateTermRecordInjection
        | DuplicateRecFunctionName
        | BottomUpNumberParseError of string * string
        | ExpectedPairedSymbolInUnion
        | DuplicateUnionKey
        | MetavarShadowedByVar
        | VarShadowedByMetavar
        | ListLiteralsNotAllowedInBottomUp
        | ArrayLiteralsNotAllowedInBottomUp
        | ForallNotAllowedInTypecase
        | ExistsNotAllowedInTypecase

    /// ### RawKindExpr
    type RawKindExpr =
        | RawKindWildcard
        | RawKindStar
        | RawKindFun of RawKindExpr * RawKindExpr

    /// ### UnionLayout
    type UnionLayout = UStack | UHeap

    /// ### HoVar
    type HoVar = VSCRange * (VarString * RawKindExpr)

    /// ### TypeVar
    type TypeVar = HoVar * (VSCRange * VarString) list

    /// ### RawMacro
    type RawMacro =
        | RawMacroText of VSCRange * string
        | RawMacroTerm of VSCRange * RawExpr * is_inline : bool
        | RawMacroType of VSCRange * RawTExpr
        | RawMacroTypeLit of VSCRange * RawTExpr
    and RawRecordWith =
        | RawRecordWithSymbol of (VSCRange * SymbolString) * RawExpr
        | RawRecordWithSymbolModify of (VSCRange * SymbolString) * RawExpr
        | RawRecordWithInjectVar of (VSCRange * VarString) * RawExpr
        | RawRecordWithInjectVarModify of (VSCRange * VarString) * RawExpr
    and RawRecordWithout =
        | RawRecordWithoutSymbol of VSCRange * SymbolString
        | RawRecordWithoutInjectVar of VSCRange * VarString
    and PatRecordMember =
        | PatRecordMembersSymbol of (VSCRange * SymbolString) * name: Pattern
        | PatRecordMembersInjectVar of (VSCRange * VarString) * name: Pattern
    and Pattern =
        | PatB of VSCRange
        | PatE of VSCRange
        | PatVar of VSCRange * VarString
        | PatDyn of VSCRange * Pattern
        | PatUnbox of VSCRange * symbol: string * Pattern
        | PatExists of VSCRange * (VSCRange * VarString) list * Pattern
        | PatAnnot of VSCRange * Pattern * RawTExpr
        | PatPair of VSCRange * Pattern * Pattern
        | PatSymbol of VSCRange * string
        | PatRecordMembers of VSCRange * PatRecordMember list
        | PatOr of VSCRange * Pattern * Pattern
        | PatAnd of VSCRange * Pattern * Pattern
        | PatValue of VSCRange * Literal
        | PatDefaultValue of VSCRange * VarString
        | PatWhen of VSCRange * Pattern * RawExpr
        | PatNominal of VSCRange * (VSCRange * VarString) *  (VSCRange * VarString) list * Pattern
        | PatArray of VSCRange * Pattern list
        | PatFilledDefaultValue of VSCRange * VarString * RawTExpr // Filled in by the inferencer.
    and RawExpr =
        | RawB of VSCRange
        | RawV of VSCRange * VarString * is_tvar_applied : bool
        | RawLit of VSCRange * Literal
        | RawDefaultLit of VSCRange * string
        | RawSymbol of VSCRange * SymbolString
        | RawType of VSCRange * RawTExpr
        | RawMatch of VSCRange * body: RawExpr * (Pattern * RawExpr) list
        | RawFun of VSCRange * (Pattern * RawExpr) list
        | RawForall of VSCRange * TypeVar * RawExpr
        | RawExists of VSCRange * (VSCRange * RawTExpr list option) * RawExpr
        | RawRecBlock of VSCRange * ((VSCRange * VarString) * RawExpr) list * on_succ: RawExpr // The bodies of a block must be RawFun or RawForall.
        | RawRecordWith of VSCRange * RawExpr list * RawRecordWith list * RawRecordWithout list
        | RawOp of VSCRange * Op * RawExpr list
        | RawJoinPoint of VSCRange * backend: (VSCRange * string) option * RawExpr * name: string option
        | RawAnnot of VSCRange * RawExpr * RawTExpr
        | RawTypecase of VSCRange * RawTExpr * (RawTExpr * RawExpr) list
        | RawOpen of VSCRange * (VSCRange * VarString) * (VSCRange * SymbolString) list * on_succ: RawExpr
        | RawApply of VSCRange * RawExpr * RawExpr
        | RawIfThenElse of VSCRange * RawExpr * RawExpr * RawExpr
        | RawIfThen of VSCRange * RawExpr * RawExpr
        | RawPair of VSCRange * RawExpr * RawExpr
        | RawSeq of VSCRange * RawExpr * RawExpr
        | RawHeapMutableSet of VSCRange * RawExpr * RawExpr list * RawExpr
        | RawReal of VSCRange * RawExpr
        | RawMacro of VSCRange * RawMacro list
        | RawArray of VSCRange * RawExpr list
        | RawMissingBody of VSCRange
        | RawFilledForall of VSCRange * string * RawExpr // Filled in by the inferencer.
    and RawTExpr =
        | RawTWildcard of VSCRange
        | RawTB of VSCRange
        | RawTMetaVar of VSCRange * VarString
        | RawTLit of VSCRange * Literal
        | RawTVar of VSCRange * VarString
        | RawTPair of VSCRange * RawTExpr * RawTExpr
        | RawTFun of VSCRange * RawTExpr * RawTExpr * FunType
        | RawTArray of VSCRange * RawTExpr
        | RawTRecord of VSCRange * Map<int * string,RawTExpr>
        | RawTSymbol of VSCRange * SymbolString
        | RawTApply of VSCRange * RawTExpr * RawTExpr
        | RawTForall of VSCRange * TypeVar * RawTExpr
        | RawTExists of VSCRange * TypeVar list * RawTExpr
        | RawTPrim of VSCRange * PrimitiveType
        | RawTTerm of VSCRange * RawExpr
        | RawTMacro of VSCRange * RawMacro list
        | RawTUnion of VSCRange * Map<int * string,bool * RawTExpr> * UnionLayout * this: RawTExpr  // The boolean arg determines whether the union case is generalized. `this` is the self type.
        | RawTLayout of VSCRange * RawTExpr * Layout
        | RawTTypecase of VSCRange * RawTExpr * (RawTExpr * RawTExpr) list
        | RawTFilledNominal of VSCRange * GlobalId // Filled in by the inferencer.

    /// ### (+.)
    let (+.) (a,_) (_,b) = a,b

    /// ### range_of_hovar
    let range_of_hovar ((r,_) : HoVar) = r

    /// ### range_of_typevar
    let range_of_typevar ((x,_) : TypeVar) = range_of_hovar x

    /// ### hovar_name
    let hovar_name ((_,(name,_)) : HoVar) = name

    /// ### typevar_name
    let typevar_name ((h,_) : TypeVar) = hovar_name h

    /// ### range_of_record_with
    let range_of_record_with = function
        | RawRecordWithSymbol((r,_),_)
        | RawRecordWithSymbolModify((r,_),_)
        | RawRecordWithInjectVar((r,_),_)
        | RawRecordWithInjectVarModify((r,_),_) -> r

    /// ### range_of_record_without
    let range_of_record_without = function
        | RawRecordWithoutSymbol(r,_)
        | RawRecordWithoutInjectVar(r,_) -> r

    /// ### range_of_pattern
    let range_of_pattern = function
        | PatB r
        | PatE r
        | PatVar(r,_)
        | PatDyn(r,_)
        | PatUnbox(r,_,_)
        | PatExists(r,_,_)
        | PatSymbol(r,_)
        | PatValue(r,_)
        | PatDefaultValue(r,_)
        | PatRecordMembers(r,_)
        | PatArray(r,_)
        | PatAnnot(r,_,_)
        | PatPair(r,_,_)
        | PatOr(r,_,_)
        | PatAnd(r,_,_)
        | PatWhen(r,_,_)
        | PatFilledDefaultValue(r,_,_)
        | PatNominal(r,_,_,_) -> r

    /// ### range_of_pat_record_member
    let range_of_pat_record_member = function
        | PatRecordMembersSymbol((r,_),x)
        | PatRecordMembersInjectVar((r,_),x) -> r +. range_of_pattern x

    /// ### range_of_expr
    let range_of_expr = function
        | RawB r
        | RawMissingBody r
        | RawMacro(r,_)
        | RawV(r,_,_)
        | RawLit(r,_)
        | RawDefaultLit(r,_)
        | RawSymbol(r,_)
        | RawType(r,_)
        | RawJoinPoint(r,_,_,_)
        | RawArray(r,_)
        | RawMatch(r,_,_)
        | RawFun(r,_)
        | RawReal(r,_)
        | RawRecBlock(r,_,_)
        | RawOp(r,_,_)
        | RawAnnot(r,_,_)
        | RawTypecase(r,_,_)
        | RawForall(r,_,_)
        | RawExists(r,_,_)
        | RawFilledForall(r,_,_)
        | RawApply(r,_,_)
        | RawPair(r,_,_)
        | RawIfThen(r,_,_)
        | RawSeq(r,_,_)
        | RawHeapMutableSet(r,_,_,_)
        | RawRecordWith(r,_,_,_)
        | RawIfThenElse(r,_,_,_)
        | RawOpen(r,_,_,_) -> r

    /// ### rawv
    let rawv (r,x) = RawV(r,x,true)

    /// ### range_of_texpr
    let range_of_texpr = function
        | RawTWildcard r
        | RawTB r
        | RawTLit(r,_)
        | RawTMacro(r,_)
        | RawTMetaVar(r,_)
        | RawTVar(r,_)
        | RawTArray(r,_)
        | RawTRecord(r,_)
        | RawTUnion(r,_,_,_)
        | RawTSymbol(r,_)
        | RawTPrim(r,_)
        | RawTTerm(r,_)
        | RawTFilledNominal(r,_)
        | RawTPair(r,_,_)
        | RawTFun(r,_,_,_)
        | RawTApply(r,_,_)
        | RawTLayout(r,_,_)
        | RawTExists(r,_,_)
        | RawTTypecase(r,_,_)
        | RawTForall(r,_,_) -> r

    /// ### range_of_texpr_gadt_constructor
    let rec range_of_texpr_gadt_constructor = function
        | RawTForall(_,_,x) -> range_of_texpr_gadt_constructor x
        | RawTFun(_,_,x,_) | x -> range_of_texpr x

    /// ### range_of_texpr_gadt_body
    let rec range_of_texpr_gadt_body = function
        | RawTForall(_,_,x) -> range_of_texpr_gadt_body x
        | RawTFun(_,x,_,_) | x -> range_of_texpr x

    /// ### VectorCord
    type VectorCord = {|row : int; col : int|}

    /// ### BlockParsingEnv
    type BlockParsingEnv = {
        semantic_updates : (VectorCord * SemanticTokenLegend) ResizeArray
        tokens_cords : VectorCord []
        tokens : (VSCRange * SpiralToken) []
        comments : LineComment option []
        i : int ref
        is_top_down : bool
        default_env : DefaultEnv
        } with

        member d.Index with get() = d.i.contents and set(i) = d.i.Value <- i

    /// ### try_current_template
    let inline try_current_template (d : BlockParsingEnv) on_succ on_fail =
        let i = d.Index
        if i < d.tokens.Length then on_succ d.tokens.[i]
        else on_fail()

    /// ### try_current
    let inline try_current d f = try_current_template d (fun (p,t) -> f (p, t)) (fun () -> Error [])

    /// ### print_current
    let print_current d = try_current d (fun x -> printfn "%A" x; Ok()) // For parser debugging purposes.

    /// ### line_template
    let inline line_template d f = try_current_template d (fst >> f) (fun _ -> -1)

    /// ### col
    let col d = line_template d (fun (r,_) -> r.character)

    /// ### lineBlockParsing
    let lineBlockParsing d = line_template d (fun (r,_) -> r.line)

    /// ### skip'
    let skip' (d : BlockParsingEnv) i = d.i.Value <- d.i.contents+i

    /// ### blockParsingSkip
    let blockParsingSkip d = skip' d 1

    /// ### skip_string_open
    let skip_string_open d =
        try_current d <| function
            | p,TokStringOpen -> blockParsingSkip d; Ok(p)
            | p, _ -> Error [p, ExpectedStringOpen]

    /// ### skip_string_close
    let skip_string_close d =
        try_current d <| function
            | p,TokStringClose -> blockParsingSkip d; Ok(p)
            | p, _ -> Error [p, ExpectedStringClose]

    /// ### skip_macro_open
    let skip_macro_open d =
        try_current d <| function
            | p,TokMacroOpen -> blockParsingSkip d; Ok(p)
            | p, _ -> Error [p, ExpectedMacroOpen]

    /// ### skip_macro_close
    let skip_macro_close d =
        try_current d <| function
            | p,TokMacroClose -> blockParsingSkip d; Ok(p)
            | p, _ -> Error [p, ExpectedMacroClose]

    /// ### read_text
    let read_text is_term_macro d =
        let (+.) a b =
            match a with
            | Some a -> Some (a +. b)
            | None -> Some b
        let rec loop (a : VSCRange option) (str : Text.StringBuilder) =
            try_current d <| function
                | b,TokText x -> blockParsingSkip d; loop (a +. b) (str.Append(x))
                | b,TokEscapedVar when is_term_macro -> blockParsingSkip d; loop (a +. b) (str.Append("\\v"))
                | b,(TokEscapedChar x | TokUnescapedChar x) -> blockParsingSkip d; loop (a +. b) (str.Append(x))
                | b, _ -> 
                    if Option.isNone a then Error [b, ExpectedText; b, ExpectedEscapedChar is_term_macro; b, ExpectedUnescapedChar]
                    else Ok(Option.get a, str.ToString())
        loop None (Text.StringBuilder())

    /// ### read_macro_var
    let read_macro_var d =
        try_current d <| function
            | p, TokMacroTermVar (x, is_inline) -> blockParsingSkip d; Ok(RawMacroTerm(p,rawv(p,x),is_inline))
            | p, TokMacroTypeVar x -> blockParsingSkip d; Ok(RawMacroType(p,RawTVar(p,x)))
            | p, TokMacroTypeLitVar x -> blockParsingSkip d; Ok(RawMacroTypeLit(p,RawTVar(p,x)))
            | p,_ -> Error [p, ExpectedMacroVar]

    /// ### read_macro_type_var
    let read_macro_type_var d =
        try_current d <| function
            | p, TokMacroTypeVar x -> blockParsingSkip d; Ok(RawMacroType(p,RawTVar(p,x)))
            | p, TokMacroTypeLitVar x -> blockParsingSkip d; Ok(RawMacroTypeLit(p,RawTVar(p,x)))
            | p,_ -> Error [p, ExpectedMacroTypeVar]

    /// ### skip_keyword
    let skip_keyword t d =
        try_current d <| function
            | p,TokKeyword t' when t = t' -> blockParsingSkip d; Ok t'
            | p, _ -> Error [p, ExpectedKeyword t]

    /// ### skip_keyword'
    let skip_keyword' t d =
        try_current d <| function
            | p,TokKeyword t' when t = t' -> blockParsingSkip d; Ok p
            | p, _ -> Error [p, ExpectedKeyword t]

    /// ### read_unary_op
    let read_unary_op d =
        try_current d <| function
            | p, TokUnaryOperator(t',_) -> blockParsingSkip d; Ok t'
            | p, _ -> Error [p, ExpectedUnaryOperator']

    /// ### read_unary_op'
    let read_unary_op' d =
        try_current d <| function
            | p, TokUnaryOperator(t',_) -> blockParsingSkip d; Ok(p,t')
            | p, _ -> Error [p, ExpectedUnaryOperator']

    /// ### read_op
    let read_op d =
        try_current d <| function
            | p, TokOperator(t',_) -> blockParsingSkip d; Ok t'
            | p, _ -> Error [p, ExpectedOperator']

    /// ### read_op'
    let read_op' d =
        try_current d <| function
            | p, TokOperator(t',_) -> blockParsingSkip d; Ok(p,t')
            | p, _ -> Error [p, ExpectedOperator']

    /// ### update_semantic
    let update_semantic (d : BlockParsingEnv) = let i = d.Index in fun x -> d.semantic_updates.Add(d.tokens_cords.[i], x)

    /// ### read_op_type
    let read_op_type d =
        try_current d <| function
            | p, TokOperator(t',r) -> update_semantic d SemanticTokenLegend.type_variable; blockParsingSkip d; Ok(p,t')
            | p, _ -> Error [p, ExpectedOperator']

    /// ### skip_op
    let skip_op t d =
        try_current d <| function
            | p, TokOperator(t',_) when t' = t -> blockParsingSkip d; Ok p
            | p, _ -> Error [p, ExpectedOperator t]

    /// ### skip_unary_op
    let skip_unary_op t d =
        try_current d <| function
            | p, TokUnaryOperator(t',_) when t' = t -> blockParsingSkip d; Ok t'
            | p, _ -> Error [p, ExpectedUnaryOperator t]

    /// ### read_var
    let read_var d =
        try_current d <| function
            | p, TokVar(t',_) -> blockParsingSkip d; Ok t'
            | p, _ -> Error [p, ExpectedVar]

    /// ### read_var'
    let read_var' d =
        try_current d <| function
            | p, TokVar(t',_) -> let r = update_semantic d in blockParsingSkip d; Ok(p,t',r)
            | p, _ -> Error [p, ExpectedVar]

    /// ### read_var''
    let read_var'' d =
        try_current d <| function
            | p, TokVar(t',_) -> blockParsingSkip d; Ok(p,t')
            | p, _ -> Error [p, ExpectedVar]

    /// ### read_big_var
    let read_big_var d =
        try_current d <| function
            | p, TokVar(t',_) when Char.IsUpper(t',0) -> blockParsingSkip d; Ok(p,t')
            | p, _ -> Error [p, ExpectedBigVar]

    /// ### read_var_as_symbol
    let read_var_as_symbol d =
        try_current d <| function
            | p, TokVar(t',_) -> update_semantic d SemanticTokenLegend.symbol; blockParsingSkip d; Ok t'
            | p, _ -> Error [p, ExpectedVar]

    /// ### read_big_var_as_symbol
    let read_big_var_as_symbol d =
        try_current d <| function
            | p, TokVar(t',_) when Char.IsUpper(t',0) -> update_semantic d SemanticTokenLegend.symbol; blockParsingSkip d; Ok t'
            | p, _ -> Error [p, ExpectedBigVar]

    /// ### read_big_var_as_keyword
    let read_big_var_as_keyword d =
        try_current d <| function
            | p, TokVar(t',_) when Char.IsUpper(t',0) -> update_semantic d SemanticTokenLegend.keyword; blockParsingSkip d; Ok(p,t')
            | p, _ -> Error [p, ExpectedBigVar]

    /// ### read_small_var
    let read_small_var d =
        try_current d <| function
            | p, TokVar(t',r) when Char.IsUpper(t',0) = false -> blockParsingSkip d; Ok t'
            | p, _ -> Error [p, ExpectedSmallVar]

    /// ### read_small_var'
    let read_small_var' d =
        try_current d <| function
            | p, TokVar(t',r) when Char.IsUpper(t',0) = false -> blockParsingSkip d; Ok(p,t')
            | p, _ -> Error [p, ExpectedSmallVar]

    /// ### read_big_type_var
    let read_big_type_var d =
        try_current d <| function
            | p, TokVar(t',r) when Char.IsUpper(t',0) -> update_semantic d SemanticTokenLegend.type_variable; blockParsingSkip d; Ok(t')
            | p, _ -> Error [p, ExpectedSmallVar]

    /// ### read_big_type_var'
    let read_big_type_var' d =
        try_current d <| function
            | p, TokVar(t',r) when Char.IsUpper(t',0) -> update_semantic d SemanticTokenLegend.type_variable; blockParsingSkip d; Ok(p,t')
            | p, _ -> Error [p, ExpectedSmallVar]

    /// ### read_small_type_var
    let read_small_type_var d =
        try_current d <| function
            | p, TokVar(t',r) when Char.IsUpper(t',0) = false -> update_semantic d SemanticTokenLegend.type_variable; blockParsingSkip d; Ok(t')
            | p, _ -> Error [p, ExpectedSmallVar]

    /// ### read_small_type_var'
    let read_small_type_var' d =
        try_current d <| function
            | p, TokVar(t',r) when Char.IsUpper(t',0) = false -> update_semantic d SemanticTokenLegend.type_variable; blockParsingSkip d; Ok(p,t')
            | p, _ -> Error [p, ExpectedSmallVar]

    /// ### read_value
    let read_value d =
        try_current d <| function
            | p, TokValue t' -> 
                blockParsingSkip d
                if d.Index < d.tokens.Length then 
                    match snd d.tokens.[d.Index] with 
                    | TokValueSuffix -> blockParsingSkip d 
                    | _ -> ()
                Ok(p,t')
            | p, _ -> Error [p, ExpectedLit]

    /// ### read_symbol
    let read_symbol d =
        try_current d <| function
            | p, TokSymbol(t',r) -> blockParsingSkip d; Ok(p,t')
            | p, _ -> Error [p, ExpectedSymbol]

    /// ### skip_parenthesis
    let skip_parenthesis a b d =
        try_current d <| function
            | p, TokParenthesis(a',b') when a = a' && b = b' -> blockParsingSkip d; Ok()
            | p, _ -> Error [p, ExpectedParenthesis(a,b)]

    /// ### skip_macro_expression
    let skip_macro_expression a b d =
        try_current d <| function
            | p, TokMacroExpression(a',b') when a = a' && b = b' -> blockParsingSkip d; Ok()
            | p, _ -> Error [p, ExpectedMacroExpression(a,b)]

    /// ### on_succ
    let on_succ x _ = Ok x

    /// ### macro_expression
    // open FParsec
    let macro_expression ty a d = (skip_macro_expression ty Open >>. a .>> skip_macro_expression ty Close) d

    /// ### rounds
    let rounds a d = (skip_parenthesis Round Open >>. a .>> skip_parenthesis Round Close) d

    /// ### curlies
    let curlies a d = (skip_parenthesis Curly Open >>. a .>> skip_parenthesis Curly Close) d

    /// ### squares
    let squares a d = (skip_parenthesis Square Open >>. a .>> skip_parenthesis Square Close) d

    /// ### blockParsingIndex
    let blockParsingIndex (t : BlockParsingEnv) = t.Index

    /// ### blockParsingIndex_set
    let blockParsingIndex_set v (t : BlockParsingEnv) = t.Index <- v

    /// ### blockParsingRange
    let inline blockParsingRange exp s =
        let i = blockParsingIndex s
        exp s |> Result.map (fun x ->
            let i' = blockParsingIndex s
            if i < i' then fst s.tokens.[i] +. fst s.tokens.[i'-1], x : VSCRange * _
            else
                failwith "Compiler error: The parser passed into `range` has to consume at least one token for it to work."
            )

    /// ### kind
    let rec kind d = (sepBy1 ((skip_op "*" >>% RawKindStar) <|> rounds kind) (skip_op "->") |>> List.reduceBack (fun a b -> RawKindFun (a,b))) d

    /// ### duplicates
    let duplicates er x = 
        let h = Collections.Generic.HashSet()
        x |> List.choose (fun (r : VSCRange,n : string) -> if h.Add n = false then Some(r,er) else None)

    /// ### blockParsingIndent
    let inline blockParsingIndent i op next d = if op i (col d) then next d else Error []

    /// ### record_var
    let record_var d = (read_var_as_symbol <|> rounds read_op) d

    /// ### patterns_validate
    let patterns_validate pats = 
        let pos = Collections.Generic.Dictionary(HashIdentity.Reference)
        let errors = ResizeArray()
        let rec loop is_type pat =
            let loop = loop is_type
            let inline duplicate_var() = InvalidPattern (if is_type then DuplicateTypeVar else DuplicateTermVar)
            match pat with
            | PatFilledDefaultValue _ | PatDefaultValue _ | PatValue _ | PatSymbol _ | PatE _ | PatB _ -> Set.empty
            | PatArray(_,x) -> 
                List.fold (fun s x -> 
                    let x = loop x
                    let inters = Set.intersect s x
                    if Set.isEmpty inters = false then inters |> Set.iter (fun x -> errors.Add(pos.[x], duplicate_var()))
                    s + x
                    ) Set.empty x
            | PatExists(r,l,p) ->
                if is_type then
                    let s = List.fold (fun s (r,x) -> pos.Add(x,r); Set.add x s) Set.empty l
                    let x = loop p
                    let inters = Set.intersect s x
                    if Set.isEmpty inters = false then inters |> Set.iter (fun x -> errors.Add(pos.[x], duplicate_var()))
                    s + x
                else 
                    loop p
            | PatVar(r,x) -> 
                if is_type then
                    Set.empty
                else 
                    pos.Add(x,r)
                    Set.singleton x
            | PatDyn(_,p) | PatAnnot (_,p,_) | PatNominal(_,_,_,p) | PatUnbox(_,_,p) | PatWhen(_,p,_) -> loop p
            | PatRecordMembers(_,items) ->
                let symbols = Collections.Generic.HashSet()
                let injects = Collections.Generic.HashSet()
                let vars = Collections.Generic.HashSet()
                List.iter (fun item ->
                    match item with
                    | PatRecordMembersSymbol((r,keyword),name) ->
                        if symbols.Add(keyword) = false then errors.Add (r, InvalidPattern DuplicateRecordSymbol); Set.empty else loop name
                    | PatRecordMembersInjectVar((r,var),name) ->
                        if injects.Add(var) = false then errors.Add (r, InvalidPattern DuplicateRecordInjection); Set.empty else loop name
                    |> Set.iter (fun x -> if vars.Add x = false then errors.Add (pos.[x], duplicate_var()))
                    ) items
                Set vars
            | PatPair(_,a,b) | PatAnd(_,a,b) -> 
                let a, b = loop a, loop b
                Set.intersect b a |> Set.iter (fun x -> errors.Add (pos.[x], duplicate_var()))
                a + b
            | PatOr(_,a,b) -> 
                let a, b = loop a, loop b
                let f = Set.iter (fun x -> errors.Add (pos.[x], InvalidPattern DisjointOrPatternVar))
                f (a-b); f (b-a)
                a

        let validate is_type =
            List.fold (fun s x ->
                let s' = loop is_type x
                Set.intersect s' s |> Set.iter (fun x -> errors.Add(pos.[x],InvalidPattern ShadowedVar))
                s + s'
                ) Set.empty pats |> ignore
        validate true; validate false
        errors |> Seq.toList

    /// ### join_point
    let join_point is_let name = function // Has the effect of removing nested join points due to not duplicating them.
        | RawJoinPoint(a,b,c,_) -> RawJoinPoint(a,b,c,name)
        | x -> if is_let then RawJoinPoint(range_of_expr x, None, x, name) else x

    /// ### join_point_backend
    let join_point_backend (a,b) = RawJoinPoint(range_of_expr b, Some a, b, None)

    /// ### unintern
    /// Some places need unique string refs, so this is to keep the compiler from interning static strings.
    let unintern (x : string) = Text.StringBuilder(x).ToString()

    /// ### adjust_join_point
    let rec adjust_join_point is_let name x =
        let dyn_if_let a = if is_let then PatDyn(range_of_pattern a, a) else a
        match x with
        | RawForall(r,a,b) -> RawForall(r,a,adjust_join_point is_let name b)
        | RawFun(r,[a,b]) -> RawFun(r,[dyn_if_let a, adjust_join_point is_let name b])
        | RawFun(r,l) ->
            let empty = fst r, fst r
            let n = unintern " arg"
            let a = PatVar(empty,n) |> dyn_if_let
            let b = RawMatch(empty,rawv(empty,n),l)
            RawFun(r,[a,join_point is_let name b])
        | x -> join_point is_let name x

    /// ### adjust_join_point'
    let adjust_join_point' is_let name = function
        | RawForall _ | RawFun _ as x -> adjust_join_point is_let name x
        | x -> x

    /// ### inl_or_let_process
    let inl_or_let_process (r, (is_let, is_rec, name, foralls, pats, body)) _ =
        match is_rec, name, foralls, pats with
        | false, _, [], [] -> 
            match patterns_validate [name] with
            | [] -> Ok((r,name,adjust_join_point' is_let (match name with PatVar(_,name) -> Some name | _ -> None) body),is_rec)
            | ers -> Error ers
        | _, PatVar(_,name'), _, _ -> 
            match patterns_validate (if is_rec then name :: pats else pats) with
            | [] ->
                let body =
                    let dyn_if_let x = if is_let then PatDyn(range_of_pattern x, x) else x
                    adjust_join_point is_let (Some name') body
                    |> List.foldBack (fun pat body -> RawFun(range_of_pattern pat +. range_of_expr body,[dyn_if_let pat,body])) pats
                    |> List.foldBack (fun typevar body -> RawForall(range_of_typevar typevar +. range_of_expr body,typevar,body)) foralls
                match is_rec, body with
                | false, _ | true, (RawFun _ | RawForall _) -> Ok((r,name,body),is_rec)
                | true, _ -> Error [r, ExpectedFunctionAsBodyOfRecStatement]
            | ers -> Error ers
        | true, _, _, _ -> Error [range_of_pattern name, ExpectedVarOrOpAsNameOfRecStatement]
        | false, _, _, _ -> Error [range_of_pattern name, ExpectedSinglePatternWhenStatementNameIsNorVarOrOp]

    /// ### ho_var
    let ho_var d : Result<HoVar,_> = blockParsingRange ((read_small_type_var |>> fun x -> x, RawKindWildcard) <|> rounds ((read_small_type_var .>> skip_op ":") .>>. kind)) d

    /// ### forall_var
    let forall_var d : Result<TypeVar,_> = (ho_var .>>. (curlies (sepBy (read_small_type_var' <|> rounds read_op_type) (skip_op ";")) <|>% [])) d

    /// ### forall
    let forall d = 
        (skip_keyword SpecForall >>. many1 forall_var .>> skip_op "." 
        >>= fun q _ -> 
            let x' = q |> List.collect (fun (_,l) -> duplicates DuplicateConstraint l)
            let x = q |> List.map (fun ((r,(a,_)),_) -> r,a) |> duplicates DuplicateForallVar
            match List.append x x' with [] -> Ok q | er -> Error er
            ) d

    /// ### pat_exists'
    let pat_exists' d = 
        (skip_keyword SpecExists >>. many (blockParsingRange read_small_type_var) .>> skip_op "." 
        >>= fun q _ -> 
            match duplicates DuplicateExistsVar q with [] -> Ok q | er -> Error er
            ) d

    /// ### exists
    let exists d = 
        (skip_keyword SpecExists >>. many forall_var .>> skip_op "." 
        >>= fun q _ -> 
            let x' = q |> List.collect (fun (_,l) -> duplicates DuplicateConstraint l)
            let x = q |> List.map (fun ((r,(a,_)),_) -> r,a) |> duplicates DuplicateExistsVar
            match List.append x x' with [] -> Ok q | er -> Error er
            ) d

    /// ### annotated_body
    let inline annotated_body sep exp ty =
        pipe2 (opt (skip_op ":" >>. ty))
            (skip_op sep .>>. opt exp)
            (fun a (r,b) ->
                let b = match b with Some b -> b | None -> RawMissingBody r
                match a with
                | Some a -> RawAnnot(range_of_expr b +. range_of_texpr a,b,a)
                | None -> b)

    /// ### inl_or_let
    let inline inl_or_let exp pattern ty =
        blockParsingRange (tuple6 ((skip_keyword SpecInl >>% false) <|> (skip_keyword SpecLet >>% true))
                ((skip_keyword SpecRec >>% true) <|>% false) pattern
                (forall <|>% []) (many pattern) (annotated_body "=" exp ty))
        >>= inl_or_let_process

    /// ### and_inl_or_let
    let inline and_inl_or_let exp pattern ty =
        blockParsingRange (tuple6 (skip_keyword SpecAnd >>. ((skip_keyword SpecInl >>% false) <|> (skip_keyword SpecLet >>% true)))
                (fun _ -> Ok true) pattern
                (forall <|>% []) (many pattern) (annotated_body "=" exp ty))
        >>= inl_or_let_process

    /// ### Associativity
    type Associativity = FParsec.Associativity

    /// ### inbuilt_operators
    let inbuilt_operators x = 
        match x with
        | "+" -> ValueSome(60, Associativity.Left)
        | "-" -> ValueSome(60, Associativity.Left)
        | "*" -> ValueSome(70, Associativity.Left)
        | "/" -> ValueSome(70, Associativity.Left)
        | "%" -> ValueSome(70, Associativity.Left)
        | "|>" -> ValueSome(10, Associativity.Left)
        | ">>" -> ValueSome(10, Associativity.Left)
        | "<-" -> ValueSome(4, Associativity.Left)

        | "<=" -> ValueSome(40, Associativity.None)
        | "<" -> ValueSome(40, Associativity.None)
        | "=" -> ValueSome(40, Associativity.None)
        | "`=" -> ValueSome(40, Associativity.None)
        | ">" -> ValueSome(40, Associativity.None)
        | ">=" -> ValueSome(40, Associativity.None)
        | "<>" -> ValueSome(40, Associativity.None)
        | "<<<" -> ValueSome(40, Associativity.None)
        | ">>>" -> ValueSome(40, Associativity.None)
        | "&&&" -> ValueSome(40, Associativity.None)
        | "|||" -> ValueSome(40, Associativity.None)

        | "||" -> ValueSome(20, Associativity.Right)
        | "&&" -> ValueSome(30, Associativity.Right)
        | "::" -> ValueSome(50, Associativity.Right)
        | "^" -> ValueSome(45, Associativity.Right)
        | "<|" -> ValueSome(10, Associativity.Right)
        | "<<" -> ValueSome(10, Associativity.Right)
        | "." -> ValueSome(2, Associativity.Right)
        | "," -> ValueSome(6, Associativity.Right)
        | ":>" -> ValueSome(35, Associativity.Right)
        | ":?>" -> ValueSome(35, Associativity.Right)
        | "**" -> ValueSome(80, Associativity.Right)
        | _ -> ValueNone

    /// ### precedence_associativity
    // The `.` operator has special behavior similar to F#.
    let rec precedence_associativity name = 
        if 0 < String.length name then
            if 1 < String.length name && name.[0] = '.' then precedence_associativity name.[1..]
            else
                match inbuilt_operators name with
                | ValueNone -> precedence_associativity (name.[0..name.Length-2])
                | v -> v
        else ValueNone

    /// ### op
    let op (d : BlockParsingEnv) =
        blockParsingRange read_op d |> Result.bind (fun (o,x) ->
            match x with
            | "=>" | "|" | ":" | ";" -> skip' d -1; Error [] // Separators get special handling for sake of better error messages.
            | _ ->
                match precedence_associativity x with // TODO: Might be good to memoize this.
                | ValueNone -> Error [o, UnknownOperator]
                | ValueSome(p,a) ->
                    let inline f on_succ = Ok(p,a,fun (a,b) -> 
                        let ra, rb = range_of_expr a, range_of_expr b
                        let r = ra +. rb
                        on_succ(r,a,b)
                        )
                    match x with
                    | "." -> f RawSeq
                    | "&&" -> f (fun (r,a,b) -> RawIfThenElse(r,a,b,RawLit(o,LitBool false)))
                    | "||" -> f (fun (r,a,b) -> RawIfThenElse(r,a,RawLit(o,LitBool true),b))
                    | "," -> f RawPair
                    | "<-" -> f (fun (r,a,c) ->
                        let rec loop l = function
                            | RawApply(_,a,b) -> loop (b :: l) a
                            | a -> a, l
                        let a,b = loop [] a
                        RawHeapMutableSet(r,a,b,c)
                        )
                    | x -> f (fun (r,a,b) -> RawApply(r,RawApply(r +. o,rawv(o,x),a),b))
            )

    /// ### string_to_op_dict
    let string_to_op_dict : Dictionary<string,Op> = Collections.Generic.Dictionary(HashIdentity.Structural)

    Microsoft.FSharp.Reflection.FSharpType.GetUnionCases(typeof<Op>)
    |> Array.iter (fun x -> string_to_op_dict.[x.Name] <- Microsoft.FSharp.Reflection.FSharpValue.MakeUnion(x,[||]) :?> Op)

    /// ### string_to_op
    let string_to_op x = string_to_op_dict.TryGetValue x

    /// ### symbol_paired_concat
    let symbol_paired_concat k =
        let b = Text.StringBuilder()
        List.iter (fun (_, x : string) -> b.Append(x).Append('_') |> ignore) k
        b.ToString()

    /// ### blockParsingModule_open
    let blockParsingModule_open = blockParsingRange ((skip_keyword SpecOpen >>. read_small_var') .>>. (many read_symbol))

    /// ### bar
    let bar i d = blockParsingIndent i (<=) (skip_op "|") d

    /// ### pat_pair
    let inline pat_pair next = 
        sepBy1 next (skip_op ",") 
        |>> List.reduceBack (fun a b -> PatPair(range_of_pattern a +. range_of_pattern b,a,b))

    /// ### RootTypeFlags
    type RootTypeFlags = {
        allow_typecase_metavars : bool
        allow_term : bool
        allow_wildcard : bool
        }

    /// ### root_type_defaults
    let root_type_defaults = {
        allow_typecase_metavars = false
        allow_term = false
        allow_wildcard = false
        }

    /// ### bottom_up_number
    let bottom_up_number (default_env : DefaultEnv) (r : VSCRange,x : string) =
        let inline f string_to_val val_to_lit val_dsc =
            match string_to_val x with
            | true, x -> Ok(r, val_to_lit x)
            | false, _ -> Error [r, BottomUpNumberParseError(x,val_dsc)]
        if x.Contains '.' then
            match default_env.default_float with
            | Float32T -> f Single.TryParse LitFloat32 "f32"
            | Float64T -> f Double.TryParse LitFloat64 "f64"
            | x -> failwithf "Compiler error: Invalid default float type. Got: %A" x
        else
            match default_env.default_int with
            | Int8T -> f SByte.TryParse LitInt8 "i8"
            | Int16T -> f Int16.TryParse LitInt16 "i16"
            | Int32T -> f Int32.TryParse LitInt32 "i32"
            | Int64T -> f Int64.TryParse LitInt64 "i64"
            | UInt8T -> f Byte.TryParse LitUInt8 "u8"
            | UInt16T -> f UInt16.TryParse LitUInt16 "u16"
            | UInt32T -> f UInt32.TryParse LitUInt32 "u32"
            | UInt64T -> f UInt64.TryParse LitUInt64 "u64"
            | x -> failwithf "Compiler error: Invalid default int type. Got: %A" x

    /// ### typecase_validate
    let typecase_validate x _ =
        let metavars = Collections.Generic.HashSet()    
        let vars = Collections.Generic.HashSet()
        let errors = ResizeArray()
        let rec f = function
            | RawTFilledNominal _ | RawTTerm _ | RawTTypecase _ -> failwith "Compiler error: This case is not supposed to appear in typecase."
            | RawTForall(r,_,_) -> errors.Add(r,ForallNotAllowedInTypecase)
            | RawTExists(r,_,_) -> errors.Add(r,ExistsNotAllowedInTypecase)
            | RawTLit _ | RawTPrim _ | RawTSymbol _ | RawTB _ | RawTWildcard _ -> ()
            | RawTMetaVar(r,a) -> if vars.Contains(a) then errors.Add(r,MetavarShadowedByVar) else metavars.Add(a) |> ignore
            | RawTVar(r,a) -> if metavars.Contains(a) then errors.Add(r,VarShadowedByMetavar) else vars.Add(a) |> ignore
            | RawTApply(_,a,b) | RawTFun(_,a,b,_) | RawTPair(_,a,b) -> f a; f b
            | RawTLayout(_,a,_) | RawTArray(_,a) -> f a
            | RawTUnion(_,a,_,_) -> Map.iter (fun _ x -> f (snd x)) a 
            | RawTRecord(_,a) -> Map.iter (fun _ -> f) a
            | RawTMacro(_,a) -> a |> List.iter (function RawMacroType(_,a) -> f a | _ -> ())
        f x
        if 0 < errors.Count then Error (Seq.toList errors) else Ok(x)

    /// ### expr_tight
    // Parses an expression only if it is directly next to the previous one.
    let inline expr_tight next (d: BlockParsingEnv) = 
        let i = blockParsingIndex d
        if 0 < i && i < d.tokens.Length then
            let r,r' = snd (fst d.tokens.[i-1]), fst (fst d.tokens.[i])
            if r.line = r'.line && r.character = r'.character then next d else Error []
        else Error []

    /// ### read_default_value'
    let inline read_default_value' f d =
        try_current d <| function
            | p, TokDefaultValue t' -> blockParsingSkip d; f (p,t')
            | p, _ -> Error [p, ExpectedLit]

    /// ### read_default_value
    let inline read_default_value on_top on_bot d =
        read_default_value' (fun (p,t') ->
            if d.is_top_down then Ok(on_top (p,t'))
            else bottom_up_number d.default_env (p,t') |> Result.map on_bot
            ) d

    /// ### read_string
    let read_string = tuple3 skip_string_open ((read_text false |>> snd) <|>% "") skip_string_close

    /// ### pat_var
    let pat_var d = (read_small_var' |>> PatVar) d

    /// ### pat_list_pair
    let pat_list_pair r a b = PatUnbox(r,"Cons",PatPair(r,a,b))

    /// ### root_pattern_var_nominal_union
    let rec root_pattern_var_nominal_union s =
        (read_var' >>= fun (r,a,re) s ->
            if Char.IsUpper(a,0) then
                (opt root_pattern_var |>> fun b ->
                    re SemanticTokenLegend.symbol
                    let b = match b with Some b -> b | None -> PatE r
                    PatUnbox(r,a,b)
                    ) s
            else 
                (many (expr_tight read_symbol) >>= fun syms s ->
                    match syms with
                    | [] ->
                        (opt root_pattern_var |>> fun b ->
                            match b with
                            | Some b ->
                                re SemanticTokenLegend.type_variable
                                PatNominal(r +. range_of_pattern b,(r,a),syms,b)
                            | None ->
                                PatVar(r,a)
                            ) s
                    | _ ->
                        (root_pattern_var |>> fun b ->
                            re SemanticTokenLegend.type_variable
                            PatNominal(r +. range_of_pattern b,(r,a),syms,b)
                            ) s
                    ) s
            ) s
    and root_pattern_wildcard d = (skip_keyword' SpecWildcard |>> PatE) d
    and root_pattern_dyn d = (blockParsingRange (skip_unary_op "~" >>. root_pattern_var) |>> PatDyn) d
    and root_pattern_record d = 
        let pat_record_item =
            let inj = skip_unary_op "$" >>. read_small_var' |>> fun a -> PatRecordMembersInjectVar,a
            let var = blockParsingRange record_var |>> fun a -> PatRecordMembersSymbol,a
            ((inj <|> var) .>>. (opt (skip_op "=" >>. root_pattern_pair)))
            |>> fun ((f,a),b) -> f (a, defaultArg b (PatVar a))
        (blockParsingRange (curlies (many pat_record_item)) |>> PatRecordMembers) d
    and root_pattern_type s = 
        pipe2 root_pattern (opt (skip_op ":" >>. root_type_annot))
            (fun a -> function Some b -> PatAnnot(range_of_pattern a +. range_of_texpr b,a,b) | None -> a) s
    and root_pattern_rounds d = 
        (blockParsingRange (rounds ((((read_op' |>> PatVar) <|> root_pattern_type) |>> fun x _ -> x) <|>% PatB))
        |>> fun (r,x) -> x r) d
    and pat_array s = (skip_unary_op ";" >>. blockParsingRange (squares (sepBy root_pattern_type (skip_op ";"))) |>> fun (r,x) -> PatArray(r,x)) s
    and pat_list s =
        (blockParsingRange (squares (sepBy root_pattern_type (skip_op ";")))
        |>> fun ((r,_),x) -> let r = r,r in List.foldBack (pat_list_pair r) x (PatUnbox(r,"Nil",PatB r))) s
    and pat_exists s = (blockParsingRange (pat_exists' .>>. root_pattern) |>> fun (r,(l,b)) -> PatExists(r,l,b)) s
    and root_pattern s =
        let body s = 
            let pat_value = (read_value |>> PatValue) <|> (read_default_value PatDefaultValue PatValue)
            let pat_string = read_string |>> (fun (a,x,b) -> PatValue(a +. b,LitString x))
            let pat_symbol = read_symbol |>> PatSymbol
            let (+) = alt (blockParsingIndex s)
            (root_pattern_rounds + root_pattern_var_nominal_union + root_pattern_wildcard + root_pattern_dyn + pat_value + pat_string 
            + root_pattern_record + pat_symbol + pat_array + pat_list + pat_exists) s

        let pat_and = sepBy1 body (skip_op "&") |>> List.reduce (fun a b -> PatAnd(range_of_pattern a +. range_of_pattern b,a,b))
        let pat_pair = pat_pair pat_and
        let pat_cons = blockParsingRange (sepBy1 pat_pair (skip_op "::")) |>> fun (r,x) -> List.reduceBack (pat_list_pair r) x
        let pat_or = sepBy1 pat_cons (skip_op "|") |>> List.reduce (fun a b -> PatOr(range_of_pattern a +. range_of_pattern b,a,b))
        let pat_as = pat_or .>>. (opt (skip_keyword SpecAs >>. pat_or )) |>> function a, Some b -> PatAnd(range_of_pattern a +. range_of_pattern b,a,b) | a, None -> a
        pat_as s
    and root_pattern_when d = (root_pattern .>>. (opt (skip_keyword SpecWhen >>. root_term)) |>> function a, Some b -> PatWhen(range_of_pattern a +. range_of_expr b,a,b) | a, None -> a) d
    and root_pattern_var d =
        let (+) = alt (blockParsingIndex d)
        (pat_var + root_pattern_wildcard + root_pattern_dyn + root_pattern_rounds + root_pattern_record + pat_array + pat_list + pat_exists) d
    and root_pattern_pair d = pat_pair root_pattern_var d
    and root_type_annot d = root_type {root_type_defaults with allow_term=d.is_top_down=false; allow_wildcard=d.is_top_down} d
    and root_type_record (flags : RootTypeFlags) d =
        (blockParsingRange (curlies (sepBy ((blockParsingRange record_var .>> skip_op ":") .>>. root_type flags) (optional (skip_op ";"))))
        >>= fun (r,x) _ ->
            x |> List.map fst |> duplicates DuplicateRecordTypeVar
            |> function [] -> Ok(RawTRecord(r,x |> List.mapi (fun i ((_,n),x) -> (i,n),x) |> Map.ofList)) | er -> Error er
            ) d
    and root_type_union (flags : RootTypeFlags) d =
        let bar = bar (col d)
        let vanilla = skip_op ":" >>. root_type flags |>> fun x -> Some (false, x)
        let gadt = 
            skip_op "::"
            >>. pipe2 (opt forall) (root_type flags) (Option.foldBack (List.foldBack (fun a b -> RawTForall(range_of_typevar a +. range_of_texpr b,a,b))))
            |>> fun x -> Some (true, x)

        let body = vanilla <|> gadt <|>% None
        (blockParsingRange (optional bar >>. sepBy1 (blockParsingRange read_big_var_as_symbol .>>. body) bar)
        >>= fun (r,x) _ ->
            x |> List.map fst |> duplicates DuplicateUnionKey
            |> function 
                | [] -> Ok(r,x |> List.mapi (fun i ((r,n),x) -> (i,n), match x with Some x -> x | None -> false, RawTB r) |> Map.ofList)
                | er -> Error er
            ) d
    and root_type (flags : RootTypeFlags) d =
        let next = root_type flags
        let cases d =
            let wildcard d = if flags.allow_wildcard then (skip_keyword' SpecWildcard |>> RawTWildcard) d else Error []
            // This metavar case only occurs in typecase during the bottom-up segment. It should not be confused with metavars during top-down type inference.
            let metavar d = if flags.allow_typecase_metavars then (skip_unary_op "~" >>. read_var' |>> fun (a,b,r) -> r SemanticTokenLegend.type_variable; RawTMetaVar(a,b)) d else Error []
            let term d = if flags.allow_term then (blockParsingRange (skip_unary_op "`" >>. ((read_var'' |>> rawv) <|> rounds root_term)) |>> RawTTerm) {d with is_top_down=false} else Error []
            let symbol = read_symbol |>> RawTSymbol
            let record = root_type_record flags
            let lit = (read_value |>> RawTLit) <|> (read_string |>> fun (a,b,c) -> RawTLit(a +. c, LitString b))
            let lit_default = read_default_value' (bottom_up_number d.default_env >> Result.map RawTLit)
            let var = read_var' |>> fun (o,x,r) ->
                r SemanticTokenLegend.type_variable
                RawTVar(o, x)
            let rounds =
                blockParsingRange (rounds ((next |>> fun x _ -> x) <|>% RawTB))
                |>> fun (r,x) -> x r
            let macro = 
                let read_macro_expression s = 
                    (macro_expression MType (root_type root_type_defaults |>> fun x -> RawMacroType(range_of_texpr x,x))
                    <|> macro_expression MTypeLit (root_type root_type_defaults |>> fun x -> RawMacroTypeLit(range_of_texpr x,x))) s
                let body = many ((read_text false |>> RawMacroText) <|> read_macro_type_var <|> read_macro_expression)
                pipe3 skip_macro_open body skip_macro_close (fun a l b -> RawTMacro(a +. b, l))
            let exists = blockParsingRange (exists .>>. root_type flags) |>> fun (r,(l,b)) -> RawTExists(r,l,b)
            let foralls = blockParsingRange (forall .>>. root_type flags) |>> (fun (r,(l,b)) -> List.foldBack (fun a b -> RawTForall(range_of_typevar a +. range_of_texpr b,a,b)) l b)
            let (+) = alt (blockParsingIndex d)
            (rounds + lit + lit_default + wildcard + term + metavar + var + record + symbol + macro + exists + foralls) d

        let fold_applies a b = List.fold (fun a b -> RawTApply(range_of_texpr a +. range_of_texpr b,a,b)) a b
        let apply_tight d = pipe2 cases (many (expr_tight cases)) fold_applies d
        let apply d = pipe2 apply_tight (many (blockParsingIndent (col d) (<) apply_tight)) fold_applies d

        let pairs = sepBy1 apply (skip_op "*") |>> List.reduceBack (fun a b -> RawTPair(range_of_texpr a +. range_of_texpr b,a,b))
        let functions = sepBy1 pairs (skip_op "->") |>> List.reduceBack (fun a b -> RawTFun(range_of_texpr a +. range_of_texpr b,a,b,FT_Vanilla))

        functions d

    and root_term d =
        let rec expressions d =
            let next = root_term
            let case_var = read_var'' |>> rawv
            let case_value = read_value |>> RawLit
            let case_exists = 
                let sequence_type d = (many (blockParsingIndent (col d) (=) (sepBy1 (root_type root_type_defaults)  (skip_op ";"))) |>> List.concat) d
                ((skip_keyword' SpecExists) .>>. (opt (squares sequence_type)) .>>. next)
                    >>= fun ((r,type_vars),body) d ->
                            if d.is_top_down || Option.isSome type_vars
                            then Ok(RawExists(r +. range_of_expr body, (r, type_vars), body))
                            else Error [r, TypeVarsNeedToBeExplicitForExists]
            let case_rounds = 
                blockParsingRange (rounds ((((read_op' |>> rawv) <|> next) |>> fun x _ -> x) <|>% RawB))
                |>> fun (r,x) -> x r
            let case_fun =
                (skip_keyword SpecFun >>. many1 root_pattern_pair .>>. (annotated_body "=>" next root_type_annot))
                >>= fun (pats, body) _ ->
                    match patterns_validate pats with
                    | [] -> List.foldBack (fun pat body -> RawFun(range_of_pattern pat +. range_of_expr body,[pat,body])) pats body |> Ok
                    | ers -> Error ers

            let case_forall d =
                if d.is_top_down then Error [] else
                    (tuple3 forall (many root_pattern_pair) (annotated_body "=>" next root_type_annot)
                    >>= fun (foralls : TypeVar list, pats, body) _ ->
                        match patterns_validate pats with
                        | [] -> 
                            List.foldBack (fun pat body -> RawFun(range_of_pattern pat +. range_of_expr body,[pat,body])) pats body
                            |> List.foldBack (fun a body -> RawForall(range_of_typevar a +. range_of_expr body,a,body)) foralls |> Ok
                        | ers -> Error ers) d

            let case_default_value = read_default_value RawDefaultLit RawLit
            let case_if_then_else d =
                let i = col d
                let inline f' keyword = blockParsingRange (skip_keyword keyword >>. next)
                let inline f keyword = blockParsingIndent i (<=) (f' keyword)
                (pipe4 (f' SpecIf) (f SpecThen) (many (f SpecElif .>>. f SpecThen)) (opt (f SpecElse))
                    (fun cond tr elifs fl -> 
                        let f cond tr = function
                            | Some fl -> fst fl, RawIfThenElse(fst cond +. fst fl,snd cond,snd tr,snd fl)
                            | None -> fst tr, RawIfThen(fst cond +. fst tr,snd cond,snd tr)
                        let fl = List.foldBack (fun (cond,tr) fl -> f cond tr fl |> Some) elifs fl
                        f cond tr fl |> snd)) d

            let case_match =
                let clauses d = 
                    let bar = bar (col d)
                    (optional bar >>. sepBy1 (root_pattern_when .>>. (skip_op "=>" >>. next)) bar
                    >>= fun l _ ->
                        match l |> List.collect (fun (a,_) -> patterns_validate [a]) with
                        | [] -> Ok l
                        | e -> Error e
                        ) d

                (blockParsingRange (skip_keyword SpecFunction >>. clauses) |>> RawFun)
                <|> (blockParsingRange ((skip_keyword SpecMatch >>. next .>> skip_keyword SpecWith) .>>. clauses) |>> fun (a,(b,c)) -> RawMatch(a,b,c))

            let case_typecase d =
                let clauses d = 
                    let bar = bar (col d)
                    let typecase = root_type {root_type_defaults with allow_typecase_metavars=true; allow_wildcard=true} >>= typecase_validate
                    (optional bar >>. sepBy1 (typecase .>>. (skip_op "=>" >>. next)) bar) d

                if d.is_top_down then Error [] else
                    (blockParsingRange ((skip_keyword SpecTypecase >>. root_type {root_type_defaults with allow_term=true} .>> skip_keyword SpecWith) .>>. clauses)
                    |>> fun (r, (a, b)) -> RawTypecase(r,a,b)) d

            let case_record =
                let create = skip_op "=" >>. next
                let modify = skip_op "#=" >>. next
                let var = blockParsingRange record_var
                let inject = skip_unary_op "$" >>. blockParsingRange read_small_var
                let record_create_body =
                    (var .>>. opt create |>> function (a,Some b) -> RawRecordWithSymbol(a,b) | (a,None) -> RawRecordWithSymbol(a,rawv a))
                    <|> (inject .>>. create |>> RawRecordWithInjectVar)
                let record_create = blockParsingRange (curlies (sepBy record_create_body (optional (skip_op ";")))) |>> fun (r,withs) -> (r,[],withs,[])
                let record_with_bodies =
                    (var >>= fun a ->
                        ((modify |>> fun b -> RawRecordWithSymbolModify(a,b))
                        <|> (opt create |>> function Some b -> RawRecordWithSymbol(a,b) | None -> RawRecordWithSymbol(a,rawv a))))
                    <|> (inject >>= fun a ->
                        ((modify |>> fun b -> RawRecordWithInjectVarModify(a,b))
                        <|> (create |>> fun b -> RawRecordWithInjectVar(a,b))))
                let record_without_bodies = (var |>> RawRecordWithoutSymbol) <|> (inject |>> RawRecordWithoutInjectVar)
                let record_with =
                    blockParsingRange
                        (curlies
                            (tuple4 read_small_var'
                                (many ((read_symbol |>> RawSymbol) <|> (skip_op "$" >>. read_small_var' |>> rawv)))
                                ((skip_keyword SpecWith >>. sepBy record_with_bodies (optional (skip_op ";"))) <|>% [])
                                ((skip_keyword SpecWithout >>. many record_without_bodies) <|>% [])))
                    |>> fun (r,(name, acs, withs, withouts)) -> (r,rawv name :: acs,withs,withouts)

                restore 2 record_create <|> record_with
                >>= fun (_,_,withs,withouts as x) _ ->
                    [
                    withs |> List.choose (function RawRecordWithSymbol(a,_) | RawRecordWithSymbolModify(a,_) -> Some a | _ -> None) |> duplicates DuplicateTermRecordSymbol
                    withs |> List.choose (function RawRecordWithInjectVar(a,_) | RawRecordWithInjectVarModify(a,_) -> Some a | _ -> None) |> duplicates DuplicateTermRecordInjection
                    withouts |> List.choose (function RawRecordWithoutSymbol(a,b) -> Some(a,b) | _ -> None) |> duplicates DuplicateTermRecordSymbol
                    withouts |> List.choose (function RawRecordWithoutInjectVar(a,b) -> Some(a,b) | _ -> None) |> duplicates DuplicateTermRecordInjection
                    ] |> List.concat |> function [] -> Ok(RawRecordWith x) | er -> Error er

            let case_join_point = skip_keyword SpecJoin >>. next |>> join_point true None
            let case_join_point_backend = skip_keyword SpecJoinBackend >>. (read_big_var_as_keyword .>>. next) |>> join_point_backend
            let case_real = skip_keyword SpecReal >>. (fun d -> next {d with is_top_down=false}) |>> fun x -> RawReal(range_of_expr x,x)
            let case_symbol = read_symbol |>> RawSymbol
            let case_list = blockParsingRange (squares sequence_body) >>= fun (r,l) d -> 
                if d.is_top_down then
                    let r = fst r, fst r
                    List.foldBack (fun a b -> 
                        RawApply(r,rawv(r,unintern "Cons"),RawPair(r,a,b))
                        ) l (rawv(r,unintern "Nil")) |> Ok
                else
                    Error [r, ListLiteralsNotAllowedInBottomUp]

            let case_string = read_string |>> fun (a, x, b) -> RawLit(a +. b,LitString x)

            let case_macro =
                let read_macro_expression s = 
                    (macro_expression MTerm (root_term |>> fun x -> RawMacroTerm(range_of_expr x,x,false))
                    <|> macro_expression MTermInline (root_term |>> fun x -> RawMacroTerm(range_of_expr x,x,true))
                    <|> macro_expression MType (root_type root_type_defaults |>> fun x -> RawMacroType(range_of_texpr x,x))
                    <|> macro_expression MTypeLit (root_type root_type_defaults |>> fun x -> RawMacroTypeLit(range_of_texpr x,x))) s
                let body = many ((read_text true |>> RawMacroText) <|> read_macro_var <|> read_macro_expression)
                pipe3 skip_macro_open body skip_macro_close (fun a l b -> RawMacro(a +. b, l))

            let (+) = alt (blockParsingIndex d)

            (case_value + case_default_value + case_var + case_join_point + case_join_point_backend + case_real + case_symbol
            + case_typecase + case_match + case_typecase + case_rounds + case_list + case_record
            + case_if_then_else + case_fun + case_forall + case_string + case_macro + case_exists) d

        and application_tight d =
            let next = expressions
            pipe2 next (many (expr_tight next)) (List.fold (fun a b -> RawApply(range_of_expr a +. range_of_expr b,a,b))) d

        and sequence_body d = (many (blockParsingIndent (col d) (=) (sepBy1 operators (skip_op ";"))) |>> List.concat) d
        and unary_op d =
            let next = application_tight
            let f = 
                read_unary_op' >>= fun (o,a) d ->
                    let type_expr d = 
                        choice [|
                            read_small_type_var' |>> RawTVar
                            read_value |>> RawTLit
                            read_string |>> fun (a,b,c) -> RawTLit(a +. c, LitString b)
                            rounds (root_type {root_type_defaults with allow_term=true})
                            |] d
                    let term_expr d =
                        choice [|
                            read_var'' |>> rawv
                            read_value |>> RawLit
                            read_default_value RawDefaultLit RawLit
                            read_string |>> fun (a,b,c) -> RawLit(a +. c, LitString b)
                            rounds root_term
                            |] d
                    match a with
                    | ";" -> 
                        if d.is_top_down then (blockParsingRange (squares sequence_body) |>> fun (r,x) -> RawApply(o,RawV(o,unintern "array",true), RawArray(o,x))) d
                        else Error [o, ArrayLiteralsNotAllowedInBottomUp]
                    | "!!!!" -> 
                        (blockParsingRange (read_big_var .>>. (rounds (sepBy (fun d -> unary_op {d with is_top_down=false}) (skip_op ","))))
                        >>= fun (r,((ra,a), b)) _ ->
                            match string_to_op a with
                            | true, op' -> Ok(RawOp(r,op',b))
                            | false, _ -> Error [ra,InbuiltOpNotFound]) d
                    | "`" -> if d.is_top_down then Error [] else (blockParsingRange type_expr |>> RawType) d
                    | "`@" -> 
                        if d.is_top_down then Error [] else 
                            (blockParsingRange term_expr |>> fun (r,x) -> 
                                let r' = o +. r 
                                RawType(r', RawTTerm(r',RawOp(r',LitToTypeLit,[x])))
                                ) d
                    | "``" -> if d.is_top_down then Error [] else (blockParsingRange type_expr |>> fun (r,x) -> RawOp(o +. r,TypeToVar,[RawType(r,x)])) d
                    | "`$" -> (read_var'' |>> fun (r,x) -> RawV(r,x,false)) d
                    | _ -> (next |>> fun b -> RawApply(o +. range_of_expr b,rawv(o, "~" + a),b)) d
            (f <|> next) d

        and application (d: BlockParsingEnv) =
            let next = unary_op
            pipe2 next (many (blockParsingIndent (col d) (<) next)) (List.fold (fun a b -> RawApply(range_of_expr a +. range_of_expr b,a,b))) d

        and operators d =
            let term = application
            let i = col d
            let op = blockParsingIndent i (<=) op

            /// Pratt parser
            let rec led left (prec,asoc,m) d =
                match asoc with
                | Associativity.Right -> (tdop (prec-1) |>> fun right -> m (left, right)) d
                | _ -> (tdop prec |>> fun right -> m (left, right)) d

            and tdop rbp d =
                let rec loop left d = 
                    ((op >>= fun (prec,_,_ as v) d ->
                        if rbp < prec then (led left v >>= loop) d
                        else skip' d -1; Error []) <|>% left) d
                (term >>= loop) d

            pipe2 (tdop Int32.MinValue)
                (opt (blockParsingIndent i (<=) (skip_op ":" >>. root_type_annot)))
                (fun a -> function Some b -> RawAnnot(range_of_expr a +. range_of_texpr b,a,b) | _ -> a)
                d

        let statements d =
            let next = operators
            let inl_or_let =
                (inl_or_let root_term root_pattern_pair root_type_annot .>>. many (and_inl_or_let root_term root_pattern_pair root_type_annot))
                >>= fun x _ -> 
                    match x with
                    | ((r,name,body),false), [] -> Ok(fun on_succ -> RawMatch(r,body,[name,on_succ]))
                    | ((_,_,_),false), l -> l |> List.map (fun ((r,_,_),_) -> r, UnexpectedAndInlRec) |> Error
                    | x, xs ->
                        let l = x :: xs |> List.map (function 
                            | (r,PatVar(o,name),body),true -> r, ((o,name), body)
                            | _ -> failwith "Compiler error: Recursive inl/let statements should always have PatVar for names and should always be recursive."
                            )
                        let r = l |> List.map fst |> List.reduce (+.)
                        l |> List.map (snd >> fst) 
                        |> duplicates DuplicateRecFunctionName
                        |> function [] -> Ok(fun on_succ -> RawRecBlock(r, List.map snd l, on_succ)) | er -> Error er
            let module_open = blockParsingModule_open |>> fun (r,(name,acs)) on_succ -> RawOpen(r,name,acs,on_succ)
            let statement_parsers d =
                let (+) = alt (blockParsingIndex d)
                (inl_or_let + module_open) d

            let i = col d
            let inline if_ x = blockParsingIndent i x
            let stmts = 
                many1 (if_ (=) (blockParsingRange statement_parsers)) .>>. opt ((if_ (<=) (skip_keyword SpecIn) >>. root_term) <|> if_ (=) next)
                >>= fun (a,b) _ -> match b with Some b -> Ok(a,b) | None -> Error [List.last a |> fst, ExpectedExpression]
            let expr = if_ (=) next |>> fun x -> [],x
            (many1 (stmts <|> expr)
            |>> fun x -> 
                List.foldBack (fun (stmts,expr) s -> 
                    let process_statements s = List.foldBack (fun (_,a) b -> a b) stmts s
                    match s with
                    | ValueNone -> ValueSome (process_statements expr)
                    | ValueSome expr' -> ValueSome (process_statements (RawSeq(range_of_expr expr +. range_of_expr expr',expr,expr')))
                    ) x ValueNone |> ValueOption.get
                ) d

        statements d

    /// ### comments
    let comments (s : BlockParsingEnv) = 
        let line_near_to = lineBlockParsing s
        let rec loop line d =
            if 0 <= line then 
                match s.comments.[line] with
                | Some(r,text) -> 
                    let text = text.TrimEnd()
                    loop (line-1) ((if text = "" then "\n" else text + " ") :: d)
                | _ -> d
            else d
        loop (line_near_to-1) []
        |> String.concat ""
        |> fun x -> Ok(x.TrimEnd())

    /// ### Comments
    type Comments = string

    /// ### TopStatement
    type [<ReferenceEquality>] TopStatement =
        | TopAnd of VSCRange * TopStatement
        | TopInl of Comments * VSCRange * (VSCRange * VarString) * RawExpr * is_top_down: bool
        | TopRecInl of Comments * VSCRange * (VSCRange * VarString) * RawExpr * is_top_down: bool
        | TopNominal of VSCRange * (VSCRange * VarString) * HoVar list * RawTExpr
        | TopNominalRec of VSCRange * (VSCRange * VarString) * HoVar list * RawTExpr
        | TopType of VSCRange * (VSCRange * VarString) * HoVar list * RawTExpr
        | TopPrototype of Comments * VSCRange * (VSCRange * VarString) * (VSCRange * VarString) * TypeVar list * RawTExpr
        | TopInstance of VSCRange * (VSCRange * VarString) * (VSCRange * VarString) * TypeVar list * RawExpr
        | TopOpen of VSCRange * (VSCRange * VarString) * (VSCRange * SymbolString) list

    /// ### top_inl_or_let_process
    let top_inl_or_let_process comments is_top_down = function
        | (r,PatVar(r',name),body),is_rec -> 
            let rec loop = function
                | RawAnnot(r,body,t) -> loop body
                | RawForall _ | RawFun _ ->
                    if is_rec then Ok(TopRecInl(comments,r,(r',name),body,is_top_down))
                    else Ok(TopInl(comments,r,(r',name),body,is_top_down))
                | _ -> Error [r, ExpectedGlobalFunction]
            loop body
        | (_,x,_),_ -> Error [range_of_pattern x, ExpectedVarOrOpAsNameOfGlobalStatement]

    /// ### top_inl_or_let
    let top_inl_or_let d = ((comments .>>. inl_or_let root_term root_pattern_pair root_type_annot) >>= fun (comments,x) d -> top_inl_or_let_process comments d.is_top_down x) d

    /// ### process_union
    let process_union (r,(layout,n,a,(r',b))) _ =
        let this = (RawTVar n,a) ||> List.fold (fun s x -> RawTApply(r',s,RawTVar(r',hovar_name x)))
        match layout with
        | UHeap -> Ok(TopNominalRec(r,n,a,RawTUnion(r',b,layout,this)))
        | UStack -> Ok(TopNominal(r,n,a,RawTUnion(r',b,layout,this)))

    /// ### union_clauses
    let union_clauses d = root_type_union root_type_defaults d

    /// ### top_union
    let top_union d = ((blockParsingRange (tuple4 (skip_keyword SpecUnion >>. ((skip_keyword SpecRec >>% UHeap) <|>% UStack)) read_small_type_var' (many ho_var .>> skip_op "=") union_clauses)) >>= process_union) d

    /// ### top_nominal
    let top_nominal d = 
        (blockParsingRange (tuple3 (skip_keyword SpecNominal >>. read_small_type_var') (many ho_var .>> skip_op "=") (root_type {root_type_defaults with allow_term=true}))
        |>> fun (r,(n,a,b)) -> TopNominal(r,n,a,b)) d

    /// ### type_forall
    let inline type_forall next d = (pipe2 (forall <|>% []) next (List.foldBack (fun x s -> RawTForall(range_of_typevar x +. range_of_texpr s,x,s)))) d

    /// ### top_prototype
    let top_prototype d = 
        (blockParsingRange 
            (tuple5 comments
                (skip_keyword SpecPrototype >>. (read_small_var' <|> rounds read_op')) read_small_type_var' (many forall_var) 
                (skip_op ":" >>. type_forall (root_type root_type_defaults)))
        |>> fun (r,(com,a,b,c,d)) -> TopPrototype(com,r,a,b,c,d)) d

    /// ### top_instance
    let top_instance d =
        (blockParsingRange
            (tuple4 (skip_keyword SpecInstance >>. (read_small_var' <|> rounds read_op')) read_small_type_var' (many forall_var) (skip_op "=" >>. root_term))
        >>= fun (r,(prototype_name, nominal_name, nominal_foralls, body)) _ ->
                Ok(TopInstance(r,prototype_name,nominal_name,nominal_foralls,body))
                ) d

    /// ### top_type
    let top_type d = (blockParsingRange (tuple3 (skip_keyword SpecType >>. read_small_type_var') (many ho_var) (skip_op "=" >>. root_type root_type_defaults)) |>> fun (r,(a,b,c)) -> TopType(r,a,b,c)) d

    /// ### top_and_inl_or_let
    let top_and_inl_or_let d = 
        (comments .>>. restore 1 (blockParsingRange (and_inl_or_let root_term root_pattern_pair root_type_annot)) 
        >>= fun (comments,(r,x)) d -> top_inl_or_let_process comments d.is_top_down x |> Result.map (fun x -> TopAnd(r,x))) d

    /// ### top_and
    let inline top_and f = restore 1 (blockParsingRange (skip_keyword SpecAnd >>. f)) |>> TopAnd

    /// ### top_and_union
    let top_and_union d = top_and ((blockParsingRange (tuple4 (skip_keyword SpecUnion >>% UHeap) read_small_type_var' (many ho_var .>> skip_op "=") union_clauses)) >>= process_union) d

    /// ### top_open
    let top_open d = (blockParsingModule_open |>> fun (r,(name,acs)) -> TopOpen(r,name,acs)) d

    /// ### top_statement
    let top_statement s =
        let (+) = alt (blockParsingIndex s)
        (top_inl_or_let + top_union + top_nominal + top_prototype + top_type + top_instance + top_and_inl_or_let + top_and_union + top_open) s

    /// ### ParserErrorsList
    type ParserErrorsList = (VSCRange * ParserErrors) list

    /// ### ParseResult
    type ParseResult = Result<TopStatement,ParserErrorsList>

    /// ### blockParsingParse
    let blockParsingParse (s : BlockParsingEnv) : ParseResult =
        if 0 < s.tokens.Length then
            match top_statement s with
            | Ok _ as x -> if s.Index = s.tokens.Length then x else Error [fst s.tokens.[s.Index], ExpectedEob]
            | Error [] ->
                if s.Index = s.tokens.Length then Error [fst (Array.last s.tokens), UnexpectedEob]
                else Error [fst s.tokens.[s.Index], ExpectedEob]
            | Error _ as l -> l
        else
            Error []

    /// ### show_parser_error
    let show_parser_error = function
        | TypeVarsNeedToBeExplicitForExists -> "The type vars for the exists body have to be specified up front in the bottom-up segment."
        | DuplicateExistsVar -> "Duplicate variable in the exists type."
        | ExistsNotAllowedInTypecase -> "The existential type is not allowed in typecase."
        | ForallNotAllowedInTypecase -> "The type lambda is not allowed in typecase."
        | MetavarShadowedByVar -> "The metavariable is shadowed by a variable."
        | VarShadowedByMetavar -> "The variable is shadowed by a metavariable."
        | ExpectedPairedSymbolInUnion -> "The union clause should be pair whose left side is a symbol."
        | ExpectedEscapedChar false -> "escaped character"
        | ExpectedEscapedChar true -> "escaped character or the escaped variable (\\v)"
        | ExpectedUnescapedChar -> "unescaped character"
        | ExpectedMacroVar -> "variable"
        | ExpectedMacroTypeVar -> "type variable"
        | ExpectedMacroTypeLitVar -> "type literal variable"
        | ExpectedText -> "text"
        | ExpectedMacroOpen -> "$\""
        | ExpectedStringOpen -> "\""
        | ExpectedMacroClose | ExpectedStringClose -> "\""
        | ExpectedKeyword x ->
            match x with
            | SpecExists -> "exists"
            | SpecIn -> "in"
            | SpecAnd -> "and"
            | SpecFun -> "fun"
            | SpecMatch -> "match"
            | SpecTypecase -> "typecase"
            | SpecFunction -> "function"
            | SpecWith -> "with"
            | SpecWithout -> "without"
            | SpecAs -> "as"
            | SpecWhen -> "when"
            | SpecInl -> "inl"
            | SpecLet -> "let"
            | SpecForall -> "forall"
            | SpecInm -> "inm"
            | SpecInb -> "inb"
            | SpecRec -> "rec"
            | SpecIf -> "if"
            | SpecThen -> "then"
            | SpecElif -> "elif"
            | SpecElse -> "else"
            | SpecJoin -> "join"
            | SpecJoinBackend -> "join_backend"
            | SpecType -> "type"
            | SpecNominal -> "nominal"
            | SpecReal -> "real"
            | SpecUnion -> "union"
            | SpecOpen -> "open"
            | SpecWildcard -> "_"
            | SpecInstance -> "instance"
            | SpecPrototype -> "prototype"
        | ExpectedParenthesis(Round,Open) -> "("
        | ExpectedParenthesis(Curly,Open) -> "{"
        | ExpectedParenthesis(Square,Open) -> "["
        | ExpectedParenthesis(Round,Close) -> ")"
        | ExpectedParenthesis(Curly,Close) -> "}"
        | ExpectedParenthesis(Square,Close) -> "]"
        | ExpectedMacroExpression(MTerm,Open) -> "`("
        | ExpectedMacroExpression(MType,Open) -> "!("
        | ExpectedMacroExpression(MTypeLit,Open) -> "@("
        | ExpectedMacroExpression(MTermInline,Open) -> "#("
        | ExpectedMacroExpression((MTerm | MTermInline | MType | MTypeLit),Close) -> ")"
        | ExpectedOpenParenthesis -> "(, { or ["
        | ExpectedOperator' -> "operator"
        | ExpectedOperator x -> x
        | ExpectedUnaryOperator' -> "unary operator"
        | ExpectedUnaryOperator x -> x
        | ExpectedUnit -> "()"
        | ExpectedSmallVar -> "lowercase variable"
        | ExpectedBigVar -> "uppercase variable"
        | ExpectedVar -> "variable"
        | ExpectedLit -> "literal"
        | ExpectedSymbol -> "symbol"
        | ExpectedSymbolPaired -> "paired symbol"
        | ExpectedStatement -> "statement"
        | ExpectedFunctionAsBodyOfRecStatement -> "Rec statements should all return functions known at parse time."
        | ExpectedGlobalFunction -> "Global inl/let statements should all return functions known at parse time."
        | ExpectedSinglePatternWhenStatementNameIsNorVarOrOp -> "Unexpected pattern."
        | ExpectedVarOrOpAsNameOfGlobalStatement -> "The first pattern of a global statement should either be a variable or compile down to it."
        | ExpectedVarOrOpAsNameOfRecStatement -> "The first pattern of a recursive statement should either be a variable or compile down to it."
        | ExpectedExpression -> "A sequence of statements should end in an expression."
        | InbuiltOpNotFound -> "Not found among the inbuilt operations."
        | UnknownOperator -> "Operator does not have known precedence and associativity."
        | ForallNotAllowed -> "Forall not allowed here."
        | InvalidPattern DisjointOrPatternVar -> "Both branches of an or pattern need to have the same variables. This one is disjoint."
        | InvalidPattern DuplicateTermVar -> "Duplicate term variable in pattern."
        | InvalidPattern DuplicateTypeVar -> "Duplicate type variable in pattern."
        | InvalidPattern ShadowedVar -> "Shadowed pattern variable."
        | MetavarNotAllowed -> "Metavariable is not allowed here."
        | SymbolPairedShouldStartWithUppercaseInTypeScope -> "Paired symbol should start with uppercase in type scope."
        | TermNotAllowed -> "The term is not allowed here."
        | TypecaseNotAllowed -> "Typecase is not allowed here."
        | UnexpectedAndInlRec -> "The first statement of a recursive block has to be marked as recursive."
        | ExpectedEob -> "Failed to parse this token."
        | UnexpectedEob -> "Unexpected end of block past this token."
        | UnknownError -> "Compiler error: Parsing failed at this position with no error message and without consuming all the tokens in a block."
        | DuplicateRecordTypeVar -> "Duplicate record type variable."
        | DuplicateForallVar -> "Duplicate forall variable."
        | DuplicateConstraint -> "Duplicate constraint."
        | InvalidPattern DuplicateRecordSymbol
        | DuplicateTermRecordSymbol -> "Duplicate record symbol."
        | InvalidPattern DuplicateRecordInjection
        | DuplicateTermRecordInjection -> "Duplicate record injection."
        | DuplicateRecFunctionName -> "Shadowing of functions by the members of the same mutually recursive block is not allowed."
        | BottomUpNumberParseError (x, val_dsc) -> sprintf "The string %s cannot be safely parsed as %s." x val_dsc
        | DuplicateUnionKey -> "Duplicate union keys are not allowed."
        | ListLiteralsNotAllowedInBottomUp -> "List literals are not allowed in the bottom-up segment."
        | ArrayLiteralsNotAllowedInBottomUp -> "Array literals are not allowed in the bottom-up segment."

    /// ## HopacExtensions
    open Hopac
    open Hopac.Infixes

    let (>>**) x f =
        if x |> Hopac.Promise.Now.isFulfilled
        then x |> Hopac.Promise.Now.get |> f
        else Hopac.Infixes.(>>=*) x f

    /// ## BlockBundling
    open Hopac.Extensions
    open Hopac.Stream

    // open FSharpx.Collections

    /// ### Bundle
    // These bundles are top statements that have their range offsets distributed into them.
    type [<ReferenceEquality>] Bundle =
        | BundleType of VSCRange * (VSCRange * VarString) * HoVar list * RawTExpr
        | BundleNominal of VSCRange * (VSCRange * VarString) * HoVar list * RawTExpr
        | BundleNominalRec of (VSCRange * (VSCRange * VarString) * HoVar list * RawTExpr) list
        | BundleInl of Comments * VSCRange * (VSCRange * VarString) * RawExpr * is_top_down: bool
        | BundleRecInl of (Comments * VSCRange * (VSCRange * VarString) * RawExpr) list * is_top_down: bool
        | BundlePrototype of Comments * VSCRange * (VSCRange * VarString) * (VSCRange * VarString) * TypeVar list * RawTExpr
        | BundleInstance of VSCRange * (VSCRange * VarString) * (VSCRange * VarString) * TypeVar list * RawExpr
        | BundleOpen of VSCRange * (VSCRange * VarString) * (VSCRange * SymbolString) list

    /// ### bundle_range
    let bundle_range = function
        | BundleType(r,_,_,_) | BundleNominal(r,_,_,_) | BundleInl(_,r,_,_,_) 
        | BundlePrototype(_,r,_,_,_,_) | BundleInstance(r,_,_,_,_) | BundleOpen(r,_,_) -> r
        | BundleNominalRec l -> List.head l |> fun (r,_,_,_) -> r
        | BundleRecInl(l,_) -> List.head l |> fun (_,r,_,_) -> r

    /// ### add_offset
    let add_offset offset (range : VSCRange) : VSCRange = 
        let f (a : VSCPos) = {|a with line=offset + a.line|}
        let a,b = range
        f a, f b

    /// ### add_offset_hovar
    let add_offset_hovar offset (a,b) = add_offset offset a, b

    /// ### add_offset_hovar_list
    let add_offset_hovar_list offset x = List.map (add_offset_hovar offset) x

    /// ### add_offset_typevar
    let add_offset_typevar offset ((a,b),c) = (add_offset offset a, b), add_offset_hovar_list offset c

    /// ### add_offset_typevar_list
    let add_offset_typevar_list offset x = List.map (add_offset_typevar offset) x

    /// ### fold_offset_ty
    let rec fold_offset_ty offset x = 
        let f = fold_offset_ty offset
        let g = add_offset offset
        match x with
        | RawTWildcard r -> RawTWildcard(g r)
        | RawTLit(r,a) -> RawTLit(g r, a)
        | RawTB r -> RawTB(g r)
        | RawTMetaVar(r,a) -> RawTMetaVar(g r,a)
        | RawTVar(r,a) -> RawTVar(g r,a)
        | RawTArray(r,a) -> RawTArray(g r,f a)
        | RawTPair(r,a,b) -> RawTPair(g r,f a,f b)
        | RawTFun(r,a,b,t) -> RawTFun(g r,f a,f b,t)
        | RawTRecord(r,a) -> RawTRecord(g r,Map.map (fun _ -> f) a)
        | RawTUnion(r,a,b,c) -> RawTUnion(g r,Map.map (fun _ (is_gadt,body) -> is_gadt, f body) a,b,f c)
        | RawTTypecase(r,a,b) -> RawTTypecase(g r,f a,List.map (fun (a,b) -> f a, f b) b)
        | RawTSymbol(r,a) -> RawTSymbol(g r,a)
        | RawTApply(r,a,b) -> RawTApply(g r,f a,f b)
        | RawTForall(r,a,b) -> RawTForall(g r,add_offset_typevar offset a,f b)
        | RawTExists(r,a,b) -> RawTExists(g r,add_offset_typevar_list offset a,f b)
        | RawTPrim(r,a) -> RawTPrim(g r,a)
        | RawTTerm(r,a) -> RawTTerm(g r,fold_offset_term offset a)
        | RawTMacro(r,a) -> RawTMacro(g r,fold_offset_macro offset a)
        | RawTFilledNominal(r,a) -> RawTFilledNominal(g r,a)
        | RawTLayout(r,a,b) -> RawTLayout(g r,f a,b)
    and fold_offset_macro offset a =
        let g = add_offset offset
        List.map (function
            | RawMacroText(r,a) -> RawMacroText(g r,a)
            | RawMacroTerm(r,a,b) -> RawMacroTerm(g r,fold_offset_term offset a,b)
            | RawMacroType(r,a) -> RawMacroType(g r,fold_offset_ty offset a)
            | RawMacroTypeLit(r,a) -> RawMacroTypeLit(g r,fold_offset_ty offset a)
            ) a
    and fold_offset_term offset x = 
        let f = fold_offset_term offset
        let ty = fold_offset_ty offset
        let g = add_offset offset
        match x with
        | RawB r -> RawB (g r)
        | RawV(r,a,b) -> RawV (g r,a,b)
        | RawLit(r,a) -> RawLit (g r,a)
        | RawDefaultLit(r,a) -> RawDefaultLit (g r,a)
        | RawSymbol(r,a) -> RawSymbol (g r,a)
        | RawType(r,a) -> RawType(g r, ty a)
        | RawMatch(r,a,b) -> RawMatch(g r,f a,List.map (fun (a,b) -> fold_offset_pattern offset a,f b) b)
        | RawFun(r,a) -> RawFun(g r,List.map (fun (a,b) -> fold_offset_pattern offset a,f b) a)
        | RawForall(r,a,b) -> RawForall(g r,add_offset_typevar offset a,f b)
        | RawExists(r,(r',a),b) -> RawExists(g r,(g r',Option.map (List.map ty) a),f b)
        | RawFilledForall(r,a,b) -> RawFilledForall(g r,a,f b)
        | RawRecBlock(r,a,b) -> RawRecBlock(g r,List.map (fun ((r,a),b) -> (g r,a),f b) a,f b)
        | RawRecordWith(r,a,b,c) -> 
            let b =
                b |> List.map (function
                    | RawRecordWithSymbol((r,a),b) -> RawRecordWithSymbol((g r,a),f b)
                    | RawRecordWithSymbolModify((r,a),b) -> RawRecordWithSymbolModify((g r,a),f b)
                    | RawRecordWithInjectVar((r,a),b) -> RawRecordWithInjectVar((g r,a),f b)
                    | RawRecordWithInjectVarModify((r,a),b) -> RawRecordWithInjectVarModify((g r,a),f b)
                    )
            let c =
                c |> List.map (function
                    | RawRecordWithoutSymbol(r,a) -> RawRecordWithoutSymbol(g r,a)
                    | RawRecordWithoutInjectVar(r,a) -> RawRecordWithoutInjectVar(g r,a)
                    )
            RawRecordWith(g r, List.map f a,b,c)
        | RawOp(r,a,b) -> RawOp(g r,a,List.map f b)
        | RawJoinPoint(r,q,a,b) -> RawJoinPoint(g r,Option.map (fun (r',w) -> g r',w) q,f a,b)
        | RawAnnot(r,a,b) -> RawAnnot(g r,f a,ty b)
        | RawTypecase(r,a,b) -> RawTypecase(g r,ty a,List.map (fun (a,b) -> ty a,f b) b)
        | RawOpen(r,a,b,c) -> RawOpen(g r,add_offset_hovar offset a,add_offset_hovar_list offset b,f c)
        | RawApply(r,a,b) -> RawApply(g r,f a,f b)
        | RawIfThenElse(r,a,b,c) -> RawIfThenElse(g r,f a,f b,f c)
        | RawIfThen(r,a,b) -> RawIfThen(g r,f a,f b)
        | RawPair(r,a,b) -> RawPair(g r,f a,f b)
        | RawSeq(r,a,b) -> RawSeq(g r,f a,f b)
        | RawHeapMutableSet(r,a,b,c) -> RawHeapMutableSet(g r,f a,List.map f b,f c)
        | RawReal(r,a) -> RawReal(g r,f a)
        | RawMissingBody r -> RawMissingBody(g r)
        | RawMacro(r,a) -> RawMacro(g r,fold_offset_macro offset a)
        | RawArray(r,a) -> RawArray(g r,List.map f a)
    and fold_offset_pattern offset x = 
        let f = fold_offset_pattern offset
        let term = fold_offset_term offset
        let ty = fold_offset_ty offset
        let g = add_offset offset
        let g' x = add_offset_hovar offset x
        match x with
        | PatFilledDefaultValue _ -> failwith "Compiler error: Later stages only."
        | PatB r -> PatB(g r)
        | PatE r -> PatE(g r)
        | PatVar(r,a) -> PatVar(g r,a)
        | PatDyn(r,a) -> PatDyn(g r,f a)
        | PatUnbox(r,q,a) -> PatUnbox(g r,q,f a)
        | PatAnnot(r,a,b) -> PatAnnot(g r,f a,ty b)
        | PatPair(r,a,b) -> PatPair(g r,f a,f b)
        | PatSymbol(r,a) -> PatSymbol(g r,a)
        | PatRecordMembers(r,a) ->
            let a = a |> List.map (function
                | PatRecordMembersSymbol((r,a),b) -> PatRecordMembersSymbol((g r,a),f b)
                | PatRecordMembersInjectVar((r,a),b) -> PatRecordMembersInjectVar((g r,a),f b)
                )
            PatRecordMembers(g r,a)
        | PatOr(r,a,b) -> PatOr(g r,f a,f b)
        | PatAnd(r,a,b) -> PatAnd(g r,f a,f b)
        | PatValue(r,a) -> PatValue(g r,a)
        | PatDefaultValue(r,a) -> PatDefaultValue(g r,a)
        | PatWhen(r,a,b) -> PatWhen(g r,f a,term b)
        | PatNominal(r,a,b,c) -> PatNominal(g r,g' a,List.map g' b,f c)
        | PatExists(r,a,b) -> PatExists(g r,List.map g' a,f b)
        | PatArray(r,a) -> PatArray(g r,List.map f a)

    /// ### bundle_blocks
    let bundle_blocks (blocks : TopStatement Block list) =
        match blocks with
        | [] -> None
        | {block=TopAnd _} :: x' -> failwith "Compiler error: TopAnd should be eliminated during the first bundling step."
        | {block=TopRecInl _} :: _ as l ->
            l |> List.mapFold (fun _ -> function
                | {offset=i; block=TopRecInl(com,r,a,b,c)} -> (com, add_offset i r, add_offset_hovar i a, fold_offset_term i b), c
                | _ -> failwith "Compiler error: Recursive inl statements can only be followed by statements of the same type."
                ) true
            |> BundleRecInl |> Some
        | {block=TopNominalRec _} :: _ as l ->
            l |> List.map (function 
                | {offset=i; block=TopNominalRec(r,a,b,c)} -> (add_offset i r, add_offset_hovar i a, add_offset_hovar_list i b, fold_offset_ty i c)
                | _ -> failwith "Compiler error: Recursive type statements can only be followed by statements of the same type."
                )
            |> BundleNominalRec |> Some
        | [{offset=i; block=TopInl(com,r,a,b,c)}] -> BundleInl(com, add_offset i r, add_offset_hovar i a, fold_offset_term i b, c) |> Some
        | [{offset=i; block=TopPrototype(com,r,a,b,c,d)}] -> BundlePrototype(com,add_offset i r, add_offset_hovar i a, add_offset_hovar i b, add_offset_typevar_list i c, fold_offset_ty i d) |> Some
        | [{offset=i; block=TopNominal(r,a,b,c)}] -> BundleNominal(add_offset i r, add_offset_hovar i a, add_offset_hovar_list i b, fold_offset_ty i c) |> Some
        | [{offset=i; block=TopType(r,a,b,c)}] -> BundleType(add_offset i r, add_offset_hovar i a, add_offset_hovar_list i b, fold_offset_ty i c) |> Some
        | [{offset=i; block=TopInstance(r,a,b,c,d)}] -> BundleInstance(add_offset i r, add_offset_hovar i a, add_offset_hovar i b, add_offset_typevar_list i c, fold_offset_term i d) |> Some
        | [{offset=i; block=TopOpen(r,a,b)}] -> BundleOpen(add_offset i r, add_offset_hovar i a, add_offset_hovar_list i b) |> Some
        | {block=TopInl _ | TopPrototype _ | TopNominal _ | TopType _ | TopInstance _ | TopOpen _} :: _ -> failwith "Compiler error: Regular top level statements should be singleton bundles."

    /// ### add_line_to_range
    let add_line_to_range line ((a,b) : VSCRange) = {|a with line=line+a.line|}, {|b with line=line+b.line|}

    /// ### process_error
    let process_error v = 
        let messages, expecteds = v |> List.distinct |> List.partition (fun x -> System.Char.IsUpper(x,0))
        let ex () = match expecteds with [x] -> sprintf "Expected: %s" x | x -> sprintf "Expected one of: %s" (String.concat ", " x)
        let f l = String.concat "\n" l
        if List.isEmpty expecteds then f messages
        elif List.isEmpty messages then ex ()
        else f (ex () :: "" :: "Other error messages:" :: messages)

    /// ### show_block_parsing_error
    let show_block_parsing_error line (l : ParserErrorsList) : RString list =
        l |> List.groupBy fst
        |> List.map (fun (k,v) -> 
            let k = add_line_to_range line k
            let v = List.map (snd >> show_parser_error) v
            k, process_error v
            )

    /// ### ParsedBlock
    type ParsedBlock = {result : ParseResult; semantic_tokens : LineTokens}

    /// ### ParserState
    type ParserState = {
        is_top_down : bool
        blocks : (LineTokens * ParsedBlock Promise Block) list
        }

    /// ### BlockBundleValue
    type BlockBundleValue = {bundle : Bundle option; errors : RString list}

    /// ### BlockBundleState
    type BlockBundleState = (TopStatement Block list * BlockBundleValue) Stream

    /// ### BlockBundleStateInner
    type BlockBundleStateInner = {errors : RString list; tmp : TopStatement Block list; state : BlockBundleState}

    /// ### wdiff_block_bundle_init
    let wdiff_block_bundle_init : BlockBundleState = Promise.Now.never()

    /// ### wdiff_block_bundle
    /// Bundles the blocks with the `and` statements. Also collects the parser errors.
    /// Does diffing to ref preserve the bundles.
    let wdiff_block_bundle (state : BlockBundleState) (l : ParserState) : BlockBundleState =
        let (+.) a b = add_line_to_range a b

        let empty = {state=wdiff_block_bundle_init; tmp=[]; errors=[]}
        let move_temp (s : BlockBundleStateInner) next =
            let o' = List.rev s.tmp
            let fl () = (o',{bundle=bundle_blocks o'; errors=Seq.toList s.errors}), next empty
            if Promise.Now.isFulfilled s.state then
                match Promise.Now.get s.state with
                | Cons((o,q),xs) when o = o' -> (o,{bundle=q.bundle; errors=Seq.toList s.errors}), next {state=xs; tmp=[]; errors=[]}
                | _ -> fl ()
            else fl ()
            |> Cons |> Promise.Now.withValue

        let inline iter (s : BlockBundleStateInner) l f = 
            match l with
            | (_,x) :: x' -> let offset = x.offset in x.block >>** fun {result=a} -> f (offset,a,x')
            | [] -> move_temp s (fun _ -> Promise.Now.withValue Nil)
        let rec init (s : BlockBundleStateInner) l = iter s l <| fun (offset,x,x') -> 
            match x with
            | Ok (TopAnd(r,_)) -> init {s with errors = (offset +. r, "Invalid `and` statement.") :: s.errors} x'
            | Ok (TopRecInl _ as a) -> recinl {s with tmp = {offset=offset; block=a} :: s.tmp} x'
            | Ok (TopNominalRec _ as a) -> rectype {s with tmp = {offset=offset; block=a} :: s.tmp} x'
            | Ok a -> move_temp {s with tmp = {offset=offset; block=a} :: s.tmp} (fun s -> init s x')
            | Error er -> init {s with errors = List.append (show_block_parsing_error offset er) s.errors} x'
        and recinl (s : BlockBundleStateInner) l = iter s l <| fun (offset,x,x') -> 
            match x with
            | Ok (TopAnd(_, TopRecInl _ & a)) -> recinl {s with tmp = {offset=offset; block=a} :: s.tmp} x'
            | Ok (TopAnd(r, _)) -> recinl {s with errors = (offset +. r, "inl/let recursive statements can only be followed by `and` inl/let statements.") :: s.errors} x'
            | Ok _ -> move_temp s (fun s -> init s l)
            | Error er -> recinl {s with errors = List.append (show_block_parsing_error offset er) s.errors} x'
        and rectype (s : BlockBundleStateInner) l = iter s l <| fun (offset,x,x') -> 
            match x with
            | Ok (TopAnd(_, TopNominalRec _ & a)) -> rectype {s with tmp = {offset=offset; block=a} :: s.tmp} x'
            | Ok (TopAnd(r, _)) -> rectype {s with errors = (offset +. r, "`union rec` can only be followed by `and union`.") :: s.errors} x'
            | Ok _ -> move_temp s (fun s -> init s l)
            | Error er -> rectype {s with errors = List.append (show_block_parsing_error offset er) s.errors} x'

        init {empty with state=state} l.blocks

    /// ### semantic_tokens
    let semantic_tokens (l : ParserState) = 
        let rec loop s = function
            | (_,x) :: xs -> x.block >>= fun x -> loop (PersistentVector.append s x.semantic_tokens) xs
            | [] -> Job.result s
        loop PersistentVector.empty l.blocks

    /// ## Infer

    /// ### 'a ref'
    type [<ReferenceEquality>] 'a ref' = {mutable contents' : 'a}

    /// ### TT
    type TT =
        | KindType
        | KindFun of TT * TT
        | KindMetavar of TT option ref'

    /// ### Constraint
    type Constraint =
        | CUInt
        | CSInt
        | CInt
        | CFloat
        | CNumber
        | CPrim
        | CSymbol
        | CRecord
        | CPrototype of GlobalId

    /// ### ConstraintOrModule
    type ConstraintOrModule = C of Constraint | M of Map<string,ConstraintOrModule>

    /// ### Var
    type [<ReferenceEquality>] Var = {
        scope : int
        constraints : Constraint Set // Must be stated up front and needs to be static in forall vars
        kind : TT // Is not supposed to have metavars.
        name : string // Is what gets printed.
        }

    /// ### MVar
    type [<ReferenceEquality>] MVar = {
        mutable scope : int
        mutable constraints : Constraint Set // Must be stated up front and needs to be static in forall vars
        kind : TT // Has metavars, and so is mutable.
        }

    /// ### TM
    type TM =
        | TMText of string
        | TMVar of T
        | TMLitVar of T
    and T =
        | TyB
        | TyLit of Literal
        | TyPrim of PrimitiveType
        | TySymbol of string
        | TyPair of T * T
        | TyRecord of Map<int * string, T>
        | TyModule of Map<string, T>
        | TyComment of Comments * T
        | TyFun of T * T * FunType
        | TyArray of T
        | TyNominal of GlobalId
        | TyUnion of Map<int * string,bool * T> * UnionLayout // The boolean arg determines whether the union case is generalized.
        | TyApply of T * T * TT // Regular type functions (TyInl) get reduced, while this represents the staged reduction of nominals.
        | TyInl of Var * T
        | TyForall of Var * T
        | TyExists of Var list * T
        | TyMetavar of MVar * T option ref
        | TyVar of Var * T option ref
        | TyMacro of TM list
        | TyLayout of T * Layout

    /// ### tyvar
    let tyvar x = TyVar(x, ref None)

    /// ### TypeError
    type TypeError =
        | KindError of TT * TT
        | KindErrorInConstraint of TT * TT
        | ExpectedSymbolAsRecordKey of T
        | ExpectedSymbolAsModuleKey of T
        | UnboundVariable of string
        | UnboundModule
        | ModuleIndexFailedInOpen
        | ModuleIndexWouldShadowLocalVars of string []
        | TermError of T * T
        | TypeVarScopeError of string * T * T
        | RecursiveMetavarsNotAllowed of T * T
        | RecursiveTypevarsNotAllowed of T * T
        | ForallVarConstraintError of string * Constraint Set * Constraint Set
        | MetavarsNotAllowedInRecordWith
        | ExpectedRecord of T
        | ExpectedExistentialInTerm of T
        | ExpectedExistentialInPattern of T
        | UnexpectedNumberOfArgumentsInExistsPattern of got: int * expected: int
        | UnexpectedNumberOfArgumentsInExistsBody of got: int * expected: int
        | ExistsShouldntHaveMetavars of T list
        | ExpectedRecordInsideALayout of T
        | UnionsCannotBeApplied
        | ExpectedNominalInApply of T
        | MalformedNominal
        | LayoutSetMustBeAnnotated
        | ExpectedMutableLayout of T
        | ExpectedRecordAsResultOfIndex of T
        | RecordIndexFailed of string
        | ModuleIndexFailed of string
        | ExpectedModule of T
        | ExpectedSymbol' of T
        | ExpectedSymbolInRecordWith of T
        | RealFunctionInTopDown
        | ModuleMustBeImmediatelyApplied
        | MissingRecordFieldsInPattern of T * string list
        | CasePatternNotFoundForType of GlobalId * string
        | CasePatternNotFound of string
        | CannotInferCasePatternFromTermInEnv of T
        | NominalInPatternUnbox of GlobalId
        | TypeInEnvIsNotNominal of T
        | UnionInPatternNominal of GlobalId
        | ConstraintError of Constraint * T
        | PrototypeConstraintCannotPropagateToMetavar of GlobalId * T
        | PrototypeConstraintCannotPropagateToVar of GlobalId * T
        | ExpectedAnnotation
        | ExpectedSinglePattern
        | RecursiveAnnotationHasMetavars of T
        | ValueRestriction of T
        | DuplicateRecInlName
        | DuplicateKeyInRecUnion
        | ExpectedConstraintInsteadOfModule
        | InstanceNotFound of prototype: GlobalId * instance: GlobalId
        | ExpectedPrototypeConstraint of Constraint
        | ExpectedPrototypeInsteadOfModule
        | ExpectedHigherOrder of T
        | InstanceArityError of prototype_arity: int * instance_arity: int
        | InstanceCoreVarsShouldMatchTheArityDifference of got: int * expected: int
        | InstanceKindError of TT * TT
        | KindNotAllowedInInstanceForall
        | InstanceVarShouldNotMatchAnyOfPrototypes
        | MissingBody
        | MacroIsMissingAnnotation
        | ArrayIsMissingAnnotation
        | ExistsIsMissingAnnotation
        | ShadowedForall
        | ShadowedExists
        | UnionTypesMustHaveTheSameLayout
        | OrphanInstance
        | ShadowedInstance
        | UnusedTypeVariable of string list
        | CompilerError of string
        | IncorrectGADTConstructorType
        | IncorrectRecursiveNominal

    /// ### shorten'<'a>
    let inline shorten'<'a> (x : 'a) link next =
        let x' : 'a = next x
        if System.Object.ReferenceEquals(x,x') = false then link.contents' <- Some x'
        x'

    /// ### visit_tt
    let rec visit_tt = function
        | KindMetavar({contents'=Some x} & link) -> shorten' x link visit_tt
        | a -> a

    /// ### shorten<'a>
    let inline shorten<'a> (x : 'a) (link : ref<option<'a>>) next =
        let x' : 'a = next x
        if System.Object.ReferenceEquals(x,x') = false then link.Value <- Some x'
        x'

    /// ### visit_t_mvar
    let rec visit_t_mvar = function
        | TyComment(_,a) -> visit_t_mvar a
        | TyMetavar(_,{contents=Some x} & link) -> shorten x link visit_t_mvar
        | a -> a

    /// ### visit_t
    let rec visit_t x = 
        match visit_t_mvar x with
        | TyVar(_,{contents=Some x}) -> visit_t x
        | x -> x

    /// ### InferTypeErrorException
    exception InferTypeErrorException of (VSCRange * TypeError) list

    /// ### metavars
    let rec metavars = function
        | RawTTypecase _ | RawTExists _ | RawTFilledNominal _ | RawTMacro _ | RawTVar _ | RawTTerm _ 
        | RawTPrim _ | RawTWildcard _ | RawTLit _ | RawTB _ | RawTSymbol _ -> Set.empty
        | RawTMetaVar(_,a) -> Set.singleton a
        | RawTArray(_,a) | RawTLayout(_,a,_) | RawTForall(_,_,a) -> metavars a
        | RawTPair(_,a,b) | RawTApply(_,a,b) | RawTFun(_,a,b,_) -> metavars a + metavars b
        | RawTUnion(_,l,_,this) -> Map.fold (fun s _ (_,v) -> s + metavars v) (metavars this) l
        | RawTRecord(_,l) -> Map.fold (fun s _ v -> s + metavars v) Set.empty l

    /// ### TopEnv
    type TopEnv = {
        nominals_next_tag : int
        nominals_aux : Map<GlobalId, {|name : string; kind : TT|}>
        nominals : Map<GlobalId, {|vars : Var list; body : T|}>
        prototypes_next_tag : int
        prototypes_instances : Map<GlobalId * GlobalId, Constraint Set list>
        prototypes : Map<GlobalId, {|name : string; signature: T; kind : TT|}>
        ty : Map<string,T>
        term : Map<string,T>
        constraints : Map<string,ConstraintOrModule>
        }

    /// ### inferTop_env_empty
    let inferTop_env_empty = {
        nominals_next_tag = 0
        nominals_aux = Map.empty
        nominals = Map.empty
        prototypes_next_tag = 0
        prototypes_instances = Map.empty
        prototypes = Map.empty
        ty = Map.empty
        term = Map.empty
        constraints = Map.empty
        }

    /// ### inferUnion
    let inferUnion small big = {
        nominals_next_tag = max small.nominals_next_tag big.nominals_next_tag
        nominals_aux = Map.foldBack Map.add small.nominals_aux big.nominals_aux
        nominals = Map.foldBack Map.add small.nominals big.nominals
        prototypes_next_tag = max small.prototypes_next_tag big.prototypes_next_tag
        prototypes_instances = Map.foldBack Map.add small.prototypes_instances big.prototypes_instances
        prototypes = Map.foldBack Map.add small.prototypes big.prototypes
        ty =
            Map.foldBack (fun k v s ->
                let v =
                    match v, s |> Map.tryFind k with
                    | TyModule x, Some (TyModule x') -> Map.foldBack Map.add x x' |> TyModule
                    | _ -> v
                s |> Map.add k v
            ) small.ty big.ty
        term =
            Map.foldBack (fun k v s ->
                let v =
                    match v, s |> Map.tryFind k with
                    | TyModule x, Some (TyModule x') -> Map.foldBack Map.add x x' |> TyModule
                    | _ -> v
                s |> Map.add k v
            ) small.term big.term
        constraints =
            Map.foldBack (fun k v s ->
                let v =
                    match v, s |> Map.tryFind k with
                    | M x, Some (M x') -> Map.foldBack Map.add x x' |> M
                    | _ -> v
                s |> Map.add k v
            ) small.constraints big.constraints
        }

    /// ### inferIn_module
    let inferIn_module m a : TopEnv =
        {a with
            ty = Map.add m (TyModule a.ty) Map.empty
            term = Map.add m (TyModule a.term) Map.empty
            constraints = Map.add m (M a.constraints) Map.empty
            }

    /// ### InferEnv
    type InferEnv = { ty : Map<string,T>; term : Map<string,T>; constraints : Map<string,ConstraintOrModule> }

    /// ### kind_get
    let kind_get x =
        let rec loop = function
            | KindFun(a,b) -> a :: loop b
            | a -> [a]
        let l = loop x
        {|arity=List.length l; args=l|}

    /// ### prototype_init_forall_kind
    let prototype_init_forall_kind = function
        | TyForall(a,_) -> a.kind
        | _ -> failwith "Compiler error: The prototype should have at least one forall."

    /// ### show_primt
    let show_primt = function
        | UInt8T -> "u8"
        | UInt16T -> "u16"
        | UInt32T -> "u32"
        | UInt64T -> "u64"
        | Int8T -> "i8"
        | Int16T -> "i16"
        | Int32T -> "i32"
        | Int64T -> "i64"
        | Float32T -> "f32"
        | Float64T -> "f64"
        | BoolT -> "bool"
        | StringT -> "string"
        | CharT -> "char"

    /// ### constraint_name
    let rec constraint_name (env : TopEnv) = function
        | CSInt -> "sint" | CUInt -> "uint" | CInt -> "int"
        | CFloat -> "float" | CNumber -> "number" | CPrim -> "prim"
        | CSymbol -> "symbol" | CRecord -> "record"
        | CPrototype i -> env.prototypes.[i].name

    /// ### constraint_kind
    let constraint_kind (env : TopEnv) = function
        | CSInt | CUInt | CInt | CFloat | CNumber | CPrim | CSymbol | CRecord -> KindType
        | CPrototype i -> env.prototypes.[i].kind

    /// ### tt
    let rec tt (env : TopEnv) = function
        | TyComment(_,x) | TyMetavar(_,{contents=Some x}) -> tt env x
        | TyNominal i -> env.nominals_aux.[i].kind
        | TyApply(_,_,x) | TyMetavar({kind=x},_) | TyVar({kind=x},_) -> x
        | TyExists _ | TyLit _ | TyUnion _ | TyLayout _ | TyMacro _ | TyB | TyPrim _ | TyForall _ | TyFun _ | TyRecord _ | TyModule _ | TyPair _ | TySymbol _ | TyArray _ -> KindType
        | TyInl(v,a) -> KindFun(v.kind,tt env a)

    /// ### has_metavars
    let rec has_metavars x =
        let f = has_metavars
        match visit_t x with
        | TyMetavar _ -> true
        | TyVar _ | TyNominal _ | TyB | TyLit _ | TyPrim _ | TySymbol _ | TyModule _ -> false
        | TyExists(_,a) | TyComment(_,a) | TyLayout(a,_) | TyForall(_,a) | TyInl(_,a) | TyArray a -> f a
        | TyApply(a,b,_) | TyFun(a,b,_) | TyPair(a,b) -> f a || f b
        | TyUnion(l,_) -> Map.exists (fun _ -> snd >> f) l
        | TyRecord l -> Map.exists (fun _ -> f) l
        | TyMacro a -> List.exists (function TMVar x -> has_metavars x | _ -> false) a

    /// ### term_subst
    // Eliminates the metavars in the type if possible.
    let term_subst a =
        let h = System.Collections.Generic.HashSet(HashIdentity.Reference)
        // 'a = 'b = ('c = int * 'd = float)
        // visit_t shortens to:
        // 'a = ('c = int * 'd = float)
        // visit_t returns:
        // ('c = int * 'd = float)
        // term_subst returns:
        // int * float
        let inline g a f =
            let _ = h.Add(a)
            let x = f()
            let _ = h.Remove(a)
            x
        let rec f a =
            match visit_t a with
            | TyMetavar _ | TyNominal _ | TyB | TyLit _ | TyPrim _ | TySymbol _ as x -> x
            | TyVar(x,r) -> TyVar(x, if h.Contains x then ref None else r)
            | TyComment(a,b) -> TyComment(a,f b)
            | TyPair(a,b) -> TyPair(f a, f b)
            | TyRecord a -> TyRecord(Map.map (fun _ -> f) a)
            | TyModule a -> TyModule(Map.map (fun _ -> f) a)
            | TyUnion(a,b) -> TyUnion(Map.map (fun _ (is_gadt, x) -> is_gadt, f x) a,b)
            | TyFun(a,b,t) -> TyFun(f a, f b, t)
            | TyForall(a,b) -> g a <| fun () -> TyForall(a,f b)
            | TyExists(a,b) -> TyExists(a,f b)
            | TyArray a -> TyArray(f a)
            | TyApply(a,b,c) -> TyApply(f a, f b, c)
            | TyInl(a,b) -> g a <| fun () -> TyInl(a,f b)
            | TyMacro a -> TyMacro(List.map (function TMVar x -> TMVar(f x) | x -> x) a)
            | TyLayout(a,b) -> TyLayout(f a,b)
        f a

    /// ### HoverTypes
    type HoverTypes() =
        // This is to allocate less trash for code that doesn't use GADTs. 
        // Unfortunately, we cannot use memoization instead as term_subst is not functionally pure.
        let rec has_substituted_tvars x = 
            let f = has_substituted_tvars
            match x with
            | TyMetavar(_,{contents=Some _}) -> true
            | TyVar (_, {contents=Some x}) | TyComment(_,x) -> f x
            | TyVar _ | TyMetavar _ | TyNominal _ | TyB | TyLit _ | TyPrim _ | TySymbol _ | TyModule _ -> false
            | TyExists(_,a) | TyComment(_,a) | TyLayout(a,_) | TyForall(_,a) | TyInl(_,a) | TyArray a -> f a
            | TyApply(a,b,_) | TyFun(a,b,_) | TyPair(a,b) -> f a || f b
            | TyUnion(l,_) -> Map.exists (fun _ -> snd >> f) l
            | TyRecord l -> Map.exists (fun _ -> f) l
            | TyMacro a -> List.exists (function TMVar x -> has_metavars x | _ -> false) a
        let hover_types = ResizeArray()
        member _.AddHover((r : VSCRange),(x,(com : string))) = hover_types.Add(r,((if has_substituted_tvars x then term_subst x else x), com))
        member _.ToArray() = hover_types.ToArray()

    /// ### inferModule_open
    let inferModule_open (hover_types : HoverTypes option) (top_env : InferEnv) (local_env_ty : Map<string,T>) (r : VSCRange) b l =
        let tryFind env x =
            match Map.tryFind x env.term, Map.tryFind x env.ty, Map.tryFind x env.constraints with
            | Some (TyModule a), Some (TyModule b), Some (M c) -> ValueSome {term=a; ty=b; constraints=c}
            | _ -> ValueNone
        match tryFind top_env b with
        | ValueNone -> Error(r, UnboundModule)
        | ValueSome env ->
            hover_types |> Option.iter (fun hover_types -> hover_types.AddHover(r,(TyModule env.term,"")))
            let rec loop env = function
                | (r,x) :: x' ->
                    match tryFind env x with
                    | ValueSome env ->
                        hover_types |> Option.iter (fun hover_types -> hover_types.AddHover(r,(TyModule env.term,"")))
                        loop env x'
                    | _ -> Error(r, ModuleIndexFailedInOpen)
                | [] -> Ok env
            loop env l |> Result.bind (fun env ->
                let h = ResizeArray()
                local_env_ty |> Map.iter (fun k _ -> if env.ty.ContainsKey k then h.Add k)
                if h.Count > 0 then Error(r, ModuleIndexWouldShadowLocalVars(h.ToArray()))
                else Ok env
                )

    /// ### validate_bound_vars
    let validate_bound_vars (top_env : InferEnv) constraints term ty x =
        let errors = ResizeArray()
        let check_term term (a,b) = if Set.contains b term = false && Map.containsKey b top_env.term = false then errors.Add(a,UnboundVariable b)
        let check_ty ty (a,b) = if Set.contains b ty = false && Map.containsKey b top_env.ty = false then errors.Add(a,UnboundVariable b)
        let check_cons constraints (a,b) =
            match Map.tryFind b constraints |> Option.orElseWith (fun () -> Map.tryFind b top_env.constraints) with
            | Some (C _) -> ()
            | Some (M _) -> errors.Add(a,ExpectedConstraintInsteadOfModule)
            | None -> errors.Add(a,UnboundVariable b)
        let rec cterm constraints (term, ty) x =
            match x with
            | RawSymbol _ | RawDefaultLit _ | RawLit _ | RawB _ -> ()
            | RawV(a,b,_) -> check_term term (a,b)
            | RawType(_,x) -> ctype constraints term ty x
            | RawMatch(_,body,l) -> cterm constraints (term, ty) body; List.iter (fun (a,b) -> cterm constraints (cpattern constraints term ty a) b) l
            | RawFun(_,l) -> List.iter (fun (a,b) -> cterm constraints (cpattern constraints term ty a) b) l
            | RawForall(_,((_,(a,_)),l),b) -> List.iter (check_cons constraints) l; cterm constraints (term, Set.add a ty) b
            | RawFilledForall _ -> failwith "Compiler error: Should not appear during variable validation."
            | RawRecBlock(_,l,on_succ) ->
                let term = List.fold (fun s ((_,x),_) -> Set.add x s) term l
                List.iter (fun (_,x) -> cterm constraints (term, ty) x) l
                cterm constraints (term, ty) on_succ
            | RawRecordWith(_,a,b,c) ->
                List.iter (cterm constraints (term, ty)) a
                List.iter (function
                    | RawRecordWithSymbol(_,e) | RawRecordWithSymbolModify(_,e) -> cterm constraints (term, ty) e
                    | RawRecordWithInjectVar(v,e) | RawRecordWithInjectVarModify(v,e) -> check_term term v; cterm constraints (term, ty) e
                    ) b
                List.iter (function RawRecordWithoutSymbol _ -> () | RawRecordWithoutInjectVar (a,b) -> check_term term (a,b)) c
            | RawOp(_,_,l) -> List.iter (cterm constraints (term, ty)) l
            | RawReal(_,x) | RawJoinPoint(_,_,x,_) -> cterm constraints (term, ty) x
            | RawExists(_,(_,a),b) -> Option.iter (List.iter (ctype constraints term ty)) a; cterm constraints (term, ty) b
            | RawAnnot(_,RawMacro(_,a),b) -> cmacro constraints term ty a; ctype constraints term ty b
            | RawMacro(r,a) -> errors.Add(r,MacroIsMissingAnnotation); cmacro constraints term ty a
            | RawAnnot(_,RawArray(_,a),b) -> List.iter (cterm constraints (term, ty)) a; ctype constraints term ty b
            | RawArray(r,a) -> errors.Add(r,ArrayIsMissingAnnotation); List.iter (cterm constraints (term, ty)) a
            | RawAnnot(_,a,b) -> cterm constraints (term, ty) a; ctype constraints term ty b
            | RawTypecase(_,a,b) ->
                ctype constraints term ty a
                List.iter (fun (a,b) ->
                    ctype constraints term ty a
                    cterm constraints (term, ty + metavars a) b
                    ) b
            | RawOpen(_,(a,b),l,on_succ) ->
                match inferModule_open None top_env Map.empty a b l with
                | Ok x ->
                    let combine e m = Map.fold (fun s k _ -> Set.add k s) e m
                    cterm (Map.foldBack Map.add x.constraints constraints) (combine term x.term, combine ty x.ty) on_succ
                | Error e -> errors.Add(e)
            | RawHeapMutableSet(_,a,b,c) -> cterm constraints (term, ty) a; List.iter (cterm constraints (term, ty)) b; cterm constraints (term, ty) c
            | RawSeq(_,a,b) | RawPair(_,a,b) | RawIfThen(_,a,b) | RawApply(_,a,b) -> cterm constraints (term, ty) a; cterm constraints (term, ty) b
            | RawIfThenElse(_,a,b,c) -> cterm constraints (term, ty) a; cterm constraints (term, ty) b; cterm constraints (term, ty) c
            | RawMissingBody r -> errors.Add(r,MissingBody)
        and cmacro constraints term ty a =
            List.iter (function
                | RawMacroText _ -> ()
                | RawMacroTerm(r,a,_) -> cterm constraints (term, ty) a
                | RawMacroType(r,a) | RawMacroTypeLit(r,a) -> ctype constraints term ty a
                ) a
        and ctype constraints term ty x =
            match x with
            | RawTFilledNominal(_,_) | RawTPrim _ | RawTWildcard _ | RawTLit _ | RawTB _ | RawTSymbol _ | RawTMetaVar _ -> ()
            | RawTTypecase(_,a,b) -> 
                ctype constraints term ty a
                List.iter (fun (a,b) -> 
                    ctype constraints term ty a
                    ctype constraints term (ty + metavars a) b
                    ) b
            | RawTVar(a,b) -> check_ty ty (a,b)
            | RawTArray(_,a) | RawTLayout(_,a,_) -> ctype constraints term ty a
            | RawTPair(_,a,b) | RawTApply(_,a,b) | RawTFun(_,a,b,_) -> ctype constraints term ty a; ctype constraints term ty b
            | RawTUnion(_,l,_,this) -> Map.iter (fun _ (_,x) -> ctype constraints term ty x) l; ctype constraints term ty this
            | RawTRecord(_,l) -> Map.iter (fun _ -> ctype constraints term ty) l
            | RawTForall(_,((_,(a,_)),l),b) -> List.iter (check_cons constraints) l; ctype constraints term (Set.add a ty) b
            | RawTExists(_,a,b) -> 
                let ty =
                    List.fold (fun ty ((_,(a,_)),l) ->
                        List.iter (check_cons constraints) l
                        Set.add a ty
                        ) ty a
                ctype constraints term ty b
            | RawTTerm (_,a) -> cterm constraints (term, ty) a
            | RawTMacro(_,a) -> cmacro constraints term ty a
        and cpattern constraints term ty x =
            //let is_first = System.Collections.Generic.HashSet()
            let rec loop (term, ty) x = 
                let f = loop (term, ty)
                match x with
                | PatDefaultValue _ | PatFilledDefaultValue _ | PatValue _ | PatSymbol _ | PatB _ | PatE _ -> term, ty
                | PatExists(_,a,b) ->
                    let ty = List.fold (fun s (_,x) -> Set.add x s) ty a
                    loop (term, ty) b
                | PatVar(_,b) ->
                    //if is_first.Add b then () // TODO: I am doing it like this so I can reuse this code later for variable highlighting.
                    Set.add b term, ty
                | PatDyn(_,x) | PatUnbox(_,_,x) -> f x
                | PatPair(_,a,b) -> loop (f a) b
                | PatRecordMembers(_,l) ->
                    List.fold (fun s -> function
                        | PatRecordMembersSymbol(_,x) -> loop s x
                        | PatRecordMembersInjectVar((a,b),x) -> check_term term (a,b); loop s x
                        ) (term, ty) l
                | PatAnd(_,a,b) | PatOr(_,a,b) -> loop (loop (term, ty) a) b
                | PatAnnot(_,a,b) -> ctype constraints term ty b; f a
                | PatWhen(_,a,b) -> let r = f a in cterm constraints r b; r
                | PatNominal(_,(r,a),_,b) -> check_ty ty (r,a); f b
                | PatArray(_,a) -> List.fold loop (term, ty) a
            loop (term, ty) x

        match x with
        | Choice1Of2 x -> cterm constraints (term, ty) x
        | Choice2Of2 x -> ctype constraints term ty x
        errors

    /// ### assert_bound_vars
    let assert_bound_vars (top_env : InferEnv) constraints term ty x =
        let errors = validate_bound_vars top_env constraints term ty x
        if 0 < errors.Count then raise (InferTypeErrorException (Seq.toList errors))

    /// ### subst
    let rec subst (m : (Var * T) list) x =
        let f = subst m
        if List.isEmpty m then x 
        else 
            match x with
            | TyComment(_,x)
            | TyMetavar(_,{contents=Some x}) 
            | TyVar (_,{contents=Some x}) -> f x // Don't do path shortening here.
            | TyMetavar _ | TyNominal _ | TyB | TyLit _ | TyPrim _ | TySymbol _ -> x
            | TyPair(a,b) -> TyPair(f a, f b)
            | TyRecord a -> TyRecord(Map.map (fun _ -> f) a)
            | TyModule a -> TyModule(Map.map (fun _ -> f) a)
            | TyUnion(a,b) -> TyUnion(Map.map (fun _ (is_gadt,body) -> is_gadt, f body) a,b)
            | TyFun(a,b,t) -> TyFun(f a, f b, t)
            | TyArray a -> TyArray(f a)
            | TyApply(a,b,c) -> TyApply(f a, f b, c)
            | TyVar (a,_) -> List.tryPick (fun (v,x) -> if a = v then Some x else None) m |> Option.defaultValue x
            | TyForall(a,b) -> TyForall(a, f b)
            | TyExists(a,b) -> TyExists(a, f b)
            | TyInl(a,b) -> TyInl(a, f b)
            | TyMacro a -> TyMacro(List.map (function TMVar x -> TMVar(f x) | x -> x) a)
            | TyLayout(a,b) -> TyLayout(f a,b)

    /// ### type_apply_split
    let type_apply_split x =
        let rec loop s x =
            match visit_t x with
            | TyApply(a,b,_) -> loop (b :: s) a
            | x -> x, s
        loop [] x

    /// ### kind_subst
    let rec kind_subst = function
        | KindMetavar ({contents'=Some x} & link) -> shorten' x link kind_subst
        | KindMetavar _ | KindType as x -> x
        | KindFun(a,b) -> KindFun(kind_subst a,kind_subst b)

    /// ### foralls_get
    let rec foralls_get = function
        | RawForall(_,a,b) -> let a', b = foralls_get b in a :: a', b
        | b -> [], b

    /// ### foralls_ty_get
    let rec foralls_ty_get = function
        | TyForall(a,b) -> let a', b = foralls_ty_get b in a :: a', b
        | b -> [], b

    /// ### kind_force
    let rec kind_force = function
        | KindMetavar ({contents'=Some x} & link) -> shorten' x link kind_force
        | KindMetavar link -> let x = KindType in link.contents' <- Some x; x
        | KindType as x -> x
        | KindFun(a,b) -> KindFun(kind_force a,kind_force b)

    /// ### p
    let p prec prec' x = if prec < prec' then x else sprintf "(%s)" x

    /// ### show_kind
    let show_kind x =
        let rec f prec x =
            let p = p prec
            match x with
            | KindMetavar {contents'=Some x} -> f prec x
            | KindMetavar _ -> "?"
            | KindType -> "*"
            | KindFun(a,b) -> p 20 (sprintf "%s -> %s" (f 20 a) (f 19 b))
        f -1 x

    /// ### show_constraints
    let show_constraints env x = Set.toList x |> List.map (constraint_name env) |> String.concat "; " |> sprintf "{%s}"

    /// ### show_nominal
    let show_nominal (env : TopEnv) i = match Map.tryFind i env.nominals_aux with Some x -> x.name | None -> "?"

    /// ### show_layout_type
    let show_layout_type = function Heap -> "heap" | HeapMutable -> "mut" | StackMutable -> "stack_mut"

    /// ### show_t
    let show_t (env : TopEnv) x =
        let show_var (a : Var) =
            let n = match a.kind with KindType -> a.name | _ -> sprintf "(%s : %s)" a.name (show_kind a.kind)
            if Set.isEmpty a.constraints then n
            else sprintf "%s %s" n (show_constraints env a.constraints)
        let rec f prec x =
            let p = p prec
            match x with
            | TyVar (_, {contents=Some x}) | TyComment(_,x) | TyMetavar(_,{contents=Some x}) -> f prec x
            | TyMetavar _ -> "_"
            | TyVar (a, _) -> a.name
            | TyNominal i ->
                match Map.tryFind i env.nominals_aux with
                | Some x when prec < 0 -> sprintf "(%s : %s)" x.name (show_kind x.kind)
                | Some x -> x.name
                | _ -> "?"
            | TyB -> "()"
            | TyLit x -> Tokenize.show_lit x
            | TyPrim x -> show_primt x
            | TySymbol x -> sprintf ".%s" x
            | TyExists(a,b) -> 
                let a = List.map show_var a |> String.concat " "
                p 0 (sprintf "exists %s. %s" a (f -1 b))
            | TyForall _ ->
                let a, b =
                    let rec loop = function
                        | TyForall(a,b) -> let a',b = loop b in (a :: a'), b
                        | b -> [], b
                    loop x
                let a = List.map show_var a |> String.concat " "
                p 0 (sprintf "forall %s. %s" a (f -1 b))
            | TyInl _ ->
                let a, b =
                    let rec loop = function
                        | TyInl(a,b) -> let a',b = loop b in (a :: a'), b
                        | b -> [], b
                    loop x
                let a = List.map show_var a |> String.concat " "
                p 0 (sprintf "%s => %s" a (f -1 b))
            | TyArray a -> p 30 (sprintf "array_base %s" (f 30 a))
            | TyApply(a,b,_) -> p 30 (sprintf "%s %s" (f 29 a) (f 30 b))
            | TyPair(a,b) -> p 25 (sprintf "%s * %s" (f 25 a) (f 24 b))
            | TyFun(a,b,FT_Vanilla) -> p 20 (sprintf "%s -> %s" (f 20 a) (f 19 b))
            | TyFun(a,b,FT_Pointer) -> p 20 (sprintf "fptr (%s -> %s)" (f 20 a) (f 19 b))
            | TyFun(a,b,FT_Closure) -> p 20 (sprintf "closure (%s -> %s)" (f 20 a) (f 19 b))
            | TyModule l ->
                if prec = -2 then
                    l |> Map.toList |> List.map (fun (k,v) ->
                        let a,b = k, f -1 v
                        match v with
                        | TyComment(com,_) -> sprintf "%s : %s\n---\n%s\n---\n" a b com
                        | _ -> sprintf "%s : %s" a b
                        )
                    |> String.concat "\n"
                else "module"
            | TyRecord l -> sprintf "{%s}" (l |> Map.toList |> List.map (fun ((_,k),v) -> sprintf "%s : %s" k (f -1 v)) |> String.concat "; ")
            | TyUnion(l,_) -> sprintf "{%s}" (l |> Map.toList |> List.map (fun ((_,k),(_,v)) -> sprintf "%s : %s" k (f -1 v)) |> String.concat "| ")
            | TyMacro a -> p 30 (List.map (function TMLitVar a | TMVar a -> f -1 a | TMText a -> a) a |> String.concat "")
            | TyLayout(a,b) -> p 30 (sprintf "%s %s" (show_layout_type b) (f 30 a))

        f -2 x

    /// ### show_type_error
    let show_type_error (env : TopEnv) x =
        let f = show_t env
        match x with
        | IncorrectRecursiveNominal -> "The non-recursive nominals should not use their own type in the clause."
        | IncorrectGADTConstructorType -> "The GADT case in the union has to result in an instance of the union being constructed. Any type other than the self being in the range of the union is not allowed."
        | ExistsShouldntHaveMetavars a -> sprintf "The variables of the exists body shouldn't have metavariables left over in them.\nGot: [%s]"  (List.map f a |> String.concat ", ")
        | ExpectedExistentialInPattern a -> sprintf "The variable being destructured in the pattern match need to be explicitly annotated and with an existential type.\nGot: %s" (f a)
        | UnexpectedNumberOfArgumentsInExistsPattern(got,exp) -> sprintf "The number of arguments in the existential pattern doesn't match the one in the type.\nGot: %i\nExpected: %i" got exp
        | UnexpectedNumberOfArgumentsInExistsBody(got,exp) -> sprintf "The number of arguments in the existential body doesn't match the one in the type.\nGot: %i\nExpected: %i" got exp
        | ExpectedExistentialInTerm a -> sprintf "The body of `expects` need to be explicitly annotated and with an existential type.\nGot: %s" (f a)
        | UnionsCannotBeApplied -> "Unions cannot be applied."
        | ExpectedNominalInApply a -> sprintf "Expected a nominal.\nGot: %s" (f a)
        | MalformedNominal -> "Malformed nominal."
        | ModuleMustBeImmediatelyApplied -> "Module must be immediately applied."
        | ExpectedSymbol' a -> sprintf "Expected a symbol.\nGot: %s" (f a)
        | KindError(a,b) -> sprintf "Kind unification failure.\nGot:      %s\nExpected: %s" (show_kind a) (show_kind b)
        | KindErrorInConstraint(a,b) -> sprintf "Kind unification failure when propagating them from constraints.\nGot:      %s\nExpected: %s" (show_kind a) (show_kind b)
        | TermError(a,b) -> sprintf "Unification failure.\nGot:      %s\nExpected: %s" (f a) (f b)
        | RecursiveMetavarsNotAllowed(a,b) -> sprintf "Recursive metavariables are not allowed. A metavar cannot be unified with a type that has itself.\nGot:      %s\nExpected: %s" (f a) (f b)
        | RecursiveTypevarsNotAllowed(a,b) -> sprintf "Recursive type variables are not allowed. A type variable cannot be unified with a type that has itself.\nGot:      %s\nExpected: %s" (f a) (f b)
        | ExpectedSymbolAsRecordKey a -> sprintf "Expected symbol as a record key.\nGot: %s" (f a)
        | ExpectedSymbolAsModuleKey a -> sprintf "Expected symbol as a module key.\nGot: %s" (f a)
        | UnboundVariable x -> sprintf "Unbound variable: %s." x
        | UnboundModule -> sprintf "Unbound module."
        | ModuleIndexFailedInOpen -> sprintf "Module does not have a submodule with that key."
        | ModuleIndexWouldShadowLocalVars [|v|] -> $"The module open would shadow a local variable: {v}."
        | ModuleIndexWouldShadowLocalVars vars -> let v = String.concat ", " vars in $"The module open would shadow the local variables: {v}."
        | TypeVarScopeError(a,_,_) -> sprintf "Tried to unify the type variable %s with a metavar outside its scope." a
        | ForallVarConstraintError(n,a,b) -> sprintf "Metavariable's constraints must be a subset of the forall var %s's.\nGot: %s\nExpected: %s" n (show_constraints env a) (show_constraints env b)
        | MetavarsNotAllowedInRecordWith -> sprintf "In the top-down segment the record keys need to be fully known. Please add an annotation."
        | LayoutSetMustBeAnnotated -> sprintf "The layout type being set must be annotated."
        | ExpectedMutableLayout a -> sprintf "Expected a mutable layout type.\nGot: %s" (f a)
        | ExpectedRecord a -> sprintf "Expected a record.\nGot: %s" (f a)
        | ExpectedRecordInsideALayout a -> sprintf "Expected a record inside a layout type.\nGot: %s" (f a)
        | ExpectedRecordAsResultOfIndex a -> sprintf "Expected a record as result of index.\nGot: %s" (f a)
        | RecordIndexFailed a -> sprintf "The record does not have the key: %s" a
        | ModuleIndexFailed a -> sprintf "The module does not have the key: %s" a
        | ExpectedModule a -> sprintf "Expected a module.\nGot: %s" (f a)
        | ExpectedSymbolInRecordWith a -> sprintf "Expected a symbol.\nGot: %s" (f a)
        | RealFunctionInTopDown -> sprintf "Real segment functions are forbidden in the top-down segment. They can only be used in `real` expressions or .spir modules."
        | MissingRecordFieldsInPattern(a,b) -> sprintf "The record is missing the following fields: %s.\nGot: %s" (String.concat ", " b) (f a)
        | CasePatternNotFoundForType(i,n) -> sprintf "%s does not have the %s case." (show_nominal env i) n
        | CasePatternNotFound n -> sprintf "Cannot find a function with the same name as the %s case in the environment." n
        | CannotInferCasePatternFromTermInEnv a -> sprintf "Cannot infer the higher order type that has this case from the following type.\nGot: %s" (f a)
        | NominalInPatternUnbox i -> sprintf "Expected an union type, but %s is a nominal." (show_nominal env i)
        | TypeInEnvIsNotNominal a -> sprintf "Expected a nominal type.\nGot: %s" (f a)
        | UnionInPatternNominal i -> sprintf "Expected a nominal type, but %s is an union." (show_nominal env i)
        | ConstraintError(a,b) -> sprintf "Constraint satisfaction error.\nGot: %s\nFails to satisfy: %s" (f b) (constraint_name env a)
        | ExpectedAnnotation -> sprintf "Recursive functions with foralls must be fully annotated."
        | ExpectedSinglePattern -> sprintf "Recursive functions with foralls must not have multiple clauses in their patterns."
        | RecursiveAnnotationHasMetavars a -> sprintf "Recursive functions with foralls must not have metavars.\nGot: %s" (f a)
        | ValueRestriction a -> sprintf "Metavars that are not part of the enclosing function's signature are not allowed. They need to be values.\nGot: %s" (f a)
        | DuplicateRecInlName -> "Shadowing of functions by the members of the same mutually recursive block is not allowed."
        | DuplicateKeyInRecUnion -> "Mutually recursive unions should not have overlapping keys."
        | ExpectedConstraintInsteadOfModule -> sprintf "Expected a constraint instead of module."
        | InstanceNotFound(prot,ins) -> sprintf "The higher order type instance %s does not have the prototype %s." (show_nominal env ins) env.prototypes.[prot].name
        | ExpectedPrototypeConstraint a -> sprintf "Expected a prototype constraint.\nGot: %s" (constraint_name env a)
        | PrototypeConstraintCannotPropagateToMetavar(a,b) -> sprintf "Cannot propagate the %s prototype constraint to the applied metavariable as the kinds would not match. If this is not intended to be a type var, provide a type annotation to a concrete type.\nGot: %s" env.prototypes.[a].name (f b)
        | PrototypeConstraintCannotPropagateToVar(a,b) -> sprintf "Cannot propagate the %s prototype constraint to the applied type variable as the kinds would not match.\nGot: %s" env.prototypes.[a].name (f b)
        | ExpectedPrototypeInsteadOfModule -> "Expected a prototype instead of module."
        | ExpectedHigherOrder a -> sprintf "Expected a higher order type.\nGot: %s" (f a)
        | InstanceArityError(prot,ins) -> sprintf "The arity of the instance must be greater or equal to that of the prototype.\nInstance arity:  %i\nPrototype arity: %i" ins prot
        | InstanceCoreVarsShouldMatchTheArityDifference(num_vars,expected) -> sprintf "The number of forall variables in the instance needs to be specified so it equals the difference between the instance arity and the prototype arity.\nInstance variables specified: %i\nExpected:                     %i" num_vars expected
        | InstanceKindError(a,b) -> sprintf "The kinds of the instance foralls are incompatible with those of the prototype.\nGot:      %s\nExpected: %s" (show_kind a) (show_kind b)
        | KindNotAllowedInInstanceForall -> "Kinds should not be explicitly stated in instance foralls."
        | InstanceVarShouldNotMatchAnyOfPrototypes -> "Instance forall must not have the same name as any of the prototype foralls."
        | MissingBody -> "The function body is missing."
        | MacroIsMissingAnnotation -> "The macro needs an annotation."
        | ArrayIsMissingAnnotation -> "The array needs an annotation."
        | ExistsIsMissingAnnotation -> "The existential type needs an annotation."
        | ShadowedForall -> "Shadowing of foralls is not allowed in the top-down segment."
        | ShadowedExists -> "Shadowing of existential type variables is not allowed in the top-down segment."
        | UnionTypesMustHaveTheSameLayout -> "The two union types must have the same layout."
        | OrphanInstance -> "The instance has to be defined in the same package as either the prototype or the nominal."
        | ShadowedInstance -> "The instance cannot be defined twice."
        | UnusedTypeVariable [x] -> sprintf "The type variable %s is unused in the function's type signature." x
        | UnusedTypeVariable vars -> sprintf "The type variables %s are unused in the function's type signature." (vars |> String.concat ", ")
        | CompilerError x -> x

    /// ### loc_env
    let loc_env (x : TopEnv) = {term=x.term; ty=x.ty; constraints=x.constraints}

    /// ### names_of
    let names_of vars = List.map (fun x -> x.name) vars |> Set

    /// ### lit
    let lit = function
        | LitUInt8 _ -> TyPrim UInt8T
        | LitUInt16 _ -> TyPrim UInt16T
        | LitUInt32 _ -> TyPrim UInt32T
        | LitUInt64 _ -> TyPrim UInt64T
        | LitInt8 _ -> TyPrim Int8T
        | LitInt16 _ -> TyPrim Int16T
        | LitInt32 _ -> TyPrim Int32T
        | LitInt64 _ -> TyPrim Int64T
        | LitFloat32 _ -> TyPrim Float32T
        | LitFloat64 _ -> TyPrim Float64T
        | LitBool _ -> TyPrim BoolT
        | LitString _ -> TyPrim StringT
        | LitChar _ -> TyPrim CharT

    /// ### autogen_name_in_fun
    let autogen_name_in_fun (i : int) = let x = char i + 'a' in if 'z' < x then sprintf "'%i" i else sprintf "'%c" x

    /// ### autogen_name_in_typecase
    let autogen_name_in_typecase (i : int) = let x = char i + 'a' in if 'z' < x then sprintf "'t%i" i else sprintf "'t%c" x

    /// ### trim_kind
    let trim_kind = function KindFun(_,k) -> k | _ -> failwith "impossible"

    /// ### FilledTop
    // Similar to BundleTop except with type annotations and type application filled in.
    type FilledTop =
        | FType of VSCRange * RString * HoVar list * RawTExpr
        | FNominal of VSCRange * RString * HoVar list * RawTExpr
        | FNominalRec of (VSCRange * RString * HoVar list * RawTExpr) list
        | FInl of VSCRange * RString * RawExpr
        | FRecInl of (VSCRange * RString * RawExpr) list
        | FPrototype of VSCRange * RString * RString * TypeVar list * RawTExpr
        | FInstance of VSCRange * RGlobalId * RGlobalId * RawExpr
        | FOpen of VSCRange * RString * RString list

    /// ### 'a AdditionType
    type 'a AdditionType =
        | AOpen of 'a
        | AInclude of 'a

    /// ### InferScope
    type InferScope = int

    /// ### InferResult
    type [<ReferenceEquality>] InferResult = {
        filled_top : FilledTop Hopac.Promise
        top_env_additions : TopEnv AdditionType
        offset : int
        hovers : RString []
        errors : RString list
        }

    /// ### dispose_gadt_links
    let dispose_gadt_links gadt_links = Seq.iter (fun (x : ref<option<'a>>) -> x.Value <- None) gadt_links

    /// ### assert_foralls_used'
    let assert_foralls_used' (errors : (VSCRange * TypeError) ResizeArray) outside_foralls r x =
        let h = HashSet()
        let rec f x =
            match visit_t x with
            | TyVar (v,_) -> Set.singleton v.name
            | TyExists(v,a) ->
                List.fold (fun a v -> 
                    if Set.contains v.name a = false then h.Add(v.name) |> ignore; a
                    else Set.remove v.name a
                    ) (f a) v
            | TyForall(v,a) ->
                let a = f a
                if Set.contains v.name a = false then h.Add(v.name) |> ignore; a
                else Set.remove v.name a
            | TyUnion _ | TyModule _ | TyMetavar _ | TyNominal _ | TyB | TyLit _ | TyPrim _ | TySymbol _ -> Set.empty
            | TyPair(a,b) | TyApply(a,b,_) | TyFun(a,b,_) -> f a + f b
            | TyRecord a -> Map.fold (fun s _ x -> Set.union s (f x)) Set.empty a
            | TyComment(_,a) | TyLayout(a,_) | TyInl(_,a) | TyArray a -> f a
            | TyMacro a -> 
                List.fold (fun s x ->
                    match x with
                    | TMLitVar a | TMVar a -> f a 
                    | TMText _ -> Set.empty
                    ) Set.empty a
        let used_vars = f x
        Seq.iter (h.Add >> ignore) (outside_foralls - used_vars)
        if 0 < h.Count then
            errors.Add(r, UnusedTypeVariable (Seq.toList h))

    /// ### assert_foralls_used
    let assert_foralls_used errors r x = assert_foralls_used' errors Set.empty r x

    /// ### validate_nominal
    let validate_nominal (errors : _ ResizeArray) global_id body v =
        // Stack union types and regular nominals must not be recursive.
        // Unlike in the previous version of Spiral which simply didn't put the nominal type in the environment
        // this one has to do it becaus the GADT constructors need access to it.
        let rec assert_nominal_non_recursive v =
            let f = assert_nominal_non_recursive
            match visit_t v with
            | TyNominal global_id' -> if global_id = global_id' then errors.Add(range_of_texpr_gadt_body body, IncorrectRecursiveNominal)
            | TyMetavar _ | TyVar _ | TyModule _ | TyUnion _ | TyB | TyLit _ | TyPrim _ | TySymbol _ -> ()
            | TyPair(a,b) | TyApply(a,b,_) | TyFun(a,b,_) -> f a; f b
            | TyRecord a -> Map.iter (fun _ -> f) a
            | TyExists(_,a) | TyComment(_,a) | TyLayout(a,_) | TyForall(_,a) | TyInl(_,a) | TyArray a -> f a
            | TyMacro a -> List.iter (function TMLitVar a | TMVar a -> f a | TMText _ -> ()) a
        match v with // Validates the union type.
        | TyUnion(a,b) ->
            a |> Map.iter (fun name (is_gadt, v) -> 
                let body =
                    match body with
                    | RawTUnion(_,a,_,_) -> Map.find name a |> snd
                    | _ -> failwith "Compiler error: Expected an union."
                let is_stack = b = UStack

                // Makes sure that the GADT constructor is resulting in its own type.
                // Also make sure that it's not using an instance of itself in its constructor other than in first position.
                let rec assert_gadt_has_proper_specialized_constructor = function
                    | TyNominal global_id' -> if global_id <> global_id' then errors.Add(range_of_texpr_gadt_constructor body, IncorrectGADTConstructorType)
                    | TyApply(a,b,_) -> 
                        assert_gadt_has_proper_specialized_constructor a
                        if is_stack then assert_nominal_non_recursive b
                    | _ -> errors.Add(range_of_texpr_gadt_constructor body, IncorrectGADTConstructorType)

                let assert_gadt_is_valid v =
                    let rec find_gadt_constructor outside_foralls = function
                        | TyForall(n,t) -> find_gadt_constructor (Set.add n.name outside_foralls) t
                        | TyFun(a,b,_) -> 
                            if is_stack then assert_nominal_non_recursive a
                            assert_gadt_has_proper_specialized_constructor b
                            assert_foralls_used errors (range_of_texpr_gadt_body body) a
                            assert_foralls_used' errors outside_foralls (range_of_texpr_gadt_constructor body) b
                        | b ->
                            assert_gadt_has_proper_specialized_constructor b
                            assert_foralls_used' errors outside_foralls (range_of_texpr_gadt_constructor body) b

                    find_gadt_constructor Set.empty v

                if is_gadt then assert_gadt_is_valid v
                else
                    if is_stack then assert_nominal_non_recursive v
                    assert_foralls_used errors (range_of_texpr body) v // We need to assert that the foralls in regular union bodies are checked.
                )
        | _ ->
            assert_nominal_non_recursive v

    /// ### kind_to_rawkind
    let rec kind_to_rawkind (x : TT) : RawKindExpr =
        match visit_tt x with
        | KindMetavar _ | KindType -> RawKindStar
        | KindFun(a,b) -> RawKindFun(kind_to_rawkind a, kind_to_rawkind b)

    /// ### var_to_hovar
    let var_to_hovar r (x : Var) : HoVar = r,(x.name,kind_to_rawkind x.kind)

    /// ### var_to_typevar
    let var_to_typevar r (x : Var) : TypeVar = var_to_hovar r x, [] // In the bottom up segment the constrains aren't checked anywhere so we'll put an empty list here.

    /// ### infer
    let infer package_id module_id (top_env' : TopEnv) expr =
        let at_tag i = {package_id=package_id; module_id=module_id; tag=i}
        let mutable top_env = top_env' // Is mutated only in two places at the top level. During actual inference can otherwise be thought of as immutable.
        let errors = ResizeArray()
        let generalized_statements = Dictionary(HashIdentity.Reference)
        let type_apply_args = Dictionary(HashIdentity.Reference)
        let module_type_apply_args = Dictionary(HashIdentity.Reference)
        let annotations = Dictionary<obj,_>(HashIdentity.Reference)
        let exists_vars = Dictionary<obj,_>(HashIdentity.Reference)
        let gadt_typecases = Dictionary<obj,_>(HashIdentity.Reference)
        let mutable autogened_forallvar_count_in_typecase = 0
        let mutable autogened_forallvar_count_in_funs = 0
        let hover_types = HoverTypes()

        /// Fills in the type applies and annotations, and generalizes statements. Also strips annotations from terms and patterns.
        /// Dealing with recursive statement type applies requires some special consideration.
        let fill r rec_term expr =
            assert (0 = errors.Count)
            let t_to_rawtexpr r vars_to_metavars expr =
                let rec f x =
                    match visit_t x with
                    | TyUnion _ | TyMetavar _  | TyInl _  | TyModule _ as x -> failwithf "Compiler error: These cases should not appear in fill.\nGot: %A" x
                    | TyForall(a,b) -> RawTForall(r,var_to_typevar r a,f b)
                    | TyComment(_,x) -> f x
                    | TyB -> RawTB r
                    | TyLit x -> RawTLit(r,x)
                    | TyPrim x -> RawTPrim(r,x)
                    | TySymbol x -> RawTSymbol(r,x)
                    | TyPair(a,b) -> RawTPair(r,f a,f b)
                    | TyRecord l -> RawTRecord(r,Map.map (fun _ -> f) l)
                    | TyFun(a,b,t) -> RawTFun(r,f a,f b,t)
                    | TyExists(a,b) -> RawTExists(r,a |> List.map (fun n -> (r,(n.name,RawKindWildcard)),[]), f b)
                    | TyArray a -> RawTArray(r,f a)
                    | TyNominal i -> RawTFilledNominal(r,i)
                    | TyApply(a,b,_) -> RawTApply(r,f a,f b)
                    | TyVar (a,_) -> 
                        let is_typecase_metavar = List.tryFind (function TyVar(b,_) -> a = b | _ -> failwith "Compiler error: Expected a TyVar.") vars_to_metavars |> Option.isSome
                        if is_typecase_metavar then RawTMetaVar(r,a.name) else RawTVar(r,a.name)
                    | TyMacro l -> l |> List.map (function TMText x -> RawMacroText(r,x) | TMVar x -> RawMacroType(r,f x) | TMLitVar x -> RawMacroTypeLit(r,f x)) |> fun l -> RawTMacro(r,l)
                    | TyLayout(a,b) -> RawTLayout(r,f a,b)
                f expr
            let annot r x = t_to_rawtexpr r [] (snd annotations.[x])
            let rec fill_typecases rec_term x =
                match gadt_typecases.TryGetValue(x) with
                | true, typecase_data ->
                    Seq.foldBack (fun (typecase_cond,forall_vars,typecase_constructor) typecase_body ->
                        let r = range_of_expr typecase_body
                        RawTypecase(r, t_to_rawtexpr r [] typecase_cond, [t_to_rawtexpr r forall_vars typecase_constructor, typecase_body])
                        ) typecase_data (term rec_term x)
                | _ ->
                    term rec_term x
            and fill_foralls r rec_term body = 
                let _,body = foralls_get body
                let l,_ = foralls_ty_get generalized_statements.[body]
                List.foldBack (fun (x : Var) s -> RawFilledForall(r,x.name,s)) l (term rec_term body)
            and term rec_term x =
                let f = term rec_term
                let clauses l = 
                    List.map (fun (a, b) -> 
                        let rec_term,a = pattern rec_term a 
                        a,fill_typecases rec_term b
                        ) l
                match x with
                | RawFilledForall _ | RawMissingBody _ | RawType _ as x -> failwithf "Compiler error: These cases should not appear in fill. It is intended to be called on top level statements only.\nGot: %A" x
                | RawTypecase _
                | RawSymbol _ | RawB _ | RawLit _ | RawOp _ -> x
                | RawReal(_,x) -> x
                | RawV(r,n,false) -> x
                | RawV(r,n,true) ->
                    match type_apply_args.TryGetValue(n) with
                    | true, type_apply_args ->
                        match Map.tryFind n rec_term with
                        | None -> fst type_apply_args
                        | Some t -> t |> snd type_apply_args
                        |> List.fold (fun s x -> RawApply(r,s,RawType(r,t_to_rawtexpr r [] x))) x
                    | _ -> x
                | RawDefaultLit(r,_) -> RawAnnot(r,x,annot r x)
                | RawForall(r,a,b) -> RawForall(r,a,f b)
                | RawMatch(r'',(RawForall _ | RawFun _) & body,[PatVar(r,name), on_succ]) ->
                    let _,body = foralls_get body
                    RawMatch(r'',fill_foralls r rec_term body,[PatVar(r,name), fill_typecases (Map.remove name rec_term) on_succ])
                | RawMatch(r,a,b) -> RawMatch(r,f a,clauses b)
                | RawFun(r,a) -> RawAnnot(r,RawFun(r,clauses a),annot r x)
                | RawExists(r,(r',a),b) -> RawExists(r,(r',Some(Option.defaultWith (fun () -> List.map (t_to_rawtexpr r []) exists_vars.[x]) a)),f b)
                | RawRecBlock(r,l,on_succ) ->
                    let has_foralls = List.exists (function (_,RawForall _) -> true | _ -> false) l
                    if has_foralls then RawRecBlock(r,List.map (fun (a,b) -> a, f b) l,f on_succ)
                    else
                        let rec_term = List.fold (fun s ((_,name),b) -> Map.add name generalized_statements.[foralls_get b |> snd] s) rec_term l
                        let l = List.map (fun (a,b) -> a, fill_foralls (fst a) rec_term b) l
                        RawRecBlock(r,l,f on_succ)
                | RawRecordWith(r,a,b,c) ->
                    let b = b |> List.map (function
                        | RawRecordWithSymbol(a,b) -> RawRecordWithSymbol(a,f b)
                        | RawRecordWithSymbolModify(a,b) -> RawRecordWithSymbolModify(a,f b)
                        | RawRecordWithInjectVar(a,b) -> RawRecordWithInjectVar(a,f b)
                        | RawRecordWithInjectVarModify(a,b) -> RawRecordWithInjectVarModify(a,f b)
                        )
                    RawRecordWith(r,List.map f a,b,c)
                | RawJoinPoint(r,q,a,b) -> RawAnnot(r,RawJoinPoint(r,q,f a,b),annot r x)
                | RawAnnot(r,a,_) -> f a
                | RawOpen(r,a,b,c) ->
                    let f = function TyModule s -> s | _ -> failwith "Compiler error: Module open should always succeed in fill."
                    List.fold (fun s x -> (f s).[snd x]) top_env.term.[snd a] b |> f
                    |> Map.fold (fun s k _ -> Map.remove k s) rec_term
                    |> fun rec_term -> RawOpen(r,a,b,term rec_term c)
                | RawApply(r,a,b) ->
                    let q = RawApply(r,f a,f b)
                    match module_type_apply_args.TryGetValue(x) with
                    | true, typevars -> List.fold (fun a b -> RawApply(r,a,RawType(r,t_to_rawtexpr r [] b))) q typevars
                    | _ -> q
                | RawIfThenElse(r,a,b,c) -> RawIfThenElse(r,f a,f b,f c)
                | RawIfThen(r,a,b) -> RawIfThen(r,f a,f b)
                | RawPair(r,a,b) -> RawPair(r,f a,f b)
                | RawSeq(r,a,b) -> RawSeq(r,f a,f b)
                | RawHeapMutableSet(r,a,b,c) -> RawHeapMutableSet(r,f a,List.map f b,f c)
                | RawMacro(r,l) ->
                    let l = l |> List.map (function RawMacroTerm(r,x,b) -> RawMacroTerm(r,f x,b) | x -> x )
                    RawAnnot(r,RawMacro(r,l),annot r x)
                | RawArray(r,a) -> RawAnnot(r,RawArray(r,List.map f a),annot r x)
            and pattern recbterm x' =
                let mutable rec_term = rec_term
                let rec f = function
                    | PatFilledDefaultValue _ -> failwith "Compiler error: PatDefaultValueFilled should not appear in fill."
                    | PatValue _ | PatSymbol _ | PatE _ | PatB _ as x -> x
                    | PatVar(r,name) as x -> rec_term <- Map.remove name rec_term; x
                    | PatDyn(r,a) -> PatDyn(r,f a)
                    | PatUnbox(r,q,a) -> PatUnbox(r,q,f a)
                    | PatExists(r,q,a) -> PatExists(r,q,f a)
                    | PatAnnot(_,a,_) -> f a
                    | PatPair(r,a,b) -> PatPair(r,f a,f b)
                    | PatRecordMembers(r,a) ->
                        let a = a |> List.map (function
                            | PatRecordMembersSymbol(a,b) -> PatRecordMembersSymbol(a,f b)
                            | PatRecordMembersInjectVar(a,b) -> PatRecordMembersInjectVar(a,f b)
                            )
                        PatRecordMembers(r,a)
                    | PatOr(r,a,b) -> PatOr(r,f a,f b)
                    | PatAnd(r,a,b) -> PatAnd(r,f a,f b)
                    | PatDefaultValue(r,a) as x -> PatFilledDefaultValue(r,a,annot r x)
                    | PatWhen(r,a,b) -> PatWhen(r,f a,term rec_term b)
                    | PatNominal(r,a,b,c) -> PatNominal(r,a,b,f c)
                    | PatArray(r,a) -> PatArray(r,List.map f a)
                rec_term, f x'

            let x = fill_foralls r rec_term expr
            assert (0 = errors.Count)
            x

        let fresh_kind () = KindMetavar {contents'=None}
        let fresh_var'' x = TyMetavar (x, ref None)
        let fresh_var' scope kind = fresh_var'' {scope=scope; constraints=Set.empty; kind=kind}
        let fresh_subst_var scope cons kind = fresh_var'' {scope=scope; constraints=cons; kind=kind}
        let forall_subst_all scope x =
            let rec loop m x =
                match visit_t x with
                | TyForall(a,b) ->
                    let v = fresh_subst_var scope a.constraints a.kind
                    let type_apply_args,b = loop ((a, v) :: m) b
                    v :: type_apply_args, b
                | x -> [], subst m x
            loop [] x

        let exists_subst_term scope (l : Var list, body) =
            let vars = l |> List.map (fun a -> fresh_subst_var scope a.constraints a.kind)
            vars, subst (List.zip l vars) body

        let assert_exists_hasnt_metavars r vars =
            if List.exists has_metavars vars then errors.Add(r, ExistsShouldntHaveMetavars vars)

        let generalize r scope (forall_vars : Var list) (body : T) =
            let h = HashSet(HashIdentity.Reference)
            List.iter (h.Add >> ignore) forall_vars
            let generalized_metavars = ResizeArray()
            let rec replace_metavars x =
                let f = replace_metavars
                match x with
                | TyVar (_,{contents=Some x})
                | TyMetavar(_,{contents=Some x}) -> f x
                | TyMetavar(x, link) when scope = x.scope ->
                    let v = tyvar {scope=x.scope; constraints=x.constraints; kind=kind_force x.kind; name=autogen_name_in_fun autogened_forallvar_count_in_funs}
                    autogened_forallvar_count_in_funs <- autogened_forallvar_count_in_funs+1
                    link.Value <- Some v
                    replace_metavars v
                // This scheme with the HashSet is so generalize works for mutually recursive statements.
                | TyVar (v,_) -> if scope = v.scope && h.Add(v) then generalized_metavars.Add(v)
                | TyMetavar _ | TyNominal _ | TyB | TyLit _ | TyPrim _ | TySymbol _ -> ()
                | TyPair(a,b) | TyApply(a,b,_) | TyFun(a,b,_) -> f a; f b
                | TyUnion(a,_) -> Map.iter (fun _ -> snd >> f) a
                | TyRecord a -> Map.iter (fun _ -> f) a
                | TyExists(v,a) -> List.iter (h.Add >> ignore) v; f a
                | TyForall(v,a) -> (h.Add >> ignore) v; f a
                | TyComment(_,a) | TyLayout(a,_) | TyArray a -> f a
                | TyMacro a -> List.iter (function TMLitVar a | TMVar a -> f a | TMText _ -> ()) a
                | TyModule _ | TyInl _ -> ()

            let f x s = TyForall(x,s)
            replace_metavars body
            let x = Seq.foldBack f generalized_metavars body |> List.foldBack f forall_vars |> term_subst
            if List.isEmpty forall_vars = false then assert_foralls_used errors r x
            x

        let gadt_extract scope (v : T) =
            let forall_subst_all_gadt x =
                let rec loop m x = 
                    match visit_t x with
                    | TyForall(a,b) ->
                        let v = tyvar {a with name=autogen_name_in_typecase autogened_forallvar_count_in_typecase; scope=scope}
                        autogened_forallvar_count_in_typecase <- autogened_forallvar_count_in_typecase+1
                        let type_apply_args,b = loop ((a, v) :: m) b
                        v :: type_apply_args, b
                    | x -> [], subst m x
                loop [] x
            let forall_vars,v = forall_subst_all_gadt v
            match v with
            | TyFun(a,b,_) -> forall_vars,a,b
            | b -> forall_vars,TyB,b

        let inline unify_kind' er r got expected =
            let rec loop (a'',b'') =
                match visit_tt a'', visit_tt b'' with
                | KindType, KindType -> ()
                | KindFun(a,a'), KindFun(b,b') -> loop (a,b); loop (a',b')
                | KindMetavar a, KindMetavar b & b' -> if a <> b then a.contents' <- Some b'
                | KindMetavar link, b | b, KindMetavar link -> link.contents' <- Some b
                | _ -> raise (InferTypeErrorException [r, er (got, expected)])
            loop (got, expected)
        let unify_kind r got expected = try unify_kind' KindError r got expected with :? InferTypeErrorException as e -> errors.AddRange e.Data0
        let unify_gadt (gadt_links : T option ref ResizeArray option) (r : VSCRange) (got : T) (expected : T) : unit =
            let unify_kind got expected = unify_kind' KindError r got expected
            let er () = raise (InferTypeErrorException [r, TermError(got, expected)])

            let rec constraint_process (con : Constraint Set) b =
                let unify_kind got expected = unify_kind' KindErrorInConstraint r got expected
                let body = function
                    | CUInt, TyPrim (UInt8T | UInt16T | UInt32T | UInt64T)
                    | CSInt, TyPrim (Int8T | Int16T | Int32T | Int64T)
                    | CInt, TyPrim (UInt8T | UInt16T | UInt32T | UInt64T | Int8T | Int16T | Int32T | Int64T)
                    | CFloat, TyPrim (Float32T | Float64T)
                    | CNumber, TyPrim (UInt8T | UInt16T | UInt32T | UInt64T | Int8T | Int16T | Int32T | Int64T | Float32T | Float64T)
                    | CPrim, TyPrim _
                    | CSymbol, TySymbol _
                    | CRecord, TyRecord _ -> []
                    | con, TyMetavar(x,_) -> x.constraints <- Set.add con x.constraints; []
                    | CPrototype prot & con, x ->
                        match type_apply_split x with
                        | TyNominal ins, x' ->
                            match Map.tryFind (prot,ins) top_env.prototypes_instances with
                            | Some cons ->
                                try List.fold2 (fun ers con x -> List.append (constraint_process con (visit_t x)) ers) [] cons x'
                                with :? System.ArgumentException -> [] // This case can occur due when kind application overflows in a previous expression.
                            | None -> [InstanceNotFound(prot,ins)]
                        | TyMetavar _ & x, _ -> [PrototypeConstraintCannotPropagateToMetavar(prot,x)]
                        | TyVar _ & x, _ -> [PrototypeConstraintCannotPropagateToVar(prot,x)]
                        | _ -> [ConstraintError(con,x)]
                    | con, x -> [ConstraintError(con,x)]

                match b with
                | TyVar (_,{contents=Some x}) -> constraint_process con x
                | TyVar (b,_) -> if con.IsSubsetOf b.constraints = false then [ForallVarConstraintError(b.name,con,b.constraints)] else []
                | b ->
                    let b_kind = tt top_env b
                    Set.fold (fun ers con ->
                        unify_kind b_kind (constraint_kind top_env con)
                        List.append (body (con,b)) ers
                        ) [] con

            // Does occurs checking for recursive metavariables.
            // Does scope checking in forall vars.
            let validate_mvar_unification i x =
                let nested_tvars = HashSet(HashIdentity.Reference)
                let rec f x =
                    match visit_t x with
                    | TyModule _ | TyNominal _ | TyB | TyLit _ | TyPrim _ | TySymbol _ -> ()
                    | TyMacro a -> a |> List.iter (function TMText _ -> () | TMLitVar a | TMVar a -> f a)
                    | TyForall(v,a) | TyInl(v,a) ->
                        let _ = nested_tvars.Add(v)
                        f a
                        let _ = nested_tvars.Remove(v)
                        ()
                    | TyExists(v,a) ->
                        v |> List.iter (nested_tvars.Add >> ignore)
                        f a
                        v |> List.iter (nested_tvars.Remove >> ignore)
                    | TyComment(_,a) | TyArray a -> f a
                    | TyApply(a,b,_) | TyFun(a,b,_) | TyPair(a,b) -> f a; f b
                    | TyUnion(l,_) -> Map.iter (fun _ -> snd >> f) l
                    | TyRecord l -> Map.iter (fun _ -> f) l
                    | TyVar(b,_) -> if nested_tvars.Contains b = false && i.scope < b.scope then raise (InferTypeErrorException [r,TypeVarScopeError(b.name,got,expected)])
                    | TyMetavar(x,_) -> if i = x then raise (InferTypeErrorException [r,RecursiveMetavarsNotAllowed(got,expected)]) elif i.scope < x.scope then x.scope <- i.scope
                    | TyLayout(a,_) -> f a
                f x

            // Does occurs checking for recursive type variables.
            let rec validate_tvar_unification i x =
                let f = validate_tvar_unification i
                match visit_t x with
                | TyMetavar _ | TyModule _ | TyNominal _ | TyB | TyLit _ | TyPrim _ | TySymbol _ -> ()
                | TyMacro a -> a |> List.iter (function TMText _ -> () | TMLitVar a | TMVar a -> f a)
                | TyExists(_,a) | TyComment(_,a) | TyForall(_,a) | TyInl(_,a) | TyArray a -> f a
                | TyApply(a,b,_) | TyFun(a,b,_) | TyPair(a,b) -> f a; f b
                | TyUnion(l,_) -> Map.iter (fun _ -> snd >> f) l
                | TyRecord l -> Map.iter (fun _ -> f) l
                | TyVar(x,_) -> if i = x then raise (InferTypeErrorException [r,RecursiveTypevarsNotAllowed(got,expected)])
                | TyLayout(a,_) -> f a

            let rec loop (a'',b'') = 
                match visit_t a'', visit_t b'' with
                | TyComment(_,a), b | a, TyComment(_,b) -> loop (a,b)
                | TyMetavar(a,link), TyMetavar(b,_) & b' ->
                    if a <> b then
                        unify_kind a.kind b.kind
                        b.scope <- min a.scope b.scope
                        b.constraints <- a.constraints + b.constraints
                        link.Value <- Some b'
                | TyMetavar(a,link), b | b, TyMetavar(a,link) ->
                    validate_mvar_unification a b
                    unify_kind a.kind (tt top_env b)
                    match constraint_process a.constraints b with
                    | [] -> link.Value <- Some b
                    | constraint_errors -> raise (InferTypeErrorException (List.map (fun x -> r,x) constraint_errors))
                | TyVar (a,_), TyVar (b,_) when a = b -> ()
                | TyVar (a,link), b | b, TyVar (a,link) when gadt_links.IsSome ->
                    validate_tvar_unification a b
                    unify_kind a.kind (tt top_env b)
                    match constraint_process a.constraints b with
                    | [] -> link.Value <- Some b; gadt_links.Value.Add(link)
                    | constraint_errors -> raise (InferTypeErrorException (List.map (fun x -> r,x) constraint_errors))
                | TyFun(a,a',ta), TyFun(b,b',tb) when ta = tb -> loop (a,b); loop (a',b')
                | TyPair(a,a'), TyPair(b,b') -> loop (a,b); loop (a',b')
                | TyApply(a,a',_), TyApply(b,b',_) -> loop (a',b'); loop (a,b)
                | TyUnion(l,q), TyUnion(l',q') -> 
                    if q = q' then
                        let a,b = Map.toArray l, Map.toArray l'
                        if a.Length <> b.Length then er ()
                        else Array.iter2 (fun (ka,a) (kb,b) -> if ka = kb && fst a = fst b then loop (snd a,snd b) else er()) a b
                    else raise (InferTypeErrorException [r,UnionTypesMustHaveTheSameLayout])
                | TyRecord l, TyRecord l' -> 
                    let a,b = Map.toArray l, Map.toArray l'
                    if a.Length <> b.Length then er ()
                    else
                        let a = a |> Array.sortBy (fun ((_,k),_) -> k)
                        let b = b |> Array.sortBy (fun ((_,k),_) -> k)
                        Array.iter2 (fun (ka,a) (kb,b) ->
                            if (ka |> snd) = (kb |> snd)
                            then loop (a,b)
                            else er()
                        ) a b
                | TyNominal i, TyNominal i' when i = i' -> ()
                | TyB, TyB -> ()
                | TyPrim x, TyPrim x' when x = x' -> ()
                | TyLit a, TyLit b when a = b -> ()
                | TySymbol x, TySymbol x' when x = x' -> ()
                | TyArray a, TyArray b -> loop (a,b)
                // Note: Unifying these 3 only makes sense if the `expected` is fully inferred already.
                | TyExists(a,b), TyExists(a',b') when 
                        List.length a = List.length a'
                        && List.forall2 (fun (a : Var) (a' : Var) -> a.kind = a'.kind && a.constraints = a'.constraints) a a' -> 
                    loop (b, subst (List.map2 (fun a a' -> a', tyvar a) a a') b')
                | TyForall(a,b), TyForall(a',b') 
                | TyInl(a,b), TyInl(a',b') when a.kind = a'.kind && a.constraints = a'.constraints -> loop (b, subst [a',tyvar a] b')
                | TyMacro a, TyMacro b ->
                    List.iter2 (fun a b ->
                        match a,b with
                        | TMText a, TMText b when System.Object.ReferenceEquals(a,b) || a = b -> ()
                        | TMVar a, TMVar b -> loop(a,b)
                        | _ -> er ()
                        ) a b
                | TyLayout(a,a'), TyLayout(b,b') when a' = b' -> loop (a,b)
                | _ -> er ()

            try loop (got, expected)
            with :? InferTypeErrorException as e -> errors.AddRange e.Data0

        let unify range got expected = unify_gadt None range got expected

        let apply_record r s l x =
            match visit_t x with
            | TySymbol x ->
                match l |> Map.tryPick (fun (_, k) v -> if k = x then Some v else None) with
                | Some x ->
                    let com = match x with TyComment(com,_) -> com | _ -> ""
                    unify r s x
                    hover_types.AddHover (r,(x,com))
                | None -> errors.Add(r,RecordIndexFailed x)
            | x -> errors.Add(r,ExpectedSymbolAsRecordKey x)

        let assert_bound_vars env a =
            let keys_of m = Map.fold (fun s k _ -> Set.add k s) Set.empty m
            validate_bound_vars (loc_env top_env) env.constraints (keys_of env.term) (keys_of env.ty) (Choice1Of2 a) |> errors.AddRange

        let fresh_var scope = fresh_var' scope KindType

        let v_cons env a = Map.tryFind a env |> Option.orElseWith (fun () -> Map.tryFind a top_env.constraints)
        let v env top_env a = Map.tryFind a env |> Option.orElseWith (fun () -> Map.tryFind a top_env)
        let v_term env a = v env.term top_env.term a |> Option.map (function TyComment(com,x) -> com, visit_t x | x -> "", visit_t x)
        let v_ty env a = v env.ty top_env.ty a

        let typevar_to_var scope cons (((_,(name,kind)),constraints) : TypeVar) : Var =
            let rec typevar = function
                | RawKindWildcard -> fresh_kind()
                | RawKindStar -> KindType
                | RawKindFun(a,b) -> KindFun(typevar a, typevar b)
            let kind = typevar kind
            let cons =
                constraints |> List.choose (fun (r,x) ->
                    match v_cons cons x with
                    | Some (M _) -> errors.Add(r,ExpectedConstraintInsteadOfModule); None
                    | Some (C x) -> unify_kind r kind (constraint_kind top_env x); Some x
                    | None -> errors.Add(r,UnboundVariable x); None
                    ) |> Set.ofList

            {scope=scope; constraints=cons; kind=kind_force kind; name=name}

        let typevars scope env (l : TypeVar list) =
            List.mapFold (fun s x ->
                let v = typevar_to_var scope env.constraints x
                v, Map.add v.name (tyvar v) s
                ) env.ty l

        let rec term scope env s x = term' scope false env s x
        and term' scope is_in_left_apply (env : InferEnv) s x =
            let f = term scope env
            let f' x = let v = fresh_var scope in f v x; visit_t v
            let f'' x = let v = fresh_var scope in term' scope true env v x; visit_t v
            let inline rawv (r,name,is_tvar_applied) =
                match v_term env name with
                | None -> errors.Add(r,UnboundVariable name)
                | Some (_,TySymbol "<real>") -> errors.Add(r,RealFunctionInTopDown)
                | Some (com,TyModule _ & m) when is_in_left_apply = false ->
                    hover_types.AddHover(r,(m,com))
                    errors.Add(r,ModuleMustBeImmediatelyApplied)
                | Some (com,a) ->
                    if is_tvar_applied then
                        match a with TyForall _ -> annotations.Add(x,(r,s)) | _ -> ()
                        let f a = let l,v = forall_subst_all scope a in unify r s v; l
                        let l = f a
                        hover_types.AddHover(r,(s,com))
                        type_apply_args.Add(name,(l,f))
                    else
                        unify r s a
                        hover_types.AddHover(r,(s,com))
            let match_clause (q,w) (a,b) =
                let gadt_links, gadt_typecases', (scope, env) = pattern scope env q a
                term scope env w b
                dispose_gadt_links gadt_links
                gadt_typecases.Add(b,gadt_typecases')
            match x with
            | RawB r -> unify r s TyB
            | RawV(r,a,is_tvar_applied) -> rawv (r,a,is_tvar_applied)
            | RawDefaultLit(r,_) -> unify r s (fresh_subst_var scope (Set.singleton CNumber) KindType); hover_types.AddHover(r,(s,"")); annotations.Add(x,(r,s))
            | RawLit(r,a) -> unify r s (lit a)
            | RawSymbol(r,x) -> unify r s (TySymbol x)
            | RawIfThenElse(_,cond,tr,fl) -> f (TyPrim BoolT) cond; f s tr; f s fl
            | RawIfThen(r,cond,tr) -> f (TyPrim BoolT) cond; unify r s TyB; f TyB tr
            | RawPair(r,a,b) ->
                let q,w = fresh_var scope, fresh_var scope
                unify r s (TyPair(q, w))
                f q a; f w b
            | RawSeq(_,a,b) -> f TyB a; f s b
            | RawReal(_,a) -> assert_bound_vars env a
            | RawOp(_,_,l) -> List.iter (assert_bound_vars env) l
            | RawJoinPoint(r,None,a,_) -> annotations.Add(x,(r,s)); f s a
            | RawJoinPoint(r,Some _,a,_) ->
                unify r s (TySymbol "tuple_of_free_vars")
                let s = fresh_var scope
                annotations.Add(x,(r,s))
                f s a
            | RawApply(r,a',b) ->
                let rec loop = function
                    | TyNominal _ | TyApply _ as a ->
                        match type_apply_split a with
                        | TyNominal i, l ->
                            let n = top_env.nominals.[i]
                            match n.body with
                            | TyUnion _ -> errors.Add(r,UnionsCannotBeApplied)
                            | _ ->
                                match Utils.list_try_zip n.vars l with
                                | Some l -> loop (subst l n.body)
                                | None -> errors.Add(r,MalformedNominal)
                        | _ -> errors.Add(r,ExpectedNominalInApply a)
                    | TyLayout(a,_) ->
                        match visit_t a with
                        | TyRecord l -> apply_record r s l (f' b)
                        | a -> errors.Add(r,ExpectedRecordInsideALayout a)
                    | TyRecord l -> apply_record r s l (f' b)
                    | TyModule l ->
                        match f' b with
                        | TySymbol n ->
                            match Map.tryFind n l with
                            | Some (TyModule _ as a) ->
                                if is_in_left_apply then 
                                    match b with RawSymbol(r,_) -> hover_types.AddHover(r,(a,"")) | _ -> ()
                                    unify r s a
                                else errors.Add(r,ModuleMustBeImmediatelyApplied)
                            | Some a' ->
                                let typevars,a = forall_subst_all scope a'
                                if List.isEmpty typevars = false then
                                    annotations.Add(x,(r,s))
                                    module_type_apply_args.Add(x,typevars)
                                unify r s a
                                match b with 
                                | RawSymbol(r,_) -> 
                                    let com = match a' with TyComment(com,_) -> com | _ -> ""
                                    hover_types.AddHover(r,(a,com))
                                | _ -> ()
                            | None -> errors.Add(r,ModuleIndexFailed n)
                        | b -> errors.Add(r,ExpectedSymbolAsModuleKey b)
                    | TyFun(domain,range,_) -> unify (range_of_expr a') range s; f domain b
                    | a -> let v = fresh_var scope in unify (range_of_expr a') a (TyFun(v,s,FT_Vanilla)); f v b
                loop (f'' a')
            | RawAnnot(r,a,b) ->  ty_init scope env s b; f s a
            | RawOpen(_,(r,a),l,on_succ) ->
                match inferModule_open (Some hover_types) (loc_env top_env) env.ty r a l with
                | Ok x ->
                    let combine big small = Map.foldBack Map.add small big
                    term scope {term = combine env.term x.term; ty = combine env.ty x.ty; constraints = combine env.constraints x.constraints} s on_succ
                | Error e -> errors.Add(e)
            | RawRecordWith(r,l,withs,withouts) ->
                let i = errors.Count
                let withouts,fields =
                    List.foldBack (fun x (l,s as state) ->
                        match x with
                        | RawRecordWithoutSymbol(r,a) -> {|range=r; symbol = a|} :: l, Set.add a s
                        | RawRecordWithoutInjectVar(r,a) ->
                            match v_term env a with
                            | Some (com, TySymbol a & x) -> hover_types.AddHover(r,(x,com)); {|range=r; symbol = a|} :: l, Set.add a s
                            | Some (_,x) -> errors.Add(r, ExpectedSymbolAsRecordKey x); state
                            | None -> errors.Add(r, UnboundVariable a); state
                        ) withouts ([],Set.empty)
                let withs,_ =
                    List.foldBack (fun x (l,s as state) ->
                        let with_symbol ((r,a),b) = {|range=r; symbol = a; is_blocked=Set.contains a s; is_modify=false; var=fresh_var scope; body=b|} :: l, Set.add a s
                        let with_symbol_modify ((r,a),b) = {|range=r; symbol = a; is_blocked=Set.contains a s; is_modify=true; var=TyFun(fresh_var scope,fresh_var scope,FT_Vanilla); body=b|} :: l, Set.add a s
                        let inline with_inject next ((r,a),b) =
                            match v_term env a with
                            | Some (com, TySymbol a & x) -> hover_types.AddHover(r,(x,com)); next ((r,a),b)
                            | Some (_, x) -> errors.Add(r, ExpectedSymbolAsRecordKey x); f' b |> ignore; state
                            | None -> errors.Add(r, UnboundVariable a); f' b |> ignore; state
                        match x with
                        | RawRecordWithSymbol(a,b) -> with_symbol (a,b)
                        | RawRecordWithSymbolModify(a,b) -> with_symbol_modify (a,b)
                        | RawRecordWithInjectVar(a,b) -> with_inject with_symbol (a,b)
                        | RawRecordWithInjectVarModify(a,b) -> with_inject with_symbol_modify (a,b)
                        ) withs ([],fields)

                let eval m =
                    let m = (m,withs) ||> List.fold (fun m x ->
                        if x.is_modify then
                            let i, q =
                                match m |> Map.tryPick (fun (i, k) v -> if k = x.symbol then Some (i, v) else None) with
                                | Some q -> q
                                | None -> errors.Add(x.range,RecordIndexFailed x.symbol); m.Count, fresh_var scope
                            let w = fresh_var scope
                            unify x.range (TyFun(q,w,FT_Vanilla)) x.var
                            f x.var x.body
                            Map.add (i, x.symbol) w m
                        else
                            f x.var x.body
                            let i =
                                m
                                |> Map.tryPick (fun (i, k) v -> if k = x.symbol then Some i else None)
                                |> Option.defaultValue m.Count
                            Map.add (i, x.symbol) x.var m
                        )
                    withouts |> List.fold (fun m x -> m |> Map.filter (fun (_, k) _ -> k <> x.symbol)) m

                let bind s = withs |> List.iter (fun x ->
                    if x.is_blocked = false then
                        if x.is_modify then
                            s
                            |> Map.tryPick (fun (i, k') v -> if k' = x.symbol then Some (i, v) else None)
                            |> Option.iter (fun (_, k) -> unify x.range x.var (TyFun(fresh_var scope,k,FT_Vanilla)))
                        else
                            s
                            |> Map.tryPick (fun (i, k') v -> if k' = x.symbol then Some (i, v) else None)
                            |> Option.iter (fun (_, k) -> k |> unify x.range x.var)
                    )

                let rec tail' m = function
                    | x :: xs ->
                        match f' x with
                        | TySymbol k ->
                            match m |> Map.tryPick (fun (i, k') v -> if k' = k then Some (i, v) else None) with
                            | Some (i, m) ->
                                match visit_t m with
                                | TyRecord m -> tail' m xs
                                | m -> errors.Add(range_of_expr x, ExpectedRecordAsResultOfIndex m); eval Map.empty
                            | _ -> errors.Add(range_of_expr x, RecordIndexFailed k); eval Map.empty
                            |> fun v ->
                                let i = m |> Map.tryPick (fun (i, k') v -> if k' = k then Some (i, v) else None)
                                match i with
                                | Some (i, _) -> Map.add (i, k) (TyRecord v) m
                                | None -> Map.add (m.Count, k) (TyRecord v) m
                        | TyMetavar _ -> errors.Add(range_of_expr x, MetavarsNotAllowedInRecordWith); eval Map.empty
                        | a -> errors.Add(range_of_expr x, ExpectedSymbolInRecordWith a); eval Map.empty
                    | [] -> eval m

                let rec tail (m,s) = function
                    | x :: xs ->
                        match f' x with
                        | TySymbol k ->
                            match
                                m |> Map.tryPick (fun (i, k') v -> if k' = k then Some (i, v) else None),
                                s |> Map.tryPick (fun (i, k') v -> if k' = k then Some (i, v) else None)
                            with
                            | Some (i,m), Some (_i',s) ->
                                match visit_t m, visit_t s with
                                | TyRecord m, TyRecord s -> i, tail (m,s) xs
                                | TyRecord m, _ -> i, tail' m xs
                                | m, _ -> errors.Add(range_of_expr x, ExpectedRecordAsResultOfIndex m); i, eval Map.empty
                            | Some (i,m), None ->
                                match visit_t m with
                                | TyRecord m -> i, tail' m xs
                                | m -> errors.Add(range_of_expr x, ExpectedRecordAsResultOfIndex m); i, eval Map.empty
                            | _ -> errors.Add(range_of_expr x, RecordIndexFailed k); i, eval Map.empty
                            |> fun (i,v) -> Map.add (i,k) (TyRecord v) m
                        | TyMetavar _ -> errors.Add(range_of_expr x, MetavarsNotAllowedInRecordWith); eval Map.empty
                        | a -> errors.Add(range_of_expr x, ExpectedSymbolInRecordWith a); eval Map.empty
                    | [] -> bind s; eval m

                match l with
                | [] ->
                    match visit_t s with TyRecord s -> bind s | _ -> ()
                    eval Map.empty
                | m :: l ->
                    match f' m, visit_t s with
                    | TyRecord m, TyRecord s -> tail (m,s) l
                    | TyRecord m, _ -> tail' m l
                    | TyMetavar _, _ -> errors.Add(range_of_expr x, MetavarsNotAllowedInRecordWith); eval Map.empty
                    | a,_ -> errors.Add(range_of_expr x, ExpectedRecord a); eval Map.empty
                |> fun v -> if errors.Count = i then unify r (TyRecord v) s
            | RawExists(r,(r',l),body) ->
                match visit_t s with
                | TyExists(type_vars,type_body) ->
                    let vars, s = exists_subst_term scope (type_vars,type_body)
                    l |> Option.iter (fun l ->
                        let l1,l2 = vars.Length, l.Length
                        if l1 = l2 then List.iter2 (ty_init scope env) vars l
                        else errors.Add(r', UnexpectedNumberOfArgumentsInExistsBody(l1,l2))
                        )
                    term scope env s body
                    assert_exists_hasnt_metavars (range_of_expr x) vars
                    exists_vars.Add(x,vars)
                | s -> errors.Add(r, ExpectedExistentialInTerm s); f (fresh_var scope) body
            | RawFun(r,l) ->
                annotations.Add(x,(r,s))
                let q,w = fresh_var scope, fresh_var scope
                unify r s (TyFun(q,w,FT_Vanilla))
                List.iter (match_clause (q,w)) l
            | RawForall _ -> failwith "Compiler error: Should be handled in let statements."
            | RawMatch(_,(RawForall _ | RawFun _) & body,[PatVar(r,name), on_succ]) -> term scope (inl scope env ((r, name), body)) s on_succ
            | RawRecBlock(_,l',on_succ) -> term scope (rec_block scope env l') s on_succ
            | RawMatch(_,body,l) ->
                let body_var = fresh_var scope
                f body_var body
                List.iter (match_clause (body_var,s)) l
            | RawMissingBody r -> errors.Add(r,MissingBody)
            | RawMacro(r,a) ->
                annotations.Add(x,(r,s))
                List.iter (function
                    | RawMacroText _ -> ()
                    | RawMacroTerm(_,a,_) -> term scope env (fresh_var scope) a
                    | RawMacroType(_,a) | RawMacroTypeLit(_,a) -> ty_init scope env (fresh_var scope) a
                    ) a
            | RawHeapMutableSet(r,a,b,c) ->
                unify r s TyB
                try let v = fresh_var scope
                    let i = errors.Count
                    f v a
                    match visit_t v with
                    | TyMetavar _ -> raise (InferTypeErrorException [r, LayoutSetMustBeAnnotated])
                    | TyLayout(v,lay) ->
                        match lay with
                        | HeapMutable | StackMutable ->
                            if i <> errors.Count then raise (InferTypeErrorException [])
                            let b = List.map (fun x -> range_of_expr x, f' x) b
                            List.fold (fun (r,a') (r',b') ->
                                match visit_t a' with
                                | TyRecord a ->
                                    match b' with
                                    | TySymbol b ->
                                        match a |> Map.tryPick (fun (_, k) v -> if k = b then Some v else None) with
                                        | Some x -> r', x
                                        | _ -> raise (InferTypeErrorException [r, RecordIndexFailed b])
                                    | b -> raise (InferTypeErrorException [r', ExpectedSymbol' b])
                                | a -> raise (InferTypeErrorException [r, ExpectedRecord a])
                                ) (range_of_expr a, v) b |> snd
                        | Heap -> raise (InferTypeErrorException [r, ExpectedMutableLayout v])
                    | v -> raise (InferTypeErrorException [r, ExpectedMutableLayout v])
                with :? InferTypeErrorException as e -> errors.AddRange e.Data0; fresh_var scope
                |> fun v -> f v c
            | RawArray(r,a) ->
                annotations.Add(x,(r,s))
                let v = fresh_var scope
                unify r s (TyArray v)
                List.iter (f v) a
            | RawFilledForall _ -> failwith "Compiler error: Should not manifest during type inference."
            | RawType _ -> failwith "Compiler error: RawType should not appear in the top down segment."
            | RawTypecase _ -> failwith "Compiler error: `typecase` should not appear in the top down segment."
        and inl scope env ((r, name), body) =
            let scope = scope + 1
            let vars,body = foralls_get body
            vars |> List.iter (fun ((r,(name,_)),_) -> if Map.containsKey name env.ty then errors.Add(r,ShadowedForall))
            let vars,env_ty = typevars scope env vars
            let body_var = fresh_var scope
            term scope {env with ty = env_ty} body_var body
            let t = generalize r scope vars body_var
            generalized_statements.Add(body,t)
            hover_types.AddHover(r,(t,""))
            {env with term = Map.add name t env.term }
        and rec_block scope env l' =
            let rec term_annotations scope env x =
                let f t = 
                    let i = errors.Count
                    let v = fresh_var scope
                    ty_init scope env v t
                    if i = errors.Count && has_metavars v then errors.Add(range_of_texpr t, RecursiveAnnotationHasMetavars v)
                    v
                match x with
                | RawFun(_,[(PatAnnot(_,_,t) | PatDyn(_,PatAnnot(_,_,t))),body]) -> TyFun(f t, term_annotations scope env body,FT_Vanilla)
                | RawFun(_,[pat,body]) -> errors.Add(range_of_pattern pat, ExpectedAnnotation); TyFun(fresh_var scope, term_annotations scope env body,FT_Vanilla)
                | RawFun(r,_) -> errors.Add(r, ExpectedSinglePattern); TyFun(fresh_var scope, fresh_var scope, FT_Vanilla)
                | RawJoinPoint(_,_,RawAnnot(_,_,t),_) | RawAnnot(_,_,t) -> f t
                | x -> errors.Add(range_of_expr x,ExpectedAnnotation); fresh_var scope
            let scope = scope + 1
            let has_foralls = List.exists (function (_,RawForall _) -> true | _ -> false) l'
            let l,m =
                if has_foralls then
                    List.mapFold (fun s ((r,name),body) ->
                        let vars,body = foralls_get body
                        vars |> List.iter (fun x -> if Map.containsKey (typevar_name x) env.ty then errors.Add(range_of_typevar x,ShadowedForall))
                        let vars, env_ty = typevars scope env vars
                        let body_var = term_annotations scope {env with ty = env_ty} body
                        let term env = term scope {env with ty = env_ty} body_var body
                        let gen env : InferEnv =
                            let t = generalize r scope vars body_var
                            generalized_statements.Add(body,t)
                            hover_types.AddHover(r,(t,""))
                            {env with term = Map.add name t env.term}
                        let ty = List.foldBack (fun x s -> TyForall(x,s)) vars body_var |> term_subst
                        (term, gen), Map.add name ty s
                        ) env.term l'
                else
                    List.mapFold (fun s ((r,name),body) ->
                        let body_var = fresh_var scope
                        let term env = term scope env body_var body
                        let gen env : InferEnv =
                            let t = generalize r scope [] body_var
                            generalized_statements.Add(body,t)
                            hover_types.AddHover(r,(t,""))
                            {env with term = Map.add name t env.term}
                        (term, gen), Map.add name body_var s
                        ) env.term l'
            let _ =
                let env = {env with term = m}
                List.iter (fun (term, _) -> term env) l
            List.fold (fun env (_, gen) -> gen env) env l
        and ty_init scope env s x = 
            ty scope env s x
            assert_foralls_used errors (range_of_texpr x) s
        and ty scope env s x = ty' scope false env s x
        and ty' scope is_in_left_apply (env : InferEnv) s x =
            let f s x = ty scope env s x
            match x with
            | RawTTypecase _ -> failwith "Compiler error: Type level typecase should not appear in the top down segment."
            | RawTWildcard r -> hover_types.AddHover(r,(s,""))
            | RawTArray(r,a) ->
                let v = fresh_var scope
                unify r s (TyArray v)
                f v a
            | RawTVar(r,x) ->
                match v_ty env x with
                | Some (TyModule _ & m) when is_in_left_apply = false -> hover_types.AddHover(r,(m,"")); errors.Add(r,ModuleMustBeImmediatelyApplied)
                | Some x -> unify r s x; hover_types.AddHover(r,(x,""))
                | None -> errors.Add(r, UnboundVariable x)
            | RawTB r -> unify r s TyB
            | RawTLit(r,x) -> unify r s (TyLit x)
            | RawTSymbol(r,x) -> unify r s (TySymbol x)
            | RawTPrim(r,x) -> unify r s (TyPrim x)
            | RawTPair(r,a,b) ->
                let q,w = fresh_var scope, fresh_var scope
                unify r s (TyPair(q,w))
                f q a; f w b
            | RawTFun(r,a,b,t) ->
                let q,w = fresh_var scope, fresh_var scope
                unify r s (TyFun(q,w,t))
                f q a; f w b
            | RawTRecord(r,l) ->
                let l' = Map.map (fun _ _ -> fresh_var scope) l
                unify r s (TyRecord l')
                Map.iter (fun k s -> f s l.[k]) l'
            | RawTUnion(r,l,lay,_) ->
                let l' = Map.map (fun _ (is_gadt,_) -> is_gadt, fresh_var scope) l
                unify r s (TyUnion(l',lay))
                Map.iter (fun k (is_gadt,s) -> let x = snd l.[k] in if is_gadt then ty scope {env with ty = Map.empty} s x else f s x) l'
            | RawTExists(r,a,b) ->
                let a = List.map (typevar_to_var scope env.constraints) a
                let body_var = fresh_var scope
                ty scope {env with ty = List.fold (fun s a -> Map.add a.name (tyvar a) s) env.ty a} body_var b
                unify r s (TyExists(a, body_var))
            | RawTForall(r,a,b) ->
                let a = typevar_to_var scope env.constraints a
                let body_var = fresh_var scope
                ty scope {env with ty = Map.add a.name (tyvar a) env.ty} body_var b
                unify r s (TyForall(a, body_var))
            | RawTApply(r,a',b) ->
                let f' b k x = let v = fresh_var' scope k in ty' scope b env v x; visit_t v
                match f' true (fresh_kind ()) a' with
                | TyModule l ->
                    match f' false KindType b with
                    | TySymbol x ->
                        match Map.tryFind x l with
                        | Some (TyModule _ as a) ->
                            if is_in_left_apply then 
                                unify r s a
                                match b with RawTSymbol(r,_) -> hover_types.AddHover(r,(a,"")) | _ -> ()
                            else errors.Add(r,ModuleMustBeImmediatelyApplied)
                        | Some a -> 
                            unify r s a
                            match b with
                            | RawTSymbol(r,_) ->
                                let com = match a with TyComment(com,_) -> com | _ -> ""
                                hover_types.AddHover(r,(a,com))
                            | _ -> ()
                        | None -> errors.Add(r,ModuleIndexFailed x)
                    | b -> errors.Add(r,ExpectedSymbolAsRecordKey b)
                | TyInl(a,body) -> let v = fresh_var' scope a.kind in f v b; unify r s (subst [a,v] body)
                | a ->
                    let q,w = fresh_kind(), fresh_kind()
                    unify_kind (range_of_texpr a') (tt top_env a) (KindFun(q,w))
                    let x = fresh_var' scope q
                    f x b
                    unify r s (TyApply(a,x,w))
            | RawTTerm(r,a) -> assert_bound_vars env a; unify r s (TySymbol "<term>")
            | RawTMacro(r,a) ->
                List.map (function
                    | RawMacroText(_,a) -> TMText a
                    | RawMacroTerm _ -> failwith "Compiler error: Term vars should never appear at the type level."
                    | RawMacroType(r,a) | RawMacroTypeLit(r,a) -> let v = fresh_var scope in f v a; TMVar v
                    ) a
                |> TyMacro |> unify r s
            | RawTLayout(r,a,b) ->
                let v = fresh_var scope
                unify r s (TyLayout(v,b))
                f v a
            | RawTFilledNominal _ -> failwith "Compiler error: RawTNominal should be filled in by the inferencer."
            | RawTMetaVar _ -> failwith "Compiler error: This particular metavar is only for typecase's clauses. This happens during the bottom-up segment."
        and pattern (scope : InferScope) (env : InferEnv) s a : T option ref ResizeArray * (T * T list * T) ResizeArray * (InferScope * InferEnv) = 
            let gadt_links = ResizeArray()
            let gadt_typecases = ResizeArray()
            let term_vars = Dictionary(HashIdentity.Structural)
            let ty_vars = Dictionary(HashIdentity.Structural)
            let mutable scope = scope
            let update_env () =
                scope,
                {env with
                    ty = (env.ty,ty_vars) ||> Seq.fold (fun s x -> Map.add x.Key x.Value s)
                    term = (env.term,term_vars) ||> Seq.fold (fun s x -> Map.add x.Key x.Value s)
                    }
            let ho_make (i : GlobalId) (l : Var list) =
                let h = TyNominal i
                let l' = List.map (fun (x : Var) -> x, fresh_subst_var scope x.constraints x.kind) l
                List.fold (fun s (_,x) -> match tt top_env s with KindFun(_,k) -> TyApply(s,x,k) | _ -> failwith "impossible") h l', l'
            let rec ho_index x =
                match visit_t x with
                | TyApply(a,_,_) -> ho_index a 
                | TyNominal i -> ValueSome i
                | _ -> ValueNone
            let rec ho_fun x = 
                match visit_t x with
                | TyFun(_,a,_) | TyForall(_,a) -> ho_fun a
                | a -> ho_index a
            let rec loop s x : unit =
                let f = loop
                match x with
                | PatFilledDefaultValue _ -> failwith "Compiler error: PatDefaultValueFilled should not appear during inference."
                | PatB r -> unify r s TyB
                | PatE r -> hover_types.AddHover(r,(s,""))
                | PatVar(r,a) ->
                    match term_vars.TryGetValue(a) with
                    | true, v -> unify r s v
                    | _ -> term_vars.Add(a,s)
                    hover_types.AddHover(r,(s,""))
                | PatDyn(_,a) -> f s a
                | PatAnnot(_,a,b) -> ty_init scope env s b; f s a
                | PatWhen(_,a,b) -> 
                    f s a
                    let scope,env = update_env()
                    term scope env (TyPrim BoolT) b
                | PatPair(r,a,b) ->
                    let q,w = fresh_var scope, fresh_var scope
                    unify r s (TyPair(q,w))
                    loop q a; loop w b
                | PatSymbol(r,a) -> unify r s (TySymbol a)
                | PatOr(_,a,b) | PatAnd(_,a,b) -> loop s a; loop s b
                | PatValue(r,a) -> unify r s (lit a)
                | PatDefaultValue(r,_) -> 
                    annotations.Add(x,(r,s))
                    unify r s (fresh_subst_var scope (Set.singleton CNumber) KindType)
                    hover_types.AddHover(r,(s,""))
                | PatRecordMembers(r,l) ->
                    let l =
                        List.choose (function
                            | PatRecordMembersSymbol((r,a),b) -> Some (a,b)
                            | PatRecordMembersInjectVar((r,a),b) ->
                                match v_term env a with
                                | Some (com,TySymbol a & x) -> hover_types.AddHover(r,(x,com)); Some (a,b)
                                | Some (_,x) -> errors.Add(r, ExpectedSymbolAsRecordKey x); None
                                | None -> errors.Add(r, UnboundVariable a); None
                            ) l
                    match visit_t s with
                    | TyRecord l' as s ->
                        let l, missing =
                            List.mapFoldBack (fun (a,b) missing ->
                                match l' |> Map.tryPick (fun (i, k) v -> if k = a then Some (i, v) else None) with
                                | Some (_,x) -> (x,b), missing
                                | None -> (fresh_var scope,b), a :: missing
                                ) l []
                        if List.isEmpty missing = false then errors.Add(r, MissingRecordFieldsInPattern(s, missing))
                        List.iter (fun (a,b) -> loop a b) l
                    | s ->
                        let l =
                            List.mapi (fun i (a,b) -> 
                                let v = fresh_var scope
                                loop v b
                                (i, a), v
                                ) l
                        unify r s (l |> Map |> TyRecord)
                | PatExists(r,l,p) ->
                    l |> List.iter (fun (r,name) -> if Map.containsKey name env.ty then errors.Add(r,ShadowedExists))
                    match visit_t s with
                    | TyExists(type_var_list,type_body) ->
                        if l.Length = type_var_list.Length then
                            scope <- scope + 1
                            let vars = (l, type_var_list) ||> List.map2 (fun (_,name) l -> 
                                Utils.memoize ty_vars (fun name -> tyvar {l with scope=scope; name=name}) name
                                )
                            loop (subst (List.zip type_var_list vars) type_body) p
                        else
                        errors.Add(r, UnexpectedNumberOfArgumentsInExistsPattern(l.Length,type_var_list.Length))
                    | s -> errors.Add(r, ExpectedExistentialInPattern s)
                | PatUnbox(r,name,a) ->
                    let assume i =
                        let n = top_env.nominals.[i]
                        match n.body with
                        | TyUnion(cases,_) ->
                            let x,m = ho_make i n.vars
                            unify r s x
                            match Map.tryPick (fun (_, name') v -> if name = name' then Some v else None) cases with
                            | Some (is_gadt, v) -> 
                                if is_gadt then 
                                    scope <- scope + 1
                                    let forall_vars,body,specialized_constructor = gadt_extract scope v
                                    gadt_typecases.Add(s, forall_vars, specialized_constructor)
                                    match a with PatE r' when r = r' -> () | _ -> loop body a // This check for PatE is so the hovers for it don't overwrite the main pattern.
                                    unify_gadt (Some gadt_links) r s specialized_constructor
                                else
                                    match a with PatE r' when r = r' -> () | _ -> f (subst m v) a
                                hover_types.AddHover(r,(s,""))
                            | None -> errors.Add(r,CasePatternNotFoundForType(i,name)); f (fresh_var scope) a
                        | _ -> errors.Add(r,NominalInPatternUnbox i); f (fresh_var scope) a
                    match ho_index s with
                    | ValueSome i -> assume i
                    | ValueNone ->
                        match v_term env name with
                        | Some (_,x) ->
                            match ho_fun x with
                            | ValueSome i -> assume i
                            | ValueNone -> errors.Add(r,CannotInferCasePatternFromTermInEnv x); f (fresh_var scope) a
                        | None -> errors.Add(r,CasePatternNotFound name); f (fresh_var scope) a
                | PatNominal(_,(r,name),l,a) ->
                    match v_ty env name with
                    | Some x ->
                        let rec loop r x = function
                            | (r,name) :: l ->
                                match x with
                                | TyModule x ->
                                    match Map.tryFind name x with
                                    | Some x -> loop r x l
                                    | None -> errors.Add(r,ModuleIndexFailed name); f (fresh_var scope) a
                                | _ ->
                                    errors.Add(r,ExpectedModule x); f (fresh_var scope) a
                            | [] ->
                                match ho_index x with
                                | ValueSome i ->
                                    let n = top_env.nominals.[i]
                                    match n.body with
                                    | TyUnion _ -> errors.Add(r,UnionInPatternNominal i); f (fresh_var scope) a
                                    | _ -> let x,m = ho_make i n.vars in unify r s x; f (subst m n.body) a
                                | ValueNone -> errors.Add(r,TypeInEnvIsNotNominal x); f (fresh_var scope) a
                        loop r x l
                    | _ -> errors.Add(r,UnboundVariable name); f (fresh_var scope) a
                | PatArray(r,a) ->
                    let v = fresh_var scope
                    unify r s (TyArray v)
                    List.iter (fun x -> loop v x) a
            loop s a
            gadt_links, gadt_typecases, update_env()

        let nominal_term global_id tt name vars v =
            let constructor body =
                let t,_ = List.fold (fun (a,k) b -> let k = trim_kind k in TyApply(a,tyvar b,k),k) (TyNominal global_id,tt) vars
                let x = match body with TyB -> t | _ -> TyFun(body,t,FT_Vanilla)
                List.foldBack (fun var ty -> TyForall(var,ty)) vars x
            match v with
            | TyUnion(l,_) -> Map.fold (fun s (_,name) (is_gadt,v) -> Map.add name (if is_gadt then v else constructor v) s) Map.empty l
            | _ -> Map.add name (constructor v) Map.empty

        let psucc = Hopac.Job.thunk >> Hopac.Hopac.memo
        let pfail = Hopac.Promise.Now.withFailure (System.Exception "Compiler error: Tried to read from a FilledTop that has errors.")

        let top_env_nominal top_env (global_id : GlobalId) tt name vars v : TopEnv =
            { top_env with
                nominals_next_tag = max top_env.nominals_next_tag global_id.tag + 1
                nominals_aux = Map.add global_id {|kind=tt; name=name|} top_env.nominals_aux
                nominals = Map.add global_id {|vars=vars; body=v|} top_env.nominals
                term = Map.foldBack Map.add (nominal_term global_id tt name vars v) top_env.term
                ty = Map.add name (TyNominal global_id) top_env.ty
                }

        let rec typevar = function
            | RawKindWildcard | RawKindStar -> KindType
            | RawKindFun(a,b) -> KindFun(typevar a, typevar b)
        let hovars (x : HoVar list) =
            List.mapFold (fun s (_,(n,t)) ->
                let v = {scope=0; kind=typevar t; name=n; constraints=Set.empty}
                v, Map.add n (tyvar v) s
                ) Map.empty x

        let scope = 0
        let bundle_nominal_rec l' =
            let l,_ =
                List.mapFold (fun i (_,name,vars,body) ->
                    let l,env = hovars vars
                    let tt = List.foldBack (fun (x : Var) s -> KindFun(x.kind,s)) l KindType
                    (at_tag i,name,l,env,tt,body), i+1
                    ) top_env.nominals_next_tag l'

            top_env <-
                {top_env with 
                    nominals_aux = (top_env.nominals_aux, l) ||> List.fold (fun s (i,(_,name),_,_,tt,_) -> Map.add i {|name=name; kind=tt|} s)
                    ty = (top_env.ty, l) ||> List.fold (fun s (i,(_,name),_,_,_,_) -> Map.add name (TyNominal i) s) 
                    }

            List.fold (fun top_env (global_id,(r,name),vars,env_ty,tt,body) ->
                let v = fresh_var scope
                ty_init scope {term=Map.empty; ty=env_ty; constraints=Map.empty} v body
                let v = term_subst v
                validate_nominal errors global_id body v
                top_env_nominal top_env global_id tt name vars v
                ) inferTop_env_empty l

        match expr with
        | BundleType(q,(r,name),vars',expr) ->
            let vars,env_ty = hovars vars'
            let v = fresh_var scope
            ty_init scope {term=Map.empty; ty=env_ty; constraints=Map.empty} v expr
            let t = List.foldBack (fun x s -> TyInl(x,s)) vars (term_subst v)
            hover_types.AddHover(r,(t,""))
            if 0 = errors.Count then psucc (fun () -> FType(q,(r,name),vars',expr)), AInclude {inferTop_env_empty with ty = Map.add name t Map.empty}
            else pfail, AInclude inferTop_env_empty
        | BundleNominal(q,(r,name),vars',expr) ->
            let x = bundle_nominal_rec [q,(r,name),vars',expr]
            if 0 = errors.Count then psucc (fun () -> FNominal(q,(r,name),vars',expr)), AInclude x
            else pfail, AInclude inferTop_env_empty
        | BundleNominalRec l ->
            let _ = // Checks that mutually recursive unions do not have duplicates.
                let h = HashSet()
                l |> List.iter (fun (_,_,_,x) ->
                    match x with
                    | RawTUnion(_,l,_,_) -> l |> Map.iter (fun k v -> if h.Add k = false then errors.Add(range_of_texpr (snd v),DuplicateKeyInRecUnion))
                    | _ -> ()
                    )
            let x = bundle_nominal_rec l
            if 0 = errors.Count then psucc (fun () -> FNominalRec l), AInclude x
            else pfail, AInclude inferTop_env_empty
        | BundlePrototype(com,r,(r',name),(w,var_init),vars',expr) ->
            let i = at_tag top_env'.prototypes_next_tag
            let cons = CPrototype i
            let scope = 0
            let vars,env_ty = typevars scope {term=Map.empty; constraints=Map.empty; ty=Map.empty} vars'
            let kind = List.foldBack (fun (k : Var) s -> KindFun(k.kind,s)) vars KindType
            let v' = {scope=scope; constraints=Set.singleton cons; name=var_init; kind=kind}
            let env_ty = Map.add var_init (tyvar v') env_ty
            let vars = v' :: vars
            let v = fresh_var scope
            ty_init scope {term=Map.empty; ty=env_ty; constraints=Map.empty} v expr
            let body = List.foldBack (fun a b -> TyForall(a,b)) vars (term_subst v)
            if 0 = errors.Count && (assert_foralls_used errors r' body; 0 = errors.Count) then
                let x =
                    { inferTop_env_empty with
                        prototypes_next_tag = i.tag + 1
                        prototypes = Map.add i {|name=name; signature=body; kind=v'.kind|} Map.empty
                        term = Map.add name (if com <> "" then TyComment(com,body) else body) Map.empty
                        constraints = Map.add name (C cons) Map.empty
                        }
                psucc (fun () -> FPrototype(r,(r',name),(w,var_init),vars',expr)), AInclude x
            else pfail, AInclude inferTop_env_empty
        | BundleInl(com,q,(_,name as w),a,true) ->
            let env = inl scope {term=Map.empty; ty=Map.empty; constraints=Map.empty} (w,a)
            let term =
                let x = env.term.[name]
                if com <> "" then TyComment(com, x) else x
            (if 0 = errors.Count then psucc (fun () -> FInl(q,w,fill q Map.empty a)) else pfail),
            AInclude { inferTop_env_empty with term = Map.add name term Map.empty}
        | BundleInl(com,q,(_,name as w),a,false) ->
            assert_bound_vars {term=Map.empty; ty=Map.empty; constraints=Map.empty} a
            (if 0 = errors.Count then psucc (fun () -> FInl(q,w,a)) else pfail),
            AInclude { inferTop_env_empty with term = Map.add name (TySymbol "<real>") Map.empty }
        | BundleRecInl(l,is_top_down) ->
            let _ =
                let h = HashSet()
                List.iter (fun (_,_,(r,n),_) -> if h.Add n = false then errors.Add(r,DuplicateRecInlName)) l
            let env_term =
                if is_top_down then
                    let l = List.map (fun (com,_,a,b) -> a,b) l
                    (rec_block scope {term=Map.empty; ty=Map.empty; constraints=Map.empty} l).term
                else
                    let env_term = List.fold (fun s (com,_,(_,a),_) -> Map.add a (TySymbol "<real>") s) Map.empty l
                    l |> List.iter (fun (com,_,_,x) -> assert_bound_vars {term = env_term; ty = Map.empty; constraints=Map.empty} x)
                    env_term
            let filled_top =
                if 0 = errors.Count then
                    if is_top_down then psucc (fun () -> FRecInl(List.map (fun (_,a,b,c) -> a,b,fill a env_term c) l))
                    else psucc (fun () -> FRecInl(List.map (fun (_,a,b,c) -> a,b,c) l))
                else pfail
            let env_term =
                List.fold (fun env_term (com,_,(_,n),_) ->
                    if com <> "" then Map.add n (TyComment(com, Map.find n env_term)) env_term else env_term
                    ) env_term l
            filled_top, AInclude (Map.fold (fun s k v -> {s with term = Map.add k v s.term}) inferTop_env_empty env_term)
        | BundleInstance(r,prot,ins,vars,body) ->
            let fail = pfail,AInclude inferTop_env_empty
            let assert_no_kind x = x |> List.iter (fun ((r,(_,k)),_) -> match k with RawKindWildcard -> () | _ -> errors.Add(r,KindNotAllowedInInstanceForall))
            let assert_vars_count vars_count vars_expected = if vars_count <> vars_expected then errors.Add(r,InstanceCoreVarsShouldMatchTheArityDifference(vars_count,vars_expected))
            let assert_kind_compatibility got expected =
                try unify_kind' InstanceKindError r got expected
                with :? InferTypeErrorException as e -> errors.AddRange e.Data0
            let assert_kind_arity prot_kind_arity ins_kind_arity = if ins_kind_arity < prot_kind_arity then errors.Add(r,InstanceArityError(prot_kind_arity,ins_kind_arity))
            let assert_instance_forall_does_not_shadow_prototype_forall prot_forall_name = List.iter (fun ((r,(a,_)),_) -> if a = prot_forall_name then errors.Add(r,InstanceVarShouldNotMatchAnyOfPrototypes)) vars
            let assert_orphan_shadow_check (prot_id : GlobalId) (ins_id : GlobalId) =
                // if Map.containsKey (prot_id, ins_id) top_env.prototypes_instances
                // then errors.Add(r,ShadowedInstance)
                ()
            let assert_orphan_instance_check (prot_id : GlobalId) (ins_id : GlobalId) =
                // if (prot_id.package_id = package_id || ins_id.package_id = package_id) = false then errors.Add(r,OrphanInstance)
                ()
            let body prot_id ins_id =
                let ins_kind' = top_env.nominals_aux.[ins_id].kind
                let guard next = if 0 = errors.Count then next () else fail
                let ins_kind = kind_get ins_kind'
                let prototype = top_env.prototypes.[prot_id]
                hover_types.AddHover(fst prot, (prototype.signature,"")) // TODO: Add the hover for the instance signature.
                let prototype_init_forall_kind = prototype_init_forall_kind prototype.signature
                let prot_kind = kind_get prototype_init_forall_kind
                assert_kind_arity prot_kind.arity ins_kind.arity
                guard <| fun () ->
                let vars_expected = ins_kind.arity - prot_kind.arity
                assert_kind_compatibility (List.skip vars_expected ins_kind.args |> List.reduceBack (fun a b -> KindFun(a,b))) prototype_init_forall_kind
                guard <| fun () ->
                assert_vars_count (List.length vars) vars_expected
                guard <| fun () ->
                assert_no_kind vars
                guard <| fun () ->
                let ins_vars, env_ty =
                    List.mapFold (fun s (((r,_),_) & x,k) ->
                        let v = {typevar_to_var scope Map.empty x with kind = k}
                        let x = tyvar v
                        hover_types.AddHover(r,(x,""))
                        x, Map.add v.name x s
                        ) Map.empty (List.zip vars (List.take vars_expected ins_kind.args))
                let ins_constraints = ins_vars |> List.map (visit_t >> function TyVar (x,_) -> x.constraints | _ -> failwith "impossible")
                let ins_core, _ = List.fold (fun (a,k) (b : T) -> let k = trim_kind k in TyApply(a,b,k),k) (TyNominal ins_id,ins_kind') ins_vars
                let env_ty, prot_body =
                    match foralls_ty_get prototype.signature with
                    | (prot_core :: prot_foralls), prot_body ->
                        List.fold (fun ty x ->
                            assert_instance_forall_does_not_shadow_prototype_forall x.name
                            Map.add x.name (tyvar x) ty) env_ty prot_foralls,
                        let prot_body = subst [prot_core, ins_core] prot_body
                        let _ =
                            List.foldBack (fun x s -> TyForall(x,s)) prot_foralls prot_body
                            |> List.foldBack (fun x s -> match visit_t x with TyVar(x,_) -> TyForall(x,s) | _ -> failwith "impossible") ins_vars
                            |> fun x -> generalized_statements.Add(body,x)
                        prot_body
                    | _ -> failwith "impossible"
                assert_orphan_shadow_check prot_id ins_id
                assert_orphan_instance_check prot_id ins_id
                guard <| fun () ->
                top_env <- {top_env with prototypes_instances = Map.add (prot_id,ins_id) ins_constraints top_env.prototypes_instances}
                term scope {term=Map.empty; ty=env_ty; constraints=Map.empty} prot_body body
                (if 0 = errors.Count then psucc (fun () -> FInstance(r,(fst prot, prot_id),(fst ins, ins_id),fill r Map.empty body)) else pfail),
                AInclude {inferTop_env_empty with prototypes_instances = Map.add (prot_id,ins_id) ins_constraints Map.empty}

            let fake _ = fail
            let check_ins on_succ =
                match Map.tryFind (snd ins) top_env.ty with
                | None -> errors.Add(fst ins, UnboundVariable (snd ins)); fail
                | Some(TyNominal i') -> on_succ i'
                | Some x -> errors.Add(fst ins, ExpectedHigherOrder x); fail
            match Map.tryFind (snd prot) top_env.constraints with
            | None -> errors.Add(fst prot, UnboundVariable (snd prot)); check_ins fake
            | Some(C (CPrototype i)) -> check_ins (body i)
            | Some(C x) -> errors.Add(fst prot, ExpectedPrototypeConstraint x); check_ins fake
            | Some(M _) -> errors.Add(fst prot, ExpectedPrototypeInsteadOfModule); check_ins fake
        | BundleOpen(q,(r,a),b) ->
            match inferModule_open (Some hover_types) (loc_env top_env) Map.empty r a b with
            | Ok x -> psucc (fun () -> FOpen(q,(r,a),b)), AOpen {inferTop_env_empty with term=x.term; ty=x.ty; constraints=x.constraints}
            | Error er -> errors.Add(er); pfail, AOpen inferTop_env_empty
        |> fun (filled_top, top_env_additions) ->
            if 0 = errors.Count then
                annotations |> Seq.iter (fun (KeyValue(_,(r,x))) -> if has_metavars x then errors.Add(r, ValueRestriction x))
            {
            filled_top = filled_top
            top_env_additions = top_env_additions
            offset = bundle_range expr |> fst |> fun x -> x.line
            hovers = hover_types.ToArray() |> Array.map (fun ((a:VSCRange),(b,(com : string))) -> a, let b = show_t top_env b in if com <> "" then sprintf "%s\n---\n%s" b com else b)
            errors = errors |> Seq.toList |> List.map (fun (a,b) -> a, show_type_error top_env b)
            }

    /// ### base_types
    let base_types (default_env : DefaultEnv) =
        let var name = {scope=0; kind=KindType; constraints=Set.empty; name=name} 
        let inline inl f = let x = var "x" in TyInl(x,f x)
        let inline inl2 f = let x,y = var "x", var "y" in TyInl(x,TyInl(y,f x y))
        [
        "i8", TyPrim Int8T
        "i16", TyPrim Int16T
        "i32", TyPrim Int32T
        "i64", TyPrim Int64T
        "u8", TyPrim UInt8T
        "u16", TyPrim UInt16T
        "u32", TyPrim UInt32T
        "u64", TyPrim UInt64T
        "f32", TyPrim Float32T
        "f64", TyPrim Float64T
        "string", TyPrim StringT
        "bool", TyPrim BoolT
        "char", TyPrim CharT
        "array_base", inl (fun x -> TyArray(tyvar x))
        "heap", inl (fun x -> TyLayout(tyvar x,Layout.Heap))
        "mut", inl (fun x -> TyLayout(tyvar x,Layout.HeapMutable))
        "stack_mut", inl (fun x -> TyLayout(tyvar x,Layout.StackMutable))
        "fptr", inl2 (fun x y -> TyFun(tyvar x,tyvar y,FT_Pointer))
        "closure", inl2 (fun x y -> TyFun(tyvar x,tyvar y,FT_Closure))
        "int", TyPrim default_env.default_int
        "uint", TyPrim default_env.default_uint
        "float", TyPrim default_env.default_float
        ]

    /// ### inferTop_env_default
    let inferTop_env_default default_env : TopEnv =
        // Note: `top_env_default` should have no nominals, prototypes or terms.
        {inferTop_env_empty with
            ty = Map.ofList (base_types default_env)
            constraints =
                [
                "uint", CUInt
                "sint", CSInt
                "int", CInt
                "float", CFloat
                "number", CNumber
                "prim", CPrim
                "record", CRecord
                "symbol", CSymbol
                ] |> Map.ofList |> Map.map (fun _ -> C)
            }

    module Infer =
        let base_types x =
            base_types x

    /// ## Prepass

    /// ### Id
    type Id = int32

    /// ### ScopeEnv
    type ScopeEnv = {|free_vars : int []; stack_size : int|}

    /// ### Scope
    type Scope = {term : ScopeEnv; ty : ScopeEnv}

    /// ### Range
    type Range = {path : string; range : VSCRange}

    /// ### Macro
    type Macro =
        | MText of string
        | MTerm of E * is_inline : bool
        | MType of TPrepass
        | MLitType of TPrepass
    and TypeMacro =
        | TMText of string
        | TMType of TPrepass
        | TMLitType of TPrepass
    and RecordWith =
        | RSymbol of (Range * string) * E
        | RSymbolModify of (Range * string) * E
        | RVar of (Range * E) * E
        | RVarModify of (Range * E) * E
    and RecordWithout =
        | WSymbol of Range * string
        | WVar of Range * E
    and PatRecordMemberPrepass =
        | Symbol of (Range * string) * Id
        | Var of (Range * E) * Id
    and [<ReferenceEquality>] E =
        | EFun of Range * Id * E * TPrepass option
        | EFun' of Range * Scope * Id * E * TPrepass option
        | EForall of Range * Id * E
        | EForall' of Range * Scope * Id * E
        | ERecursiveFun' of Range * Scope * Id * E ref * TPrepass option
        | ERecursiveForall' of Range * Scope * Id * E ref
        | ERecursive of E ref // For global mutually recursive functions
        | EPatternRef of E ref
        | EJoinPoint of Range * E * TPrepass option * backend: (Range * string) option * name: string option
        | EJoinPoint' of Range * Scope * E * TPrepass option * backend: (Range * string) option * name: string option
        | EB of Range
        | EV of Id
        | ELit of Range * Literal
        | EDefaultLit of Range * string * TPrepass
        | ESymbol of Range * string
        | EType of Range * TPrepass
        | EApply of Range * E * E
        | EArray of Range * E list * TPrepass
        | ETypeApply of Range * E * TPrepass
        | ERecBlock of Range * (Id * E) list * on_succ: E
        | ERecordWith of Range * (Range * E) list * RecordWith list * RecordWithout list
        | EModule of Map<string, E>
        | EOp of Range * Op * E list
        | EPatternMiss of E
        | ETypePatternMiss of TPrepass
        | EAnnot of Range * E * TPrepass
        | EIfThenElse of Range * E * E * E
        | EIfThen of Range * E * E
        | EPair of Range * E * E
        | ESeq of Range * E * E
        | EMutableSet of Range * E * (Range * E) list * E
        | EReal of Range * E
        | EExists of Range * TPrepass list * E
        | EMacro of Range * Macro list * TPrepass
        | EPrototypeApply of Range * prototype_id: GlobalId * TPrepass
        | EPatternMemo of E
        | ENominal of Range * E * TPrepass
        // Regular pattern matching
        | ELet of Range * Id * E * E
        | EUnbox of Range * symbol: string * Id * body: E * on_succ: E * on_fail: E
        | EExistsTest of Range * bind: Id * pat_type: Id [] * pat: Id * on_succ: E * on_fail: E
        | EPairTest of Range * bind: Id * pat1: Id * pat2: Id * on_succ: E * on_fail: E
        | ESymbolTest of Range * string * bind: Id * on_succ: E * on_fail: E
        | ERecordTest of Range * PatRecordMemberPrepass list * bind: Id * on_succ: E * on_fail: E
        | EAnnotTest of Range * TPrepass * bind: Id * on_succ: E * on_fail: E
        | EUnitTest of Range * bind: Id * on_succ: E * on_fail: E
        | ENominalTest of Range * TPrepass * bind: Id * pat: Id * on_succ: E * on_fail: E
        | ELitTest of Range * Literal * bind: Id * on_succ: E * on_fail: E
        | EDefaultLitTest of Range * string * TPrepass * bind: Id * on_succ: E * on_fail: E
        | ETypecase of Range * TPrepass * (TPrepass * E) list
    and [<ReferenceEquality>] TPrepass =
        | TForall' of Range * Scope * Id * TPrepass
        | TForall of Range * Id * TPrepass
        | TArrow' of Scope * Id * TPrepass
        | TArrow of Id * TPrepass
        | TExists
        | TJoinPoint' of Range * Scope * TPrepass
        | TJoinPoint of Range * TPrepass
        | TPatternRef of TPrepass ref
        | TB of Range
        | TLit of Range * Literal
        | TV of Id
        | TPair of Range * TPrepass * TPrepass
        | TFun of TPrepass * TPrepass * FunType
        | TRecord of Range * Map<int * string,TPrepass>
        | TModule of Map<string,TPrepass>
        | TUnion of Range * (Map<int * string,TPrepass * TPrepass option> * UnionLayout)
        | TSymbol of Range * string
        | TApply of Range * TPrepass * TPrepass
        | TPrim of PrimitiveType
        | TTerm of Range * E
        | TMacro of Range * TypeMacro list
        | TNominal of GlobalId
        | TArray of TPrepass
        | TLayout of TPrepass * Layout
        | TMetaV of Id
        | TTypecase of Range * TPrepass * (TPrepass * TPrepass) list

    /// ### Printable
    module Printable =
        type PMacro =
            | MText of string
            | MTerm of PE * bool
            | MType of PT
            | MLitType of PT
        and PTypeMacro =
            | TMText of string
            | TMType of PT
            | TMLitType of PT
        and PRecordWith =
            | RSymbol of string * PE
            | RSymbolModify of string * PE
            | RVar of PE * PE
            | RVarModify of PE * PE
        and PRecordWithout =
            | WSymbol of string
            | WVar of PE
        and PPatRecordMember =
            | Symbol of string * Id
            | Var of PE * Id
        and [<ReferenceEquality>] PE =
            | EFun' of Scope * Id * PE * PT option
            | EForall' of Scope * Id * PE
            | ERecursiveFun' of Scope * Id * PE * PT option
            | ERecursiveForall' of Scope * Id * PE
            | ERecursive of PE
            | EJoinPoint of PE * PT option * string option
            | EJoinPoint' of Scope * PE * PT option * string option
            | EArray of PE list * PT
            | EFun of Id * PE * PT option
            | EForall of Id * PE
            | EB
            | EV of Id
            | ELit of Literal
            | EDefaultLit of string * PT
            | ESymbol of string
            | EType of PT
            | EApply of PE * PE
            | ETypeApply of PE * PT
            | ERecBlock of (Id * PE) list * on_succ: PE
            | ERecordWith of PE list * PRecordWith list * PRecordWithout list
            | EModule of Map<string, PE>
            | EOp of Op * PE list
            | EPatternMiss of PE
            | ETypePatternMiss of PT
            | EAnnot of PE * PT
            | EIfThenElse of PE * PE * PE
            | EIfThen of PE * PE
            | EPair of PE * PE
            | ESeq of PE * PE
            | EHeapMutableSet of PE * PE list * PE
            | EReal of PE
            | EExists of PT list * PE
            | EMacro of PMacro list * PT
            | EPrototypeApply of prototype_id: GlobalId * PT
            | EPatternMemo of PE
            | ENominal of PE * PT
            // Regular pattern matching
            | ELet of Id * PE * PE
            | EUnbox of Id * string * PE * PE * PE
            | EExistsTest of bind: Id * pat_type: Id [] * pat: Id * on_succ: PE * on_fail: PE
            | EPairTest of bind: Id * pat1: Id * pat2: Id * on_succ: PE * on_fail: PE
            | ESymbolTest of string * bind: Id * on_succ: PE * on_fail: PE
            | ERecordTest of PPatRecordMember list * bind: Id * on_succ: PE * on_fail: PE
            | EAnnotTest of PT * bind: Id * on_succ: PE * on_fail: PE
            | EUnitTest of bind: Id * on_succ: PE * on_fail: PE
            | ENominalTest of PT * bind: Id * pat: Id * on_succ: PE * on_fail: PE
            | ELitTest of Literal * bind: Id * on_succ: PE * on_fail: PE
            | EDefaultLitTest of string * PT * bind: Id * on_succ: PE * on_fail: PE
            | ETypecase of PT * (PT * PE) list
            | EOmmitedRecursive
        and [<ReferenceEquality>] PT =
            | TTypecase of PT * (PT * PT) list
            | TForall' of Scope * Id * PT
            | TForall of Id * PT
            | TArrow' of Scope * Id * PT
            | TArrow of Id * PT
            | TExists
            | TJoinPoint' of Scope * PT
            | TJoinPoint of PT
            | TB
            | TLit of Literal
            | TV of Id
            | TMetaV of Id
            | TPair of PT * PT
            | TFun of PT * PT * FunType
            | TFunPtr of PT * PT
            | TRecord of Map<int * string,PT>
            | TModule of Map<string,PT>
            | TUnion of Map<int * string,PT> * UnionLayout
            | TSymbol of string
            | TApply of PT * PT
            | TPrim of PrimitiveType
            | TTerm of PE
            | TMacro of PTypeMacro list
            | TNominal of GlobalId
            | TArray of PT
            | TLayout of PT * Layout

        let eval x =
            let recs = System.Collections.Generic.HashSet(HashIdentity.Reference)
            let rec term = function
                | E.ETypecase(r,a,b) -> ETypecase(ty a,b |> List.map (fun (a,b) -> ty a, term b))
                | E.EPatternRef a -> term a.Value
                | E.EFun'(_,a,b,c,d) -> EFun'(a,b,term c,Option.map ty d)
                | E.EForall'(_,a,b,c) -> EForall'(a,b,term c)
                | E.EArray(_,a,b) -> EArray(List.map term a,ty b)
                | E.ERecursiveFun'(_,a,b,c,d) -> 
                    let r = c.Value
                    let r = if recs.Add(r) then term r else EOmmitedRecursive
                    ERecursiveFun'(a,b,r,Option.map ty d)
                | E.ERecursiveForall'(_,a,b,c) -> 
                    let r = c.Value
                    let r = if recs.Add(r) then term r else EOmmitedRecursive
                    ERecursiveForall'(a,b,r)
                | E.ERecursive a -> 
                    let r = a.Value
                    if isNull (box r) then EOmmitedRecursive
                    else
                        let r = if recs.Add(r) then term r else EOmmitedRecursive
                        ERecursive r
                | E.EJoinPoint(_,a,b,d,_) -> EJoinPoint(term a,Option.map ty b,Option.map snd d)
                | E.EJoinPoint'(_,a,b,c,d,_) -> EJoinPoint'(a,term b,Option.map ty c,Option.map snd d)
                | E.EFun(_,a,b,c) -> EFun(a,term b,Option.map ty c)
                | E.EForall(_,a,b) -> EForall(a,term b)
                | E.EB _ -> EB
                | E.EV i -> EV i
                | E.ELit(_,a) -> ELit(a)
                | E.EDefaultLit(_,a,b) -> EDefaultLit(a,ty b)
                | E.ESymbol(_,a) -> ESymbol a
                | E.EType(_,a) -> EType(ty a)
                | E.EApply(_,a,b) -> EApply(term a,term b)
                | E.ETypeApply(_,a,b) -> ETypeApply(term a,ty b)
                | E.ERecBlock(_,a,b) -> ERecBlock(List.map (fun (a,b) -> a, term b) a,term b)
                | E.ERecordWith(_,a,b,c) ->
                    let a = a |> List.map (fun (_,a) -> term a)
                    let b = b |> List.map (function
                        | RecordWith.RSymbol((_,a),b) -> RSymbol(a,term b)
                        | RecordWith.RSymbolModify((_,a),b) -> RSymbolModify(a,term b)
                        | RecordWith.RVar((_,a),b) -> RVar(term a,term b)
                        | RecordWith.RVarModify((_,a),b) -> RVarModify(term a,term b)
                        )
                    let c = c |> List.map (function
                        | RecordWithout.WSymbol(_,a) -> WSymbol a
                        | RecordWithout.WVar(_,a) -> WVar(term a)
                        )
                    ERecordWith(a,b,c)
                | E.EModule a -> EModule(Map.map (fun _ -> term) a)
                | E.EOp(_,a,b) -> EOp(a,List.map term b)
                | E.EPatternMiss a -> EPatternMiss(term a)
                | E.ETypePatternMiss a -> ETypePatternMiss(ty a)
                | E.EAnnot(_,a,b) -> EAnnot(term a,ty b)
                | E.EIfThenElse(_,a,b,c) -> EIfThenElse(term a,term b,term c)
                | E.EIfThen(_,a,b) -> EIfThen(term a,term b)
                | E.EPair(_,a,b) -> EPair(term a,term b)
                | E.ESeq(_,a,b) -> ESeq(term a,term b)
                | E.EMutableSet(_,a,b,c) -> EHeapMutableSet(term a,List.map (snd >> term) b,term c)
                | E.EReal(_, a) -> EReal(term a)
                | E.EExists(_, a, b) -> EExists(List.map ty a, term b)
                | E.EMacro(_,a,b) ->
                    let a = a |> List.map (function
                        | Macro.MText a -> MText a
                        | Macro.MTerm (a,b) -> MTerm(term a,b)
                        | Macro.MType a -> MType(ty a)
                        | Macro.MLitType a -> MLitType(ty a)
                        )
                    EMacro(a,ty b)
                | E.EPrototypeApply(_,a,b) -> EPrototypeApply(a,ty b)
                | E.EPatternMemo a -> EPatternMemo(term a)
                | E.ENominal(_,a,b) -> ENominal(term a,ty b)
                // Regular pattern matching
                | E.ELet(_,a,b,c) -> ELet(a,term b,term c)
                | E.EUnbox(_,q,a,b,c,d) -> EUnbox(a,q,term b,term c,term d)
                | E.EExistsTest(_,a,l,q,d,e) -> EExistsTest(a,l,q,term d,term e)
                | E.EPairTest(_,a,b,c,d,e) -> EPairTest(a,b,c,term d,term e)
                | E.ESymbolTest(_,a,b,c,d) -> ESymbolTest(a,b,term c,term d)
                | E.ERecordTest(_,a,b,c,d) ->
                    let a = a |> List.map (function
                        | PatRecordMemberPrepass.Symbol((_,a),b) -> Symbol(a,b)
                        | PatRecordMemberPrepass.Var((_,a),b) -> Var(term a,b)
                        )
                    ERecordTest(a,b,term c,term d)
                | E.EAnnotTest(_,a,b,c,d) -> EAnnotTest(ty a,b,term c,term d)
                | E.EUnitTest(_,a,b,c) -> EUnitTest(a,term b,term c)
                | E.ENominalTest(_,a,b,c,d,e) -> ENominalTest(ty a,b,c,term d,term e)
                | E.ELitTest(_,a,b,c,d) -> ELitTest(a,b,term c,term d)
                | E.EDefaultLitTest(_,a,b,c,d,e) -> EDefaultLitTest(a,ty b,c,term d,term e)
            and ty = function
                | TPrepass.TTypecase(_,a,b) -> TTypecase(ty a,List.map (fun (a,b) -> ty a, ty b) b)
                | TPrepass.TPatternRef a -> ty a.Value
                | TPrepass.TForall'(_,a,b,c) -> TForall'(a,b,ty c)
                | TPrepass.TForall(_,a,b) -> TForall(a,ty b)
                | TPrepass.TArrow'(a,b,c) -> TArrow'(a,b,ty c)
                | TPrepass.TArrow(a,b) -> TArrow(a,ty b)
                | TPrepass.TExists -> TExists
                | TPrepass.TJoinPoint'(_,a,b) -> TJoinPoint'(a,ty b)
                | TPrepass.TJoinPoint(_,a) -> TJoinPoint(ty a)
                | TPrepass.TB _ -> TB
                | TPrepass.TLit(_,x) -> TLit x
                | TPrepass.TV a -> TV a
                | TPrepass.TMetaV a -> TMetaV a
                | TPrepass.TPair(_,a,b) -> TPair(ty a,ty b)
                | TPrepass.TFun(a,b,t) -> TFun(ty a,ty b,t)
                | TPrepass.TRecord(_,a) -> TRecord(Map.map (fun _ -> ty) a)
                | TPrepass.TModule a -> TModule(Map.map (fun _ -> ty) a)
                | TPrepass.TUnion(_,(a,b)) -> TUnion(Map.map (fun _ x -> ty (fst x)) a,b)
                | TPrepass.TSymbol(_,a) -> TSymbol a
                | TPrepass.TApply(_,a,b) -> TApply(ty a, ty b)
                | TPrepass.TPrim a -> TPrim a
                | TPrepass.TTerm(_,a) -> TTerm(term a)
                | TPrepass.TMacro(_,a) -> 
                    let a = a |> List.map (function
                        | TypeMacro.TMText a -> TMText a
                        | TypeMacro.TMType a -> TMType(ty a)
                        | TypeMacro.TMLitType a -> TMLitType(ty a)
                        )
                    TMacro(a)
                | TPrepass.TNominal a -> TNominal a
                | TPrepass.TArray a -> TArray(ty a)
                | TPrepass.TLayout(a,b) -> TLayout(ty a,b)

            match x with
            | Choice1Of2(x,ret) -> ret (term x)
            | Choice2Of2(x,ret) -> ret (ty x)

    /// ### PrepassTopEnv
    type PrepassTopEnv = {
        prototypes_next_tag : int
        prototypes_instances : Map<GlobalId * GlobalId,E>
        nominals_next_tag : int
        nominals : Map<GlobalId,{|body : TPrepass; name : string|}>
        term : Map<string,E>
        ty : Map<string,TPrepass>
        }

    /// ### prepassTop_env_empty
    let prepassTop_env_empty = {
        prototypes_next_tag = 0
        prototypes_instances = Map.empty
        nominals_next_tag = 0
        nominals = Map.empty
        term = Map.empty
        ty = Map.empty
        }

    /// ### prepassUnion
    let prepassUnion small big = {
        prototypes_next_tag = max small.prototypes_next_tag big.prototypes_next_tag
        prototypes_instances = Map.foldBack Map.add small.prototypes_instances big.prototypes_instances
        nominals_next_tag = max small.nominals_next_tag big.nominals_next_tag
        nominals = Map.foldBack Map.add small.nominals big.nominals
        term =
            Map.foldBack (fun k v s ->
                let v =
                    match v, s |> Map.tryFind k with
                    | EModule x, Some (EModule x') -> Map.foldBack Map.add x x' |> EModule
                    | _ -> v
                s |> Map.add k v
            ) small.term big.term
        ty =
            Map.foldBack (fun k v s ->
                let v =
                    match v, s |> Map.tryFind k with
                    | TModule x, Some (TModule x') -> Map.foldBack Map.add x x' |> TModule
                    | _ -> v
                s |> Map.add k v
            ) small.ty big.ty
        }

    /// ### in_modulePrepass
    let in_modulePrepass m (a : PrepassTopEnv) =
        {a with 
            ty = Map.add m (TModule a.ty) Map.empty
            term = Map.add m (EModule a.term) Map.empty
            }

    /// ### PropagatedVarsEnv
    type PropagatedVarsEnv = {|vars : Set<int>; range : (int * int) option|}

    /// ### PropagatedVars
    type PropagatedVars = {term : PropagatedVarsEnv; ty : PropagatedVarsEnv}

    /// ### propagate
    // Attaches scopes to all the nodes.
    let propagate x =
        let dict = Dictionary(HashIdentity.Reference)
        let (+*) a b = 
            match a,b with
            | Some(min',max'), Some(min'',max'') -> Some(min min' min'', max max' max'')
            | Some(a,b), _ | _, Some(a,b) -> Some(a,b)
            | None, None -> None
        let (+) (a : PropagatedVars) (b : PropagatedVars) : PropagatedVars = {
            term = {|vars = Set.union a.term.vars b.term.vars; range = a.term.range +* b.term.range |} 
            ty = {|vars = Set.union a.ty.vars b.ty.vars; range = a.ty.range +* b.ty.range |} 
            }
        let (-*) a i =
            if 0 <= i then 
                match a with 
                | Some(min',max') -> Some(min min' i, max max' i)
                | None -> Some(i,i)
            else a // Recursive vars are negative and get inlined so they should be ignored when calculating the range of a scope.
        let (-) (a : PropagatedVars) i = {a with term = {|vars = Set.remove i a.term.vars; range = a.term.range -* i |} }
        let (-.) (a : PropagatedVars) i = {a with ty = {|vars = Set.remove i a.ty.vars; range = a.ty.range -* i |} }
        let empty' term ty = let f x = {|vars = x; range=None|} in {term = f term; ty = f ty}
        let empty = empty' Set.empty Set.empty
        let singleton_term i = empty' (Set.singleton i) Set.empty
        let singleton_ty i = empty' Set.empty (Set.singleton i)

        let scope_dict = Dictionary<obj,_>(HashIdentity.Reference)
        let scope x (v : PropagatedVars) = scope_dict.Add(x,v); empty' v.term.vars v.ty.vars
        let rec term x =
            match x with
            | EFun' _ | EForall' _ | ERecursiveFun' _ | ERecursiveForall' _ | ERecursive _ | EJoinPoint' _ | EModule _ | ESymbol _ | ELit _ | EB _ -> empty
            | EPatternRef a -> term a.Value
            | EV i -> singleton_term i
            | EPrototypeApply(_,_,a) | EType(_,a) | ETypePatternMiss a | EDefaultLit(_,_,a) -> ty a
            | ESeq(_,a,b) | EPair(_,a,b) | EIfThen(_,a,b) | EApply(_,a,b) -> term a + term b
            | EArray(_,a,b) -> List.fold (fun s x -> s + term x) (ty b) a
            | ENominal(_,a,b) | EAnnot(_,a,b) | ETypeApply(_,a,b) -> term a + ty b
            | EForall(_,i,a) -> scope x (term a -. i)
            | EJoinPoint(_,a,t,_,_) -> scope x (match t with Some t -> term a + ty t | None -> term a)
            | EFun(_,i,a,t) -> scope x (match t with Some t -> term a - i + ty t | None -> term a - i)
            | ERecBlock(_,l,on_succ) ->
                let s = List.fold (fun s (_,body) -> s + term body) (term on_succ) l
                List.fold (fun s (id,_) -> s - id) s l
            | ERecordWith(_,a,b,c) ->
                let fold f a b = List.fold f b a
                List.fold (fun s (_,a) -> s + term a) empty a
                |> fold (fun s -> function
                        | RSymbolModify(_,a) | RSymbol(_,a) -> s + term a
                        | RVar((_,a),b) | RVarModify((_,a),b) -> s + term a + term b
                        ) b
                |> fold (fun s -> function
                    | WSymbol _ -> s
                    | WVar(_,a) -> s + term a
                    ) c
            | EOp(_,_,a) -> List.fold (fun s a -> s + term a) empty a
            | EMutableSet(_,a,b,c) -> term a + List.fold (fun s (_,a) -> s + term a) empty b + term c
            | EIfThenElse(_,a,b,c) -> term a + term b + term c
            | EExists(_,a,b) -> List.fold (fun s a -> s + ty a) (term b) a
            | EPatternMiss a | EReal(_,a) -> term a
            | EMacro(_,a,b) -> List.fold (fun s -> function MLitType x | MType x -> s + ty x | MTerm (x,_) -> s + term x | MText _ -> s) (ty b) a
            | EPatternMemo a -> Utils.memoize dict term a
            // Regular pattern matching
            | ELet(_,bind,body,on_succ) -> term on_succ - bind + term body
            | EUnbox(_,_,bind,body,on_succ,on_fail) -> term on_succ - bind + term body + term on_fail
            | EExistsTest(_,bind,pat_type,pat,on_succ,on_fail) -> singleton_term bind + (Array.fold (-.) (term on_succ) pat_type - pat) + term on_fail
            | EPairTest(_,bind,pat1,pat2,on_succ,on_fail) -> singleton_term bind + (term on_succ - pat1 - pat2) + term on_fail
            | ESymbolTest(_,_,bind,on_succ,on_fail) 
            | EUnitTest(_,bind,on_succ,on_fail) 
            | ELitTest(_,_,bind,on_succ,on_fail) -> singleton_term bind + term on_succ + term on_fail
            | ERecordTest(_,a,bind,on_succ,on_fail) ->
                let on_succ_and_injects =
                    let on_succ = List.fold (fun s (Symbol(_,a) | Var(_,a)) -> s - a) (term on_succ) a
                    List.fold (fun s -> function Var((_,a),_) -> s + term a | Symbol _ -> s) on_succ a // Though it is less efficient, I am using two passes here to guard against future changes to pattern compilation breaking this part by accident.
                singleton_term bind + term on_fail + on_succ_and_injects
            | EDefaultLitTest(_,_,t,bind,on_succ,on_fail)
            | EAnnotTest(_,t,bind,on_succ,on_fail) -> singleton_term bind + ty t + term on_succ + term on_fail
            | ENominalTest(_,t,bind,pat,on_succ,on_fail) -> singleton_term bind + ty t + (term on_succ - pat) + term on_fail
            | ETypecase(_,a,b) -> 
                List.fold (fun s (a,b) -> 
                    let a = ty a
                    let mutable b = term b
                    match a.ty.range with
                    | Some(a,a') -> for i=a to a' do b <- b -. i
                    | None -> ()
                    s + a + b
                    ) (ty a) b
        and ty = function
            | TExists | TJoinPoint' _ | TForall' _ | TArrow' _ | TSymbol _ | TPrim _ | TNominal _ | TLit _ | TB _ -> empty
            | TTypecase(_,a,b) -> 
                List.fold (fun s (a,b) -> 
                    let a = ty a
                    let mutable b = ty b
                    match a.ty.range with
                    | Some(a,a') -> for i=a to a' do b <- b -. i
                    | None -> ()
                    s + a + b
                    ) (ty a) b
            | TPatternRef a -> ty a.Value
            | TV i -> singleton_ty i
            | TMetaV i -> {empty with ty = {|empty.ty with range = Some(i,i)|} }
            | TApply(_,a,b) | TPair(_,a,b) | TFun(a,b,_) -> ty a + ty b
            | TUnion(_,(a,_)) -> a |> Map.fold (fun s k (a,b) -> s + ty a + (Option.map ty b |> Option.defaultValue empty)) empty
            | TRecord(_,a) -> Map.fold (fun s k v -> s + ty v) empty a
            | TModule a -> Map.fold (fun s k v -> s + ty v) empty a
            | TTerm(_,a) -> term a
            | TMacro(_,a) -> a |> List.fold (fun s -> function TMText _ -> s | TMLitType x | TMType x -> s + ty x) empty
            | TForall(_,i,a) | TArrow(i,a) as x -> scope x (ty a -. i)
            | TJoinPoint(_,a) as x -> scope x (ty a)
            | TArray(a) | TLayout(a,_) -> ty a

        let _ = match x with Choice1Of2 x -> term x | Choice2Of2 x -> ty x
        scope_dict

    /// ### ResolveEnvValue
    type ResolveEnvValue = {|term : Set<Id>; ty : Set<Id> |}

    /// ### ResolveEnv
    type ResolveEnv = Map<int, ResolveEnvValue>

    /// ### resolve_recursive_free_vars
    let resolve_recursive_free_vars env =
        Map.fold (fun (env : ResolveEnv) k v ->
            let has_visited = HashSet()
            let rec f (s : ResolveEnvValue) k v = 
                if has_visited.Add(k) then 
                    let s = Set.fold (fun s k -> if k < 0 then f s k env.[k] else {|s with term = Set.add k s.term|}) s v.term
                    Set.fold (fun s k -> {|s with ty = Set.add k s.ty|}) s v.ty
                else s
            Map.add k (f {|term=Set.empty; ty=Set.empty|} k v) env
            ) env env

    /// ### resolve
    let resolve (scope : Dictionary<obj,PropagatedVars>) x =
        let dict = Dictionary(HashIdentity.Reference)
        let subst' (env : ResolveEnv) (x : PropagatedVars) : PropagatedVars = 
            let f (s : ResolveEnvValue) x = 
                if x < 0 then 
                    match Map.tryFind x env with 
                    | Some x -> {|term=Set.union s.term x.term; ty=Set.union s.ty x.ty|}
                    | None -> {|s with term=Set.add x s.term|}
                else {|s with term=Set.add x s.term|}
            let fv = Set.fold f {|term=Set.empty; ty=Set.empty|} x.term.vars
            {term = {|x.term with vars = fv.term|}; ty = {|x.ty with vars = Set.union fv.ty x.ty.vars|} }
        let subst env (x : obj) = match scope.TryGetValue(x) with true, v -> scope.[x] <- subst' env v | _ -> ()
        let rec term (env : ResolveEnv) x =
            let f = term env
            match x with
            | EForall' _ | EFun' _ | ERecursiveForall' _ | ERecursiveFun' _ | ERecursive _ | EJoinPoint' _ | EModule _ | EV _ | ESymbol _ | ELit _ | EB _ -> ()
            | EPatternRef a -> f a.Value
            | EDefaultLit(_,_,a) | EPrototypeApply(_,_,a) | EType(_,a) | ETypePatternMiss a -> ty env a
            | EJoinPoint(_,a,b,_,_) | EFun(_,_,a,b) -> subst env x; f a; Option.iter (ty env) b
            | EForall(_,_,a) -> subst env x; f a
            | ERecBlock(r,a,b) ->
                // Goes over all the functions in a recursive block, resolving them.
                // The reason why this is sound is because the outer blocks are progressively resolved as they go in.
                let env = 
                    let l =
                        List.fold (fun s (id,body) ->
                            let x = subst' env scope.[body]
                            Map.add id {|term=x.term.vars; ty=x.ty.vars|} s
                            ) Map.empty a
                        |> resolve_recursive_free_vars
                    Map.foldBack Map.add l env
                a |> List.iter (fun (id,body) ->
                    scope.[body] <- 
                        let x = env.[id]
                        let v = scope.[body]
                        {term = {|v.term with vars = x.term |}; ty = {|v.ty with vars=x.ty|} }
                    term env body
                    )
                term env b
            | ERecordWith(_,a,b,c) ->
                List.iter (snd >> f) a
                b |> List.iter (function
                    | RSymbolModify(_,a) | RSymbol(_,a) -> f a
                    | RVarModify((_,a),b) | RVar((_,a),b) -> f a; f b)
                c |> List.iter (function 
                    | WSymbol _ -> ()
                    | WVar(_,a) -> f a)
            | ENominal(_,a,b) | ETypeApply(_,a,b) | EAnnot(_,a,b) -> f a; ty env b
            | EOp(_,_,a) -> List.iter f a
            | EExists(_,a,b) -> List.iter (ty env) a; f b 
            | EPatternMiss a | EReal(_,a) -> f a
            | EArray(_,a,b) -> List.iter f a; ty env b
            | EExistsTest(_,_,_,_,a,b)
            | EUnitTest(_,_,a,b) | ESymbolTest(_,_,_,a,b) | EPairTest(_,_,_,_,a,b) | ELitTest(_,_,_,a,b)
            | ELet(_,_,a,b) | EIfThen(_,a,b) | EPair(_,a,b) | ESeq(_,a,b) | EApply(_,a,b) -> f a; f b
            | EMutableSet(_,a,b,c) -> f a; List.iter (snd >> f) b; f c
            | EUnbox(_,_,_,a,b,c) | EIfThenElse(_,a,b,c) -> f a; f b; f c
            | EMacro(_,a,b) ->
                a |> List.iter (function MLitType a | MType a -> ty env a | MTerm (a,_) -> f a | MText _ -> ())
                ty env b
            | EPatternMemo a -> Utils.memoize dict f a
            | ERecordTest(_,l,_,a,b) -> 
                l |> List.iter (function Symbol _ -> () | Var((_,a),_) -> f a)
                f a; f b
            | EDefaultLitTest(_,_,t,_,a,b) | ENominalTest(_,t,_,_,a,b) | EAnnotTest(_,t,_,a,b) -> ty env t; f a; f b
            | ETypecase(_,a,b) -> ty env a; b |> List.iter (fun (a,b) -> ty env a; term env b)

        and ty (env : ResolveEnv) x = 
            let f = ty env
            match x with
            | TExists | TJoinPoint' _ | TForall' _ | TArrow' _ | TNominal _ | TPrim _ | TSymbol _ | TV _ | TMetaV _ | TLit _ | TB _ -> ()
            | TTypecase(_,a,b) -> ty env a; b |> List.iter (fun (a,b) -> ty env a; ty env b)
            | TPatternRef a -> f a.Value
            | TForall(_,_,a)
            | TArrow(_,a) -> subst env x; f a
            | TApply(_,a,b) | TFun(a,b,_) | TPair(_,a,b) -> f a; f b
            | TUnion(_,(a,_)) -> a |> Map.iter (fun _ (a,b) -> f a; Option.iter f b)
            | TRecord(_,a) -> Map.iter (fun _ -> f) a
            | TModule a -> Map.iter (fun _ -> f) a
            | TTerm(_,a) -> term env a
            | TMacro(_,a) -> a |> List.iter (function TMText _ -> () | TMLitType a | TMType a -> f a)
            | TJoinPoint(_,a) | TLayout(a,_) | TArray(a) -> f a

        match x with
        | Choice1Of2 x -> term Map.empty x
        | Choice2Of2 x -> ty Map.empty x

    /// ### LowerSubEnv
    type LowerSubEnv = {|var : Map<int,int>; adj : int|}

    /// ### LowerEnv
    type LowerEnv = {term : LowerSubEnv; ty : LowerSubEnv }

    /// ### LowerEnvRec
    type LowerEnvRec = Map<int,LowerEnv -> E>

    /// ### lower
    let lower (scope : Dictionary<obj,PropagatedVars>) x =
        let dict = Dictionary(HashIdentity.Reference)
        let scope (env : LowerEnv) x =
            let v = scope.[x]
            let fv v env = v |> Set.toArray |> Array.map (fun i -> Map.find i env)
            let sz = function Some(min',max') -> max' - min' + 1 | None -> 0
            let scope : Scope = {
                term = {|free_vars = fv v.term.vars env.term.var; stack_size = sz v.term.range|}
                ty = {|free_vars = fv v.ty.vars env.ty.var; stack_size = sz v.ty.range|}
                }

            let vars v = Set.fold (fun (s,i) x -> Map.add x i s,i+1) (Map.empty, 0) v |> fst
            let adj len = function Some(min',_) -> len - min' | None -> 0
            let env : LowerEnv = {
                term = {|var = vars v.term.vars; adj = adj scope.term.free_vars.Length v.term.range|}
                ty = {|var = vars v.ty.vars; adj = adj scope.ty.free_vars.Length v.ty.range|}
                }

            scope, env

        let adj_term (env : LowerEnv) i = 
            let i' = i + env.term.adj
            i', {env with term = {|env.term with var = Map.add i i' env.term.var|}}
        let adj_ty (env : LowerEnv) i =
            let i' = i + env.ty.adj
            i', {env with ty = {|env.ty with var = Map.add i i' env.ty.var|}}

        let rec term (env_rec : LowerEnvRec) (env : LowerEnv) x = 
            let f = term env_rec env
            let g = ty env_rec
            match x with
            | EForall' _ | EJoinPoint' _ | EFun' _ | ERecursiveForall' _ | ERecursiveFun' _ | ERecursive _ | EModule _ | ESymbol _ | ELit _ | EB _ -> x
            | EPatternRef a -> f a.Value
            | EFun(r,pat,body,t) -> 
                let scope, env = scope env x 
                let pat, env = adj_term env pat
                assert (scope.term.free_vars.Length = pat)
                EFun'(r,scope,pat,term env_rec env body,Option.map (g env) t)
            | EForall(r,pat,body) ->
                let scope, env = scope env x 
                let pat, env = adj_ty env pat
                assert (scope.ty.free_vars.Length = pat)
                EForall'(r,scope,pat,term env_rec env body)
            | EJoinPoint(r,body,t,q,name) ->
                let scope, env = scope env x 
                EJoinPoint'(r,scope,term env_rec env body,Option.map (g env) t,q,name)
            | EV i when 0 <= i -> EV env.term.var.[i]
            | EV i -> env_rec.[i] env
            | EDefaultLit(r,a,b) -> EDefaultLit(r,a,g env b)
            | EType(r,a) -> EType(r,g env a)
            | ETypePatternMiss a -> ETypePatternMiss(g env a)
            | EApply(r,a,b) -> EApply(r,f a,f b)
            | ETypeApply(r,a,b) -> ETypeApply(r,f a,g env b)
            | ENominal(r,a,b) -> ENominal(r,f a,g env b)
            | ERecBlock(r,a,b) ->
                let l,env_rec =
                    List.mapFold (fun (env_rec : LowerEnvRec) (i,body) ->
                        let re = ref Unchecked.defaultof<_>
                        let eval env_rec = 
                            let _,env = scope env body
                            re.Value <-
                                match body with
                                | EFun(_,i,body,_) ->
                                    let _,env = adj_term env i
                                    term env_rec env body
                                | EForall(_,i,body) -> 
                                    let _,env = adj_ty env i
                                    term env_rec env body
                                | _ -> failwith "Compiler error: Expected a fun or a forall."
                        let body env =
                            let scope,env = scope env body
                            match body with
                            | EFun(r,i,_,d) -> 
                                let i,_ = adj_term env i
                                ERecursiveFun'(r,scope,i,re,d)
                            | EForall(r,i,_) -> 
                                let i,_ = adj_ty env i
                                ERecursiveForall'(r,scope,i,re)
                            | _ -> failwith "Compiler error: Expected a fun or a forall."
                        eval,Map.add i body env_rec
                        ) env_rec a
                List.iter (fun eval -> eval env_rec) l
                term env_rec env b
            | ERecordWith(r,a,b,c) ->
                let a = List.map (fun (r,a) -> r, f a) a
                let b = b |> List.map (function
                    | RSymbol(a,b) -> RSymbol(a,f b)
                    | RSymbolModify(a,b) -> RSymbolModify(a,f b)
                    | RVar((r,a),b) -> RVar((r,f a),f b)
                    | RVarModify((r,a),b) -> RVarModify((r,f a),f b)
                    )
                let c = c |> List.map (function
                    | WSymbol _ as x -> x
                    | WVar(r,a) -> WVar(r,f a)
                    )
                ERecordWith(r,a,b,c)
            | EOp(r,a,b) -> EOp(r,a,List.map f b)
            | EAnnot(r,a,b) -> EAnnot(r,f a,g env b)
            | EIfThenElse(r,a,b,c) -> EIfThenElse(r,f a,f b,f c)
            | EIfThen(r,a,b) -> EIfThen(r,f a,f b)
            | EArray(r,a,b) -> EArray(r,List.map f a, g env b)
            | EPair(r,a,b) -> EPair(r,f a,f b)
            | ESeq(r,a,b) -> ESeq(r,f a,f b)
            | EMutableSet(r,a,b,c) -> EMutableSet(r,f a,List.map (fun (a,b) -> a, f b) b,f c)
            | EPatternMiss a -> EPatternMiss(f a)
            | EReal(r,a) -> EReal(r,f a)
            | EExists(r,a,b) -> EExists(r,List.map (g env) a,f b)
            | EMacro(r,a,b) -> 
                let a = a |> List.map (function
                    | MText _ as x -> x
                    | MLitType a -> MLitType(g env a)
                    | MType a -> MType(g env a)
                    | MTerm (a,b) -> MTerm(f a,b)
                    )
                EMacro(r,a,g env b)
            | EPrototypeApply(r,a,b) -> EPrototypeApply(r,a,g env b)
            | EPatternMemo x -> Utils.memoize dict f x
            // Regular pattern matching
            | ELet(r,pat,body,on_succ) -> 
                let body = term env_rec env body
                let pat,env = adj_term env pat
                let on_succ = term env_rec env on_succ
                ELet(r,pat,body,on_succ)
            | EUnbox(r,q,pat,body,on_succ,on_fail) ->
                let body = term env_rec env body
                let on_fail = term env_rec env on_fail
                let pat,env = adj_term env pat
                let on_succ = term env_rec env on_succ
                EUnbox(r,q,pat,body,on_succ,on_fail)
            | EPairTest(r,i,pat1,pat2,on_succ,on_fail) -> 
                let on_fail = term env_rec env on_fail
                let i = env.term.var.[i]
                let pat1,env = adj_term env pat1
                let pat2,env = adj_term env pat2
                let on_succ = term env_rec env on_succ
                EPairTest(r,i,pat1,pat2,on_succ,on_fail)
            | EExistsTest(r,i,pat_type,pat,on_succ,on_fail) -> 
                let on_fail = term env_rec env on_fail
                let i = env.term.var.[i]
                let pat,env = adj_term env pat
                let pat_type,env = Array.mapFold adj_ty env pat_type
                let on_succ = term env_rec env on_succ
                EExistsTest(r,i,pat_type,pat,on_succ,on_fail)
            | ESymbolTest(r,a,i,on_succ,on_fail) -> 
                let on_fail = term env_rec env on_fail
                let i = env.term.var.[i]
                let on_succ = term env_rec env on_succ
                ESymbolTest(r,a,i,on_succ,on_fail)
            | ERecordTest(r,a,i,on_succ,on_fail) ->
                let on_fail = term env_rec env on_fail
                let b = env.term.var.[i]
                let a, env = 
                    List.mapFold (fun env x ->
                        match x with
                        | Symbol(a,b) -> let b,env = adj_term env b in Symbol(a,b), env
                        | Var((r,a),b) -> let b,env = adj_term env b in Var((r,f a),b), env
                        ) env a
                ERecordTest(r,a,b,term env_rec env on_succ,on_fail)
            | EAnnotTest(r,a,i,on_succ,on_fail) -> EAnnotTest(r,g env a,env.term.var.[i],f on_succ,f on_fail)
            | ELitTest(r,a,i,on_succ,on_fail) -> ELitTest(r,a,env.term.var.[i],f on_succ,f on_fail)
            | EUnitTest(r,i,on_succ,on_fail) -> EUnitTest(r,env.term.var.[i],f on_succ,f on_fail)
            | ENominalTest(r,a,i,pat,on_succ,on_fail) ->
                let on_fail = term env_rec env on_fail
                let i = env.term.var.[i]
                let pat, env = adj_term env pat
                let on_succ = term env_rec env on_succ
                ENominalTest(r,g env a,i,pat,on_succ,on_fail)
            | EDefaultLitTest(r,a,b,i,on_succ,on_fail) -> EDefaultLitTest(r,a,g env b,env.term.var.[i],f on_succ,f on_fail)
            | ETypecase(r,a,b) -> 
                let b = b |> List.map (fun (a,b) -> 
                    let metavars = Dictionary()
                    let mutable env_case = env
                    let a = 
                        ty' (Utils.memoize metavars (fun i ->
                            let i, env = adj_ty env_case i
                            env_case <- env
                            TMetaV i
                            )) env_rec env_case a
                    a, term env_rec env_case b
                    )
                ETypecase(r,g env a,b)
        and ty env_rec env x = ty' (fun _ -> failwith "Compiler error: TMetaV should not appear here.") env_rec env x
        and ty' case_tmetav env_rec env x =
            let f = ty' case_tmetav env_rec env
            match x with
            | TMetaV i -> case_tmetav i
            | TExists | TJoinPoint' _ | TForall' _ | TArrow' _ | TNominal  _ | TPrim _ | TSymbol _ | TLit _ | TB _ as x -> x
            | TTypecase(r,a,b) -> 
                let b = b |> List.map (fun (a,b) -> 
                    let metavars = Dictionary()
                    let mutable env_case = env
                    let a = 
                        ty' (Utils.memoize metavars (fun i ->
                            let i, env = adj_ty env_case i
                            env_case <- env
                            TMetaV i
                            )) env_rec env_case a
                    a, ty env_rec env_case b
                    )
                TTypecase(r,ty env_rec env a,b)
            | TPatternRef a -> f a.Value
            | TJoinPoint(r,a) as x ->
                let scope, env = scope env x
                TJoinPoint'(r,scope,ty env_rec env a)
            | TForall(r,a,b) as x ->  
                let scope, env = scope env x
                let a, env = adj_ty env a
                TForall'(r,scope,a,ty env_rec env b)
            | TArrow(a,b) as x ->  
                let scope, env = scope env x
                let a, env = adj_ty env a
                TArrow'(scope,a,ty env_rec env b)
            | TV i -> TV(env.ty.var.[i])
            | TPair(r,a,b) -> TPair(r,f a,f b)
            | TFun(a,b,t) -> TFun(f a,f b,t)
            | TRecord(r,a) -> TRecord(r,Map.map (fun _ -> f) a)
            | TModule a -> TModule(Map.map (fun _ -> f) a)
            | TUnion(r,(a,b)) -> TUnion(r,(Map.map (fun _ (a,b) -> f a, Option.map f b) a,b))
            | TApply(r,a,b) -> TApply(r,f a,f b)
            | TTerm(r,a) -> TTerm(r,term env_rec env a)
            | TMacro(r,a) ->
                let a = a |> List.map (function 
                    | TMText _ as x -> x
                    | TMType a -> TMType(f a)
                    | TMLitType a -> TMLitType(f a)
                    )
                TMacro(r,a)
            | TArray(a) -> TArray(f a)
            | TLayout(a,b) -> TLayout(f a,b)
        let env : LowerEnv = {
            term = {|var = Map.empty; adj = 0|}
            ty = {|var = Map.empty; adj = 0|}
            }
        match x with
        | Choice1Of2(x,ret) -> ret (term Map.empty env x)
        | Choice2Of2(x,ret) -> ret (ty Map.empty env x)

    /// ### PartEvalPrepassEnv
    type PartEvalPrepassEnv = {
        term : {| env : Map<string,E>; i : Id; i_rec : Id |}
        ty : {| env : Map<string,TPrepass>; i : Id |}
        }

    /// ### add_term
    let add_term (e : PartEvalPrepassEnv) k v = let term = e.term in {e with term = {|term with i = term.i+1; env = Map.add k v term.env|} }

    /// ### add_term_rec
    let add_term_rec (e : PartEvalPrepassEnv) k v = let term = e.term in {e with term = {|term with i_rec = term.i_rec-1; env = Map.add k v term.env|} }

    /// ### add_ty
    let add_ty (e : PartEvalPrepassEnv) k v = let ty = e.ty in {e with ty = {|ty with i = ty.i+1; env = Map.add k v ty.env|} }

    /// ### add_wildcard
    let add_wildcard (e : PartEvalPrepassEnv) = let ty = e.ty in {e with ty = {|ty with i = ty.i+1|} }

    /// ### add_term_var
    let add_term_var (e : PartEvalPrepassEnv) k = e.term.i, add_term e k (EV e.term.i)

    /// ### fresh_term_var
    let fresh_term_var (e : PartEvalPrepassEnv) = e.term.i, (let term = e.term in {e with term = {|term with i = term.i+1|} })

    /// ### fresh_ty_var
    let fresh_ty_var (e : PartEvalPrepassEnv) = e.ty.i, (let ty = e.ty in {e with ty = {|ty with i = ty.i+1|} })

    /// ### add_term_rec_var
    let add_term_rec_var (e : PartEvalPrepassEnv) k = e.term.i_rec, add_term_rec e k (EV e.term.i_rec)

    /// ### add_ty_var
    let add_ty_var (e : PartEvalPrepassEnv) k = e.ty.i, add_ty e k (TV e.ty.i)

    /// ### add_ty_wildcard
    let add_ty_wildcard (e : PartEvalPrepassEnv) = e.ty.i, add_wildcard e

    /// ### process_term
    let process_term (x : E) =
        let scope = propagate (Choice1Of2 x)
        resolve scope (Choice1Of2 x)
        lower scope (Choice1Of2(x,id))

    /// ### process_ty
    let process_ty (x : TPrepass) =
        let scope = propagate (Choice2Of2 x)
        resolve scope (Choice2Of2 x)
        lower scope (Choice2Of2(x,id))

    /// ### prepassModule_open
    let prepassModule_open (top_env : PrepassTopEnv) env a l =
        let a,b = 
            match top_env.term.[snd a], top_env.ty.[snd a] with
            | EModule a, TModule b ->
                List.fold (fun (a,b) (_,x) ->
                    match Map.find x a, Map.find x b with
                    | EModule a, TModule b -> a,b
                    | _ -> failwith "Compiler error: Module open's symbol index should have been validated."
                    ) (a,b) l
            | _ -> failwith "Compiler error: Module open should have been validated."
        {
        term = {|env.term with env = Map.foldBack Map.add a env.term.env|}
        ty = {|env.ty with env = Map.foldBack Map.add b env.ty.env|}
        }

    /// ### prepassPrepass
    let prepassPrepass package_id module_id path (top_env : PrepassTopEnv) =
        let p r = {path=path; range=r}
        let at_tag i = { package_id = package_id; module_id = module_id; tag = i }
        let v_term (env : PartEvalPrepassEnv) x = Map.tryFind x env.term.env |> Option.defaultWith (fun () -> top_env.term.[x])
        let v_ty (env : PartEvalPrepassEnv) x = Map.tryFind x env.ty.env |> Option.defaultWith (fun () -> top_env.ty.[x])

        // The functions in this block are basically renaming string id to int ids, in addition to pattern compilation.
        let rec compile_pattern (id : Id) (env : PartEvalPrepassEnv) (clauses : (Pattern * RawExpr) list) =
            let mutable term_var_count = env.term.i
            let mutable ty_var_count = env.ty.i
            let patvar () = let x = term_var_count in term_var_count <- term_var_count+1; x
            let ty_patvar () = let x = ty_var_count in ty_var_count <- ty_var_count+1; x
            let loop (pat, on_succ) on_fail =
                let mutable dict = Map.empty
                let mutable dict_type = Map.empty
                let pat_refs_term = ResizeArray()
                //let pat_ref_term x = let re = ref Unchecked.defaultof<_> in pat_refs_term.Add(x,dict,re); EPatternRef re
                let pat_ref_term' x k =
                    let re = ref Unchecked.defaultof<_>
                    let r = k (EPatternRef re)
                    pat_refs_term.Add(x,(dict,dict_type),re)
                    r
                let pat_refs_ty = ResizeArray()
                let pat_ref_ty x = let re = ref Unchecked.defaultof<_> in pat_refs_ty.Add(x,(dict,dict_type),re); TPatternRef re
                let rec cp id pat on_succ on_fail =
                    let v x =
                        match Map.tryFind x dict with
                        | Some x -> x
                        | None -> let v = patvar() in dict <- Map.add x v dict; v
                    let tv x =
                        match Map.tryFind x dict_type with
                        | Some x -> x
                        | None -> let v = ty_patvar() in dict_type <- Map.add x v dict_type; v
                    let step pat on_succ =
                        match pat with
                        | PatVar(_,x) -> v x, on_succ
                        | _ -> let id = patvar() in id, cp id pat on_succ on_fail
                    match pat with
                    | PatDefaultValue _ -> failwith "Compiler error: The default value should be filled."
                    | PatE _ -> on_succ
                    | PatB r -> EUnitTest(p r,id,on_succ,on_fail)
                    | PatVar(r,a) -> ELet(p r,v a,EV id,on_succ)
                    | PatAnnot(r,a,b) -> EAnnotTest(p r,pat_ref_ty b,id,cp id a on_succ on_fail,on_fail)
                    | PatPair(r,a,b) -> 
                        // Evaling the b then a causes the call args to be rotated in join points during peval. 
                        // This is not a problem, but it might be surprising if you aren't aware why that is happening.
                        // Swapping the next two statements would fix it for pairs.
                        let b,on_succ = step b on_succ
                        let a,on_succ = step a on_succ
                        EPairTest(p r,id,a,b,on_succ,on_fail)
                    | PatExists(r,l,b) -> 
                        let pat_type = List.map (snd >> tv) l |> List.toArray
                        let pat,on_succ = step b on_succ
                        EExistsTest(p r,id,pat_type,pat,on_succ,on_fail)
                    | PatArray(r,a) ->
                        let r = p r
                        let ar_ids,on_succ = List.mapFoldBack step a on_succ
                        let a_length = List.length a
                        let on_succ,_ = 
                            List.foldBack (fun id' (on_succ,i) -> 
                                ELet(r,id',EOp(r,ArrayIndex,[EV id; ELit(r,LitInt32 i)]),on_succ), i-1
                                ) ar_ids (on_succ, a_length - 1)
                        let id_length = EOp(r,ArrayLength,[EType(r,TPrim UInt64T); EV id])
                        let pat_length = ELit(r,LitUInt64(uint64 a_length))
                        EIfThenElse(r,EOp(r,EQ,[id_length;pat_length]),on_succ,on_fail)
                    | PatSymbol(r,a) -> ESymbolTest(p r,a,id,on_succ,on_fail)
                    | PatRecordMembers(r,items) ->
                        let inject_vars = Dictionary(HashIdentity.Reference)
                        List.iter (function
                            | PatRecordMembersSymbol _ -> ()
                            | PatRecordMembersInjectVar((_,var),_) -> 
                                match dict.TryGetValue(var) with
                                | true, x -> inject_vars.[var] <- EV x
                                | _ -> inject_vars.[var] <- v_term env var
                            ) items
                        let binds, on_succ =
                            List.mapFoldBack (fun item on_succ ->
                                match item with
                                | PatRecordMembersSymbol((r,keyword),name) -> let arg, on_succ = step name on_succ in Symbol((p r,keyword),arg), on_succ
                                | PatRecordMembersInjectVar((r,var),name) -> let arg, on_succ = step name on_succ in Var((p r,inject_vars.[var]),arg), on_succ
                                ) items on_succ
                        ERecordTest(p r,binds,id,on_succ,on_fail)
                    | PatOr(r,a,b) -> let on_succ = EPatternMemo on_succ in cp id a on_succ (cp id b on_succ on_fail)
                    | PatAnd(r,a,b) -> let on_fail = EPatternMemo on_fail in cp id a (cp id b on_succ on_fail) on_fail
                    | PatValue(r,x) -> ELitTest(p r,x,id,on_succ,on_fail)
                    | PatWhen(r,p',e) -> pat_ref_term' e (fun e -> cp id p' (EIfThenElse(p r, e, on_succ, on_fail)) on_fail)
                    | PatNominal(r,(_,a),l,b) -> 
                        let id', on_succ = step b on_succ
                        let a = List.fold (fun s (r',x) -> TApply(p (r +. r'),s,TSymbol(p r',x))) (v_ty env a) l
                        ENominalTest(p r,a,id,id',on_succ,on_fail)
                    | PatFilledDefaultValue(r,a,b) -> EDefaultLitTest(p r,a,pat_ref_ty b,id,on_succ,on_fail)
                    | PatDyn(r,a) -> let id' = patvar() in ELet(p r,id',EOp(p r,Dyn,[EV id]),cp id' a on_succ on_fail)
                    | PatUnbox(r,q,a) -> let id' = patvar() in EUnbox(p r,q,id',EV id,cp id' a on_succ on_fail,on_fail)
                (pat_refs_term, pat_refs_ty), pat_ref_term' on_succ (fun on_succ -> cp id pat on_succ (EPatternMemo on_fail))

            let l, e = List.mapFoldBack loop clauses (EPatternMiss(EV id))
            l |> List.iter (fun (terms,tys) -> // The reason I am not evaling it in place is because of the var count which is mutable. I need to deal with the patterns first before replacing the strings in the body.
                let env (dict,dict_type) = 
                    {env with 
                        term = {|env.term with i=term_var_count; env=dict |> Map.fold (fun s k v -> Map.add k (EV v) s) env.term.env|} 
                        ty = {|env.ty with i=ty_var_count; env=dict_type |> Map.fold (fun s k v -> Map.add k (TV v) s) env.ty.env|} 
                        }
                terms |> Seq.iter (fun (a,dict,b) -> b.Value <- term (env dict) a)
                tys |> Seq.iter (fun (a,dict,b) -> b.Value <- ty (env dict) a)
                )
            e
        and pattern_match (env : PartEvalPrepassEnv) r body clauses =
            match clauses with
            | [PatVar(_,x), on_succ] ->
                let id,env = add_term_var env x
                ELet(r,id,body,term env on_succ)
            | _ ->
                let id,env = fresh_term_var env
                ELet(r,id,body,compile_pattern id env clauses)
        and pattern_function env r clauses annot =
            match clauses with
            | [PatVar(_,x), on_succ] ->
                let id,env = add_term_var env x
                EFun(r,id,term env on_succ,annot)
            | _ ->
                let id,env = fresh_term_var env
                EFun(r,id,compile_pattern id env clauses,annot)
        and ty env x = ty' (fun _ -> failwith "Compiler error: RawTMetaVar should not appear here.") env x
        and ty' case_metavar (env : PartEvalPrepassEnv) x =
            let f = ty' case_metavar env
            match x with
            | RawTMetaVar(_,name) -> case_metavar (Some name)
            | RawTWildcard _ -> case_metavar None
            | RawTForall(r,a,b) ->
                let id, env = add_ty_var env (typevar_name a)
                TForall(p r,id,ty' case_metavar env b)
            | RawTB r -> TB (p r)
            | RawTLit (r, x) -> TLit(p r,x)
            | RawTVar(r,a) -> v_ty env a
            | RawTPair(r,a,b) -> TPair(p r,f a,f b)
            | RawTFun(r,a,b,t) -> TFun(f a,f b,t)
            | RawTExists(r,l,b) -> TExists
            | RawTRecord(r,l) -> TRecord(p r,Map.map (fun _ -> f) l)
            | RawTUnion(r,a,b,this) -> 
                let rec subst_vars_with_metavars vars a =
                    let f = subst_vars_with_metavars vars
                    match a with
                    | RawTTypecase _ | RawTUnion _ -> failwith "Compiler error: Not expecting typecase or union here."
                    | RawTVar(r,n) -> if List.contains n vars then RawTMetaVar(r,n) else a
                    | RawTPrim _ | RawTFilledNominal _ | RawTTerm _ | RawTSymbol _ | RawTLit _ | RawTMetaVar _ | RawTB _ | RawTWildcard _ -> a
                    | RawTPair(r,a,b) -> RawTPair(r,f a,f b)
                    | RawTFun(r,a,b,c) -> RawTFun(r,f a,f b,c)
                    | RawTArray(r,a) -> RawTArray(r,f a)
                    | RawTRecord(r,a) -> RawTRecord(r,Map.map (fun _ -> f) a)
                    | RawTApply(r,a,b) -> RawTApply(r,f a,f b)
                    | RawTForall(r,a,b) -> RawTForall(r,a,subst_vars_with_metavars (List.removeAt (List.findIndex ((=) (typevar_name a)) vars) vars) b)
                    | RawTExists(r,a,b) -> 
                        let f vars a = List.removeAt (List.findIndex ((=) (typevar_name a)) vars) vars
                        RawTExists(r,a,subst_vars_with_metavars (List.fold f vars a) b)
                    | RawTMacro(r,a) -> 
                        let f = function (RawMacroText _ | RawMacroTerm _ | RawMacroTypeLit _) as a -> a | RawMacroType(r,a) -> RawMacroType(r,f a)
                        RawTMacro(r, List.map f a)
                    | RawTLayout(r,a,b) -> RawTLayout(r,f a,b)

                let make_typecase x =
                    let rec loop vars x =
                        match x with
                        | RawTForall(_,a,b) -> loop (typevar_name a :: vars) b
                        | RawTFun(r,a,b,_) -> RawTTypecase(r,this,[subst_vars_with_metavars vars b,a])
                        | b -> let r = range_of_texpr b in RawTTypecase(r,this,[subst_vars_with_metavars vars b,RawTB r])
                    loop [] x |> f
                TUnion(p r,(Map.map (fun _ (is_gadt,x) -> f x, if is_gadt then Some (make_typecase x) else None) a,b))
            | RawTTypecase(r,a,b) ->
                let b = b |> List.map (fun (t,e) ->
                    let metavars = Dictionary()
                    let mutable env_case = env
                    let t = 
                        let f (id,env) = env_case <- env; TMetaV id
                        ty' (function
                            | None -> add_ty_wildcard env_case |> f
                            | Some name -> Utils.memoize metavars (add_ty_var env_case >> f) name
                            ) env t
                    t, ty env_case e
                    )
                TTypecase(p r,ty env a,b)
            | RawTSymbol(r,a) -> TSymbol(p r,a)
            | RawTApply(r,a,b) ->
                match f a, f b with
                | TRecord(_,a') & a, TSymbol(_,b') & b ->

                    match a' |> Map.tryPick (fun (_, k) v -> if k = b' then Some v else None) with
                    | Some x -> x
                    | None -> TApply(p r,a,b) // TODO: Will be an error during partial evaluation time. Could be substituted for an exception here, but I do not want to have errors during the prepass.
                | a,b -> TApply(p r,a,b)
            | RawTPrim(r,a) -> TPrim(a)
            | RawTTerm(r,a) -> TTerm(p r,term env a)
            | RawTMacro(r,l) -> 
                let f = function
                    | RawMacroText(r,a) -> TMText a
                    | RawMacroType(r,a) -> TMType(f a)
                    | RawMacroTypeLit(r,a) -> TMLitType(f a)
                    | RawMacroTerm _ -> failwith "Compiler error: Term vars should not appear on the type level."
                TMacro(p r,List.map f l)
            | RawTArray(r,a) -> TArray(f a)
            | RawTFilledNominal(r,a) -> TNominal a
            | RawTLayout(r,a,b) -> TLayout(f a,b)
        and term env x =
            let f = term env
            match x with
            | RawDefaultLit(r,a) -> failwith "Compiler error: Default values should have been annotated in `fill` by prepass time."
            | RawAnnot(_,RawDefaultLit(r,a),b) -> EDefaultLit(p r,a,ty env b)
            | RawAnnot(_,RawLit(r,a),b) -> EDefaultLit(p r,a.LitToString(),ty env b)
            | RawB r -> EB(p r)
            | RawV(r,a,_) -> v_term env a
            | RawLit(r,a) -> ELit(p r,a)
            | RawSymbol(r,a) -> ESymbol(p r,a)
            | RawType(r,a) -> EType(p r,ty env a)
            | RawMatch(r,a,b) -> pattern_match env (p r) (f a) b
            | RawFun(r,a) -> pattern_function env (p r) a None
            | RawAnnot(_,RawFun(r,a),t) -> pattern_function env (p r) a (Some (ty env t))
            | RawArray(r,a) -> failwith "Compiler error: The array should have been annotated in `fill` by prepass time."
            | RawAnnot(_,RawArray(r,a),b) -> EArray(p r,List.map f a,ty env b)
            | RawTypecase(r,a,b) ->
                let b = b |> List.map (fun (t,e) ->
                    let metavars = Dictionary()
                    let mutable env_case = env
                    let t = 
                        let f (id,env) = env_case <- env; TMetaV id
                        ty' (function
                            | None -> add_ty_wildcard env_case |> f
                            | Some name -> Utils.memoize metavars (add_ty_var env_case >> f) name
                            ) env t
                    t, term env_case e
                    )
                ETypecase(p r,ty env a,b)
            | RawFilledForall(r,name,b)
            | RawForall(r,((_,(name,_)),_),b) -> 
                let id, env = add_ty_var env name
                EForall(p r,id,term env b)
            | RawRecBlock(r,l,on_succ) ->
                let l,env = List.mapFold (fun env ((r,name),body) -> let id,env = add_term_rec_var env name in (id,body), env) env l
                ERecBlock(p r,List.map (fun (id,body) -> id, term env body) l,term env on_succ)
            | RawRecordWith(r,a,b,c) ->
                let a = List.map (fun a -> p (range_of_expr a), f a) a
                let b = b |> List.map (function
                    | RawRecordWithSymbol((r,a),b) -> RSymbol((p r,a),f b)
                    | RawRecordWithSymbolModify((r,a),b) -> RSymbolModify((p r,a),f b)
                    | RawRecordWithInjectVar((r,a),b) -> RVar((p r,v_term env a),f b)
                    | RawRecordWithInjectVarModify((r,a),b) -> RVarModify((p r,v_term env a),f b))
                let c = c |> List.map (function
                    | RawRecordWithoutSymbol(r,a) -> WSymbol(p r,a)
                    | RawRecordWithoutInjectVar(r,a) -> WVar(p r,v_term env a))
                ERecordWith(p r,a,b,c)
            | RawOp(r,a,b) -> EOp(p r,a,List.map f b)
            | RawJoinPoint(r,q,a,name) -> EJoinPoint(p r,f a,None,Option.map (fun (r',w) -> p r',w) q,name)
            | RawAnnot(_,RawJoinPoint(r,q,a,name),b) -> EJoinPoint(p r,f a,Some (ty env b),Option.map (fun (r',w) -> p r',w) q,name)
            | RawOpen (_,a,l,on_succ) -> term (prepassModule_open top_env env a l) on_succ
            | RawApply(r,a,b) ->
                let rec loop = function
                    | EModule a' & a, EPair(_,ESymbol(_, b'),b'') & b ->
                        match Map.tryFind b' a' with
                        | Some a -> loop (a,b'')
                        | None -> EApply(p r,a,b) // TODO: Will be an error during partial evaluation time. Could be substituted for an exception here, but I do not want to have errors during the prepass.
                    | EModule a' & a, ESymbol(_,b') & b ->
                        match Map.tryFind b' a' with
                        | Some a -> a
                        | None -> EApply(p r,a,b) // TODO: Ditto.
                    | a,EType(_,b) -> ETypeApply(p r,a,b)
                    | a,b -> EApply(p r,a,b)
                loop (f a, f b)
            | RawIfThenElse(r,a,b,c) -> EIfThenElse(p r,f a,f b,f c)
            | RawIfThen(r,a,b) -> EIfThen(p r,f a,f b)
            | RawPair(r,a,b) -> EPair(p r,f a,f b)
            | RawSeq(r,a,b) -> ESeq(p r,f a,f b)
            | RawHeapMutableSet(r,a,b,c) -> EMutableSet(p r,f a,List.map (fun a -> p (range_of_expr a), f a) b,f c)
            | RawReal(r,a) -> f a
            | RawExists(r,(_,Some a),b) -> EExists(p r, List.map (ty env) a, f b)
            | RawExists(_,(_,None),_) -> failwith "Compiler error: The exists' vars should have been added during `fill`."
            | RawMacro _ -> failwith "Compiler error: The macro's annotation should have been added during `fill`."
            | RawAnnot(_,RawMacro(r,a),b) ->
                let a = a |> List.map (function
                    | RawMacroText(r,a) -> MText a
                    | RawMacroTerm(r,a,b) -> MTerm(f a,b)
                    | RawMacroType(r,a) -> MType(ty env a)
                    | RawMacroTypeLit(r,a) -> MLitType(ty env a)
                    )
                EMacro(p r,a,ty env b)
            | RawMissingBody _ -> failwith "Compiler error: The missing body cases should have been validated."
            | RawAnnot(r,a,b) -> EAnnot(p r,f a,ty env b)

        let env : PartEvalPrepassEnv =
            {
            term = {|env=Map.empty; i=0; i_rec= -1|}
            ty = {|env=Map.empty; i=0|}
            }

        let eval_type ((r,(name,kind)) : HoVar) on_succ env =
            let id, env = add_ty_var env name
            TArrow(id,on_succ env)
        let eval_type' env l body = List.foldBack eval_type l body env |> process_ty

        {|
        base_type = process_ty
        filled_top = fun x ->
            let nominal_rec l =
                let env,_ = 
                    List.fold (fun (env,i) (r,(_,name),l,body) -> 
                        add_ty env name (TNominal (at_tag i)), i+1
                        ) (env, top_env.nominals_next_tag) l
                List.fold (fun (term,ty',nominals,i) (r, (_,name),l,body) -> 
                    let r = p r
                    let at_tag_i = at_tag i
                    let nom = TNominal at_tag_i
                    let bodyt = eval_type' env l (fun env -> TJoinPoint(p (range_of_texpr body), ty env body))
                    let term =
                        match body with
                        | RawTUnion(_,l,_,_) -> 
                            Map.fold (fun term (_,name) (is_gadt,_) ->
                                if is_gadt then
                                    let rec loop_outer = function
                                        | TArrow'(_,_,t) -> loop_outer t // GADTs have the foralls in their cases' type, not here.
                                        | TJoinPoint'(r,_,TUnion(_,(l,_))) -> 
                                            let rec loop vars = function
                                                | TForall'(r,scope,id,t) -> EForall(r,id,loop (id :: vars) t)
                                                | TFun(t,t',_) -> EFun(r,0,ENominal(r,EPair(r,ESymbol(r,name),EV 0),t'),Some(TFun(t,t',FT_Vanilla)))
                                                | t' -> ENominal(r,EPair(r,ESymbol(r,name),EB r),t')
                                            let t = l |> Map.pick (fun (_, k) v -> if k = name then Some v else None) |> fst
                                            loop [] t
                                        | _ -> failwith "Compiler error: Expected a join point with a gadt union."
                                    Map.add name (loop_outer bodyt |> process_term) term
                                else
                                    let rec loop vars = function
                                        | TArrow'(scope,id,t) -> EForall(r,id,loop (id :: vars) t)
                                        | TJoinPoint'(r,_,TUnion(_,(l,_))) -> 
                                            let t = l |> Map.pick (fun (_, k) v -> if k = name then Some v else None) |> fst
                                            let t' = List.foldBack (fun id nom -> TApply(r,nom,TV id)) vars nom
                                            match t with
                                            | TB _ -> ENominal(r,EPair(r,ESymbol(r,name),EB r),t')
                                            | _ -> EFun(r,0,ENominal(r,EPair(r,ESymbol(r,name),EV 0),t'),Some(TFun(t,t',FT_Vanilla)))
                                        | _ -> failwith "Compiler error: Expected a join point with an union."
                                    Map.add name (loop [] bodyt |> process_term) term
                                ) term l
                        | _ ->
                            let rec loop vars = function
                                | TArrow'(scope,id,t) -> EForall(r,id,loop (id :: vars) t)
                                | TJoinPoint'(r,_,t) -> 
                                    let t' = List.foldBack (fun id nom -> TApply(r,nom,TV id)) vars nom
                                    match t with
                                    | TB _ -> ENominal(r,EB r,t')
                                    | _ -> EFun(r,0,ENominal(r,EV 0,t'),Some(TFun(t,t',FT_Vanilla)))                                
                                | _ -> failwith "Compiler error: Expected a join point."
                            Map.add name (loop [] bodyt |> process_term) term
                    term,Map.add name nom ty', Map.add at_tag_i {|body=bodyt; name=name|} nominals, i+1
                    ) (Map.empty, Map.empty, Map.empty, top_env.nominals_next_tag) l
            match x with
            | FType(_,(_,name),l,body) -> AInclude {prepassTop_env_empty with ty = Map.add name (eval_type' env l (fun env -> ty env body)) Map.empty}
            | FNominal(r,a,b,c) ->
                let term,ty,nominals,i = nominal_rec [r,a,b,c]
                AInclude {prepassTop_env_empty with term = term; ty = ty; nominals = nominals; nominals_next_tag=i}
            | FNominalRec l ->
                let term,ty,nominals,i = nominal_rec l
                AInclude {prepassTop_env_empty with term = term; ty = ty; nominals = nominals; nominals_next_tag=i}
            | FInl(_,(_,name),body) -> AInclude {prepassTop_env_empty with term = Map.add name (term env body |> process_term) Map.empty}
            | FRecInl l ->
                let l, env = 
                    List.mapFold (fun env (_,(_,name),_ as x) -> 
                        let r = ref Unchecked.defaultof<_>
                        (x,r), add_term_rec env name (ERecursive r)
                        ) env l
                let term = 
                    List.fold (fun top_env_term ((_,(_,name),body),(r : ref<E>)) ->
                        r.Value <- term env body |> process_term
                        Map.add name r.Value top_env_term
                        ) Map.empty l
                AInclude {prepassTop_env_empty with term = term}
            | FPrototype(r,(_,name),_,_,_) ->
                let i = at_tag top_env.prototypes_next_tag
                let r = p r
                let x = EForall(r,0,EPrototypeApply(r,i,TV 0)) |> process_term
                AInclude {prepassTop_env_empty with term = Map.add name x Map.empty; prototypes_next_tag = i.tag+1}
            | FInstance(_,(_,prot_id),(_,ins_id),body) ->
                AInclude {prepassTop_env_empty with prototypes_instances = Map.add (prot_id,ins_id) (term env body |> process_term) Map.empty}
            | FOpen(r,a,b) ->
                let x = prepassModule_open top_env env a b
                AOpen {prepassTop_env_empty with term=x.term.env; ty=x.ty.env}
        |}

    /// ### prepassTop_env_default
    let prepassTop_env_default default_env =
        let convert_infer_to_prepass x = 
            let m = Dictionary(HashIdentity.Reference)
            let rec f = function
                | TyVar (_,{contents=Some x}) -> f x
                | TyVar (x,_) -> TV m.[x.name] 
                | TyPrim x -> TPrim x
                | TyArray x -> TArray (f x)
                | TyLayout(a,b) -> TLayout(f a,b)
                | TyInl(a,b) -> let i = m.Count in m.Add(a.name,i); TArrow(i,f b)
                | TyFun(a,b,t) -> TFun(f a, f b, t)
                | _ -> failwith "Compiler error: The base type in Infer is not supported in the prepass yet."
            f x

        List.fold (fun (top_env : PrepassTopEnv) (k, x) ->
            {top_env with ty = Map.add k ((prepassPrepass -1 0 "<base_types>" top_env).base_type (convert_infer_to_prepass x)) top_env.ty}
            ) prepassTop_env_empty (Infer.base_types default_env)

    /// ## PartEval
    // #r @"../../../../../../../.nuget/packages/softcircuits.ordereddictionary/3.2.0/lib/net8.0/SoftCircuits.OrderedDictionary.dll"

    // open System
    open System.Collections.Generic
    // open SoftCircuits.Collections
    // open Common

    /// ### Tag
    type Tag = int

    /// ### L<'a,'b when 'a: equality and 'a: comparison>
    type [<CustomComparison;CustomEquality>] L<'a,'b when 'a: equality and 'a: comparison> = 
        | L of 'a * 'b

        override a.Equals(b) =
            match b with
            | :? L<'a,'b> as b -> match a,b with L(a,_), L(b,_) -> a = b
            | _ -> false
        override a.GetHashCode() = match a with L(a,_) -> hash a
        interface IComparable with
            member a.CompareTo(b) =
                match b with
                | :? L<'a,'b> as b -> match a,b with L(a,_), L(b,_) -> compare a b
                | _ -> raise <| ArgumentException "Invalid comparison for T."

    /// ### H<'a when 'a : equality>
    type H<'a when 'a : equality>(x : 'a) = 
        let h = hash x

        member _.Item = x
        override _.Equals(b) =
            match b with
            | :? H<'a> as b -> Object.ReferenceEquals(x,b.Item)
            | _ -> false
        override _.GetHashCode() = h

    /// ### StackSize
    type StackSize = int

    /// ### Nominal
    type Nominal = {|body : TPrepass; id : GlobalId; name : string|} ConsedNode // TODO: When the time comes to implement incremental compilation, make the `body` field a weak reference.

    /// ### PartEvalMacro
    type PartEvalMacro = Text of string | Type of Ty | TypeLit of Ty
    and Ty =
        | YVoid
        | YB
        | YLit of Literal
        | YSymbol of string
        | YPair of Ty * Ty
        | YTypeFunction of body : TPrepass * ty : Ty [] * term_stack_size : StackSize * ty_stack_size : StackSize
        | YExists
        | YForall
        | YRecord of Map<int * string, Ty>
        | YPrim of PrimitiveType
        | YArray of Ty
        | YFun of Ty * Ty * FunType
        | YMacro of PartEvalMacro list
        | YNominal of Nominal
        | YApply of Ty * Ty
        | YLayout of Ty * Layout
        | YUnion of Union
        | YMetavar of Id
    and Data =
        | DB
        | DSymbol of string
        | DTLit of Literal
        | DPair of Data * Data
        | DFunction of body : E * annot : TPrepass option * term : Data [] * ty : Ty [] * term_stack_size : StackSize * ty_stack_size : StackSize
        | DForall of body : E * term : Data [] * ty : Ty [] * term_stack_size : StackSize * ty_stack_size : StackSize
        | DExists of vars_type : Ty [] * term : Data
        | DRecord of Map<int * string, Data>
        | DLit of Literal
        | DUnion of Data * Union
        | DNominal of Data * Ty
        | DV of TyV
        | DHashSet of HashSet<Data>
        | DHashMap of OrderedDictionary<Data,Data> * bool ref
    and TyV = L<Tag,Ty>
    // Unions always go through a join point which enables them to be compared via ref eqaulity.
    // tags and tag_cases are straightforward mapping from cases for the sake of efficiency.
    and Union = {|cases : Map<int * string, Ty>; layout : UnionLayout; tags : Dictionary<string, int>; tag_cases : (string * Ty) []; is_degenerate : bool|} H

    /// ### TermVar
    type TermVar =
        | WV of TyV
        | WLit of Literal

    /// ### RData
    type RData =
        | ReB
        | RePair of ConsedNode<RData * RData>
        | ReSymbol of string
        | ReFunction of ConsedNode<E * RData [] * Ty []> // T option and stack sizes are entirely dependent on the body. And unlike in v0.09/v0.1 there are no reified join points.
        | ReForall of ConsedNode<E * RData [] * Ty []>
        | ReExists of ConsedNode<Ty [] * RData>
        | ReRecord of ConsedNode<Map<int * string, RData>>
        | ReLit of Literal
        | ReTLit of Literal
        | ReUnion of ConsedNode<RData * Union>
        | ReNominal of ConsedNode<RData * Ty>
        | ReV of ConsedNode<Tag * Ty>
        | ReHashMap of ConsedNode<(RData * RData)[]>

    /// ### Trace
    type Trace = Range list

    /// ### JoinPointKey
    type JoinPointKey = 
        | JPMethod of (string ConsedNode * E) * ConsedNode<RData [] * Ty []>
        | JPClosure of (string ConsedNode * E) * ConsedNode<RData [] * Ty [] * Ty>

    /// ### JoinPointCall
    type JoinPointCall = JoinPointKey * TyV []

    /// ### CodeMacro
    type CodeMacro =
        | CMText of string
        | CMTerm of Data * is_inline : bool
        | CMType of Ty
        | CMTypeLit of Ty

    /// ### TypedBind
    type TypedBind =
        | TyLet of Data * Trace * TypedOp
        | TyLocalReturnOp of Trace * TypedOp * Data
        | TyLocalReturnData of Data * Trace

    and TypedOp = 
        | TyMacro of CodeMacro list
        | TyOp of Op * Data list
        | TyUnionBox of string * Data * Union
        | TyUnionUnbox of TyV list * Union * Map<string,Data list * TypedBind []> * TypedBind [] option
        | TyIntSwitch of TyV * TypedBind [] [] * TypedBind []
        | TyToLayout of Data * Ty
        | TyLayoutIndexAll of TyV
        | TyLayoutIndexByKey of TyV * string
        | TyLayoutMutableSet of TyV * string list * Data
        | TyFailwith of Ty * Data
        | TyApply of TyV * Data
        | TyConv of Ty * Data
        | TySizeOf of Ty
        | TyArrayLiteral of Ty * Data list
        | TyArrayCreate of Ty * Data
        | TyArrayLength of Ty * Data
        | TyStringLength of Ty * Data
        | TyIf of cond: Data * tr: TypedBind [] * fl: TypedBind []
        | TyWhile of cond: JoinPointCall * TypedBind []
        | TyDo of TypedBind []
        | TyIndent of TypedBind []
        | TyJoinPoint of JoinPointCall
        | TyBackend of (string ConsedNode * E) * ConsedNode<RData [] * Ty []> * Range

    /// ### UnionRewrite
    type UnionRewrite = UnionData of string * Data | UnionBlockers of string Set

    /// ### LangEnv
    type LangEnv = {
        trace : Trace
        seq : ResizeArray<TypedBind>
        cse : Dictionary<TypedOp, Data> list
        unions : Map<TyV, UnionRewrite>
        i : int ref
        env_global_type : Ty []
        env_global_term : Data []
        env_stack_type : Ty []
        env_stack_term : Data []
        backend : string ConsedNode
        globals : ResizeArray<string>
        }

    /// ### PartEvalTopEnv
    type PartEvalTopEnv = {
        prototypes_instances : Dictionary<GlobalId * GlobalId, E>
        nominals : Dictionary<GlobalId, Nominal>
        backend : string
        }

    /// ### PartEvalTypeError
    exception PartEvalTypeError of Trace * string

    /// ### raise_type_error
    let raise_type_error (d: LangEnv) x = raise (PartEvalTypeError(d.trace,x))

    /// ### data_to_rdata
    let data_to_rdata (d: LangEnv) (hc : HashConsTable) call_data =
        let hc x = hc.Add x
        let m = Dictionary(HashIdentity.Reference)
        let call_args = ResizeArray()
        let rec f x =
            Utils.memoize m (function
                | DPair(a,b) -> RePair(hc(f a, f b))
                | DSymbol a -> ReSymbol a
                | DFunction(a,_,b,c,_,_) -> ReFunction(hc(a,Array.map f b,c))
                | DForall(a,b,c,_,_) -> ReFunction(hc(a,Array.map f b,c))
                | DExists(a,b) -> ReExists(hc(a,f b))
                | DRecord l -> ReRecord(hc(Map.map (fun _ -> f) l))
                | DV(L(_,ty) as t) -> call_args.Add t; ReV(hc (call_args.Count-1,ty))
                | DLit a -> ReLit a
                | DTLit a -> ReTLit a
                | DUnion(a,b) -> ReUnion(hc(f a,b))
                | DNominal(a,b) -> ReNominal(hc(f a,b))
                | DB -> ReB
                | DHashMap(x,is_writable) when is_writable.Value = false -> x |> Seq.map (fun kv -> f kv.Key, f kv.Value) |> Seq.toArray |> hc |> ReHashMap
                | DHashMap _ -> raise_type_error d "The mutable compile time HashMap needs to be made immutable before it can be passed through a join point."
                | DHashSet _ -> raise_type_error d "The mutable compile-time HashSet cannot be passed through join points."
                ) x
        let x = Array.map f call_data
        call_args.ToArray(),x

    /// ### rename_global_term
    // This rename is a consideration for when I do incremental compilation.
    // In order to allow them to be cleaned by the garbage collection, I do not want the 
    // references to unused nodes to end up in anywhere other than join point keys (which will be weak).
    let rename_global_term (s : LangEnv) =
        let m = Dictionary(HashIdentity.Reference)
        let rec f x =
            Utils.memoize m (function
                | DPair(a,b) -> DPair(f a, f b)
                | DForall(body,a,b,c,d) -> DForall(body,Array.map f a,b,c,d)
                | DFunction(body,annot,a,b,c,d) -> DFunction(body,annot,Array.map f a,b,c,d)
                | DExists(annot,a) -> DExists(annot, f a)
                | DRecord l -> DRecord(Map.map (fun _ -> f) l)
                | DV(L(_,ty)) -> let x = DV(L(s.i.Value,ty)) in s.i.Value <- s.i.Value + 1; x
                | DUnion(a,b) -> DUnion(f a,b)
                | DNominal(a,b) -> DNominal(f a,b)
                | DSymbol _ | DLit _ | DTLit _ | DB as x -> x
                | DHashMap(x,is_writable) when is_writable.Value = false -> 
                    let q = OrderedDictionary(HashIdentity.Reference)
                    x |> Seq.iter (fun kv -> q.Add(f kv.Key, f kv.Value))
                    DHashMap(q,is_writable)
                | DHashMap _ -> raise_type_error s "The mutable compile time HashMap needs to be made immutable before it can be renamed."
                | DHashSet _ -> raise_type_error s "The mutable compile-time HashSets cannot be renamed."
                ) x
        {s with env_global_term = Array.map f s.env_global_term}

    /// ### data_free_vars
    let data_free_vars call_data =
        let m = HashSet(HashIdentity.Reference)
        let free_vars = ResizeArray()
        let rec f x =
            if m.Add x then
                match x with
                | DPair(a,b) -> f a; f b
                | DForall(_,a,_,_,_) | DFunction(_,_,a,_,_,_) -> Array.iter f a
                | DRecord l -> Map.iter (fun _ -> f) l
                | DV(L _ as t) -> free_vars.Add t
                | DExists(_,a) | DUnion(a,_) | DNominal(a,_) -> f a
                | DSymbol _ | DLit _ | DTLit _ | DB -> ()
                | DHashSet x -> Seq.iter f x
                | DHashMap(x,_) -> x |> Seq.iter (fun kv -> f kv.Value)
        f call_data
        free_vars.ToArray()

    /// ### data_free_vars_replace
    let data_free_vars_replace s (d : Dictionary<TyV,TyV>) (x : Data) =
        let m = Dictionary(HashIdentity.Reference)
        let rec f x =
            Utils.memoize m (function
                | DPair(a,b) -> DPair(f a, f b)
                | DForall(body,a,b,c,d) -> DForall(body,Array.map f a,b,c,d)
                | DFunction(body,annot,a,b,c,d) -> DFunction(body,annot,Array.map f a,b,c,d)
                | DExists(annot,a) -> DExists(annot, f a)
                | DRecord l -> DRecord(Map.map (fun _ -> f) l)
                | DV(tyv) -> DV(d[tyv])
                | DUnion(a,b) -> DUnion(f a,b)
                | DNominal(a,b) -> DNominal(f a,b)
                | DSymbol _ | DLit _ | DTLit _ | DB as x -> x
                | DHashMap(x,is_writable) -> 
                    let q = OrderedDictionary(HashIdentity.Reference)
                    x |> Seq.iter (fun kv -> q.Add(f kv.Key, f kv.Value))
                    DHashMap(q,ref is_writable.Value)
                | DHashSet _ -> 
                    raise_type_error s "The mutable compile-time HashSets cannot have their free vars replaced."
                ) x
        f x

    /// ### (|C|)
    let inline (|C|) (x : _ ConsedNode) = x.node

    /// ### (|C'|)
    let inline (|C'|) (x : _ ConsedNode) = x.node, x.tag

    /// ### rdata_free_vars
    let rdata_free_vars call_data =
        let m = HashSet(HashIdentity.Structural)
        let free_vars = ResizeArray()
        let rec g = function // Note: Using the same scheme as in `data_free_vars` would give wrong results here. Comparing the tags instead is a necessity.
            | RePair(C'((a,b),tag)) -> if m.Add tag then g a; g b
            | ReForall(C'((_,a,_),tag)) | ReFunction(C'((_,a,_),tag)) -> if m.Add tag then Array.iter g a
            | ReRecord(C'(l,tag)) -> if m.Add tag then Map.iter (fun _ -> g) l
            | ReV(C'((a,b),tag)) -> if m.Add tag then free_vars.Add(L(a,b))
            | ReExists(C'((_,a),tag)) | ReUnion(C'((a,_),tag)) | ReNominal(C'((a,_),tag)) -> if m.Add tag then g a
            | ReHashMap(C'(x,tag)) -> if m.Add tag then Array.iter (fun (k,v) -> g k; g v) x
            | ReSymbol _ | ReLit _ | ReTLit _ | ReB -> ()
        Array.iter g call_data
        free_vars.ToArray()

    /// ### data_term_vars'
    let data_term_vars' call_data =
        let term_vars = ResizeArray(64)
        let rec f = function
            | DPair(a,b) -> f a; f b
            | DForall(_,a,_,_,_) | DFunction(_,_,a,_,_,_) -> Array.iter f a
            | DRecord l -> Map.iter (fun _ -> f) l
            | DLit _ | DV _ as x -> term_vars.Add(x)
            | DExists(_,a) | DUnion(a,_) | DNominal(a,_) -> f a
            | DSymbol _ | DTLit _ | DB -> ()
            | DHashSet x -> Seq.iter f x
            | DHashMap(x,_) -> x |> Seq.iter (fun kv -> f kv.Value)
        f call_data
        term_vars.ToArray()

    /// ### data_nominals
    let data_nominals call_data =
        let term_vars = ResizeArray(64)
        let rec f = function
            | DPair(a,b) -> f a; f b
            | DForall(_,a,_,_,_) | DFunction(_,_,a,_,_,_) -> Array.iter f a
            | DRecord l -> Map.iter (fun _ -> f) l
            | DLit _ | DV _ 
            | DExists _ | DUnion _ | DNominal _ as x -> term_vars.Add(x)
            | DSymbol _ | DTLit _ | DB -> ()
            | DHashSet x -> Seq.iter f x
            | DHashMap(x,_) -> x |> Seq.iter (fun kv -> f kv.Value)
        f call_data
        term_vars.ToArray()

    /// ### data_term_vars
    let data_term_vars call_data =
        let term_vars = ResizeArray(64)
        let rec f = function
            | DPair(a,b) -> f a; f b
            | DForall(_,a,_,_,_) | DFunction(_,_,a,_,_,_) -> Array.iter f a
            | DRecord l -> Map.iter (fun _ -> f) l
            | DLit x -> term_vars.Add(WLit x)
            | DV x -> term_vars.Add(WV x)
            | DExists(_,a) | DUnion(a,_) | DNominal(a,_) -> f a
            | DSymbol _ | DTLit _ | DB -> ()
            | DHashSet x -> Seq.iter f x
            | DHashMap(x,_) -> x |> Seq.iter (fun kv -> f kv.Value)
        f call_data
        term_vars.ToArray()

    /// ### lit_to_primitive_type
    let lit_to_primitive_type = function
        | LitUInt8 _ -> UInt8T
        | LitUInt16 _ -> UInt16T
        | LitUInt32 _ -> UInt32T
        | LitUInt64 _ -> UInt64T
        | LitInt8 _ -> Int8T
        | LitInt16 _ -> Int16T
        | LitInt32 _ -> Int32T
        | LitInt64 _ -> Int64T
        | LitFloat32 _ -> Float32T
        | LitFloat64 _ -> Float64T   
        | LitBool _ -> BoolT
        | LitString _ -> StringT
        | LitChar _ -> CharT

    /// ### lit_to_ty
    let lit_to_ty x = lit_to_primitive_type x |> YPrim

    /// ### is_tco_compatible
    let is_tco_compatible = function 
        | TyApply _ | TyJoinPoint _ | TyArrayLiteral _ | TyUnionBox _ | TyToLayout _
        | TyIf _ | TyIntSwitch _ | TyUnionUnbox _ | TyArrayCreate _ | TyFailwith _ -> true 
        | _ -> false

    /// ### seq_apply
    let seq_apply (d: LangEnv) end_dat =
        let inline end_ () = d.seq.Add(TyLocalReturnData(end_dat,d.trace))
        if d.seq.Count > 0 then
            match d.seq.[d.seq.Count-1] with
            | TyLet(end_dat',a,b) when Object.ReferenceEquals(end_dat,end_dat') && is_tco_compatible b -> d.seq.[d.seq.Count-1] <- TyLocalReturnOp(a,b,end_dat')
            | _ -> end_()
        else end_()
        d.seq.ToArray()

    /// ### cse_tryfind
    let cse_tryfind (d: LangEnv) key =
        d.cse |> List.tryPick (fun x ->
            match x.TryGetValue key with
            | true, v -> Some v
            | _ -> None
            )

    /// ### cse_add
    let cse_add (d: LangEnv) k v = (List.head d.cse).Add(k,v)

    /// ### show_ty
    let show_ty x =
        let rec f prec x =
            let p = p prec
            match x with
            | YVoid -> "void"
            | YB -> "()"
            | YLit x -> show_lit x
            | YPair(a,b) -> p 25 (sprintf "%s * %s" (f 25 a) (f 24 b))
            | YSymbol x -> sprintf ".%s" x
            | YTypeFunction _ -> p 0 (sprintf "? => ?")
            | YForall -> p 0 (sprintf "forall ?. ?")
            | YExists -> p 0 (sprintf "exists ?. ?")
            | YRecord l -> sprintf "{%s}" (l |> Map.toList |> List.map (fun ((_,k),v) -> sprintf "%s : %s" k (f -1 v)) |> String.concat "; ")
            | YUnion l -> sprintf "{%s}" (l.Item.cases |> Map.toList |> List.map (fun ((_,k),v) -> sprintf "%s : %s" k (f -1 v)) |> String.concat " | ")
            | YPrim x -> show_primt x
            | YArray a -> p 30 (sprintf "array_base %s" (f 30 a))
            | YFun(a,b,FT_Vanilla) -> p 20 (sprintf "%s -> %s" (f 20 a) (f 19 b))
            | YFun(a,b,FT_Pointer) -> p 20 (sprintf "fptr (%s -> %s)" (f 20 a) (f 19 b))
            | YFun(a,b,FT_Closure) -> p 20 (sprintf "closure (%s -> %s)" (f 20 a) (f 19 b))
            | YMacro a -> p 30 (List.map (function TypeLit a | Type a -> f -1 a | Text a -> a) a |> String.concat "")
            | YApply(a,b) -> p 30 (sprintf "%s %s" (f 29 a) (f 30 b))
            | YLayout(a,b) -> p 30 (sprintf "%s %s" (show_layout_type b) (f 30 a))
            | YNominal x -> x.node.name
            | YMetavar _ -> "?"
        f -1 x

    /// ### show_data
    let show_data x =
        let rec f prec x =
            let p = p prec
            match x with
            | DB -> "()"
            | DPair(a,b) -> p 25 (sprintf "%s, %s" (f 25 a) (f 24 b))
            | DSymbol x -> sprintf ".%s" x
            | DFunction _ -> p 20 "? -> ?"
            | DForall _ -> p 0 "forall ?. ?"
            | DExists(a,b) ->
                let a = Array.map (show_ty >> sprintf "(%s)") a |> String.concat " "
                p 0 $"exists {a}. %s{f 0 b}"
            | DRecord l -> sprintf "{%s}" (l |> Map.toList |> List.map (fun ((_,k),v) -> sprintf "%s : %s" k (f -1 v)) |> String.concat "; ")
            | DLit a -> show_lit a
            | DTLit a -> $"`{show_lit a}"
            | DV(L(_,ty)) -> show_ty ty
            | DUnion(a,_) -> f prec a
            | DNominal(a,b) -> p 0 (sprintf "%s : %s" (f 0 a) (show_ty b))
            | DHashSet _ -> p 0 "<HashSet>"
            | DHashMap _ -> p 0 "<HashMap>"

        f -1 x

    /// ### is_lit
    let is_lit = function
        | DLit _ -> true
        | _ -> false

    /// ### is_numeric
    let is_numeric = function
        | YPrim (UInt8T | UInt16T | UInt32T | UInt64T 
            | Int8T | Int16T | Int32T | Int64T 
            | Float32T | Float64T) -> true
        | _ -> false

    /// ### is_signed_numeric
    let is_signed_numeric = function
        | YPrim (Int8T | Int16T | Int32T | Int64T | Float32T | Float64T) -> true
        | _ -> false

    /// ### is_non_float_primitive
    let is_non_float_primitive = function
        | YPrim (Float32T | Float64T) -> false
        | YPrim _ -> true
        | _ -> false

    /// ### is_primitive
    let is_primitive = function
        | YPrim _ -> true
        | _ -> false

    /// ### is_string
    let is_string = function
        | YPrim StringT -> true
        | _ -> false

    /// ### is_char
    let is_char = function
        | YPrim CharT -> true
        | _ -> false

    /// ### is_float
    let is_float = function
        | YPrim (Float32T | Float64T) -> true
        | _ -> false

    /// ### is_bool
    let is_bool = function
        | YPrim BoolT -> true
        | _ -> false

    /// ### is_int
    let is_int = function
        | YPrim (UInt32T | UInt64T | Int32T | Int64T) -> true
        | _ -> false

    /// ### is_int
    let is_any_int = function
        | YPrim (UInt8T | UInt16T | UInt32T | UInt64T 
            | Int8T | Int16T | Int32T | Int64T) -> true
        | _ -> false

    /// ### is_int64
    let is_int64 = function
        | YPrim Int64T -> true
        | _ -> false

    /// ### is_int32
    let is_int32 = function
        | YPrim Int32T -> true
        | _ -> false

    /// ### is_lit_zero
    let is_lit_zero = function
        | DLit a ->
            match a with
            | LitInt8 0y | LitInt16 0s | LitInt32 0 | LitInt64 0L
            | LitUInt8 0uy | LitUInt16 0us | LitUInt32 0u | LitUInt64 0UL
            | LitFloat32 0.0f | LitFloat64 0.0 -> true
            | _ -> false
        | _ -> false

    /// ### is_lit_one
    let is_lit_one = function
        | DLit a ->
            match a with
            | LitInt8 1y | LitInt16 1s | LitInt32 1 | LitInt64 1L
            | LitUInt8 1uy | LitUInt16 1us | LitUInt32 1u | LitUInt64 1UL
            | LitFloat32 1.0f | LitFloat64 1.0 -> true
            | _ -> false
        | _ -> false

    /// ### is_int_lit_zero
    let is_int_lit_zero = function
        | DLit a ->
            match a with
            | LitInt8 0y | LitInt16 0s | LitInt32 0 | LitInt64 0L
            | LitUInt8 0uy | LitUInt16 0us | LitUInt32 0u | LitUInt64 0UL -> true
            | _ -> false
        | _ -> false

    /// ### is_int_lit_one
    let is_int_lit_one = function
        | DLit a ->
            match a with
            | LitInt8 1y | LitInt16 1s | LitInt32 1 | LitInt64 1L
            | LitUInt8 1uy | LitUInt16 1us | LitUInt32 1u | LitUInt64 1UL -> true
            | _ -> false
        | _ -> false

    /// ### lit_zero
    let lit_zero = function
        | YPrim Int8T -> LitInt8 0y
        | YPrim Int16T -> LitInt16 0s
        | YPrim Int32T -> LitInt32 0
        | YPrim Int64T -> LitInt64 0L
        | YPrim UInt8T -> LitUInt8 0uy
        | YPrim UInt16T -> LitUInt16 0us
        | YPrim UInt32T -> LitUInt32 0u
        | YPrim UInt64T -> LitUInt64 0UL
        | YPrim Float32T -> LitFloat32 0.0f
        | YPrim Float64T -> LitFloat64 0.0
        | _ -> failwith "Compiler error: Expected a numeric value."

    /// ### vt
    let vt s i = if i < s.env_global_type.Length then s.env_global_type.[i] else s.env_stack_type.[i-s.env_global_type.Length]

    /// ### v
    let v s i = if i < s.env_global_term.Length then s.env_global_term.[i] else s.env_stack_term.[i-s.env_global_term.Length]

    /// ### add_trace
    let add_trace (s : LangEnv) r = {s with trace = r :: s.trace}

    /// ### store_term
    let store_term (s : LangEnv) i v = s.env_stack_term.[i-s.env_global_term.Length] <- v

    /// ### store_ty
    let store_ty (s : LangEnv) i v = s.env_stack_type.[i-s.env_global_type.Length] <- v

    /// ### is_unify
    let is_unify s x =
        let is_metavar = HashSet()
        let rec f = function
            | YB, YB | YExists, YExists | YForall, YForall -> true
            | YFun(a,b,t), YFun(a',b',t') -> t = t' && f (a,a') && f (b,b')
            | YApply(a,b), YApply(a',b')
            | YPair(a,b), YPair(a',b') -> f (a,a') && f (b,b')
            | YSymbol a, YSymbol b -> a = b
            | YTypeFunction(a,b,c,d), YTypeFunction(a',b',c',d') -> a = a' && Array.forall2 (fun b b' -> f (b,b')) b b' && c = c' && d = d'
            | YRecord a, YRecord a' -> Map.forall (fun k v' -> match Map.tryFind k a with Some v -> f (v, v') | None -> false) a'
            | YPrim a, YPrim a' -> a = a'
            | YArray a, YArray a' -> f (a, a')
            | YMacro a, YMacro a' ->
                List.forall2 (fun a a' ->
                    match a, a' with
                    | Text a, Text a' -> a = a'
                    | Type a, Type a' -> f (a,a')
                    | _ -> false
                    ) a a'
            | YNominal a, YNominal a' -> a = a'
            | YLayout(a,b), YLayout(a',b') -> f (a,a') && b = b'
            | YUnion a, YUnion a' -> a = a'
            | YLit a, YLit b -> a = b
            | a, YMetavar i -> (is_metavar.Add i && (store_ty s i a; true)) || a = vt s i
            | _ -> false
        f x

    /// ### PartEvalResult
    type PartEvalResult = {
        join_point_method : Dictionary<string ConsedNode * E,Dictionary<ConsedNode<RData [] * Ty []>,TypedBind [] option * Ty option * string option> * HashConsTable>
        join_point_closure : Dictionary<string ConsedNode * E,Dictionary<ConsedNode<RData [] * Ty [] * Ty>,(Data * TypedBind []) option> * HashConsTable>
        ty_to_data : Ty -> Data
        nominal_apply : Ty -> Ty
        globals : ResizeArray<string>
        }

    /// ### peval
    let peval (env : PartEvalTopEnv) (x : E) =
        let join_point_method = Dictionary(HashIdentity.Structural)
        let join_point_closure = Dictionary(HashIdentity.Structural)
        let join_point_type = Dictionary(HashIdentity.Structural)
        let backend_strings = HashConsTable()

        let rec ty_to_data s x =
            let f = ty_to_data s
            match x with
            | YVoid -> raise_type_error s "Compiler error: Cannot construct an instance of a void type."
            | YB -> DB
            | YPair(a,b) -> DPair(f a, f b) 
            | YSymbol a -> DSymbol a
            | YRecord l -> DRecord(Map.map (fun _ -> f) l)
            | YForall | YExists | YUnion _ | YLayout _ | YPrim _ | YArray _ | YFun _ | YMacro _ as x -> let r = DV(L(s.i.Value,x)) in s.i.Value <- s.i.Value + 1; r
            | YNominal _ | YApply _ as a -> DNominal(nominal_type_apply s a |> ty_to_data s, a)
            | YLit x -> DTLit x
            | YTypeFunction _ -> raise_type_error s "Cannot turn a type function into a runtime variable."
            | YMetavar _ -> raise_type_error s "Compiler error: Cannot turn a metavar into a runtime variable."
        and assert_ty_lit s = function 
            | YSymbol _ | YLit _ as x -> x
            | YNominal _ | YApply _ as x -> nominal_type_apply s x |> assert_ty_lit s
            | x -> raise_type_error s <| sprintf "Expected a type literal or a symbol.\nGot: %s" (show_ty x)
        and push_typedop_no_rewrite d op ret_ty =
            let ret = ty_to_data d ret_ty
            d.seq.Add(TyLet(ret,d.trace,op))
            ret
        and push_typedop (d: LangEnv) key ret_ty =
            match cse_tryfind d key with
            | Some x -> x
            | None ->
                let x = ty_to_data d ret_ty
                d.seq.Add(TyLet(x,d.trace,key))
                cse_add d key x
                x
        and push_op_no_rewrite' (d: LangEnv) op l ret_ty = push_typedop_no_rewrite d (TyOp(op,l)) ret_ty
        and push_op_no_rewrite d op a ret_ty = push_op_no_rewrite' d op [a] ret_ty
        and push_binop_no_rewrite d op (a,b) ret_ty = push_op_no_rewrite' d op [a;b] ret_ty
        and push_triop_no_rewrite d op (a,b,c) ret_ty = push_op_no_rewrite' d op [a;b;c] ret_ty

        and push_op' d op a ret_ty = push_typedop d (TyOp(op, a)) ret_ty
        and push_op d op a ret_ty = push_op' d op [a] ret_ty
        and push_binop d op (a,b) ret_ty = push_op' d op [a;b] ret_ty
        and push_triop d op (a,b,c) ret_ty = push_op' d op [a;b;c] ret_ty
        and closure_env s (body,annot,gl_term,gl_ty,sz_term,sz_ty) = {
            trace = s.trace
            seq = ResizeArray()
            cse = [Dictionary(HashIdentity.Structural)]
            unions = Map.empty
            i = ref 0
            env_global_type = gl_ty
            env_global_term = gl_term
            env_stack_type = Array.zeroCreate<_> sz_ty
            env_stack_term = Array.zeroCreate<_> sz_term
            backend = s.backend
            globals = s.globals
            }
        and closure_convert s (body,annot,gl_term,gl_ty,sz_term,sz_ty as args) =
            let join_point_key, call_args, fun_ty =
                let s : LangEnv = closure_env s args
                let domain, range, fun_ty = 
                    match ty s annot with
                    | YFun(a,b,_) as x -> a,b,x
                    | annot -> raise_type_error s <| sprintf "Expected a function type in annotation during closure conversion. Got: %s" (show_ty annot)
                let dict, hc_table = Utils.memoize join_point_closure (fun _ -> Dictionary(HashIdentity.Structural), HashConsTable()) (s.backend, body)
                let call_args, env_global_value = data_to_rdata s hc_table gl_term
                let join_point_key = hc_table.Add(env_global_value, s.env_global_type, fun_ty)

                match fun_ty with
                | YFun(_,_,FT_Pointer) when call_args.Length <> 0 -> raise_type_error s "Function pointers shouldn't have any runtime free variables in their environment."
                | _ -> ()

                match dict.TryGetValue(join_point_key) with
                | true, _ -> ()
                | false, _ ->
                    let s = rename_global_term s
                    let domain_data = ty_to_data s domain
                    s.env_stack_term.[0] <- domain_data
                    dict.[join_point_key] <- None
                    let seq,ty = term_scope'' s body (Some fun_ty)
                    dict.[join_point_key] <- Some(domain_data, seq)
                    let ty =
                        match ty with
                        | YRecord a ->
                            a
                            |> Seq.map (fun (KeyValue ((i, k), v)) ->
                                let i =
                                    match range with
                                    | YRecord a ->
                                        a |> Map.tryPick (fun (i', k') _ -> if k = k' then Some i' else None)
                                    | _ -> None
                                    |> Option.defaultValue i
                                (i, k), v
                            )
                            |> Map.ofSeq
                            |> YRecord
                        | _ -> ty
                    if range <> ty then raise_type_error s <| sprintf "The annotation of the function does not match its body's type.\nGot: %s\nExpected: %s" (show_ty ty) (show_ty range)
                join_point_key, call_args, fun_ty
            push_typedop s (TyJoinPoint(JPClosure((s.backend,body),join_point_key),call_args)) fun_ty, fun_ty
        and data_to_ty s x =
            let m = Dictionary(HashIdentity.Reference)
            let rec f x =
                Utils.memoize m (function
                    | DPair(a,b) -> YPair(f a, f b)
                    | DSymbol a -> YSymbol a
                    | DRecord l -> YRecord(Map.map (fun _ -> f) l)
                    | DUnion(_,a) -> YUnion a
                    | DNominal(_,a) | DV(L(_,a)) -> a
                    | DLit x -> lit_to_ty x
                    | DTLit x -> YLit x
                    | DB -> YB
                    | DFunction(body,Some annot,gl_term,gl_ty,sz_term,sz_ty) -> ty (closure_env s (body,annot,gl_term,gl_ty,sz_term,sz_ty)) annot
                    | DExists _ -> YExists
                    | DFunction(_,None,_,_,_,_) -> raise_type_error s "Cannot convert a function that is not annotated into a type."
                    | DForall _ -> YForall
                    | DHashSet _ -> raise_type_error s "Cannot convert a compile time HashSet into a type."
                    | DHashMap _ -> raise_type_error s "Cannot convert a compile time HashMap into a type."
                    ) x
            f x
        and dyn do_lit s x =
            let m = Dictionary(HashIdentity.Reference)
            let mutable dirty = false
            let rec f x =
                Utils.memoize m (function
                    | DPair(a,b) -> DPair(f a, f b)
                    | DB | DV _ | DTLit _ | DSymbol _ as a -> a
                    | DRecord l -> DRecord(Map.map (fun _ -> f) l)
                    | DNominal(DUnion(DPair(DSymbol k,v),b),b') -> dirty <- true; push_typedop_no_rewrite s (TyUnionBox(k,f v,b)) b'
                    | DUnion _ -> raise_type_error s "Compiler error: Malformed union"
                    | DNominal(a,b) -> DNominal(f a,b)
                    | DLit (LitString _ as v) -> dirty <- true; push_op s Dyn x (lit_to_ty v)
                    | DLit v as x -> if do_lit then dirty <- true; push_op_no_rewrite s Dyn x (lit_to_ty v) else x
                    | DFunction(body,Some annot,term',ty',sz_term,sz_ty) -> dirty <- true; closure_convert s (body,annot,term',ty',sz_term,sz_ty) |> fst
                    | DFunction(_,None,_,_,_,_) -> raise_type_error s "Cannot convert a function that is not annotated into a runtime variable."
                    | DExists _ -> raise_type_error s "Cannot dyn an existential into a runtime var."
                    | DForall _ -> raise_type_error s "Cannot dyn a forall into a runtime var."
                    | DHashSet _ -> raise_type_error s "Cannot dyn a compile time HashSet into a runtime var."
                    | DHashMap _ -> raise_type_error s "Cannot dyn a compile time HashMap into a runtime var."
                    ) x
            let v = f x
            if dirty then v else x
        and term_real_nominal s x =
            let s = {s with seq=ResizeArray(); cse=Dictionary(HashIdentity.Structural) :: s.cse}
            term s x |> data_to_ty s
        and term_scope'' s x fun_ty =
            let x = term s x |> dyn false s
            let x =
                match x with
                | DRecord c ->
                    c
                    |> Seq.map (fun (KeyValue ((i, k), v)) ->
                        let i =
                            match fun_ty with
                            | Some (YFun (YNominal _, YRecord a, _) | YRecord a) ->
                                a |> Map.tryPick (fun (i', k') _ -> if k = k' then Some i' else None)
                            | _ -> None
                            |> Option.defaultValue i
                        (i, k), v
                    )
                    |> Map.ofSeq
                    |> DRecord
                | _ -> x
            let x_ty = data_to_ty s x
            seq_apply s x, x_ty
        and term_scope' s cse x = term_scope'' {s with seq=ResizeArray(); cse=cse :: s.cse} x None
        and term_scope s x = term_scope' s (Dictionary(HashIdentity.Structural)) x
        and nominal_type_apply s x =
            match x with
            | YApply(a,b) ->
                match nominal_type_apply s a with
                | YTypeFunction(body,gl_ty,sz_term,sz_ty) ->
                    let s =
                        {s with
                            env_global_type = gl_ty
                            env_global_term = [||]
                            env_stack_type = Array.zeroCreate<_> sz_ty
                            env_stack_term = Array.zeroCreate<_> sz_term
                            }
                    s.env_stack_type.[0] <- b
                    ty s body
                | a -> raise_type_error s <| sprintf "Expected a type level function in nominal application.\nGot: %s" (show_ty a)
            | YNominal a -> ty s a.node.body
            | _ -> raise_type_error s <| sprintf "Expected a nominal or a deferred type apply.\nGot: %s" (show_ty x)
        and ty s x =
            match x with
            | TPatternRef _ -> failwith "Compiler error: TPatternRef should have been eliminated during the prepass."
            | TForall _ | TArrow _ | TJoinPoint _ -> failwith "Compiler error: Should have been transformed during the prepass."
            | TMetaV i -> YMetavar i
            | TArrow'(scope,i,body) -> 
                assert (i = scope.ty.free_vars.Length)
                YTypeFunction(body,Array.map (vt s) scope.ty.free_vars,scope.term.stack_size,scope.ty.stack_size)
            | TForall' _ -> YForall
            | TExists -> YExists
            | TJoinPoint'(r,scope,body) ->
                let env_global_type = Array.map (vt s) scope.ty.free_vars
                let env_global_term = Array.map (v s) scope.term.free_vars

                let dict, hc_table = Utils.memoize join_point_type (fun _ -> Dictionary(HashIdentity.Structural), HashConsTable()) body
                let join_point_key = hc_table.Add(env_global_type)
                match dict.TryGetValue(join_point_key) with
                | true, Some ret_ty -> ret_ty
                | true, None -> raise_type_error (add_trace s r) "Type join points must not be unboxed during their definition."
                | false, _ ->
                    assert (0 = scope.term.free_vars.Length)
                    let s : LangEnv = {
                        trace = r :: s.trace
                        seq = ResizeArray()
                        cse = [Dictionary(HashIdentity.Structural)]
                        unions = Map.empty
                        i = ref 0
                        env_global_type = env_global_type
                        env_global_term = env_global_term
                        env_stack_type = Array.zeroCreate<_> scope.ty.stack_size
                        env_stack_term = Array.zeroCreate<_> scope.term.stack_size
                        backend = s.backend
                        globals = s.globals
                        }
                    let s = rename_global_term s
                    dict.[join_point_key] <- None
                    let ret_ty = ty s body
                    dict.[join_point_key] <- Some ret_ty
                    ret_ty
            | TB _ -> YB
            | TLit(_,x) -> YLit x
            | TV i -> vt s i
            | TPair(_,a,b) -> YPair(ty s a, ty s b)
            | TFun(a,b,t) -> YFun(ty s a, ty s b,t)
            | TModule a ->
                YRecord(
                    a
                    |> Seq.mapi (fun i (KeyValue (k, v)) -> (i, k), (v |> ty s))
                    |> Map.ofSeq
                )
            | TRecord(_,a) -> YRecord(Map.map (fun _ -> ty s) a)
            | TUnion(_,(a,b)) ->
                let tags = Dictionary()
                let tag_cases = Array.zeroCreate (Map.count a)
                let mutable is_degenerate = true
                let cases =
                    Map.fold (fun cases (i,k) v ->
                        let v = Option.defaultValue (fst v) (snd v) // If the union case is generalized, use the specialized destructor instead of the constructor to evaluate the type.
                        match ty s v with
                        | YVoid -> cases
                        | v ->
                            is_degenerate <- is_degenerate && match v with YB -> true | _ -> false
                            tags.[k] <- i
                            tag_cases.[i] <- (k,v)
                            Map.add (i,k) v cases
                        ) Map.empty a
                YUnion(H {|cases=cases; layout=b; tags=tags; tag_cases=tag_cases; is_degenerate=is_degenerate|})
            | TTypecase(r,a,b) ->
                let s = add_trace s r
                let a = ty s a
                let rec loop = function
                    | (a',b) :: rest -> if is_unify s (a,ty s a') then Some(ty s b) else loop rest
                    | [] -> None
                match loop b with
                | Some r -> r
                | None -> YVoid
            | TSymbol(_,a) -> YSymbol a
            | TApply(r,a,b) ->
                let s = add_trace s r
                match ty s a with
                | YRecord a ->
                    match ty s b with
                    | YSymbol b ->
                        match a |> Map.tryPick (fun (_, k) v -> if k = b then Some v else None) with
                        | Some x -> x
                        | None -> raise_type_error s <| sprintf  "Cannot find key %s in the record." b
                    | b -> raise_type_error s <| sprintf "Expected a symbol in the record application.\nGot: %s" (show_ty b)
                | YMetavar _ | YNominal _ | YApply _ as a -> YApply(a,ty s b)
                | YTypeFunction(body,gl_ty,sz_term,sz_ty) -> 
                    let b = ty s b
                    let s = 
                        {s with 
                            env_global_type = gl_ty
                            env_global_term = [||]
                            env_stack_type = Array.zeroCreate<_> sz_ty
                            env_stack_term = Array.zeroCreate<_> sz_term
                            }
                    s.env_stack_type.[0] <- b
                    ty s body
                | a -> raise_type_error s <| sprintf "Expected a record, nominal or a type function. Or a metavar when in typecase.\nGot: %s" (show_ty a)
            | TPrim a -> YPrim a
            | TTerm(_,a) -> term_real_nominal s a
            | TMacro(r,a) -> 
                let s = add_trace s r
                YMacro(a |> List.map (function TMText a -> Text a | TMType a -> Type(ty s a) | TMLitType a -> TypeLit(ty s a |> assert_ty_lit s)))
            | TNominal i -> YNominal env.nominals.[i]
            | TArray a -> YArray(ty s a)
            | TLayout(a,b) -> YLayout(ty s a,b)
        and term (s : LangEnv) x = 

            let global' =
                let has_added = HashSet s.globals
                fun x -> if has_added.Add(x) then s.globals.Add x

            let term2 s a b = term s a, term s b
            let term3 s a b c = term s a, term s b, term s c
            let type_apply s a b =
                match a with
                | DForall(body,gl_term,gl_ty,sz_term,sz_ty) ->
                    let s =
                        {s with 
                            env_global_type = gl_ty
                            env_global_term = gl_term
                            env_stack_type = Array.zeroCreate<_> sz_ty
                            env_stack_term = Array.zeroCreate<_> sz_term
                            }
                    s.env_stack_type.[0] <- b
                    term s body
                | DV(L(_,YForall)) -> raise_type_error s <| sprintf "Cannot apply a runtime forall during the partial evaluation stage."
                | a -> raise_type_error s <| sprintf "Expected a forall.\nGot: %s" (show_data a)

            let rec apply s = function
                | DNominal(DUnion _,_), _ -> raise_type_error s "Unions cannot be applied."
                | DNominal(a,_), b -> apply s (a,b)
                | DRecord a, DSymbol b ->
                    match a |> Map.tryPick (fun (_, k) v -> if k = b then Some v else None) with
                    | Some a -> a
                    | None -> raise_type_error s <| sprintf "Cannot find the key %s inside the record." b
                | DFunction(body,_,gl_term,gl_ty,sz_term,sz_ty), b ->
                    let s : LangEnv = 
                        {s with
                            env_global_type = gl_ty
                            env_global_term = gl_term
                            env_stack_type = Array.zeroCreate<_> sz_ty
                            env_stack_term = Array.zeroCreate<_> sz_term
                            }
                    s.env_stack_term.[0] <- b
                    term s body
                | DV(L(_,YForall)), _ -> raise_type_error s "Cannot apply a runtime forall, and not with a term. Foralls have to be known at compile time and applied with a type."
                | DForall _, _ -> raise_type_error s "Cannot apply a forall with a term."
                | DV(L(_,YFun(domain,range,t) & a_ty) & a), b ->
                    let b = dyn false s b
                    let b_ty = data_to_ty s b
                    if domain = b_ty then push_typedop_no_rewrite s (TyApply(a,b)) range
                    else raise_type_error s <| sprintf "Cannot apply an argument of type %s to a function of type: %s" (show_ty b_ty) (show_ty a_ty)
                | DV(L(i,YLayout(ty,layout)) as tyv) as a, DSymbol b -> 
                    let key = TyLayoutIndexByKey(tyv, b)
                    let ret_ty = 
                        match ty with
                        | YRecord r ->
                            match r |> Map.tryPick (fun (i, k) v -> if k = b then Some (i,v) else None) with
                            | Some (_i, a) -> a
                            | None -> raise_type_error s <| sprintf "Cannot find the key %s inside the layout type's record." b
                        | _ -> raise_type_error s <| sprintf "Expected a record inside the layout type.\nGot: %s" (show_ty ty)
                    match layout with
                    | Heap | StackMutable | HeapMutable -> push_typedop_no_rewrite s key ret_ty
                | DV(L(_,YLayout _)), b -> raise_type_error s <| sprintf "Expected a symbol as the index into the layout type.\nGot: %s" (show_data b)
                | a,_ -> raise_type_error s <| sprintf "Expected a function, closure, record or a layout type possibly inside a nominal.\nGot: %s" (show_data a)

            let rec if_ s cond on_succ on_fail = 
                match cond with
                | DLit (LitBool true) -> term s on_succ
                | DLit (LitBool false) -> term s on_fail
                | DV(L(_,YPrim BoolT & type_bool)) ->
                    let lit_tr = DLit(LitBool true)
                    match cse_tryfind s (TyOp(EQ, [cond; lit_tr])) with
                    | Some cond -> if_ s cond on_succ on_fail
                    | None ->
                        let lit_fl = DLit(LitBool false)
                        let add_rewrite_cases is_true = 
                            let cse = Dictionary(HashIdentity.Structural)
                            let tr,fl = if is_true then lit_tr, lit_fl else lit_fl, lit_tr
                            let inline op op cond' res = cse.Add(TyOp(op,[cond;cond']),res); cse.Add(TyOp(op,[cond';cond]),res)
                            op EQ lit_tr tr; op NEQ lit_tr fl; op EQ lit_fl fl; op NEQ lit_fl tr
                            cse
                        let tr, type_tr = term_scope' s (add_rewrite_cases true) on_succ
                        let fl, type_fl = term_scope' s (add_rewrite_cases false) on_fail
                        let type_tr, type_fl =
                            match type_tr, type_fl with
                            | YRecord tr, YRecord fl ->
                                let tr =
                                    tr
                                    |> Seq.map (fun (KeyValue ((i, k), v)) ->
                                        let i =
                                            fl |> Map.tryPick (fun (i', k') _ -> if k = k' then Some i' else None)
                                            |> Option.defaultValue i
                                        (i, k), v
                                    )
                                    |> Map.ofSeq
                                    |> YRecord

                                let fl =
                                    fl
                                    |> Seq.map (fun (KeyValue ((i, k), v)) ->
                                        k, ((i, k), v)
                                    )
                                    |> Seq.distinctBy fst
                                    |> Seq.map snd
                                    |> Map.ofSeq
                                    |> YRecord

                                tr, fl

                            | _ ->
                                type_tr, type_fl

                        if type_tr = type_fl then
                            if tr.Length = 1 && fl.Length = 1 then
                                match tr.[0], fl.[0] with
                                | TyLocalReturnOp(_,tr,_), TyLocalReturnOp(_,fl,_) when tr = fl -> push_typedop_no_rewrite s tr type_tr
                                | TyLocalReturnData(tr',_), TyLocalReturnData(fl',_) -> 
                                    match tr', fl' with
                                    | tr, fl when tr = fl -> tr
                                    | DLit(LitBool false), DLit(LitBool true) -> push_binop s EQ (cond,lit_fl) type_bool
                                    | DLit(LitBool false), fl when cond = fl -> lit_fl
                                    | DLit(LitBool true), fl -> // boolean or
                                        match fl with
                                        | DLit (LitBool false) -> cond
                                        | _ -> if cond = fl then cond else push_binop s BoolOr (cond,fl) type_bool
                                    | tr, DLit(LitBool false) -> // boolean and
                                        match tr with
                                        | DLit(LitBool true) -> cond
                                        | _ -> if cond = tr then cond else push_binop s BoolAnd (cond,tr) type_bool
                                    | _ -> push_typedop_no_rewrite s (TyIf(cond,tr,fl)) type_tr
                                | _ -> push_typedop_no_rewrite s (TyIf(cond,tr,fl)) type_tr
                            else push_typedop_no_rewrite s (TyIf(cond,tr,fl)) type_tr
                        else raise_type_error s <| sprintf "Types in branches of If do not match.\nGot: %s and %s" (show_ty type_tr) (show_ty type_fl)
                | cond -> raise_type_error s <| sprintf "Expected a bool in conditional.\nGot: %s" (show_data cond)

            let eq s a b = 
                let inline op a b = a = b
                match a,b with
                | DLit a, DLit b ->
                    match a, b with
                    | LitInt8 a, LitInt8 b -> op a b |> LitBool |> DLit
                    | LitInt16 a, LitInt16 b -> op a b |> LitBool |> DLit
                    | LitInt32 a, LitInt32 b -> op a b |> LitBool |> DLit
                    | LitInt64 a, LitInt64 b -> op a b |> LitBool |> DLit
                    | LitUInt8 a, LitUInt8 b -> op a b |> LitBool |> DLit
                    | LitUInt16 a, LitUInt16 b -> op a b |> LitBool |> DLit
                    | LitUInt32 a, LitUInt32 b -> op a b |> LitBool |> DLit
                    | LitUInt64 a, LitUInt64 b -> op a b |> LitBool |> DLit
                    | LitFloat32 a, LitFloat32 b -> op a b |> LitBool |> DLit
                    | LitFloat64 a, LitFloat64 b -> op a b |> LitBool |> DLit
                    | LitString a, LitString b -> op a b |> LitBool |> DLit
                    | LitChar a, LitChar b -> op a b |> LitBool |> DLit
                    | LitBool a, LitBool b -> op a b |> LitBool |> DLit
                    | a, b -> raise_type_error s <| sprintf "The two literals must be equal in type.\nGot: %s and %s" (show_lit a) (show_lit b)
                | DV(L(a,a_ty)), DV(L(b,_)) when a = b && is_non_float_primitive a_ty -> LitBool true |> DLit
                | a, b ->
                    let a_ty, b_ty = data_to_ty s a, data_to_ty s b
                    if a_ty = b_ty then
                        match a, b with
                        | DLit (LitBool true), x | x, DLit (LitBool true) -> x
                        | _ ->
                            if is_primitive a_ty then push_binop s EQ (a,b) (YPrim BoolT)
                            else raise_type_error s <| sprintf "The type of the two arguments needs to be a primitive type.\nGot: %s" (show_ty a_ty)
                    else
                        raise_type_error s <| sprintf "The two sides need to have the same primitive types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)    
            let default_lit s (a : string) b =
                let inline f string_to_val val_to_lit val_dsc =
                    match string_to_val a with
                    | true, x -> val_to_lit x
                    | false, _ -> raise_type_error s <| sprintf "Cannot parse the literal as: %s" val_dsc
                match b with
                | YPrim Float32T -> f Single.TryParse LitFloat32 "f32"
                | YPrim Float64T -> f Double.TryParse LitFloat64 "f64"
                | YPrim Int8T -> f SByte.TryParse LitInt8 "i8"
                | YPrim Int16T -> f Int16.TryParse LitInt16 "i16"
                | YPrim Int32T -> f Int32.TryParse LitInt32 "i32"
                | YPrim Int64T -> f Int64.TryParse LitInt64 "i64"
                | YPrim UInt8T -> f Byte.TryParse LitUInt8 "u8"
                | YPrim UInt16T -> f UInt16.TryParse LitUInt16 "u16"
                | YPrim UInt32T -> f UInt32.TryParse LitUInt32 "u32"
                | YPrim UInt64T -> f UInt64.TryParse LitUInt64 "u64"
                | b -> raise_type_error s <| sprintf "Expected a numberic type (f32,f64,i8,i16,i32,i64,u8,u16,u32,u64) as the type of literal.\nGot: %s" (show_ty b)

            let lit_test s a bind on_succ on_fail =
                let b = v s bind
                if lit_to_ty a = data_to_ty s b then if_ s (eq s (DLit a) b) on_succ on_fail
                else term s on_fail

            let inline nan_guardf32 x = if Single.IsNaN x then raise_type_error s "A 32-bit floating point operation resulting in a nan detected at compile time." else x
            let inline nan_guardf64 x = if Double.IsNaN x then raise_type_error s "A 64-bit floating point operation resulting in a nan detected at compile time." else x

            let eforall (free_vars : Scope,i,body) =
                assert (free_vars.ty.free_vars.Length = i)
                DForall(body,Array.map (v s) free_vars.term.free_vars,Array.map (vt s) free_vars.ty.free_vars,free_vars.term.stack_size,free_vars.ty.stack_size)

            let efun (free_vars : Scope,i,body,annot) =
                assert (free_vars.term.free_vars.Length = i)
                DFunction(body,annot,Array.map (v s) free_vars.term.free_vars,Array.map (vt s) free_vars.ty.free_vars,free_vars.term.stack_size,free_vars.ty.stack_size)

            let enominal (r,a,b) =
                let a = term s a
                let b = ty s b
                match nominal_type_apply s b with
                | YUnion h ->
                    match a with
                    | DPair(DSymbol k, v) ->
                        let v_ty = data_to_ty s v
                        match Map.tryPick (fun (_, name') v -> if k = name' then Some v else None) h.Item.cases with
                        | Some v_ty' when v_ty = v_ty' -> DNominal(DUnion(a,h),b) 
                        | Some v_ty' -> raise_type_error s <| sprintf "For key %s, The type of the value does not match the union case.\nGot: %s\nExpected: %s" k (show_ty v_ty) (show_ty v_ty')
                        | None -> raise_type_error s <| sprintf "The union does not have key %s.\nGot: %s" k (show_ty b)
                    | _ -> raise_type_error s <| sprintf "Expected key/value pair.\nGot: %s" (show_data a)
                | b' ->
                    let a =
                        match a with
                        | DRecord a ->
                            a
                            |> Seq.map (fun (KeyValue ((i, k), v)) ->
                                k, ((i, k), v)
                            )
                            |> Seq.distinctBy fst
                            |> Seq.map snd
                            |> Map.ofSeq
                            |> DRecord
                        | _ -> a

                    let a_ty = data_to_ty s a

                    if a_ty = b' then DNominal(a,b)
                    else raise_type_error s <| sprintf "Type error in nominal constructor.\nGot: %s\nExpected: %s" (show_ty a_ty) (show_ty b')

            let ty_union s x = 
                let x = ty s x
                match nominal_type_apply s x with
                | YUnion x -> x
                | _ -> raise_type_error s <| sprintf "Expected an union.\nGot: %s" (show_ty x)

            let ty_record s x =
                match ty s x with
                | YRecord l -> l
                | x -> raise_type_error s <| sprintf "Expected a type record.\nGot: %s" (show_ty x)

            let to_i32 x = 
                try 
                    match x with
                    | LitUInt8 x -> Convert.ToInt32(x)
                    | LitUInt16 x -> Convert.ToInt32(x)
                    | LitUInt32 x -> Convert.ToInt32(x)
                    | LitUInt64 x -> Convert.ToInt32(x)
                    | LitInt8 x -> Convert.ToInt32(x)
                    | LitInt16 x -> Convert.ToInt32(x)
                    | LitInt32 x -> Convert.ToInt32(x)
                    | LitInt64 x -> Convert.ToInt32(x)
                    | x -> raise_type_error s <| sprintf "Expected an int convertible to an i32.\nGot: %s" (show_lit x)
                with :? System.OverflowException -> raise_type_error s <| sprintf "The literal cannot be converted to an i32 as it is either too small or to big.\nGot: %s" (show_lit x)

            let record2 (a,b) (a',b') = DRecord(Map.empty |> Map.add a b |> Map.add a' b')
            let record3 (a,b) (a',b') (a'',b'') = DRecord(Map.empty |> Map.add a b |> Map.add a' b' |> Map.add a'' b'')

            match x with
            | EPatternRef _ -> failwith "Compiler error: EPatternRef should have been eliminated during the prepass."
            | EB _ -> DB
            | EV a -> v s a
            | ELit(_,a) -> DLit a
            | ESymbol(_,a) -> DSymbol a
            | EFun _ -> failwith "Compiler error: Raw functions should be transformed during the prepass."
            | EFun'(_,free_vars,i,body,annot) -> efun (free_vars,i,body,annot)
            | ERecursiveFun'(_,free_vars,i,body,annot) -> efun (free_vars,i,body.Value,annot)
            | EForall _ -> failwith "Compiler error: Raw foralls should be transformed during the prepass."
            | EForall'(_,free_vars,i,body) -> eforall (free_vars,i,body)
            | ERecursiveForall'(_,free_vars,i,body) -> eforall (free_vars,i,body.Value)
            | ERecursive a -> term s a.Value
            | ERecBlock _ -> failwith "Compiler error: Recursive blocks should be inlined and eliminated during the prepass."
            | EJoinPoint _ -> failwith "Compiler error: Raw join points should be transformed during the prepass."
            | EJoinPoint'(r,scope,body,annot,backend,jp_name) ->
                let env_global_type = Array.map (vt s) scope.ty.free_vars
                let env_global_term = Array.map (v s) scope.term.free_vars

                let backend' = match backend with None -> s.backend | Some (_,backend) -> backend_strings.Add backend
                let dict, hc_table = Utils.memoize join_point_method (fun _ -> Dictionary(HashIdentity.Structural), HashConsTable()) (backend', body)
                let call_args, env_global_value = data_to_rdata s hc_table env_global_term
                let join_point_key = hc_table.Add(env_global_value, env_global_type)

                let ret_ty =
                    match dict.TryGetValue(join_point_key) with
                    | true, (_, Some ret_ty, _) -> ret_ty
                    | true, (_, None, _) -> raise_type_error (add_trace s r) "Recursive join points must be annotated."
                    | false, _ ->
                        let s : LangEnv = {
                            trace = r :: s.trace
                            seq = ResizeArray()
                            cse = [Dictionary(HashIdentity.Structural)]
                            unions = Map.empty
                            i = ref 0
                            env_global_type = env_global_type
                            env_global_term = env_global_term
                            env_stack_type = Array.zeroCreate<_> scope.ty.stack_size
                            env_stack_term = Array.zeroCreate<_> scope.term.stack_size
                            backend = backend'
                            globals = s.globals
                            }
                        let s = rename_global_term s
                        let annot = Option.map (ty s) annot
                        dict.[join_point_key] <- (None, annot, jp_name)
                        let seq,ty = term_scope'' s body annot
                        dict.[join_point_key] <- (Some seq, Some ty, jp_name)
                        annot |> Option.iter (fun annot -> if annot <> ty then raise_type_error s <| sprintf "The annotation of the join point does not match its body's type.Got: %s\nExpected: %s" (show_ty ty) (show_ty annot))
                        ty

                match backend with
                | None -> push_typedop_no_rewrite s (TyJoinPoint(JPMethod((backend',body),join_point_key),call_args)) ret_ty
                | Some (range,_) ->
                    let _ = push_typedop_no_rewrite s (TyBackend((backend',body),join_point_key,range)) YB
                    let call_args = Array.foldBack (fun v s -> DPair(DV v,s)) call_args DB
                    call_args
            | EDefaultLit(r,a,b) -> let s = add_trace s r in default_lit s a (ty s b) |> DLit
            | EType(r,_) -> raise_type_error (add_trace s r) "Raw types are not allowed on the term level."
            | EApply(r,a,b) -> let s = add_trace s r in apply s (term s a, term s b)
            | ETypeApply(r,a,b) ->
                let s = add_trace s r
                type_apply s (term s a) (ty s b)
            | ERecordWith(r,vars,withs,withouts) ->
                let s = add_trace s r
                let map x =
                    let fold f a b = List.fold f b a
                    let var r a = 
                        match term s a with
                        | DSymbol a -> a
                        | a -> raise_type_error (add_trace s r) <| sprintf "Expected a symbol.\nGot: %s" (show_data a)
                    x |> fold (fun m x -> 
                        let sym a b =
                            let i =
                                m
                                |> Map.tryPick (fun (i, k) _v -> if k = a then Some i else None)
                                |> Option.defaultValue m.Count
                            Map.add (i, a) (term s b) m
                        let sym_mod r a b = 
                            match m |> Map.tryPick (fun (i, k) v -> if k = a then Some (i, v) else None) with
                            | Some (i, a') -> Map.add (i, a) (apply s (term s b, a')) m
                            | None -> raise_type_error (add_trace s r) "Cannot find key %s in record." a
                        match x with
                        | RSymbol((_,a),b) -> sym a b
                        | RSymbolModify((r,a),b) -> sym_mod r a b
                        | RVar((r,a),b) -> sym (var r a) b
                        | RVarModify((r,a),b) -> sym_mod r (var r a) b
                        ) withs
                    |> fold (fun m -> function
                        | WSymbol(r,a) ->
                            m |> Map.filter (fun (_, k) _ -> k <> a)
                        | WVar(r,a) ->
                            m |> Map.filter (fun (_, k) _ -> k <> var r a)
                        ) withouts

                let rec dive m = function
                    | (r,x) :: xs ->
                        let s = add_trace s r
                        match term s x with
                        | DSymbol b -> 
                            let v =
                                m |> Map.tryPick (fun (i, k) v -> if k = b then Some (i, v) else None)
                            match v with
                            | Some (i, DRecord a) -> Map.add (i, b) (DRecord (dive a xs)) m
                            | Some a -> raise_type_error s <| sprintf "Expected a record as the result of indexing.\nGot: %s" (show_data (a |> snd))
                            // match Map.tryFind b m with
                            // | Some (DRecord a) -> Map.add b (DRecord (dive a xs)) m
                            // | Some a -> raise_type_error s <| sprintf "Expected a record as the result of indexing.\nGot: %s" (show_data a)
                            | None -> raise_type_error s <| sprintf "Cannot find the key %s in a record." b
                        | b -> raise_type_error s <| sprintf "Expected a symbol.\nGot: %s" (show_data b)
                    | [] -> m |> map

                match vars with
                | (r,x) :: xs ->
                    match term s x with
                    | DRecord l -> dive l xs
                    | a -> raise_type_error s <| sprintf "Expected a record.\nGot: %s" (show_data a)
                | [] -> map Map.empty
                |> DRecord
            | EPatternMemo _ | EReal _ -> failwith "Compiler error: Should have been eliminated during the prepass."
            | EModule a -> DRecord(a |> Seq.map (fun (KeyValue (k, v)) -> (a.Count, k), (v |> term s)) |> Map.ofSeq)
            | EPair(r,a,b) -> DPair(term s a, term s b)
            | ESeq(r,a,b) -> 
                let s = add_trace s r
                match term s a with
                | DB -> term s b
                | a -> raise_type_error s <| sprintf "Expected unit.\nGot: %s" (show_data a)
            | EAnnot(r,a,b) ->
                let s = add_trace s r
                let a = term s a 
                let a_ty = data_to_ty s a
                let b = ty s b
                if a_ty <> b then raise_type_error s <| sprintf "The body does not match the annotation.\nGot: %s\nExpected: %s" (show_ty a_ty) (show_ty b)
                a            
            | EExists(r,a,b) ->
                let s = add_trace s r
                let a = List.map (ty s) a |> List.toArray
                let b = term s b
                DExists(a,b)
            | EPatternMiss a -> raise_type_error s <| sprintf "Pattern miss.\nGot: %s" (show_data (term s a))
            | ETypePatternMiss a -> raise_type_error s <| sprintf "Pattern miss.\nGot: %s" (show_ty (ty s a))
            | EIfThenElse(r,cond,tr,fl) -> let s = add_trace s r in if_ s (term s cond) tr fl
            | EIfThen(r,cond,tr) -> let s = add_trace s r in if_ s (term s cond) tr (EB r)
            | EMutableSet(r,a,b,c) ->
                let s = add_trace s r
                let a,a_layout_ty =
                    match term s a with
                    | DV(L(i,YLayout(a_layout_ty,(StackMutable | HeapMutable))) & a) -> a,a_layout_ty
                    | DV(L(_,YLayout _)) -> raise_type_error s "Expected a mutable layout type, but got an immutable one."
                    | a -> raise_type_error s <| sprintf "Expected a mutable layout type.\nGot: %s" (show_data a)
                let b = 
                    List.map (fun (r,b) -> 
                        match term s b with
                        | DSymbol b -> r,b
                        | b -> raise_type_error (add_trace s r) <| sprintf "Expected a symbol.\nGot: %s" (show_data b)
                        ) b
                let c_ty =
                    List.fold (fun (r,a) (r',b) ->
                        match a with
                        | YRecord a ->
                            match a |> Map.tryPick (fun (_, k) v -> if k = b then Some v else None) with
                            | Some a -> r', a
                            | None -> raise_type_error (add_trace s r) <| sprintf "Key %s not found in the layout type." b
                        | a -> raise_type_error (add_trace s r) <| sprintf "Expected a record.\nGot: %s" (show_ty a)
                        ) (r,a_layout_ty) b |> snd
                let c = term s c |> dyn false s
                let c =
                    match c with
                    | DRecord c ->
                        c
                        |> Seq.map (fun (KeyValue ((i, k), v)) ->
                            let i =
                                match c_ty with
                                | YRecord a ->
                                    a |> Map.tryPick (fun (i', k') _ -> if k = k' then Some i' else None)
                                | _ -> None
                                |> Option.defaultValue i
                            (i, k), v
                        )
                        |> Map.ofSeq
                        |> DRecord
                    | _ -> c
                let c_ty' = data_to_ty s c
                if c_ty' = c_ty then push_typedop_no_rewrite s (TyLayoutMutableSet(a,List.map snd b,c)) YB
                else raise_type_error s <| sprintf "The two side do not have the same type.\nGot: %s\nExpected: %s" (show_ty c_ty') (show_ty c_ty)
            | EMacro(r,a,b) ->
                let s = add_trace s r
                let a = a |> List.map (function MText x -> CMText x | MTerm (x,b) -> CMTerm(term s x |> dyn false s, b) | MType x -> CMType(ty s x) | MLitType x -> CMTypeLit(ty s x |> assert_ty_lit s))
                push_typedop_no_rewrite s (TyMacro(a)) (ty s b)
            | EPrototypeApply(_,prot_id,b) ->
                let rec loop = function
                    | YNominal b ->
                        match env.prototypes_instances.TryGetValue((prot_id,b.node.id)) with
                        | true,x -> term s x
                        | _ -> raise_type_error s "An instance of the prototype being applied could be found in the dictionary."
                    | YApply(a,b) -> type_apply s (loop a) b
                    | b -> raise_type_error s <| sprintf "Expected a nominal or a deferred type apply.\nGot: %s" (show_ty b)
                loop (ty s b)
            | EOp(r,NominalCreate,[a;EType(_,b)]) | ENominal(r,a,b) -> enominal (r,a,b)
            | EUnbox(r,k,id,a,on_succ,on_fail) ->
                let s = add_trace s r
                let run s a = store_term s id a; term s on_succ
                match term s a with
                | DNominal(DUnion(DPair(DSymbol k',a),_),_) -> if k = k' then run s a else term s on_fail
                | DNominal(DV(L(_,YUnion h) & i),_) ->
                    let body blk = 
                        match Map.tryPick (fun (_, name') v -> if k = name' then Some v else None) h.Item.cases with
                        | Some v when Set.contains k blk = false ->
                            let on_succ, ret_ty = 
                                let a = ty_to_data s v
                                let s = {s with unions = Map.add i (UnionData (k,a)) s.unions; cse = Dictionary(HashIdentity.Structural) :: s.cse; seq = ResizeArray()}
                                let x = run s a |> dyn false s
                                Map.add k ([a], (seq_apply s x)) Map.empty, data_to_ty s x
                            let on_succ,on_fails = 
                                let blk = Set.add k blk
                                if blk.Count = h.Item.cases.Count then on_succ, None // Have to do this otherwise it would have hit EPatternMiss
                                else
                                    let on_fails, ret_ty' = term_scope {s with unions = Map.add i (UnionBlockers blk) s.unions} on_fail
                                    if ret_ty <> ret_ty' then raise_type_error s $"The types of two branches of an union unbox do not match.\nGot: {show_ty ret_ty}\nAnd: {show_ty ret_ty'}"
                                    match on_fails with
                                    | [|TyLocalReturnOp(_,TyUnionUnbox([i'],_,on_succ',on_fail'),_)|] when i = i' -> Map.foldBack Map.add on_succ' on_succ , on_fail'
                                    | _ -> on_succ, Some on_fails
                            push_typedop_no_rewrite s (TyUnionUnbox([i],h,on_succ,on_fails)) ret_ty
                        | _ -> term s on_fail
                    match Map.tryFind i s.unions with
                    | Some (UnionData (k',a)) -> if k = k' then run s a else term s on_fail
                    | Some (UnionBlockers blk) -> body blk
                    | None -> body Set.empty
                | _ -> term s on_fail
            | EOp(r,Unbox,[a;on_succ]) -> 
                let s = add_trace s r
                let on_succ = term s on_succ
                let run s a = apply s (on_succ,a)
                match term s a with
                | DNominal(DUnion(a,_),_) -> run s a 
                | DNominal(DV(L(_,YUnion h) & i) & a,_) ->
                    let body blk = 
                        let cases, case_ty =
                            Map.fold (fun (m, case_ty) (_, k) v ->
                                if Set.contains k blk = false then
                                    let a = ty_to_data s v
                                    let s = {s with unions = Map.add i (UnionData (k,a)) s.unions; cse = Dictionary(HashIdentity.Structural) :: s.cse; seq = ResizeArray()}
                                    let x = run s (DPair(DSymbol k, a)) |> dyn false s
                                    let x_ty' = data_to_ty s x
                                    let case_ty = 
                                        match case_ty with
                                        | Some x_ty when x_ty' <> x_ty -> raise_type_error s <| sprintf "One union case for key %s has a different return that the previous one.\nGot: %s\nExpected: %s" k (show_ty x_ty') (show_ty x_ty)
                                        | Some _ -> case_ty
                                        | None -> Some x_ty'
                                    Map.add k ([a], seq_apply s x) m, case_ty
                                else
                                    m, case_ty
                                ) (Map.empty,None) h.Item.cases
                        push_typedop_no_rewrite s (TyUnionUnbox([i],h,cases,None)) (Option.get case_ty)
                    match Map.tryFind i s.unions with
                    | Some (UnionData (k,a)) -> run s (DPair(DSymbol k, a))
                    | Some (UnionBlockers blk) -> body blk
                    | None -> body Set.empty
                | a -> raise_type_error s <| sprintf "Expected an union type.\nGot: %s" (show_data a)
            | EOp(r,Unbox2,[a;b;on_succ;on_fail]) ->
                let s = add_trace s r
                let on_succ = term s on_succ
                let on_fail = term s on_fail
                let mutable case_ty = None
                let s' () = {s with cse = Dictionary(HashIdentity.Structural) :: s.cse; seq = ResizeArray()}
                let assert_case_ty s x =
                    let x_ty' = data_to_ty s x
                    match case_ty with
                    | Some x_ty -> if x_ty' <> x_ty then raise_type_error s <| sprintf "One union case has a different return than the previous one.\nGot: %s\nExpected: %s" (show_ty x_ty') (show_ty x_ty)
                    | None -> case_ty <- Some x_ty'
                let run s x =
                    let x = apply s x |> dyn false s
                    assert_case_ty s x
                    seq_apply s x
                let case_on_fail () = run (s'()) (on_fail, DB)
                let key_value = function
                    | DPair(DSymbol k, a) -> k, a
                    | _ -> failwith "Compiler error: Malformed union."
                match term s a, term s b with
                | DNominal(DUnion(_,h),_), DNominal(DUnion(_,h'),_) when h <> h' ->
                    raise_type_error s <| sprintf "The two variables have different union types.\nGot: %s\nGot: %s" (show_ty (YUnion h)) (show_ty (YUnion h'))
                | DNominal(DUnion(a,_),_), DNominal(DUnion(a',_),_) ->
                    let k,a = key_value a
                    let k',a' = key_value a'
                    if k = k' then apply s (on_succ, DPair(DSymbol k, DPair(a, a')))
                    else apply s (on_fail, DB)
                | DNominal(DV(L(_,YUnion h)),_), DNominal(DUnion(_,h'),_) | DNominal(DUnion(_,h),_), DNominal(DV(L(_,YUnion h')),_) when h <> h' ->
                    raise_type_error s <| sprintf "The two variables have different union types.\nGot: %s\nGot: %s" (show_ty (YUnion h)) (show_ty (YUnion h'))
                | DNominal(DV(L(_,YUnion h) & i),_), DNominal(DUnion(a',_),_) ->
                    let k,a' = key_value a'
                    let v = h.Item.cases |> Map.pick (fun (_, name') v -> if k = name' then Some v else None)
                    let case_on_succ =
                        let s = s'()
                        let a = ty_to_data s v
                        let s = {s with unions = Map.add i (UnionData (k,a)) s.unions}
                        [a], run s (on_succ, DPair(DSymbol k, DPair(a, a')))
                    push_typedop_no_rewrite s (TyUnionUnbox([i],h,Map.add k case_on_succ Map.empty,Some (case_on_fail()))) (Option.get case_ty)
                | DNominal(DUnion(a,_),_), DNominal(DV(L(_,YUnion h) & i'),_) ->
                    let k,a = key_value a
                    let v = h.Item.cases |> Map.pick (fun (_, name') v -> if k = name' then Some v else None)
                    let case_on_succ =
                        let s = s'()
                        let a' = ty_to_data s v
                        let s = {s with unions = Map.add i' (UnionData (k,a')) s.unions}
                        [a'], run s (on_succ, DPair(DSymbol k, DPair(a, a')))
                    push_typedop_no_rewrite s (TyUnionUnbox([i'],h,Map.add k case_on_succ Map.empty,Some (case_on_fail()))) (Option.get case_ty)
                | DNominal(DV(L(_,YUnion h & t)),_), DNominal(DV(L(_,YUnion h' & t')),_) when h <> h' -> 
                    raise_type_error s <| sprintf "The two variables have different union types.\nGot: %s\nGot: %s" (show_ty t) (show_ty t')
                | DNominal(DV(L(_,YUnion h) & i),_), DNominal(DV(L(_,YUnion _) & i'),_) ->
                    let cases_on_succ =
                        Map.map (fun (_, k) v ->
                            let s = s'()
                            let a,a' = ty_to_data s v, ty_to_data s v
                            let s = {s with unions = 
                                                let u = s.unions 
                                                let u = Map.add i (UnionData (k,a)) u
                                                Map.add i' (UnionData (k,a')) u
                                                }
                            [a;a'], run s (on_succ, DPair(DSymbol k, DPair(a, a')))
                            ) h.Item.cases
                        |> Seq.map (fun (KeyValue ((_, k), v)) -> k, v)
                        |> Map.ofSeq
                    push_typedop_no_rewrite s (TyUnionUnbox([i;i'],h,cases_on_succ,Some (case_on_fail()))) (Option.get case_ty)
                | a,a' -> raise_type_error s <| sprintf "Expected two union types.\nGot: %s\nAnd: %s" (show_data a) (show_data a')
            | EOp(r,UnionUntag,[EType(_,t);a;on_succ;on_fail]) ->
                let t = ty s t
                match nominal_type_apply s t with
                | YUnion h ->
                    let h = h.Item
                    let on_succ, on_fail = term s on_succ, term s on_fail
                    let lit i =
                        if 0 <= i && i < h.tag_cases.Length then
                            let k,v = h.tag_cases.[i]
                            type_apply s (apply s (on_succ, DSymbol k)) v
                        else raise_type_error s $"Invalid tag 0 <= {i} < {h.tag_cases.Length} in UnionUntag."
                    match term s a with
                    | DV(L(i,YPrim Int32T) as tyv) as a -> 
                        let key = TyOp(UnionUntag,[a])
                        match cse_tryfind s key with
                        | Some(DLit(LitInt32 i)) -> lit i
                        | Some _ -> failwith "Compiler error: Expected an 32-bit int."
                        | None ->
                            let on_fail, on_fail_ty =
                                let s = {s with cse = Dictionary(HashIdentity.Structural) :: s.cse; seq = ResizeArray()}
                                let r = apply s (on_fail, DB) |> dyn false s
                                seq_apply s r, data_to_ty s r
                            let on_succ =
                                Array.mapi (fun i (k,v) ->
                                    let cse = Dictionary(HashIdentity.Structural)
                                    cse.Add(key,DLit(LitInt32 i))
                                    let s = {s with cse = cse :: s.cse; seq = ResizeArray()}
                                    let r = type_apply s (apply s (on_succ, DSymbol k)) v |> dyn false s
                                    let r_ty = data_to_ty s r
                                    if on_fail_ty <> r_ty then raise_type_error s <| sprintf "Return type of the success case does not match the failure one.\nGot: %s\nExpected: %s" (show_ty r_ty) (show_ty on_fail_ty)
                                    seq_apply s r
                                    ) h.tag_cases
                            push_typedop_no_rewrite s (TyIntSwitch(tyv,on_succ,on_fail)) on_fail_ty
                    | DLit(LitInt32 i) -> lit i
                    | a -> raise_type_error s <| sprintf "Expected an i32.\nGot: %s" (show_data a)
                | _ -> raise_type_error s <| sprintf "Expected an union type.\nGot: %s" (show_ty t)
            | ELet(r,i,a,b) -> let s = add_trace s r in store_term s i (term s a); term s b
            | EPairTest(r,bind,p1,p2,on_succ,on_fail) ->
                let s = add_trace s r
                match v s bind with
                | DPair(a,b) -> store_term s p1 a; store_term s p2 b; term s on_succ
                | _ -> term s on_fail
            | EExistsTest(r,bind,pat_type,pat,on_succ,on_fail) ->
                let s = add_trace s r
                match v s bind with
                | DExists(a,b) -> Array.iter2 (store_ty s) pat_type a; store_term s pat b; term s on_succ
                | DV(L(_,YExists)) -> raise_type_error s "Runtime existentials cannot be destructured. They are a compile time feature only."
                | _ -> term s on_fail
            | ESymbolTest(r,a,bind,on_succ,on_fail) ->
                let s = add_trace s r
                match v s bind with
                | DSymbol a' when a = a' -> term s on_succ
                | _ -> term s on_fail
            | ERecordTest(r,a,bind,on_succ,on_fail) ->
                let s = add_trace s r
                match v s bind with
                | DRecord l ->
                    let rec loop = function
                        | x :: x' ->
                            let sym a b =
                                match l |> Map.tryPick (fun (_, k) v -> if k = a then Some v else None) with
                                | Some a -> store_term s b a; loop x'
                                | None -> term s on_fail
                            match x with
                            | Symbol((_,a),b) -> sym a b
                            | Var((r,a),b) ->
                                match term s a with
                                | DSymbol a -> sym a b
                                | a -> raise_type_error (add_trace s r) <| sprintf "Expected a symbol.\nGot: %s" (show_data a)
                        | [] -> term s on_succ
                    loop a
                | _ -> term s on_fail
            | EAnnotTest(r,a,bind,on_succ,on_fail) -> let s = add_trace s r in if data_to_ty s (v s bind) = ty s a then term s on_succ else term s on_fail
            | EUnitTest(r,bind,on_succ,on_fail) -> let s = add_trace s r in match v s bind with DB -> term s on_succ | _ -> term s on_fail
            | ENominalTest(r,a,bind,p1,on_succ,on_fail) ->
                let s = add_trace s r
                match ty s a with
                | YNominal a ->
                    match v s bind with
                    | DNominal((DUnion _ | DV(L(_,YUnion _))),_) -> raise_type_error s "Got an union in a nominal pattern."
                    | DNominal(v,b) ->
                        let rec loop = function
                            | YNominal b -> if a = b then store_term s p1 v; term s on_succ else term s on_fail
                            | YApply(a,_) -> loop a
                            | _ -> raise_type_error s <| sprintf "Compiler error: Expected a deferred type apply or a nominal.\nGot: %s" (show_ty b)
                        loop b
                    | _ -> term s on_fail
                | a -> raise_type_error s <| sprintf "Expected a nominal on the left side of the pattern.\nGot: %s" (show_ty a)
            | ELitTest(r,a,bind,on_succ,on_fail) -> let s = add_trace s r in lit_test s a bind on_succ on_fail
            | EDefaultLitTest(r,a,b,bind,on_succ,on_fail) -> let s = add_trace s r in lit_test s (default_lit s a (ty s b)) bind on_succ on_fail
            | ETypecase(r,a,b) ->
                let s = add_trace s r
                let a = ty s a
                let rec loop = function
                    | (a',b) :: rest -> if is_unify s (a,ty s a') then Some(term s b) else loop rest
                    | [] -> None
                match loop b with
                | Some r -> r
                | None -> raise_type_error s <| sprintf "Typecase miss.\nGot: %s" (show_ty a)
            | EOp(_,ToFunPtr,[a]) ->
                match term s a with
                | DFunction(body,Some(TFun(domain,range,_)),a,b,c,d) -> DFunction(body,Some(TFun(domain,range,FT_Pointer)),a,b,c,d)
                | DV(L(_,YFun _)) -> raise_type_error s <| sprintf "Cannot convert a runtime function to a closure. The closure conversion should be done on a compile time funciton."
                | a -> raise_type_error s <| sprintf "Expected a function.\nGot: %s" (show_data a)
            | EOp(_,ToFunClosure,[a]) ->
                match term s a with
                | DFunction(body,Some(TFun(domain,range,_)),a,b,c,d) -> DFunction(body,Some(TFun(domain,range,FT_Closure)),a,b,c,d)
                | DV(L(_,YFun _)) -> raise_type_error s <| sprintf "Cannot convert a runtime function to a function pointer. The pointer conversion should be done on a compile time funciton."
                | a -> raise_type_error s <| sprintf "Expected a function.\nGot: %s" (show_data a)
            | EOp(_,PragmaUnrollPush,[a]) ->
                match term s a with
                | DLit (LitInt32 _) as x -> push_op_no_rewrite s PragmaUnrollPush x YB
                | a -> raise_type_error s <| sprintf "Expected an i32 literal.\nGot: %s" (show_data a)
            | EOp(_,PragmaUnrollPop,[]) -> 
                push_op_no_rewrite' s PragmaUnrollPop [] YB
            | EOp(_,BackendSwitch,[a]) ->
                let mutable t = None
                let mutable d = None
                let validate_type t' =
                    match t with
                    | Some t -> if t <> t' then raise_type_error s $"The backend switch needs to have the same type for all of its branches.\nGot: {show_ty t'}\nExpected: {show_ty t}"
                    | None -> t <- Some t'
                match term s a with
                | DRecord l ->
                    l |> Map.iter (fun (_,backend) b ->
                        // The reason why we're evaling all the branches intead of just one and in this specific order is because otherwise
                        // compile time hashmaps could make type inference unsound.
                        if backend = s.backend.node then 
                            let d' = apply s (b, DB)
                            validate_type (data_to_ty s d')
                            d <- Some d'
                        else
                            let s = {s with seq=ResizeArray(); cse=Dictionary HashIdentity.Structural :: s.cse; backend=backend_strings.Add backend}
                            let d' = apply s (b, DB)
                            validate_type (data_to_ty s d')
                    )
                | a -> raise_type_error s <| sprintf "Expected an record.\nGot: %s" (show_data a)
                match d with
                | Some cur -> cur |> dyn true s
                | None -> raise_type_error s $"Cannot find the backend {s.backend.node} in the backend switch op."
            | EOp(_,UnsafeBackendSwitch,[a]) ->
                match term s a with // Unsafe version of the backend switch. Shouldn't ever be mixed with type level computations and bottom up inference.
                | DRecord l -> // Only use it if the code is backend agnostic.
                    // match Map.tryFind s.backend.node l with
                    match Map.tryPick (fun (_, backend) b -> if backend = s.backend.node then Some b else None) l with
                    | Some b -> apply s (b, DB)
                    | None -> raise_type_error s $"Cannot find the backend {s.backend.node} in the backend switch op."
                | a -> raise_type_error s <| sprintf "Expected an record.\nGot: %s" (show_data a)
            | EOp(_,UsesOriginalTermVars,[a;b]) ->
                let a = term s a |> data_term_vars'
                let b = term s b |> data_term_vars'
                let c = a.Length = b.Length && HashSet(a,HashIdentity.Reference).SetEquals(b)
                DLit(LitBool c)
            | EOp(_,UsesOriginalNominals,[a;b]) ->
                let a = term s a |> data_nominals
                let b = term s b |> data_nominals
                let c = a.Length = b.Length && HashSet(a,HashIdentity.Reference).SetEquals(b)
                DLit(LitBool c)
            | EOp(_,While,[cond;body]) -> 
                match term_scope s cond with
                | [|TyLocalReturnOp(_,TyJoinPoint cond,_)|], ty ->
                    match ty with
                    | YPrim BoolT -> 
                        match term_scope s body with
                        | body, YB & ty -> push_typedop s (TyWhile(cond,body)) ty
                        | _, ty -> raise_type_error s <| sprintf "The body of the while loop must be of type unit.\nGot: %s" (show_ty ty)
                    | _ -> raise_type_error s <| sprintf "The conditional of the while loop must be of type bool.\nGot: %s" (show_ty ty)
                | _ -> raise_type_error s "The body of the conditional of the while loop must be a solitary join point."
            | EOp(_,Do,[body]) ->
                match term_scope s body with
                | body, YB & ty -> push_typedop s (TyDo body) ty
                | _, ty -> raise_type_error s <| sprintf "The body of the do binding must be of type unit.\nGot: %s" (show_ty ty)
            | EOp(_,Indent,[body]) ->
                let body, ty = term_scope s body
                push_typedop s (TyIndent body) ty
            | EOp(_,(LayoutToHeap | LayoutToHeapMutable | LayoutToStackMutable as op),[a]) -> 
                let x = dyn false s (term s a)
                let ty = data_to_ty s x
                let layout =
                    match op with
                    | LayoutToHeap -> Heap
                    | LayoutToHeapMutable -> HeapMutable
                    | LayoutToStackMutable -> StackMutable
                    | _ -> raise_type_error s "Compiler error: Forgot a case in LayoutTo."
                let ret_ty = YLayout(ty,layout)
                let key = TyToLayout(x,ret_ty)
                push_typedop_no_rewrite s key ret_ty
            | EOp(_,LayoutIndex,[a]) -> 
                match term s a with
                | DV(L(i,YLayout(ty,layout)) as tyv) as a -> 
                    match layout with
                    | StackMutable | HeapMutable -> push_typedop_no_rewrite s (TyLayoutIndexAll tyv) ty
                    | Heap ->
                        match ty with
                        | YRecord l -> DRecord(Map.map (fun (_,b) ty -> push_typedop s (TyLayoutIndexByKey(tyv,b)) ty) l)
                        | _ -> push_typedop s (TyLayoutIndexAll tyv) ty
                | a -> raise_type_error s <| sprintf "Expected a layout type.\nGot: %s" (show_data a)
            | EOp(_,TypeToVar,[EType(_,a)]) -> push_typedop_no_rewrite s (TyOp(TypeToVar,[])) (ty s a)
            | EOp(_,LitToTypeLit,[a]) -> 
                match term s a with
                | DLit x -> DTLit x
                | DSymbol x -> DSymbol x
                | a -> raise_type_error s <| sprintf "Expected a symbol or a type literal.\nGot: %s" (show_data a)
            | EOp(_,LitToSymbol,[a]) -> 
                match term s a with
                | DLit x ->
                    match x with
                    | LitInt8 a -> a.ToString("R") |> DSymbol
                    | LitInt16 a -> a.ToString("R") |> DSymbol
                    | LitInt32 a -> a.ToString("R") |> DSymbol
                    | LitInt64 a -> a.ToString("R") |> DSymbol
                    | LitUInt8 a -> a.ToString("R") |> DSymbol
                    | LitUInt16 a -> a.ToString("R") |> DSymbol
                    | LitUInt32 a -> a.ToString("R") |> DSymbol
                    | LitUInt64 a -> a.ToString("R") |> DSymbol
                    | LitFloat32 a -> a.ToString("R") |> DSymbol
                    | LitFloat64 a -> a.ToString("R") |> DSymbol
                    | LitBool a -> a.ToString() |> DSymbol
                    | LitChar a -> a.ToString() |> DSymbol
                    | LitString a -> a.ToString() |> DSymbol
                | a -> raise_type_error s <| sprintf "Expected a symbol or a type literal.\nGot: %s" (show_data a)
            | EOp(_,StringLitToSymbol,[a]) -> 
                match term s a with
                | DLit(LitString a) -> DSymbol a
                | a -> raise_type_error s <| sprintf "Expected a string literal.\nGot: %s" (show_data a)
            | EOp(_,SymbolToString,[a]) -> 
                match term s a with
                | DSymbol a -> DLit (LitString a)
                | a -> raise_type_error s <| sprintf "Expected a symbol.\nGot: %s" (show_data a)
            | EOp(_,TypeToSymbol,[EType(_,a)]) -> 
                match ty s a with
                | YSymbol a -> DSymbol a
                | a -> raise_type_error s <| sprintf "Expected a symbol.\nGot: %s" (show_ty a)
            | EOp(_,TypeLitToLit,[EType(_,a)]) -> 
                let rec loop = function
                    | YLit a -> DLit a
                    | YSymbol a -> DSymbol a
                    | YNominal _ | YApply _ as a -> loop (nominal_type_apply s a)
                    | a -> raise_type_error s <| sprintf "Expected a type literal or a symbol.\nGot: %s" (show_ty a)
                loop (ty s a)
            | EOp(_,(TypeToVar | TypeToSymbol),[a]) -> raise_type_error s "Expected a type."
            | EOp(_,Dyn,[a]) -> term s a |> dyn true s
            | EOp(_,StringLength,[EType(_,t);a]) ->
                let t = ty s t
                if is_any_int t = false then raise_type_error s <| sprintf "Expected an int.\nGot: %s" (show_ty t)
                match term s a with
                | DLit(LitString str) -> 
                    match t with
                    | YPrim Int8T -> try DLit (LitInt8 (Convert.ToSByte str.Length)) with :? OverflowException -> raise_type_error s <| sprintf "Literal conversion to i8 failed as the string length is either too large.\nGot: %i" str.Length
                    | YPrim Int16T -> try DLit (LitInt16 (Convert.ToInt16 str.Length)) with :? OverflowException -> raise_type_error s <| sprintf "Literal conversion to i16 failed as the string length is either too large.\nGot: %i" str.Length
                    | YPrim Int32T -> try DLit (LitInt32 (Convert.ToInt32 str.Length)) with :? OverflowException -> raise_type_error s <| sprintf "Literal conversion to i32 failed as the string length is either too large.\nGot: %i" str.Length
                    | YPrim Int64T -> try DLit (LitInt64 (Convert.ToInt64 str.Length)) with :? OverflowException -> raise_type_error s <| sprintf "Literal conversion to i64 failed as the string length is either too large.\nGot: %i" str.Length
                    | YPrim UInt8T -> try DLit (LitUInt8 (Convert.ToByte str.Length)) with :? OverflowException -> raise_type_error s <| sprintf "Literal conversion to u8 failed as the string length is either too large.\nGot: %i" str.Length
                    | YPrim UInt16T -> try DLit (LitUInt16 (Convert.ToUInt16 str.Length)) with :? OverflowException -> raise_type_error s <| sprintf "Literal conversion to u16 failed as the string length is either too large.\nGot: %i" str.Length
                    | YPrim UInt32T -> try DLit (LitUInt32 (Convert.ToUInt32 str.Length)) with :? OverflowException -> raise_type_error s <| sprintf "Literal conversion to u32 failed as the string length is either too large.\nGot: %i" str.Length
                    | YPrim UInt64T -> try DLit (LitUInt64 (Convert.ToUInt64 str.Length)) with :? OverflowException -> raise_type_error s <| sprintf "Literal conversion to u64 failed as the string length is either too large.\nGot: %i" str.Length
                    | _ -> failwith "impossible"
                | DV(L(_,YPrim StringT)) & str -> push_typedop s (TyStringLength(t,str)) t
                | x -> raise_type_error s <| sprintf "Expected a string.\nGot: %s" (show_data x)
            | EOp(_,StringIndex,[a;b]) ->
                match term2 s a b with
                | DLit(LitString a), DLit b ->
                    let b = to_i32 b
                    if 0 <= b && b < a.Length then a.[int b] |> LitChar |> DLit
                    else raise_type_error s <| sprintf "Cannot index into a string of length %i at index %i." a.Length b
                | a,b ->
                    match data_to_ty s a, data_to_ty s b with
                    | YPrim StringT,bt when is_any_int bt -> push_binop s StringIndex (a,b) (YPrim CharT)
                    | a,b -> raise_type_error s <| sprintf "Expected a string and an int as arguments.\nGot: %s\nAnd: %s" (show_ty a) (show_ty b)
            | EOp(_,StringSlice,[a;b;c]) ->
                match term3 s a b c with
                | DLit(LitString a), DLit b, DLit c ->
                    let b,c = to_i32 b, to_i32 c
                    if 0 <= b && b <= c && c < a.Length then a.[int b..int c] |> LitString |> DLit
                    else raise_type_error s <| sprintf "String of length %i's slice from %i to %i is invalid." a.Length b c
                | a,b,c ->
                    match data_to_ty s a, data_to_ty s b, data_to_ty s c with
                    | YPrim StringT, bt, ct when is_any_int bt && is_any_int ct -> push_triop s StringSlice (a,b,c) (YPrim StringT)
                    | a,b,c -> raise_type_error s <| sprintf "Expected a string and two ints as arguments.\nGot: %s\nAnd: %s\nAnd: %s" (show_ty a) (show_ty b) (show_ty c)
            | EArray(_,a,b) ->
                match ty s b with
                | YArray el as b -> 
                    let a = 
                        List.map (fun x -> 
                            let x = term s x |> dyn false s
                            let x_ty = data_to_ty s x
                            if x_ty = el then x 
                            else raise_type_error s $"All the elements in the array literal have to be the type {show_ty el}.\nGot: {show_ty x_ty}"
                            ) a
                    push_typedop_no_rewrite s (TyArrayLiteral(el,a)) b
                | b -> raise_type_error s $"Expected an array_base.\nGot: {show_ty b}"
            | EOp(_,ArrayCreate,[EType(_,a);b]) ->
                let a,b = ty s a, term s b
                match data_to_ty s b with
                | bt when is_any_int bt -> push_typedop_no_rewrite s (TyArrayCreate(a,b)) (YArray a)
                | b -> raise_type_error s <| sprintf "Expected an int as the size of the array.\nGot: %s" (show_ty b)
            | EOp(_,ArrayLength,[EType(_,t);a]) ->
                let t = ty s t
                if is_any_int t = false then raise_type_error s <| sprintf "Expected an int.\nGot: %s" (show_ty t)
                let a = term s a
                match data_to_ty s a with
                | YArray _ -> push_typedop s (TyArrayLength(t,a)) t
                | a -> raise_type_error s <| sprintf "Expected an array_base.\nGot: %s" (show_ty a)
            | EOp(_,ArrayIndex,[a;b]) ->
                match term s a with
                | DV(L(_,YArray ty)) & a ->
                    let b = term s b
                    match data_to_ty s b with
                    | bt when is_any_int bt -> push_binop_no_rewrite s ArrayIndex (a,b) ty
                    | b -> raise_type_error s <| sprintf "Expected an int as the index argumet.\nGot: %s" (show_ty b)
                | a -> raise_type_error s <| sprintf "Expected an array_base.\nGot: %s" (show_data a)
            | EOp(_,ArrayIndexSet,[a;b;c]) ->
                match term s a with
                | DV(L(_,YArray ty)) & a ->
                    let b = term s b
                    match data_to_ty s b with
                    | bt when is_any_int bt -> 
                        let c = term s c |> dyn false s
                        let ty' = data_to_ty s c
                        if ty' = ty then push_triop_no_rewrite s ArrayIndexSet (a,b,c) YB
                        else raise_type_error s <| sprintf "The array and the value being set do not have the same type.\nGot: %s\nExpected: %s" (show_ty ty') (show_ty ty)
                    | b -> raise_type_error s <| sprintf "Expected an int as the index argumet.\nGot: %s" (show_ty b)
                | a -> raise_type_error s <| sprintf "Expected an array_base.\nGot: %s" (show_data a)
            | EOp(_,RecordMap,[a;b]) ->
                match term2 s a b with
                | a, DRecord l -> Map.map (fun (_i, k) v -> apply s (a, record2 ((l.Count, "key"), DSymbol k) (((l.Count + 1), "value"), v))) l |> DRecord
                | _, b -> raise_type_error s <| sprintf "Expected a record.\nGot: %s" (show_data b)
            | EOp(_,RecordIter,[a;b]) ->
                match term2 s a b with
                | a, DRecord l -> 
                    Map.iter (fun (i,k) v ->
                        match apply s (a, record2 ((l.Count, "key"), DSymbol k) (((l.Count + 1), "value"), v)) with
                        | DB -> ()
                        | x -> raise_type_error s <| sprintf "Expected an unit value.\nGot: %s" (show_data x)
                        ) l 
                    DB
                | _, b -> raise_type_error s <| sprintf "Expected a record.\nGot: %s" (show_data b)
            | EOp(_,RecordFilter,[a;b]) ->
                match term2 s a b with
                | a, DRecord l ->
                    Map.filter (fun (_i,k) v ->
                        match apply s (a, record2 ((l.Count, "key"), DSymbol k) (((l.Count + 1), "value"), v)) with
                        | DLit(LitBool x) -> x
                        | x -> raise_type_error s <| sprintf "Expected a bool literal.\nGot: %s" (show_data x)
                        ) l
                    |> DRecord
                | _, b -> raise_type_error s <| sprintf "Expected a record.\nGot: %s" (show_data b)
            | EOp(_,RecordFold,[a;b;c]) ->
                match term3 s a b c with
                | a, state, DRecord l -> Map.fold (fun state (i,k) v -> apply s (a, record3 ((l.Count, "state"), state) (((l.Count + 1), "key"), DSymbol k) (((l.Count + 2), "value"), v))) state l
                | _, _, r -> raise_type_error s <| sprintf "Expected a record.\nGot: %s" (show_data r)
            | EOp(_,RecordFoldBack,[a;b;c]) ->
                match term3 s a b c with
                | a, state, DRecord l -> Map.foldBack (fun (i,k) v state -> apply s (a, record3 ((i, "state"), state) (((l.Count + 1), "key"), DSymbol k) (((l.Count + 2), "value"), v))) l state
                | _, _, r -> raise_type_error s <| sprintf "Expected a record.\nGot: %s" (show_data r)
            | EOp(_,RecordLength,[a]) ->
                match term s a with
                | DRecord l -> Map.count l |> LitInt32 |> DLit
                | r -> raise_type_error s <| sprintf "Expected a record.\nGot: %s" (show_data r)
            | EOp(_,RecordTypeMap,[a;EType(_,b)]) ->
                let a,l = term s a, ty_record s b
                Map.map (fun (_i,k) v -> type_apply s (apply s (a, DSymbol k)) v) l |> DRecord
            | EOp(_,RecordTypeIter,[a;EType(_,b)]) ->
                let a,l = term s a, ty_record s b
                Map.iter (fun (_i, k) v ->
                    match type_apply s (apply s (a, DSymbol k)) v with
                    | DB -> ()
                    | x -> raise_type_error s <| sprintf "Expected an unit value.\nGot: %s" (show_data x)
                    ) l 
                DB
            | EOp(_,RecordTypeFold,[f;state;EType(_,x)]) ->
                let f,state,l = term s f, term s state, ty_record s x
                Map.fold (fun state (_, k) v -> type_apply s (apply s ((apply s (f, state), DSymbol k))) v) state l
            | EOp(_,RecordTypeFoldBack,[f;state;EType(_,x)]) ->
                let f,state,l = term s f, term s state, ty_record s x
                Map.foldBack (fun (_, k) v state -> apply s ((type_apply s (apply s (f, DSymbol k)) v), state)) l state
            | EOp(_,RecordTypeLength,[EType(_,a)]) ->
                Map.count (ty_record s a) |> LitInt32 |> DLit
            | EOp(_,RecordTypeTryFind,[EType(_,a);k;on_succ;on_fail]) ->
                match ty_record s a, term s k with
                | l, DSymbol k ->
                    match l |> Map.tryPick (fun (_, k') v -> if k' = k then Some v else None) with
                    | Some v -> type_apply s (term s on_succ) v
                    | None -> apply s (term s on_fail, DB)
                | _, k -> raise_type_error s <| sprintf "Expected a symbol.\nGot: %s" (show_data k)
            | EOp(_,UnionToRecord,[EType(_,a);on_succ]) ->
                type_apply s (term s on_succ) (YRecord (ty_union s a).Item.cases)
            | EOp(_,Add,[a;b]) -> 
                let inline op a b = a + b
                match term2 s a b with
                | DLit a, DLit b ->
                    match a, b with
                    | LitInt8 a, LitInt8 b -> op a b |> LitInt8 |> DLit
                    | LitInt16 a, LitInt16 b -> op a b |> LitInt16 |> DLit
                    | LitInt32 a, LitInt32 b -> op a b |> LitInt32 |> DLit
                    | LitInt64 a, LitInt64 b -> op a b |> LitInt64 |> DLit
                    | LitUInt8 a, LitUInt8 b -> op a b |> LitUInt8 |> DLit
                    | LitUInt16 a, LitUInt16 b -> op a b |> LitUInt16 |> DLit
                    | LitUInt32 a, LitUInt32 b -> op a b |> LitUInt32 |> DLit
                    | LitUInt64 a, LitUInt64 b -> op a b |> LitUInt64 |> DLit
                    | LitFloat32 a, LitFloat32 b -> op a b |> nan_guardf32  |> LitFloat32 |> DLit
                    | LitFloat64 a, LitFloat64 b -> op a b |> nan_guardf64 |> LitFloat64 |> DLit
                    | a, b -> raise_type_error s <| sprintf "The two literals must be both numeric and equal in type.\nGot: %s and %s" (show_lit a) (show_lit b)
                | a, b ->
                    let a_ty, b_ty = data_to_ty s a, data_to_ty s b 
                    if a_ty = b_ty then
                        if is_lit_zero a then b
                        elif is_lit_zero b then a
                        elif is_numeric a_ty then push_binop s Add (a,b) a_ty
                        else raise_type_error s <| sprintf "The type of the two arguments needs to be a numeric type.\nGot: %s" (show_ty a_ty)
                    else
                        raise_type_error s <| sprintf "The two sides need to have the same numeric types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
            | EOp(_,Sub,[a;b]) ->
                let inline op a b = a - b
                match term2 s a b with
                | DLit a, DLit b ->
                    match a, b with
                    | LitInt8 a, LitInt8 b -> op a b |> LitInt8 |> DLit
                    | LitInt16 a, LitInt16 b -> op a b |> LitInt16 |> DLit
                    | LitInt32 a, LitInt32 b -> op a b |> LitInt32 |> DLit
                    | LitInt64 a, LitInt64 b -> op a b |> LitInt64 |> DLit
                    | LitUInt8 a, LitUInt8 b -> op a b |> LitUInt8 |> DLit
                    | LitUInt16 a, LitUInt16 b -> op a b |> LitUInt16 |> DLit
                    | LitUInt32 a, LitUInt32 b -> op a b |> LitUInt32 |> DLit
                    | LitUInt64 a, LitUInt64 b -> op a b |> LitUInt64 |> DLit
                    | LitFloat32 a, LitFloat32 b -> op a b |> nan_guardf32  |> LitFloat32 |> DLit
                    | LitFloat64 a, LitFloat64 b -> op a b |> nan_guardf64 |> LitFloat64 |> DLit
                    | a, b -> raise_type_error s <| sprintf "The two literals must be both numeric and equal in type.\nGot: %s and %s" (show_lit a) (show_lit b)
                | a, b ->
                    let a_ty, b_ty = data_to_ty s a, data_to_ty s b 
                    if a_ty = b_ty then
                        if is_lit_zero a && is_signed_numeric a_ty then push_op s Neg b b_ty
                        elif is_lit_zero b then a
                        elif is_any_int a_ty && a = b then DLit(lit_zero a_ty)
                        elif is_numeric a_ty then push_binop s Sub (a,b) a_ty
                        else raise_type_error s <| sprintf "The type of the two arguments needs to be a numeric type.\nGot: %s" (show_ty a_ty)
                    else
                        raise_type_error s <| sprintf "The two sides need to have the same numeric types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
            | EOp(_,Mult,[a;b]) ->
                let inline op a b = a * b
                match term2 s a b with
                | DLit a, DLit b ->
                    match a, b with
                    | LitInt8 a, LitInt8 b -> op a b |> LitInt8 |> DLit
                    | LitInt16 a, LitInt16 b -> op a b |> LitInt16 |> DLit
                    | LitInt32 a, LitInt32 b -> op a b |> LitInt32 |> DLit
                    | LitInt64 a, LitInt64 b -> op a b |> LitInt64 |> DLit
                    | LitUInt8 a, LitUInt8 b -> op a b |> LitUInt8 |> DLit
                    | LitUInt16 a, LitUInt16 b -> op a b |> LitUInt16 |> DLit
                    | LitUInt32 a, LitUInt32 b -> op a b |> LitUInt32 |> DLit
                    | LitUInt64 a, LitUInt64 b -> op a b |> LitUInt64 |> DLit
                    | LitFloat32 a, LitFloat32 b -> op a b |> nan_guardf32  |> LitFloat32 |> DLit
                    | LitFloat64 a, LitFloat64 b -> op a b |> nan_guardf64 |> LitFloat64 |> DLit
                    | a, b -> raise_type_error s <| sprintf "The two literals must be both numeric and equal in type.\nGot: %s and %s" (show_lit a) (show_lit b)
                | a, b ->
                    let a_ty, b_ty = data_to_ty s a, data_to_ty s b 
                    if a_ty = b_ty then
                        if is_int_lit_zero a || is_int_lit_zero b then lit_zero a_ty |> DLit
                        elif is_lit_one a then b
                        elif is_lit_one b then a
                        elif is_numeric a_ty then push_binop s Mult (a,b) a_ty
                        else raise_type_error s <| sprintf "The type of the two arguments needs to be a numeric type.\nGot: %s" (show_ty a_ty)
                    else
                        raise_type_error s <| sprintf "The two sides need to have the same numeric types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
            | EOp(_,Div,[a;b]) -> 
                let inline op a b = a / b
                try
                    match term2 s a b with
                    | DLit a, DLit b ->
                        match a, b with
                        | LitInt8 a, LitInt8 b -> op a b |> LitInt8 |> DLit
                        | LitInt16 a, LitInt16 b -> op a b |> LitInt16 |> DLit
                        | LitInt32 a, LitInt32 b -> op a b |> LitInt32 |> DLit
                        | LitInt64 a, LitInt64 b -> op a b |> LitInt64 |> DLit
                        | LitUInt8 a, LitUInt8 b -> op a b |> LitUInt8 |> DLit
                        | LitUInt16 a, LitUInt16 b -> op a b |> LitUInt16 |> DLit
                        | LitUInt32 a, LitUInt32 b -> op a b |> LitUInt32 |> DLit
                        | LitUInt64 a, LitUInt64 b -> op a b |> LitUInt64 |> DLit
                        | LitFloat32 a, LitFloat32 b -> op a b |> nan_guardf32  |> LitFloat32 |> DLit
                        | LitFloat64 a, LitFloat64 b -> op a b |> nan_guardf64 |> LitFloat64 |> DLit
                        | a, b -> raise_type_error s <| sprintf "The two literals must be both numeric and equal in type.\nGot: %s and %s" (show_lit a) (show_lit b)
                    | a, b ->
                        let a_ty, b_ty = data_to_ty s a, data_to_ty s b 
                        if a_ty = b_ty then
                            if is_lit_zero b then raise (DivideByZeroException())
                            elif is_lit_one b then a
                            elif is_numeric a_ty then push_binop s Div (a,b) a_ty
                            else raise_type_error s <| sprintf "The type of the two arguments needs to be a numeric type.\nGot: %s" (show_ty a_ty)
                        else
                            raise_type_error s <| sprintf "The two sides need to have the same numeric types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
                with :? DivideByZeroException ->
                    raise_type_error s <| sprintf "An attempt to divide by zero has been detected at compile time."
            | EOp(_,Pow,[a;b]) -> 
                let inline op a b = a ** b
                match term2 s a b with
                | DLit a, DLit b ->
                    match a, b with
                    | LitFloat32 a, LitFloat32 b -> op a b |> nan_guardf32 |> LitFloat32 |> DLit
                    | LitFloat64 a, LitFloat64 b -> op a b |> nan_guardf64 |> LitFloat64 |> DLit
                    | a, b -> raise_type_error s <| sprintf "The two literals must be both float and equal in type.\nGot: %s and %s" (show_lit a) (show_lit b)
                | a, b ->
                    let a_ty, b_ty = data_to_ty s a, data_to_ty s b 
                    if a_ty = b_ty && is_float a_ty then push_binop s Pow (a,b) a_ty
                    else raise_type_error s <| sprintf "The two sides need to have the same float types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
            | EOp(_,Mod,[a;b]) -> 
                let inline op a b = a % b
                try
                    match term2 s a b with
                    | DLit a, DLit b ->
                        match a, b with
                        | LitInt8 a, LitInt8 b -> op a b |> LitInt8 |> DLit
                        | LitInt16 a, LitInt16 b -> op a b |> LitInt16 |> DLit
                        | LitInt32 a, LitInt32 b -> op a b |> LitInt32 |> DLit
                        | LitInt64 a, LitInt64 b -> op a b |> LitInt64 |> DLit
                        | LitUInt8 a, LitUInt8 b -> op a b |> LitUInt8 |> DLit
                        | LitUInt16 a, LitUInt16 b -> op a b |> LitUInt16 |> DLit
                        | LitUInt32 a, LitUInt32 b -> op a b |> LitUInt32 |> DLit
                        | LitUInt64 a, LitUInt64 b -> op a b |> LitUInt64 |> DLit
                        | LitFloat32 a, LitFloat32 b -> op a b |> nan_guardf32  |> LitFloat32 |> DLit
                        | LitFloat64 a, LitFloat64 b -> op a b |> nan_guardf64 |> LitFloat64 |> DLit
                        | a, b -> raise_type_error s <| sprintf "The two literals must be both numeric and equal in type.\nGot: %s and %s" (show_lit a) (show_lit b)
                    | a, b ->
                        let a_ty, b_ty = data_to_ty s a, data_to_ty s b 
                        if a_ty = b_ty then
                            if is_lit_zero b then raise (DivideByZeroException())
                            elif is_numeric a_ty then push_binop s Mod (a,b) a_ty
                            else raise_type_error s <| sprintf "The type of the two arguments needs to be a numeric type.\nGot: %s" (show_ty a_ty)
                        else
                            raise_type_error s <| sprintf "The two sides need to have the same numeric types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
                with :? DivideByZeroException ->
                    raise_type_error s <| sprintf "An attempt to divide by zero has been detected at compile time."
            | EOp(_,LT,[a;b]) ->
                let inline op a b = a < b
                match term2 s a b with
                | DLit a, DLit b ->
                    match a, b with
                    | LitInt8 a, LitInt8 b -> op a b |> LitBool |> DLit
                    | LitInt16 a, LitInt16 b -> op a b |> LitBool |> DLit
                    | LitInt32 a, LitInt32 b -> op a b |> LitBool |> DLit
                    | LitInt64 a, LitInt64 b -> op a b |> LitBool |> DLit
                    | LitUInt8 a, LitUInt8 b -> op a b |> LitBool |> DLit
                    | LitUInt16 a, LitUInt16 b -> op a b |> LitBool |> DLit
                    | LitUInt32 a, LitUInt32 b -> op a b |> LitBool |> DLit
                    | LitUInt64 a, LitUInt64 b -> op a b |> LitBool |> DLit
                    | LitFloat32 a, LitFloat32 b -> op a b |> LitBool |> DLit
                    | LitFloat64 a, LitFloat64 b -> op a b |> LitBool |> DLit
                    | LitString a, LitString b -> op a b |> LitBool |> DLit
                    | LitChar a, LitChar b -> op a b |> LitBool |> DLit
                    | LitBool a, LitBool b -> op a b |> LitBool |> DLit
                    | a, b -> raise_type_error s <| sprintf "The two literals must be equal in type.\nGot: %s and %s" (show_lit a) (show_lit b)
                | a, b ->
                    let a_ty, b_ty = data_to_ty s a, data_to_ty s b 
                    if a_ty = b_ty then
                        if is_primitive a_ty then push_binop s LT (a,b) (YPrim BoolT)
                        else raise_type_error s <| sprintf "The type of the two arguments needs to be a primitive type.\nGot: %s" (show_ty a_ty)
                    else
                        raise_type_error s <| sprintf "The two sides need to have the same primitive types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
            | EOp(_,LTE,[a;b]) ->
                let inline op a b = a <= b
                match term2 s a b with
                | DLit a, DLit b ->
                    match a, b with
                    | LitInt8 a, LitInt8 b -> op a b |> LitBool |> DLit
                    | LitInt16 a, LitInt16 b -> op a b |> LitBool |> DLit
                    | LitInt32 a, LitInt32 b -> op a b |> LitBool |> DLit
                    | LitInt64 a, LitInt64 b -> op a b |> LitBool |> DLit
                    | LitUInt8 a, LitUInt8 b -> op a b |> LitBool |> DLit
                    | LitUInt16 a, LitUInt16 b -> op a b |> LitBool |> DLit
                    | LitUInt32 a, LitUInt32 b -> op a b |> LitBool |> DLit
                    | LitUInt64 a, LitUInt64 b -> op a b |> LitBool |> DLit
                    | LitFloat32 a, LitFloat32 b -> op a b |> LitBool |> DLit
                    | LitFloat64 a, LitFloat64 b -> op a b |> LitBool |> DLit
                    | LitString a, LitString b -> op a b |> LitBool |> DLit
                    | LitChar a, LitChar b -> op a b |> LitBool |> DLit
                    | LitBool a, LitBool b -> op a b |> LitBool |> DLit
                    | a, b -> raise_type_error s <| sprintf "The two literals must be equal in type.\nGot: %s and %s" (show_lit a) (show_lit b)
                | a, b ->
                    let a_ty, b_ty = data_to_ty s a, data_to_ty s b 
                    if a_ty = b_ty then
                        if is_primitive a_ty then push_binop s LTE (a,b) (YPrim BoolT)
                        else raise_type_error s <| sprintf "The type of the two arguments needs to be a primitive type.\nGot: %s" (show_ty a_ty)
                    else
                        raise_type_error s <| sprintf "The two sides need to have the same primitive types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
            | EOp(_,GT,[a;b]) -> 
                let inline op a b = a > b
                match term2 s a b with
                | DLit a, DLit b ->
                    match a, b with
                    | LitInt8 a, LitInt8 b -> op a b |> LitBool |> DLit
                    | LitInt16 a, LitInt16 b -> op a b |> LitBool |> DLit
                    | LitInt32 a, LitInt32 b -> op a b |> LitBool |> DLit
                    | LitInt64 a, LitInt64 b -> op a b |> LitBool |> DLit
                    | LitUInt8 a, LitUInt8 b -> op a b |> LitBool |> DLit
                    | LitUInt16 a, LitUInt16 b -> op a b |> LitBool |> DLit
                    | LitUInt32 a, LitUInt32 b -> op a b |> LitBool |> DLit
                    | LitUInt64 a, LitUInt64 b -> op a b |> LitBool |> DLit
                    | LitFloat32 a, LitFloat32 b -> op a b |> LitBool |> DLit
                    | LitFloat64 a, LitFloat64 b -> op a b |> LitBool |> DLit
                    | LitString a, LitString b -> op a b |> LitBool |> DLit
                    | LitChar a, LitChar b -> op a b |> LitBool |> DLit
                    | LitBool a, LitBool b -> op a b |> LitBool |> DLit
                    | a, b -> raise_type_error s <| sprintf "The two literals must be equal in type.\nGot: %s and %s" (show_lit a) (show_lit b)
                | a, b ->
                    let a_ty, b_ty = data_to_ty s a, data_to_ty s b 
                    if a_ty = b_ty then
                        if is_primitive a_ty then push_binop s GT (a,b) (YPrim BoolT)
                        else raise_type_error s <| sprintf "The type of the two arguments needs to be a primitive type.\nGot: %s" (show_ty a_ty)
                    else
                        raise_type_error s <| sprintf "The two sides need to have the same primitive types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
            | EOp(_,GTE,[a;b]) -> 
                let inline op a b = a >= b
                match term2 s a b with
                | DLit a, DLit b ->
                    match a, b with
                    | LitInt8 a, LitInt8 b -> op a b |> LitBool |> DLit
                    | LitInt16 a, LitInt16 b -> op a b |> LitBool |> DLit
                    | LitInt32 a, LitInt32 b -> op a b |> LitBool |> DLit
                    | LitInt64 a, LitInt64 b -> op a b |> LitBool |> DLit
                    | LitUInt8 a, LitUInt8 b -> op a b |> LitBool |> DLit
                    | LitUInt16 a, LitUInt16 b -> op a b |> LitBool |> DLit
                    | LitUInt32 a, LitUInt32 b -> op a b |> LitBool |> DLit
                    | LitUInt64 a, LitUInt64 b -> op a b |> LitBool |> DLit
                    | LitFloat32 a, LitFloat32 b -> op a b |> LitBool |> DLit
                    | LitFloat64 a, LitFloat64 b -> op a b |> LitBool |> DLit
                    | LitString a, LitString b -> op a b |> LitBool |> DLit
                    | LitChar a, LitChar b -> op a b |> LitBool |> DLit
                    | LitBool a, LitBool b -> op a b |> LitBool |> DLit
                    | a, b -> raise_type_error s <| sprintf "The two literals must be equal in type.\nGot: %s and %s" (show_lit a) (show_lit b)
                | a, b ->
                    let a_ty, b_ty = data_to_ty s a, data_to_ty s b 
                    if a_ty = b_ty then
                        if is_primitive a_ty then push_binop s GTE (a,b) (YPrim BoolT)
                        else raise_type_error s <| sprintf "The type of the two arguments needs to be a primitive type.\nGot: %s" (show_ty a_ty)
                    else
                        raise_type_error s <| sprintf "The two sides need to have the same primitive types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
            | EOp(_,EQ,[a;b]) -> eq s (term s a) (term s b)
            | EOp(_,NEQ,[a;b]) ->
                let inline op a b = a <> b
                match term2 s a b with
                | DLit a, DLit b ->
                    match a, b with
                    | LitInt8 a, LitInt8 b -> op a b |> LitBool |> DLit
                    | LitInt16 a, LitInt16 b -> op a b |> LitBool |> DLit
                    | LitInt32 a, LitInt32 b -> op a b |> LitBool |> DLit
                    | LitInt64 a, LitInt64 b -> op a b |> LitBool |> DLit
                    | LitUInt8 a, LitUInt8 b -> op a b |> LitBool |> DLit
                    | LitUInt16 a, LitUInt16 b -> op a b |> LitBool |> DLit
                    | LitUInt32 a, LitUInt32 b -> op a b |> LitBool |> DLit
                    | LitUInt64 a, LitUInt64 b -> op a b |> LitBool |> DLit
                    | LitFloat32 a, LitFloat32 b -> op a b |> LitBool |> DLit
                    | LitFloat64 a, LitFloat64 b -> op a b |> LitBool |> DLit
                    | LitString a, LitString b -> op a b |> LitBool |> DLit
                    | LitChar a, LitChar b -> op a b |> LitBool |> DLit
                    | LitBool a, LitBool b -> op a b |> LitBool |> DLit
                    | a, b -> raise_type_error s <| sprintf "The two literals must be equal in type.\nGot: %s and %s" (show_lit a) (show_lit b)
                | DV(L(a,a_ty)), DV(L(b,_)) when a = b && is_non_float_primitive a_ty -> LitBool false |> DLit
                | a, b ->
                    let a_ty, b_ty = data_to_ty s a, data_to_ty s b 
                    if a_ty = b_ty then
                        match a, b with
                        | DLit (LitBool false), x | x, DLit (LitBool false) -> x
                        | _ ->
                            if is_primitive a_ty then push_binop s NEQ (a,b) (YPrim BoolT)
                            else raise_type_error s <| sprintf "The type of the two arguments needs to be a primitive type.\nGot: %s" (show_ty a_ty)
                    else
                        raise_type_error s <| sprintf "The two sides need to have the same primitive types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
            | EOp(_,BitwiseAnd,[a;b]) -> 
                let inline op a b = a &&& b
                match term2 s a b with
                | DLit a, DLit b ->
                    match a, b with
                    | LitInt8 a, LitInt8 b -> op a b |> LitInt8 |> DLit
                    | LitInt16 a, LitInt16 b -> op a b |> LitInt16 |> DLit
                    | LitInt32 a, LitInt32 b -> op a b |> LitInt32 |> DLit
                    | LitInt64 a, LitInt64 b -> op a b |> LitInt64 |> DLit
                    | LitUInt8 a, LitUInt8 b -> op a b |> LitUInt8 |> DLit
                    | LitUInt16 a, LitUInt16 b -> op a b |> LitUInt16 |> DLit
                    | LitUInt32 a, LitUInt32 b -> op a b |> LitUInt32 |> DLit
                    | LitUInt64 a, LitUInt64 b -> op a b |> LitUInt64 |> DLit
                    | a, b -> raise_type_error s <| sprintf "The two literals must be both ints and equal in type.\nGot: %s and %s" (show_lit a) (show_lit b)
                | a, b ->
                    let a_ty, b_ty = data_to_ty s a, data_to_ty s b 
                    if a_ty = b_ty then
                        if is_any_int a_ty then push_binop s BitwiseAnd (a,b) a_ty
                        else raise_type_error s <| sprintf "The type of the two arguments needs to be a int type.\nGot: %s" (show_ty a_ty)
                    else
                        raise_type_error s <| sprintf "The two sides need to have the same int types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
            | EOp(_,BitwiseOr,[a;b]) ->
                let inline op a b = a ||| b
                match term2 s a b with
                | DLit a, DLit b ->
                    match a, b with
                    | LitInt8 a, LitInt8 b -> op a b |> LitInt8 |> DLit
                    | LitInt16 a, LitInt16 b -> op a b |> LitInt16 |> DLit
                    | LitInt32 a, LitInt32 b -> op a b |> LitInt32 |> DLit
                    | LitInt64 a, LitInt64 b -> op a b |> LitInt64 |> DLit
                    | LitUInt8 a, LitUInt8 b -> op a b |> LitUInt8 |> DLit
                    | LitUInt16 a, LitUInt16 b -> op a b |> LitUInt16 |> DLit
                    | LitUInt32 a, LitUInt32 b -> op a b |> LitUInt32 |> DLit
                    | LitUInt64 a, LitUInt64 b -> op a b |> LitUInt64 |> DLit
                    | a, b -> raise_type_error s <| sprintf "The two literals must be both ints and equal in type.\nGot: %s and %s" (show_lit a) (show_lit b)
                | a, b ->
                    let a_ty, b_ty = data_to_ty s a, data_to_ty s b 
                    if a_ty = b_ty then
                        if is_any_int a_ty then push_binop s BitwiseOr (a,b) a_ty
                        else raise_type_error s <| sprintf "The type of the two arguments needs to be a int type.\nGot: %s" (show_ty a_ty)
                    else
                        raise_type_error s <| sprintf "The two sides need to have the same int types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
            | EOp(_,BitwiseXor,[a;b]) ->
                let inline op a b = a ^^^ b
                match term2 s a b with
                | DLit a, DLit b ->
                    match a, b with
                    | LitInt8 a, LitInt8 b -> op a b |> LitInt8 |> DLit
                    | LitInt16 a, LitInt16 b -> op a b |> LitInt16 |> DLit
                    | LitInt32 a, LitInt32 b -> op a b |> LitInt32 |> DLit
                    | LitInt64 a, LitInt64 b -> op a b |> LitInt64 |> DLit
                    | LitUInt8 a, LitUInt8 b -> op a b |> LitUInt8 |> DLit
                    | LitUInt16 a, LitUInt16 b -> op a b |> LitUInt16 |> DLit
                    | LitUInt32 a, LitUInt32 b -> op a b |> LitUInt32 |> DLit
                    | LitUInt64 a, LitUInt64 b -> op a b |> LitUInt64 |> DLit
                    | a, b -> raise_type_error s <| sprintf "The two literals must be both ints and equal in type.\nGot: %s and %s" (show_lit a) (show_lit b)
                | a, b ->
                    let a_ty, b_ty = data_to_ty s a, data_to_ty s b 
                    if a_ty = b_ty then
                        if is_any_int a_ty then push_binop s BitwiseXor (a,b) a_ty
                        else raise_type_error s <| sprintf "The type of the two arguments needs to be a int type.\nGot: %s" (show_ty a_ty)
                    else
                        raise_type_error s <| sprintf "The two sides need to have the same int types.\nGot: %s and %s." (show_ty a_ty) (show_ty b_ty)
            | EOp(_,BitwiseComplement,[a]) ->
                let inline op a = ~~~a
                match term s a with
                | DLit a ->
                    match a with
                    | LitInt8 a -> op a |> LitInt8 |> DLit
                    | LitInt16 a -> op a |> LitInt16 |> DLit
                    | LitInt32 a -> op a |> LitInt32 |> DLit
                    | LitInt64 a -> op a |> LitInt64 |> DLit
                    | LitUInt8 a -> op a |> LitUInt8 |> DLit
                    | LitUInt16 a -> op a |> LitUInt16 |> DLit
                    | LitUInt32 a -> op a |> LitUInt32 |> DLit
                    | LitUInt64 a -> op a |> LitUInt64 |> DLit
                    | a -> raise_type_error s <| sprintf "The literal must be an int.\nGot: %s" (show_lit a)
                | a ->
                    let a_ty = data_to_ty s a
                    if is_any_int a_ty then push_op s BitwiseComplement a a_ty
                    else raise_type_error s <| sprintf "The type of the two arguments needs to be a int type.\nGot: %s" (show_ty a_ty)
            | EOp(_,ShiftLeft,[a;b]) -> 
                let inline op a b = a <<< b
                match term2 s a b with
                | DLit a, DLit b ->
                    match a, b with
                    | LitInt8 a, LitInt32 b -> op a b |> LitInt8 |> DLit
                    | LitInt16 a, LitInt32 b -> op a b |> LitInt16 |> DLit
                    | LitInt32 a, LitInt32 b -> op a b |> LitInt32 |> DLit
                    | LitInt64 a, LitInt32 b -> op a b |> LitInt64 |> DLit
                    | LitUInt8 a, LitInt32 b -> op a b |> LitUInt8 |> DLit
                    | LitUInt16 a, LitInt32 b -> op a b |> LitUInt16 |> DLit
                    | LitUInt32 a, LitInt32 b -> op a b |> LitUInt32 |> DLit
                    | LitUInt64 a, LitInt32 b -> op a b |> LitUInt64 |> DLit
                    | a, b -> raise_type_error s <| sprintf "The first literal must be an int and the second must be a 32-bit signed int.\nGot: %s and %s" (show_lit a) (show_lit b)
                | a, b ->
                    let a_ty, b_ty = data_to_ty s a, data_to_ty s b 
                    if is_any_int a_ty && is_int32 b_ty then push_binop s ShiftLeft (a,b) a_ty
                    else raise_type_error s <| sprintf "The type of the first argument must be an int and the second must be a 32-bit signed int.\nGot: %s and %s" (show_ty a_ty) (show_ty b_ty)
            | EOp(_,ShiftRight,[a;b]) ->
                let inline op a b = a >>> b
                match term2 s a b with
                | DLit a, DLit b ->
                    match a, b with
                    | LitInt8 a, LitInt32 b -> op a b |> LitInt8 |> DLit
                    | LitInt16 a, LitInt32 b -> op a b |> LitInt16 |> DLit
                    | LitInt32 a, LitInt32 b -> op a b |> LitInt32 |> DLit
                    | LitInt64 a, LitInt32 b -> op a b |> LitInt64 |> DLit
                    | LitUInt8 a, LitInt32 b -> op a b |> LitUInt8 |> DLit
                    | LitUInt16 a, LitInt32 b -> op a b |> LitUInt16 |> DLit
                    | LitUInt32 a, LitInt32 b -> op a b |> LitUInt32 |> DLit
                    | LitUInt64 a, LitInt32 b -> op a b |> LitUInt64 |> DLit
                    | a, b -> raise_type_error s <| sprintf "The first literal must be an int and the second must be a 32-bit signed int.\nGot: %s and %s" (show_lit a) (show_lit b)
                | a, b ->
                    let a_ty, b_ty = data_to_ty s a, data_to_ty s b 
                    if is_any_int a_ty && is_int32 b_ty then push_binop s ShiftRight (a,b) a_ty
                    else raise_type_error s <| sprintf "The type of the first argument must be an int and the second must be a 32-bit signed int.\nGot: %s and %s" (show_ty a_ty) (show_ty b_ty)
            | EOp(_,Neg,[a]) ->
                let inline op a = -a
                match term s a with
                | DLit a ->
                    match a with
                    | LitInt8 a -> op a |> LitInt8 |> DLit
                    | LitInt16 a -> op a |> LitInt16 |> DLit
                    | LitInt32 a -> op a |> LitInt32 |> DLit
                    | LitInt64 a -> op a |> LitInt64 |> DLit
                    | LitFloat32 a -> op a |> LitFloat32 |> DLit
                    | LitFloat64 a -> op a |> LitFloat64 |> DLit
                    | _ -> raise_type_error s <| sprintf "The literal must be a signed numeric type.\nGot: %s" (show_lit a)
                | a ->
                    let a_ty = data_to_ty s a
                    if is_signed_numeric a_ty then push_op s Neg a a_ty
                    else raise_type_error s <| sprintf "The argument must be a signed numeric type.\nGot: %s" (show_ty a_ty)
            | EOp(_,Tanh,[a]) -> 
                let inline op a = tanh a
                match term s a with
                | DLit a ->
                    match a with
                    | LitFloat32 a -> op a |> nan_guardf32 |> LitFloat32 |> DLit
                    | LitFloat64 a -> op a |> nan_guardf64 |> LitFloat64 |> DLit
                    | _ -> raise_type_error s <| sprintf "The literal must be a float type.\nGot: %s" (show_lit a)
                | a ->
                    let a_ty = data_to_ty s a
                    if is_float a_ty then push_op s Tanh a a_ty
                    else raise_type_error s <| sprintf "The argument must be a float type.\nGot: %s" (show_ty a_ty)
            | EOp(_,Log,[a]) ->
                let inline op a = log a
                match term s a with
                | DLit a ->
                    match a with
                    | LitFloat32 a -> op a |> nan_guardf32 |> LitFloat32 |> DLit
                    | LitFloat64 a -> op a |> nan_guardf64 |> LitFloat64 |> DLit
                    | _ -> raise_type_error s <| sprintf "The literal must be a float type.\nGot: %s" (show_lit a)
                | a ->
                    let a_ty = data_to_ty s a
                    if is_float a_ty then push_op s Log a a_ty
                    else raise_type_error s <| sprintf "The argument must be a float type.\nGot: %s" (show_ty a_ty)
            | EOp(_,Exp,[a]) ->
                let inline op a = exp a
                match term s a with
                | DLit a ->
                    match a with
                    | LitFloat32 a -> op a |> nan_guardf32 |> LitFloat32 |> DLit
                    | LitFloat64 a -> op a |> nan_guardf64 |> LitFloat64 |> DLit
                    | _ -> raise_type_error s <| sprintf "The literal must be a float type.\nGot: %s" (show_lit a)
                | a ->
                    let a_ty = data_to_ty s a
                    if is_float a_ty then push_op s Exp a a_ty
                    else raise_type_error s <| sprintf "The argument must be a float type.\nGot: %s" (show_ty a_ty)
            | EOp(_,Sqrt,[a]) ->
                let inline op a = sqrt a
                match term s a with
                | DLit a ->
                    match a with
                    | LitFloat32 a -> op a |> nan_guardf32 |> LitFloat32 |> DLit
                    | LitFloat64 a -> op a |> nan_guardf64 |> LitFloat64 |> DLit
                    | _ -> raise_type_error s <| sprintf "The literal must be a float type.\nGot: %s" (show_lit a)
                | a ->
                    let a_ty = data_to_ty s a
                    if is_float a_ty then push_op s Sqrt a a_ty
                    else raise_type_error s <| sprintf "The argument must be a float type.\nGot: %s" (show_ty a_ty)
            | EOp(_,Sin,[a]) ->
                let inline op a = sin a
                match term s a with
                | DLit a ->
                    match a with
                    | LitFloat32 a -> op a |> nan_guardf32 |> LitFloat32 |> DLit
                    | LitFloat64 a -> op a |> nan_guardf64 |> LitFloat64 |> DLit
                    | _ -> raise_type_error s <| sprintf "The literal must be a float type.\nGot: %s" (show_lit a)
                | a ->
                    let a_ty = data_to_ty s a
                    if is_float a_ty then push_op s Sin a a_ty
                    else raise_type_error s <| sprintf "The argument must be a float type.\nGot: %s" (show_ty a_ty)
            | EOp(_,Cos,[a]) ->
                let inline op a = cos a
                match term s a with
                | DLit a ->
                    match a with
                    | LitFloat32 a -> op a |> nan_guardf32 |> LitFloat32 |> DLit
                    | LitFloat64 a -> op a |> nan_guardf64 |> LitFloat64 |> DLit
                    | _ -> raise_type_error s <| sprintf "The literal must be a float type.\nGot: %s" (show_lit a)
                | a ->
                    let a_ty = data_to_ty s a
                    if is_float a_ty then push_op s Cos a a_ty
                    else raise_type_error s <| sprintf "The argument must be a float type.\nGot: %s" (show_ty a_ty)
            | EOp(_,Conv,[EType(_,typ);a]) ->
                let typ = ty s typ
                let a = term s a
                let at = data_to_ty s a
                if typ = at then a
                else
                    let inline conv_lit x =
                        match typ with
                        | YPrim Int8T -> int8 x |> LitInt8
                        | YPrim Int16T -> int16 x |> LitInt16
                        | YPrim Int32T -> int32 x |> LitInt32
                        | YPrim Int64T -> int64 x |> LitInt64
                        | YPrim UInt8T -> uint8 x |> LitUInt8
                        | YPrim UInt16T -> uint16 x |> LitUInt16
                        | YPrim UInt32T -> uint32 x |> LitUInt32
                        | YPrim UInt64T -> uint64 x |> LitUInt64
                        | YPrim Float32T -> float32 x |> LitFloat32
                        | YPrim Float64T -> float x |> LitFloat64
                        | _ -> raise_type_error s <| sprintf "Cannot convert the literal to the following type: %s" (show_ty typ)
                        |> DLit
                    match a with
                    | DLit (LitInt8 a) -> conv_lit a
                    | DLit (LitInt16 a) -> conv_lit a
                    | DLit (LitInt32 a) -> conv_lit a
                    | DLit (LitInt64 a) -> conv_lit a
                    | DLit (LitUInt8 a) -> conv_lit a
                    | DLit (LitUInt16 a) -> conv_lit a
                    | DLit (LitUInt32 a) -> conv_lit a
                    | DLit (LitUInt64 a) -> conv_lit a
                    | DLit (LitFloat32 a) -> conv_lit a
                    | DLit (LitFloat64 a) -> conv_lit a
                    | _ ->
                        let is_convertible_primt x =
                            match x with
                            | YPrim BoolT | YPrim CharT | YPrim StringT -> false
                            | YPrim _ -> true
                            | _ -> false
                        if is_convertible_primt at && is_convertible_primt typ then push_typedop s (TyConv(typ,a)) typ
                        else raise_type_error s <| sprintf "Cannot convert %s to the following type: %s" (show_data a) (show_ty typ)
            | EOp(_,NanIs,[a]) ->
                let a = term s a
                match data_to_ty s a with
                | YPrim (Float32T | Float64T) -> push_op s NanIs a (YPrim BoolT)
                | a -> raise_type_error s <| sprintf "Expected a float in NanIs. Got: %s" (show_ty a)
            | EOp(_,Infinity,[EType(_,a)]) -> 
                match ty s a with
                | YPrim Float32T -> DLit (LitFloat32 infinityf)
                | YPrim Float64T -> DLit (LitFloat64 infinity)
                | a -> raise_type_error s "Expected a float.\nGot: %s" (show_ty a)
            | EOp(_,Pi,[EType(_,a)]) -> 
                match ty s a with
                | YPrim Float32T -> DLit (LitFloat32 Single.Pi)
                | YPrim Float64T -> DLit (LitFloat64 Double.Pi)
                | a -> raise_type_error s "Expected a float.\nGot: %s" (show_ty a)
            | EOp(_,LitIs,[a]) ->
                match term s a with
                | DLit _ -> DLit (LitBool true)
                | _ -> DLit (LitBool false)
            | EOp(_,PrimIs,[a]) ->
                match term s a |> data_to_ty s with
                | YPrim _ -> DLit (LitBool true)
                | _ -> DLit (LitBool false)
            | EOp(_,SymbolIs,[a]) ->
                match term s a with
                | DSymbol _ -> DLit (LitBool true)
                | _ -> DLit (LitBool false)
            | EOp(_,VarIs,[a]) ->
                match term s a with
                | DNominal(DV _, _) | DV _ -> DLit (LitBool true)
                | _ -> DLit (LitBool false)
            | EOp(_,UnionIs,[a]) -> 
                match term s a with
                | DNominal(DV(L(_,YUnion _)), _) | DNominal(DUnion _, _) -> DLit (LitBool true)
                | _ -> DLit (LitBool false)
            | EOp(_,HeapUnionIs,[a]) ->
                match term s a with
                | DNominal(DV(L(_,YUnion x)), _) | DNominal(DUnion(_,x), _) ->
                    match x.Item.layout with UHeap -> true | UStack -> false
                    |> LitBool |> DLit
                | _ -> DLit (LitBool false)
            | EOp(_,LayoutIs,[a]) ->
                match term s a with
                | DV(L(_,YLayout _)) -> DLit (LitBool true)
                | _ -> DLit (LitBool false)
            | EOp(_,NominalIs,[a]) ->
                match term s a with
                | DNominal(_, _) -> DLit (LitBool true)
                | _ -> DLit (LitBool false)
            | EOp(_,FunctionIs,[a]) ->
                match term s a with
                | DFunction _ | DV(L(_,YFun _)) -> DLit (LitBool true)
                | _ -> DLit (LitBool false)
            | EOp(_,ExistsIs,[a]) ->
                match term s a with
                | DExists _ -> DLit (LitBool true)
                | _ -> DLit (LitBool false)
            | EOp(_,PrimTypeIs,[EType(_,a)]) ->
                match ty s a with
                | YPrim _ -> DLit (LitBool true)
                | _ -> DLit (LitBool false)
            | EOp(_,SymbolTypeIs,[EType(_,a)]) ->
                match ty s a with
                | YSymbol _ -> DLit (LitBool true)
                | _ -> DLit (LitBool false)
            | EOp(_,UnionTypeIs,[EType(_,a)]) -> 
                match ty s a with
                | YNominal _ | YApply _ as a -> 
                    match nominal_type_apply s a with
                    | YUnion _ -> DLit (LitBool true)
                    | _ -> DLit (LitBool false)
                | _ -> DLit (LitBool false)
            | EOp(_,HeapUnionTypeIs,[EType(_,a)]) ->
                match ty s a with
                | YNominal _ | YApply _ as a -> 
                    match nominal_type_apply s a with
                    | YUnion x -> DLit (LitBool (match x.Item.layout with UHeap -> true | UStack -> false))
                    | _ -> DLit (LitBool false)
                | _ -> DLit (LitBool false)
            | EOp(_,LayoutTypeIs,[EType(_,a)]) ->
                match ty s a with
                | YLayout _ -> DLit (LitBool true)
                | _ -> DLit (LitBool false)
            | EOp(_,ExistsTypeIs,[EType(_,a)]) ->
                match ty s a with
                | YExists -> DLit (LitBool true)
                | _ -> DLit (LitBool false)
            | EOp(_,NominalTypeIs,[EType(_,a)]) ->
                match ty s a with
                | YNominal _ | YApply _ -> DLit (LitBool true)
                | _ -> DLit (LitBool false)
            | EOp(_,NominalStrip,[a]) -> 
                match term s a with
                | DNominal(DV(L(_,YUnion _)), _) | DNominal(DUnion _, _) -> raise_type_error s "Cannot strip the nominal wrapper from an union."
                | DNominal(a,_) -> a
                | a -> raise_type_error s <| sprintf "Expected a nominal.\nGot: %s" (show_data a)
            | EOp(_,NominalTypeApply,[EType(_,a)]) -> 
                match ty s a with
                | YNominal _ | YApply _ as a -> DExists([|nominal_type_apply s a|], DB)
                | a -> raise_type_error s <| sprintf "Expected a nominal type.\nGot: %s" (show_ty a)
            | EOp(_,ExistsStrip,[a]) -> 
                match term s a with
                | DExists(_,a) -> a
                | a -> raise_type_error s <| sprintf "Expected an existential.\nGot: %s" (show_data a)
            | EOp(_,PrototypeHas,[prot; EType(_,a)]) ->
                let body (x : Nominal) =
                    let prot_er () = raise_type_error s "Expected a forall or a prototype apply."
                    let rec loop = function
                        | EForall'(_,_,_,x) -> loop x
                        | EPrototypeApply(_,prot_id,_) -> env.prototypes_instances.ContainsKey(prot_id,x.node.id) |> LitBool |> DLit
                        | _ -> prot_er()
                    match term s prot with
                    | DForall(body,_,_,_,_) -> loop body
                    | _ -> prot_er()
                let rec loop = function
                    | YNominal x -> body x
                    | YApply(l,_) -> loop l
                    | a -> raise_type_error s <| sprintf "Expected a nominal.\nGot: %s" (show_ty a)
                loop (ty s a)
            | EOp(_,TypeEq,[EType(_,a);EType(_,b)]) -> DLit(LitBool(ty s a = ty s b))
            | EOp(_,FailWith,[EType(_,typ);a]) ->
                match ty s typ, term s a with
                | typ, (DV(L(_,YPrim StringT)) | DLit(LitString _)) & a -> push_typedop_no_rewrite s (TyFailwith(typ,a)) typ
                | _,a -> raise_type_error s "Expected a string as input to failwith.\nGot: %s" (show_data a)
            | EOp(_,FailWith,_) -> raise_type_error s "Malformed FailWith"
            | EOp(_,ErrorType,[a]) -> term s a |> show_data |> raise_type_error s
            | EOp(_,PrintStatic,[EType(_,a)]) -> printfn "%s" (ty s a |> show_ty); DB
            | EOp(_,PrintStatic,[a]) -> printfn "%s" (term s a |> show_data); DB
            | EOp(_,PrintRaw,[a]) -> printfn "%A" (Printable.eval(Choice1Of2(a,id))); DB
            | EOp(_,UnionTag,[a]) ->
                let eval k (h : Union) = h.Item.tags.[k] |> LitInt32 |> DLit
                match term s a with
                | DNominal(DV(L(_,YUnion h) & v) & a, _) ->
                    match Map.tryFind v s.unions with
                    | Some (UnionData (k,_)) -> eval k h
                    | _ -> push_op s UnionTag a (YPrim Int32T)
                | DNominal(DUnion(DPair(DSymbol k,_),h), _) -> eval k h
                | a -> raise_type_error s <| sprintf "Expected an union.\nGot: %s" (show_data a)
            | EOp(_,Global & op,[a']) ->
                match term s a' with
                | DLit (LitString text) & a ->
                    // if text.Contains "import " || text.Contains "Fable" then
                    //     let s = { s with trace = []; seq = ResizeArray() }
                    //     let l = s.cse |> List.map _.Count |> List.filter ((=) 0) |> List.length
                    //     Console.WriteLine ($"global / text: {text} / s: %A{s} / l: {l}")
                    let cse_counts = s.cse |> List.map _.Count |> List.filter ((=) 0) |> List.length
                    let x_ =
                        s.backend.node = env.backend
                        && s.i.contents < 2
                        && (cse_counts = 2 || cse_counts = 3)
                    if text.Contains "std_path_PathBuf"
                        || text.Contains "std_path_Display"
                        || text.Contains "regex_Regex"
                        || text.Contains "VarError"
                        then
                        trace Verbose (fun () -> $"PartEval.peval / | EOp(_,Global & op,[a]) -> / s.i.contents: %A{s.i.contents} / s.cse.count: %A{s.cse |> List.map _.Count} / s.backend.node: %A{s.backend.node} / op: %A{op} / a': %A{a'} / env.backend: %A{env.backend} / x_: %A{x_} / text: %A{text}") _locals
                    if s.backend.node = env.backend then
                        // trace Verbose (fun () -> $"PartEval.peval / | EOp(_,Global & op,[a]) -> / s.i.contents: %A{s.i.contents} / s.cse.count: %A{s.cse |> List.map _.Count} / s.backend.node: %A{s.backend.node} / op: %A{op} / a': %A{a'} / env.backend: %A{env.backend} / x_: %A{x_} / text: %A{text}") _locals
                    // && s.i.contents < 2
                    // && s.cse |> List.map _.Count |> List.filter ((=) 0) |> List.length = 2
                        global' text
                    push_op_no_rewrite s op a YB
                | a -> raise_type_error s $"Expected a string literal.\nGot: {show_data a}"
            | EOp(_,ToPythonRecord,[a]) ->
                match term s a |> dyn false s with
                | DRecord _ & a -> push_op_no_rewrite s ToPythonRecord a (YMacro [Text "object"])
                | a -> raise_type_error s $"Expected a record.\nGot: {show_data a}"
            | EOp(_,ToPythonNamedTuple,[n;a]) ->
                match term s n, term s a |> dyn false s with
                | (DLit (LitString _) | DV(L(_,YPrim StringT))) & n, DRecord _ & a -> push_binop_no_rewrite s ToPythonNamedTuple (n,a) (YMacro [Text "object"])
                | n, a -> raise_type_error s $"Expected a pair of string and record.\nGot: {show_data n}\nAnd: {show_data a}"
            | EOp(_,VarTag,[a]) ->
                match term s a with
                | DNominal(DV(L(i,_)), _) | DV(L(i,_)) -> DLit (LitInt32 i)
                | a -> raise_type_error s $"Expected a runtime variable.\nGot: {show_data a}"
            | EOp(_,TagToSymbol,[a]) ->
                match term s a with
                | DLit (LitInt32 i) -> DSymbol (string i)
                | a -> raise_type_error s $"Expected an i32 literal.\nGot: {show_data a}"
            | EOp(_,FunctionTermSlotsGet,[a]) ->
                match term s a with
                | DFunction(_,_,free_vars,_,_,_) -> Array.foldBack (fun x s -> DPair(x,s)) free_vars DB
                | DV(L(_,YFun _)) -> raise_type_error s $"Expected a compile time function. Got a runtime one."
                | a -> raise_type_error s $"Expected a compile time function.\nGot: {show_data a}"
            | EOp(_,FunctionTermSlotsSet,[a;b]) ->
                match term s a, term s b with
                | DFunction(q1,q2,free_vars,q4,q5,a6), b -> 
                    let mutable b = b
                    let free_vars = 
                        Array.init free_vars.Length (fun _ -> 
                            match b with
                            | DPair(q,w) -> b <- w; q
                            | DB -> raise_type_error s "Unexpected end of the tuple to be set."
                            | _ -> raise_type_error s $"Expected a pair.\nGot: {show_data b}"
                            ) 
                    match b with
                    | DB -> DFunction(q1,q2,free_vars,q4,q5,a6)
                    | _ -> raise_type_error s $"Expected an unit end of the tuple.\nGot: {show_data b}"
                | DV(L(_,YFun _)), _ -> raise_type_error s $"Expected a compile time function. Got a runtime one."
                | a, _ -> raise_type_error s $"Expected a compile time function.\nGot: {show_data a}"
            | EOp(_,SizeOf,[EType(_,a)]) ->
                match ty s a with
                | YB | YSymbol _ -> DLit (LitInt32 0)
                | YPrim (Int8T | UInt8T | BoolT) -> DLit (LitInt32 1)
                | YPrim (Int16T | UInt16T) -> DLit (LitInt32 2)
                | YPrim (Int32T | UInt32T | Float32T) -> DLit (LitInt32 4)
                | YPrim (Int64T | UInt64T | Float64T) -> DLit (LitInt32 8)
                | a -> push_typedop s (TySizeOf a) (YPrim Int32T) 
            | EOp(_,FreeVars,[a]) ->
                let x = term s a |> data_free_vars
                Array.foldBack (fun x s -> DPair(DV x,s)) x (DRecord Map.empty)
            | EOp(_,FreeVarsReplace,[a;b]) ->
                let a = term s a
                let b = term s b
                let a_fv = a |> data_free_vars
                let b_fv = b |> data_free_vars
                if a_fv.Length <> b_fv.Length then raise_type_error s "The two expressions need to have the same number of free variables."
                let d = Dictionary(HashIdentity.Reference)
                Array.iter2 (fun (L(_,ta) as a) (L(_,tb) as b) -> 
                    if ta <> tb then raise_type_error s $"The free variables can only be replaced with free vars of the same type.\nGot: {show_ty ta}\nExpected: {show_ty tb}"
                    d.Add(a,b)
                    ) a_fv b_fv
                data_free_vars_replace s d a
            | EOp(_,HashSetCreate,[]) -> DHashSet(HashSet(HashIdentity.Reference))
            | EOp(_,HashSetAdd,[h;k]) ->
                match term s h, term s k with
                | DHashSet h, k -> DLit(LitBool(h.Add k))
                | h, _ -> raise_type_error s $"Expected a compile time HashSet.\nGot: {show_data h}"
            | EOp(_,HashSetContains,[h;k]) ->
                match term s h, term s k with
                | DHashSet h, k -> DLit(LitBool(h.Contains k))
                | h, _ -> raise_type_error s $"Expected a compile time HashSet.\nGot: {show_data h}"
            | EOp(_,HashSetRemove,[h;k]) ->
                match term s h, term s k with
                | DHashSet h, k -> DLit(LitBool(h.Remove k))
                | h, _ -> raise_type_error s $"Expected a compile time HashSet.\nGot: {show_data h}"
            | EOp(_,HashSetCount,[h]) ->
                match term s h with
                | DHashSet h -> DLit(LitInt32(h.Count))
                | h -> raise_type_error s $"Expected a compile time HashSet.\nGot: {show_data h}"
            | EOp(_,HashMapCreate,[]) -> DHashMap(OrderedDictionary(HashIdentity.Reference), ref true)
            | EOp(_,HashMapSetImmutable,[h]) -> 
                match term s h with
                | DHashMap(_, is_writable) -> is_writable.Value <- false; DB
                | h -> raise_type_error s $"Expected a compile time HashMap.\nGot: {show_data h}"
            | EOp(_,HashMapSet,[h;k;v]) ->
                match term s h, term s k, term s v with
                | DHashMap(h, is_writable), k, v when is_writable.Value -> h.[k] <- v; DB
                | DHashMap(h, _), _, _ -> raise_type_error s "The hash map has been made read-only and cannot be added to."
                | h, _, _ -> raise_type_error s $"Expected a compile time HashMap.\nGot: {show_data h}"
            | EOp(_,HashMapAdd,[h;k;v]) ->
                match term s h, term s k, term s v with
                | DHashMap(h, is_writable), k, v when is_writable.Value -> if h.TryAdd(k,v) then DB else raise_type_error s "The entry with the same key already exists in the dictionary."
                | DHashMap(h, _), _, _ -> raise_type_error s "The hash map has been made read-only and cannot be added to."
                | h, _, _ -> raise_type_error s $"Expected a compile time HashMap.\nGot: {show_data h}"
            | EOp(_,HashMapTryAdd,[h;k;v]) ->
                match term s h, term s k, term s v with
                | DHashMap(h, is_writable), k, v -> if is_writable.Value then DLit(LitBool(h.TryAdd(k,v))) else raise_type_error s "The hash map has been made read-only and cannot be added to."
                | h, _, _ -> raise_type_error s $"Expected a compile time HashMap.\nGot: {show_data h}"
            | EOp(_,HashMapContains,[h;k]) ->
                match term s h, term s k with
                | DHashMap(h, _), k -> DLit(LitBool(h.ContainsKey k))
                | h, _ -> raise_type_error s $"Expected a compile time HashMap.\nGot: {show_data h}"
            | EOp(_,HashMapRemove,[h;k]) ->
                match term s h, term s k with
                | DHashMap(h, is_writable), k -> if is_writable.Value then DLit(LitBool(h.Remove k)) else raise_type_error s "The hash map has been made read-only and cannot be removed from."
                | h, _ -> raise_type_error s $"Expected a compile time HashMap.\nGot: {show_data h}"
            | EOp(_,HashMapCount,[h]) ->
                match term s h with
                | DHashMap(h, _) -> DLit(LitInt32(h.Count))
                | h -> raise_type_error s $"Expected a compile time HashMap.\nGot: {show_data h}"
            | EOp(_,HashMapTryGet,[h;k]) ->
                match term s h, term s k with
                | DHashMap(h, _), k ->
                    if k |> h.ContainsKey
                    then k |> h.GetValueOrDefault
                    else DSymbol "null"
                | h, _ -> raise_type_error s $"Expected a compile time HashMap.\nGot: {show_data h}"
            | EOp(_,StaticStringConcat,[l]) ->
                let strb = System.Text.StringBuilder()
                let rec loop = function
                    | DPair(a,b) -> loop a; loop b
                    | DLit(LitString x) -> strb.Append(x) |> ignore
                    | DB -> ()
                    | x -> raise_type_error s $"Expected a compile time string or a pair of them.\nGot: {show_data x}"
                loop (term s l)
                DLit(LitString(strb.ToString()))
            | EOp(_,Printf,[fmt;str]) ->
                let fmt,str = term2 s fmt str
                match fmt with
                | DLit(LitString _) -> push_binop_no_rewrite s Printf (fmt, str) YB
                | _ -> raise_type_error s $"Expected a compile time string as the format.\nGot: {show_data fmt}"
            | EOp(_,op,a) -> raise_type_error s <| sprintf "Compiler error: %A with %i args not implemented" op (List.length a)

        let s : LangEnv = {
            trace = []
            seq = null
            cse = []
            unions = Map.empty
            i = ref 0
            env_global_type = [||]
            env_global_term = [||]
            env_stack_type = [||]
            env_stack_term = [||]
            backend = backend_strings.Add env.backend
            globals = ResizeArray ()
            }
        let ty_to_data x = ty_to_data {s with i = ref 0} x
        let nominal_apply x = nominal_type_apply {s with i = ref 0} x

        match x with
        | EFun'(r,_,_,_,_) -> term_scope s (EApply(r,x,EB r)), {join_point_method=join_point_method; join_point_closure=join_point_closure; ty_to_data=ty_to_data; nominal_apply=nominal_apply; globals=s.globals}
        | EForall' _ -> raise_type_error s "The main function should not have a forall."
        | _ -> raise_type_error s "Expected a function as the main."

    /// ## CodegenUtils
    // open System.Text

    /// ### CodegenEnv
    type CodegenEnv =
        {
        text : StringBuilder
        indent : int
        }

    /// ### line
    let line x (s : string) = x.text.Append(' ', x.indent).AppendLine s |> ignore

    /// ### indent
    let indent x : CodegenEnv = {x with indent=x.indent+4}

    /// ### add_dec_point
    let add_dec_point (x : string) = if x.IndexOf('.') = -1 && x.Contains "E" |> not then x + ".0" else x

    /// ### CodegenError
    exception CodegenError of Range option * string

    /// ### CodegenErrorWithPos
    exception CodegenErrorWithPos of Trace * string

    /// ### raise_codegen_error
    let raise_codegen_error x = raise (CodegenError (None,x))

    /// ### raise_codegen_error_backend
    let raise_codegen_error_backend r x = raise (CodegenError (Some r,x))

    /// ### raise_codegen_error'
    let raise_codegen_error' trace (r,x) = raise (CodegenErrorWithPos(Option.fold (fun s x -> x :: s) trace r,x))

    /// ## CodegenFsharp

    /// ### backend_nameFsharp
    let backend_nameFsharp = "Fsharp"

    /// ### litFsharp
    let litFsharp = function
        | LitInt8 x -> sprintf "%iy" x
        | LitInt16 x -> sprintf "%is" x
        | LitInt32 x -> sprintf "%i" x
        | LitInt64 x -> sprintf "%iL" x
        | LitUInt8 x -> sprintf "%iuy" x
        | LitUInt16 x -> sprintf "%ius" x
        | LitUInt32 x -> sprintf "%iu" x
        | LitUInt64 x -> sprintf "%iUL" x
        | LitFloat32 x -> 
            if x = infinityf then "infinityf"
            elif x = -infinityf then "-infinityf"
            elif Single.IsNaN x then "nanf"
            else x.ToString("R") |> add_dec_point |> sprintf "%sf"
        | LitFloat64 x ->
            if x = infinity then "infinity"
            elif x = -infinity then "-infinity"
            elif Double.IsNaN x then "nan"
            else x.ToString("R") |> add_dec_point
        | LitString x -> 
            let strb = StringBuilder(x.Length+2)
            strb.Append '"' |> ignore
            String.iter (function
                | '"' -> strb.Append "\\\"" 
                | '\b' -> strb.Append @"\b"
                | '\t' -> strb.Append @"\t"
                | '\n' -> strb.Append @"\n"
                | '\r' -> strb.Append @"\r"
                | '\\' -> strb.Append @"\\"
                | x -> strb.Append x
                >> ignore 
                ) x
            strb.Append '"' |> ignore
            strb.ToString()
        | LitChar x -> 
            match x with
            | '\b' -> @"\b"
            | '\n' -> @"\n"
            | '\t' -> @"\t"
            | '\r' -> @"\r"
            | '\\' -> @"\\"
            | x -> string x
            |> sprintf "'%s'"
        | LitBool x -> if x then "true" else "false"

    /// ### primFsharp
    let primFsharp = function
        | Int8T -> "int8"
        | Int16T -> "int16"
        | Int32T -> "int32"
        | Int64T -> "int64"
        | UInt8T -> "uint8"
        | UInt16T -> "uint16"
        | UInt32T -> "uint32"
        | UInt64T -> "uint64"
        | Float32T -> "float32"
        | Float64T -> "float"
        | BoolT -> "bool"
        | StringT -> "string"
        | CharT -> "char"

    /// ### type_litFsharp
    let type_litFsharp = function
        | YLit x -> litFsharp x
        | YSymbol x -> x
        | x -> raise_codegen_error "Compiler error: Expecting a type literal in the macro."

    /// ### UnionRecFsharp
    type UnionRecFsharp = {tag : int; free_vars : Map<int * string, TyV[]>}

    /// ### LayoutRecFsharp
    type LayoutRecFsharp = {tag : int; data : Data; free_vars : TyV[]; free_vars_by_key : Map<int * string, TyV[]>}

    /// ### MethodRecFsharp
    type MethodRecFsharp = {tag : int; free_vars : L<Tag,Ty>[]; range : Ty; body : TypedBind[]}

    /// ### ClosureRecFsharp
    type ClosureRecFsharp = {tag : int; free_vars : L<Tag,Ty>[]; domain_args : TyV[]; range : Ty; body : TypedBind[]}

    /// ### codegenFsharp
    let codegenFsharp (env : PartEvalResult) (x : TypedBind []) =
        let types = ResizeArray()
        let functions = ResizeArray()

        let print is_type show r =
            let s = {text=StringBuilder(); indent=0}
            show s r
            let text = s.text.ToString()
            if is_type then types.Add(text) else functions.Add(text)

        let layout show =
            let dict' = Dictionary(HashIdentity.Structural)
            let dict = Dictionary(HashIdentity.Reference)
            let f x : LayoutRecFsharp = 
                match x with
                | YLayout(x,_) ->
                let x = env.ty_to_data x
                let a, b =
                    match x with
                    | DRecord a -> let a = Map.map (fun _ -> data_free_vars) a in a |> Map.toArray |> Array.collect snd, a
                    | _ -> data_free_vars x, Map.empty
                {data=x; free_vars=a; free_vars_by_key=b; tag=dict'.Count}
                | _ -> raise_codegen_error $"Compiler error: Expected a layout type (3).\nGot: %s{show_ty x}"
            fun x ->
                let mutable dirty = false
                let r = memoize dict (memoize dict' (fun x -> dirty <- true; f x)) x
                if dirty then print true show r
                r

        let union show =
            let dict = Dictionary(HashIdentity.Reference)
            let f (a : Map<int * string,Ty>) : UnionRecFsharp = {free_vars=a |> Map.map (fun _ -> env.ty_to_data >> data_free_vars); tag=dict.Count}
            fun x ->
                let mutable dirty = false
                let r = memoize dict (fun x -> dirty <- true; f x) x
                if dirty then print true show r
                r

        let jp f show =
            let dict = Dictionary(HashIdentity.Structural)
            let f x = f (x, dict.Count)
            fun x ->
                let mutable dirty = false
                let r = memoize dict (fun x -> dirty <- true; f x) x
                if dirty then print false show r
                r

        let args x = x |> Array.map (fun (L(i,_)) -> sprintf "v%i" i) |> String.concat ", "
        let show_w = function WV (L(i,_)) -> sprintf "v%i" i | WLit a -> litFsharp a
        let args' x = x |> data_term_vars |> Array.map show_w |> String.concat ", "

        let global' =
            let has_added = HashSet env.globals
            fun x -> if has_added.Add(x) then env.globals.Add x

        let rec tyv x =
            match x with
            | YUnion a -> 
                let a = a.Item
                match a.layout with
                | UHeap -> sprintf "UH%i" (uheap a.cases).tag
                | UStack -> sprintf "US%i" (ustack a.cases).tag
            | YLayout(_,lay) as a -> 
                match lay with
                | Heap -> sprintf "Heap%i" (heap a).tag
                | HeapMutable -> sprintf "Mut%i" (mut a).tag
                | StackMutable -> raise_codegen_error "Compiler error: The F# backend doesn't support stack mutable layout types."
            | YMacro [Text "backend_switch "; Type (YRecord r)] ->
                match r |> Map.tryPick (fun (_, k) v -> if k = backend_nameFsharp then Some v else None) with
                | Some x -> tup_ty x
                | None -> raise_codegen_error $"In the backend_switch, expected a record with the '{backend_nameFsharp}' field."
            | YMacro a -> a |> List.map (function Text a -> a | Type a -> tup_ty a | TypeLit a -> type_litFsharp a) |> String.concat ""
            | YPrim a -> primFsharp a
            | YArray a -> sprintf "(%s [])" (tup_ty a)
            | YFun(a,b,FT_Vanilla) -> sprintf "(%s -> %s)" (tup_ty a) (tup_ty b)
            | YExists -> raise_codegen_error "Existentials are not supported at runtime. They are a compile time feature only."
            | YForall -> raise_codegen_error "Foralls are not supported at runtime. They are a compile time feature only."
            | a -> raise_codegen_error $"Type not supported in the codegen.\nGot: %A{a}"
        and args_tys x = x |> Array.map (fun (L(i,t)) -> sprintf "v%i : %s" i (tup_ty t)) |> String.concat ", "
        and binds (s : CodegenEnv) (x : TypedBind []) =
            Array.iter (function
                | TyLet(d,trace,a) -> try op s (Some d) a with :? CodegenError as e -> raise_codegen_error' trace (e.Data0,e.Data1)
                | TyLocalReturnOp(trace,a,_) -> try op s None a with :? CodegenError as e -> raise_codegen_error' trace (e.Data0,e.Data1)
                | TyLocalReturnData(d,trace) -> try line s (tup d) with :? CodegenError as e -> raise_codegen_error' trace (e.Data0,e.Data1)
                ) x
        and tup x =
            match data_term_vars x with
            | [||] -> "()"
            | [|x|] -> show_w x
            | x -> Array.map show_w x |> String.concat ", " |> sprintf "struct (%s)"
        and tup_ty x =
            match env.ty_to_data x |> data_free_vars |> Array.map (fun (L(_,x)) -> tyv x) with
            | [||] -> "unit"
            | [|x|] -> x
            | x -> String.concat " * " x |> sprintf "struct (%s)"
        and op s d a =
            let jp (a, b) =
                let args = args b
                match a with
                | JPMethod(a,b) -> sprintf "method%i(%s)" (method (a,b)).tag args
                | JPClosure(a,b) -> sprintf "closure%i(%s)" (closure (a,b)).tag args
            let free_vars do_annot x =
                let f (L(i,t)) = if do_annot then sprintf "v%i : %s" i (tyv t) else sprintf "v%i" i
                match data_free_vars x with
                | [||] -> "()"
                | [|x|] -> f x
                | x -> Array.map f x |> String.concat ", " |> sprintf "struct (%s)"
            let simple x = 
                match d with
                | None -> x
                | Some d -> match free_vars true d with "()" -> x | d -> sprintf "let %s = %s" d x
                |> line s
            let complex f =
                match d with
                | None -> f s : unit
                | Some d -> match free_vars true d with "()" -> f s | d -> line s (sprintf "let %s =" d); f (indent s)
            let layout_vars a =
                let f i x =
                    match x with
                    | WV(L(i',_)) -> sprintf "l%i = v%i" i i'
                    | WLit x -> sprintf "l%i = %s" i (litFsharp x)
                a |> data_term_vars |> Array.mapi f |> String.concat "; "
            let layout_index i x =
                x |> Array.map (fun (L(i',_)) -> sprintf "v%i.l%i" i i')
                |> String.concat ", "
                |> function "" -> () | x -> simple x
            let length (a,b) =
                match a with
                | YPrim UInt8T -> sprintf "System.Convert.ToByte %s.Length" (tup b)
                | YPrim UInt16T -> sprintf "System.Convert.ToUInt16 %s.Length" (tup b)
                | YPrim UInt32T -> sprintf "System.Convert.ToUInt32 %s.Length" (tup b)
                | YPrim UInt64T -> sprintf "System.Convert.ToUInt64 %s.Length" (tup b)
                | YPrim Int8T -> sprintf "System.Convert.ToSByte %s.Length" (tup b)
                | YPrim Int16T -> sprintf "System.Convert.ToInt16 %s.Length" (tup b)
                | YPrim Int32T -> sprintf "%s.Length" (tup b)
                | YPrim Int64T -> sprintf "System.Convert.ToInt64 %s.Length" (tup b)
                | _ -> raise_codegen_error "Compiler error: Expected an int in length"
                |> simple
            match a with
            | TyMacro a -> a |> List.map (function CMText x -> x | CMTerm (x,inl) -> (if inl then args' x else tup x) | CMType x -> tup_ty x | CMTypeLit x -> type_litFsharp x) |> String.concat "" |> simple
            | TySizeOf t -> simple $"sizeof<{tup_ty t}>"
            | TyIf(cond,tr,fl) ->
                complex <| fun s ->
                line s (sprintf "if %s then" (tup cond))
                binds (indent s) tr
                match fl with
                | [|TyLocalReturnData(DB,_)|] -> ()
                | _ ->
                    line s "else"
                    binds (indent s) fl
            | TyJoinPoint(a,args) -> simple (jp (a, args))
            | TyBackend(_,_,r) -> raise_codegen_error_backend r "The F# backend does not support nesting other backends."
            | TyWhile(a,b) ->
                complex <| fun s ->
                line s (sprintf "while %s do" (jp a))
                binds (indent s) b
            | TyDo a ->
                complex <| fun s ->
                line s "do"
                binds (indent s) a
            | TyIndent a ->
                complex <| fun s ->
                binds (indent s) a
            | TyIntSwitch(L(i,_),on_succ,on_fail) ->
                complex <| fun s ->
                line s (sprintf "match v%i with" i)
                Array.iteri (fun i x ->
                    line s (sprintf "| %i ->" i)
                    binds (indent s) x
                    ) on_succ
                line s "| _ ->"
                binds (indent s) on_fail
            | TyUnionUnbox(is,x,on_succs,on_fail) ->
                complex <| fun s ->
                let case_tags = x.Item.tags
                line s (sprintf "match %s with" (is |> List.map (fun (L(i,_)) -> $"v{i}") |> String.concat ", "))
                let prefix = 
                    let x = x.Item
                    match x.layout with
                    | UHeap -> sprintf "UH%i" (uheap x.cases).tag
                    | UStack -> sprintf "US%i" (ustack x.cases).tag
                Map.iter (fun k (a,b) ->
                    let i = case_tags.[k]
                    let cases = 
                        a |> List.map (fun a ->
                            match data_free_vars a with
                            | [||] -> ""
                            | x -> sprintf "(%s)" (args x)
                            |> sprintf "%s_%i%s" prefix i
                            )
                        |> String.concat ", "
                    line s (sprintf "| %s -> (* %s *)" cases k)
                    binds (indent s) b
                    ) on_succs
                on_fail |> Option.iter (fun b ->
                    line s "| _ ->"
                    binds (indent s) b
                    )
            | TyUnionBox(a,b,c) ->
                let c = c.Item
                let i = c.tags.[a]
                let vars =
                    match data_term_vars b with
                    | [||] -> ""
                    | x -> Array.map show_w x |> String.concat ", " |> sprintf "(%s)"
                match c.layout with
                | UHeap -> sprintf "UH%i_%i%s" (uheap c.cases).tag i vars
                | UStack -> sprintf "US%i_%i%s" (ustack c.cases).tag i vars
                |> simple
            | TyToLayout(a,b) -> 
                let a = layout_vars a
                match b with
                | YLayout(_,layout) -> 
                    match layout with
                    | Heap -> if a = "" then sprintf "Heap%i()" (heap b).tag else sprintf "{%s} : Heap%i" a (heap b).tag
                    | HeapMutable -> if a = "" then sprintf "Mut%i()" (mut b).tag else sprintf "{%s} : Mut%i" a (mut b).tag
                    | StackMutable -> raise_codegen_error "The F# backend doesn't support stack mutable layout types."
                | _ -> raise_codegen_error $"Compiler error: Expected a layout type (4).\nGot: %s{show_ty b}"
                |> simple
            | TyLayoutIndexAll(L(i,YLayout(_,lay) & a)) -> 
                match lay with
                | Heap -> heap a 
                | HeapMutable -> mut a 
                | StackMutable -> raise_codegen_error "The F# backend doesn't support indexing into stack mutable layout types."
                |> fun x -> x.free_vars |> layout_index i
            | TyLayoutIndexByKey(L(i,YLayout(_,lay) & a),key) -> 
                match lay with
                | Heap -> heap a
                | HeapMutable -> mut a 
                | StackMutable -> raise_codegen_error "The F# backend doesn't support indexing into stack mutable layout types."
                |> fun x ->
                    x.free_vars_by_key
                    |> Map.tryPick (fun (_, k) v -> if k = key then Some v else None)
                    |> Option.iter (layout_index i)
            | TyLayoutIndexAll _ | TyLayoutIndexByKey _ -> raise_codegen_error "Compiler error: Expected the TyV in layout index to be a layout type."
            | TyLayoutMutableSet(L(i,t),b,c) ->
                let a = List.fold (fun s k ->
                    match s with
                    | DRecord l -> l |> Map.pick (fun (_,k') v -> if k' = k then Some v else None)
                    | _ -> raise_codegen_error "Compiler error: Expected a record.") (mut t).data b
                Array.iter2 (fun (L(i',_)) b ->
                    line s (sprintf "v%i.l%i <- %s" i i' (show_w b))
                    ) (data_free_vars a) (data_term_vars c)
            | TyArrayLiteral(a,b) -> simple <| sprintf "[|%s|]" (List.map tup b |> String.concat "; ")
            | TyArrayCreate(a,b) ->
                match b with
                | DLit(LitInt32 _) | DV(L(_,YPrim Int32T)) -> simple (sprintf "Array.zeroCreate<%s> (%s)" (tup_ty a) (tup b))
                | _ -> simple (sprintf "Array.zeroCreate<%s> (System.Convert.ToInt32(%s))" (tup_ty a) (tup b))
            | TyArrayLength(a,b) -> length (a,b)
            | TyStringLength(a,b) -> length (a,b)
            | TyFailwith(a,b) -> simple (sprintf "failwith<%s> %s" (tup_ty a) (tup b))
            | TyConv(a,b) ->
                let b = tup b
                match a with
                | YPrim Int8T -> $"int8 {b}"
                | YPrim Int16T -> $"int16 {b}"
                | YPrim Int32T -> $"int32 {b}"
                | YPrim Int64T -> $"int64 {b}"
                | YPrim UInt8T -> $"uint8 {b}"
                | YPrim UInt16T -> $"uint16 {b}"
                | YPrim UInt32T -> $"uint32 {b}"
                | YPrim UInt64T -> $"uint64 {b}"
                | YPrim Float32T -> $"float32 {b}"
                | YPrim Float64T -> $"float {b}"
                | _ -> raise_codegen_error $"Compiler error: Unexpected type in Conv. Got: {show_ty a}"
                |> simple
            | TyApply(L(i,_),b) -> sprintf "v%i %s" i (tup b) |> simple
            | TyOp(Global, [DLit (LitString x)]) -> global' x
            | TyOp(op,l) ->
                match op, l with
                | Dyn,[a] -> tup a
                | TypeToVar, _ -> raise_codegen_error "The use of `` should never appear in generated code."
                | StringIndex, [a;b] -> sprintf "%s.[int %s]" (tup a) (tup b)
                | StringSlice, [a;b;c] -> sprintf "%s.[int %s..int %s]" (tup a) (tup b) (tup c)
                | ArrayIndex, [a;b] -> sprintf "%s.[int %s]" (tup a) (tup b)
                | ArrayIndexSet, [a;b;c] -> sprintf "%s.[int %s] <- %s" (tup a) (tup b) (tup c) 

                // Math
                | Add, [a;b] -> sprintf "%s + %s" (tup a) (tup b)
                | Sub, [a;b] -> sprintf "%s - %s" (tup a) (tup b)
                | Mult, [a;b] -> sprintf "%s * %s" (tup a) (tup b)
                | Div, [a;b] -> sprintf "%s / %s" (tup a) (tup b)
                | Mod, [a;b] -> sprintf "%s %% %s" (tup a) (tup b)
                | Pow, [a;b] -> sprintf "%s ** %s" (tup a) (tup b)
                | LT, [a;b] -> sprintf "%s < %s" (tup a) (tup b)
                | LTE, [a;b] -> sprintf "%s <= %s" (tup a) (tup b)
                | EQ, [a;b] -> sprintf "%s = %s" (tup a) (tup b)
                | NEQ, [a;b] -> sprintf "%s <> %s" (tup a) (tup b)
                | GT, [a;b] -> sprintf "%s > %s" (tup a) (tup b)
                | GTE, [a;b] -> sprintf "%s >= %s" (tup a) (tup b)
                | BoolAnd, [a;b] -> sprintf "%s && %s" (tup a) (tup b)
                | BoolOr, [a;b] -> sprintf "%s || %s" (tup a) (tup b)
                | BitwiseAnd, [a;b] -> sprintf "%s &&& %s" (tup a) (tup b)
                | BitwiseOr, [a;b] -> sprintf "%s ||| %s" (tup a) (tup b)
                | BitwiseXor, [a;b] -> sprintf "%s ^^^ %s" (tup a) (tup b)
                | BitwiseComplement, [a] -> sprintf "~~~%s" (tup a)

                | ShiftLeft, [a;b] -> sprintf "%s <<< %s" (tup a) (tup b)
                | ShiftRight, [a;b] -> sprintf "%s >>> %s" (tup a) (tup b)

                | Neg, [x] -> sprintf " -%s" (tup x)
                | Log, [x] -> sprintf "log %s" (tup x)
                | Exp, [x] -> sprintf "exp %s" (tup x)
                | Tanh, [x] -> sprintf "tanh %s" (tup x)
                | Sqrt, [x] -> sprintf "sqrt %s" (tup x)
                | Sin, [x] -> sprintf "sin %s" (tup x)
                | Cos, [x] -> sprintf "cos %s" (tup x)
                | NanIs, [x] -> 
                    match x with
                    | DLit(LitFloat32 _) | DV(L(_,YPrim Float32T)) -> sprintf "Single.IsNaN(%s)" (tup x)
                    | DLit(LitFloat64 _) | DV(L(_,YPrim Float64T)) -> sprintf "Double.IsNaN(%s)" (tup x)
                    | _ -> raise_codegen_error "Compiler error: Invalid type in NanIs."
                | UnionTag, [DV(L(i,YUnion h))] -> 
                    let h = h.Item
                    let ty =
                        match h.layout with
                        | UHeap -> sprintf "UH%i" (uheap h.cases).tag
                        | UStack -> sprintf "US%i" (ustack h.cases).tag
                    let items =
                        h.cases
                        |> Seq.map (fun (KeyValue ((i, _), _)) ->
                            $"{ty}_{i}, {i}"
                        )
                        |> String.concat "; "
                    $"[ {items} ] |> Map |> Map.find v{i}"
                | _ -> raise_codegen_error <| sprintf "Compiler error: %A with %i args not supported" op l.Length
                |> simple
        and heap : _ -> LayoutRecFsharp = layout (fun s x ->
            let b = x.free_vars |> Array.map (fun (L(i,t)) -> sprintf "l%i : %s" i (tyv t)) |> String.concat "; "
            if b = "" then line s (sprintf "Heap%i() = class end" x.tag)
            else line s (sprintf "Heap%i = {%s}" x.tag b)
            )
        and mut : _ -> LayoutRecFsharp = layout (fun s x ->
            let b = x.free_vars |> Array.map (fun (L(i,t)) -> sprintf "mutable l%i : %s" i (tyv t)) |> String.concat "; "
            if b = "" then line s (sprintf "Mut%i() = class end" x.tag)
            else line s (sprintf "Mut%i = {%s}" x.tag b)
            )
        and uheap : _ -> UnionRecFsharp = union (fun s x ->
            line s (sprintf "UH%i =" x.tag)
            let mutable i = 0
            x.free_vars |> Map.iter (fun _ a ->
                match a with
                | [||] -> line (indent s) (sprintf "| UH%i_%i" x.tag i)
                | a -> line (indent s) (sprintf "| UH%i_%i of %s" x.tag i (a |> Array.map (fun (L(_,t)) -> tyv t) |> String.concat " * "))
                i <- i+1
                )
            )
        and ustack : _ -> UnionRecFsharp = union (fun s x ->
            line s (sprintf "[<Struct>] US%i =" x.tag)
            let mutable i = 0
            x.free_vars |> Map.iter (fun _ a ->
                match a with
                | [||] -> line (indent s) (sprintf "| US%i_%i" x.tag i)
                | a -> line (indent s) (sprintf "| US%i_%i of %s" x.tag i (a |> Array.mapi (fun i' (L(_,t)) -> sprintf "f%i_%i : %s" i i' (tyv t)) |> String.concat " * "))
                i <- i+1
                )
            )
        and method : _ -> MethodRecFsharp =
            jp (fun ((jp_body,key & (C(args,_))),i) ->
                match (fst env.join_point_method.[jp_body]).[key] with
                | Some a, Some range, _ -> {tag=i; free_vars=rdata_free_vars args; range=range; body=a}
                | _ -> raise_codegen_error "Compiler error: The method dictionary is malformed"
                ) (fun s x ->
                line s (sprintf "method%i (%s) : %s =" x.tag (args_tys x.free_vars) (tup_ty x.range))
                binds (indent s) x.body
                )
        and closure : _ -> ClosureRecFsharp =
            jp (fun ((jp_body,key & (C(args,_,fun_ty))),i) ->
                match fun_ty with
                | YFun(domain,range,FT_Vanilla) ->
                    match (fst env.join_point_closure.[jp_body]).[key] with
                    | Some(domain_args, body) -> {tag=i; free_vars=rdata_free_vars args; domain_args=data_free_vars domain_args; range=range; body=body}
                    | _ -> raise_codegen_error "Compiler error: The method dictionary is malformed"
                | YFun(_,_,_) -> raise_codegen_error "Non-standard functions are not supported in the F# backend."
                | _ -> raise_codegen_error "Compiler error: Unexpected type in the closure join point."
                ) (fun s x ->
                let domain = 
                    match x.domain_args |> Array.map (fun (L(i,t)) -> sprintf "v%i : %s" i (tyv t)) with
                    | [||] -> "()"
                    | [|x|] -> sprintf "(%s)" x
                    | x -> String.concat ", " x |> sprintf "struct (%s)"
                line s (sprintf "closure%i (%s) %s : %s =" x.tag (args_tys x.free_vars) domain (tup_ty x.range))
                binds (indent s) x.body
                )

        let main = StringBuilder()
        binds {text=main; indent=0} x

        let program = StringBuilder()
        env.globals |> Seq.iter (fun (x : string) -> program.AppendLine(x) |> ignore)
        types |> Seq.iteri (fun i x -> program.Append(if i = 0 then "type " else "and ").Append(x) |> ignore)
        functions |> Seq.iteri (fun i x -> program.Append(if i = 0 then "let rec " else "and ").Append(x) |> ignore)
        program.Append(main).ToString()

    /// ## CodegenGleam

    /// ### backend_nameGleam
    let backend_nameGleam = "Gleam"

    /// ### litGleam
    let litGleam = function
        | LitInt8 x -> sprintf "%i" x
        | LitInt16 x -> sprintf "%i" x
        | LitInt32 x -> sprintf "%i" x
        | LitInt64 x -> sprintf "%i" x
        | LitUInt8 x -> sprintf "%i" x
        | LitUInt16 x -> sprintf "%i" x
        | LitUInt32 x -> sprintf "%i" x
        | LitUInt64 x -> sprintf "%i" x
        | LitFloat32 x -> 
            if x = infinityf then "infinityf"
            elif x = -infinityf then "-infinityf"
            elif Single.IsNaN x then "nanf"
            else x.ToString("R") |> add_dec_point |> sprintf "%s"
        | LitFloat64 x ->
            if x = infinity then "infinity"
            elif x = -infinity then "-infinity"
            elif Double.IsNaN x then "nan"
            else x.ToString("R") |> add_dec_point
        | LitString x -> 
            let strb = StringBuilder(x.Length+2)
            strb.Append '"' |> ignore
            String.iter (function
                | '"' -> strb.Append "\\\"" 
                | '\b' -> strb.Append @"\b"
                | '\t' -> strb.Append @"\t"
                | '\n' -> strb.Append @"\n"
                | '\r' -> strb.Append @"\r"
                | '\\' -> strb.Append @"\\"
                | x -> strb.Append x
                >> ignore 
                ) x
            strb.Append '"' |> ignore
            strb.ToString()
        | LitChar x -> 
            match x with
            | '\b' -> @"\b"
            | '\n' -> @"\n"
            | '\t' -> @"\t"
            | '\r' -> @"\r"
            | '\\' -> @"\\"
            | '"' -> "\\\""
            | x -> string x
            |> sprintf "\"%s\""
        | LitBool x -> if x then "True" else "False"

    /// ### primGleam
    let primGleam = function
        | Int8T -> "Int"
        | Int16T -> "Int"
        | Int32T -> "Int"
        | Int64T -> "Int"
        | UInt8T -> "Int"
        | UInt16T -> "Int"
        | UInt32T -> "Int"
        | UInt64T -> "Int"
        | Float32T -> "Float"
        | Float64T -> "Float"
        | BoolT -> "Bool"
        | StringT -> "String"
        | CharT -> "String"

    /// ### type_litGleam
    let type_litGleam = function
        | YLit x -> litGleam x
        | YSymbol x -> x
        | x -> raise_codegen_error "Compiler error: Expecting a type literal in the macro."

    /// ### UnionRecGleam
    type UnionRecGleam = {tag : int; free_vars : Map<int * string, TyV[]>}

    /// ### LayoutRecGleam
    type LayoutRecGleam = {tag : int; data : Data; free_vars : TyV[]; free_vars_by_key : Map<int * string, TyV[]>}

    /// ### MethodRecGleam
    type MethodRecGleam = {tag : int; free_vars : L<Tag,Ty>[]; range : Ty; body : TypedBind[]}

    /// ### ClosureRecGleam
    type ClosureRecGleam = {tag : int; free_vars : L<Tag,Ty>[]; domain_args : TyV[]; range : Ty; body : TypedBind[]}

    /// ### codegenGleam
    let codegenGleam (env : PartEvalResult) (x : TypedBind []) =
        let types = ResizeArray()
        let functions = ResizeArray()

        let print is_type show r =
            let s = {text=StringBuilder(); indent=0}
            show s r
            let text = s.text.ToString()
            if is_type then types.Add(text) else functions.Add(text)

        let layout show =
            let dict' = Dictionary(HashIdentity.Structural)
            let dict = Dictionary(HashIdentity.Reference)
            let f x : LayoutRecGleam = 
                match x with
                | YLayout(x,_) ->
                let x = env.ty_to_data x
                let a, b =
                    match x with
                    | DRecord a -> let a = Map.map (fun _ -> data_free_vars) a in a |> Map.toArray |> Array.collect snd, a
                    | _ -> data_free_vars x, Map.empty
                {data=x; free_vars=a; free_vars_by_key=b; tag=dict'.Count}
                | _ -> raise_codegen_error $"Compiler error: Expected a layout type (3).\nGot: %s{show_ty x}"
            fun x ->
                let mutable dirty = false
                let r = memoize dict (memoize dict' (fun x -> dirty <- true; f x)) x
                if dirty then print true show r
                r

        let union show =
            let dict = Dictionary(HashIdentity.Reference)
            let f (a : Map<int * string,Ty>) : UnionRecGleam = {free_vars=a |> Map.map (fun _ -> env.ty_to_data >> data_free_vars); tag=dict.Count}
            fun x ->
                let mutable dirty = false
                let r = memoize dict (fun x -> dirty <- true; f x) x
                if dirty then print true show r
                r

        let jp f show =
            let dict = Dictionary(HashIdentity.Structural)
            let f x = f (x, dict.Count)
            fun x ->
                let mutable dirty = false
                let r = memoize dict (fun x -> dirty <- true; f x) x
                if dirty then print false show r
                r

        let args x = x |> Array.map (fun (L(i,_)) -> sprintf "v%i" i) |> String.concat ", "
        let show_w = function WV (L(i,_)) -> sprintf "v%i" i | WLit a -> litGleam a
        let args' x = x |> data_term_vars |> Array.map show_w |> String.concat ", "

        let global' =
            let has_added = HashSet env.globals
            fun x -> if has_added.Add(x) then env.globals.Add x

        let rec tyv x =
            match x with
            | YUnion a -> 
                let a = a.Item
                match a.layout with
                | UHeap -> sprintf "Uh%i" (uheap a.cases).tag
                | UStack -> sprintf "Us%i" (ustack a.cases).tag
            | YLayout(_,lay) as a -> 
                match lay with
                | Heap -> sprintf "Heap%i" (heap a).tag
                | HeapMutable -> sprintf "Mut%i" (mut a).tag
                | StackMutable -> raise_codegen_error "Compiler error: The F# backend doesn't support stack mutable layout types."
            | YMacro [Text "backend_switch "; Type (YRecord r)] ->
                match r |> Map.tryPick (fun (_, k) v -> if k = backend_nameGleam then Some v else None) with
                | Some x -> tup_ty x
                | None -> raise_codegen_error $"In the backend_switch, expected a record with the '{backend_nameGleam}' field."
            | YMacro a -> a |> List.map (function Text a -> a | Type a -> tup_ty a | TypeLit a -> type_litGleam a) |> String.concat ""
            | YPrim a -> primGleam a
            | YArray a ->
                global' "import gary"
                global' "import gary/array"
                sprintf "gary.ErlangArray(%s)" (tup_ty a)
            | YFun(a,b,FT_Vanilla) -> sprintf "fn(%s) -> %s" (tup_ty a) (tup_ty b)
            | YExists -> raise_codegen_error "Existentials are not supported at runtime. They are a compile time feature only."
            | YForall -> raise_codegen_error "Foralls are not supported at runtime. They are a compile time feature only."
            | a -> raise_codegen_error $"Type not supported in the codegen.\nGot: %A{a}"
        and args_tys x = x |> Array.map (fun (L(i,t)) -> sprintf "v%i :    %s" i (tup_ty t)) |> String.concat ", "
        and binds (s : CodegenEnv) (x : TypedBind []) =
            Array.iter (function
                | TyLet(d,trace,a) -> try op s (Some d) a with :? CodegenError as e -> raise_codegen_error' trace (e.Data0,e.Data1)
                | TyLocalReturnOp(trace,a,_) -> try op s None a with :? CodegenError as e -> raise_codegen_error' trace (e.Data0,e.Data1)
                | TyLocalReturnData(d,trace) -> try line s (tup d) with :? CodegenError as e -> raise_codegen_error' trace (e.Data0,e.Data1)
                ) x
        and tup x =
            match data_term_vars x with
            | [||] -> "Nil "
            | [|x|] -> show_w x
            | x -> Array.map show_w x |> String.concat ", " |> sprintf "#(%s) "
        and tup_ty x =
            match env.ty_to_data x |> data_free_vars |> Array.map (fun (L(_,x)) -> tyv x) with
            | [||] -> "Nil  "
            | [|x|] -> x
            | x -> String.concat ", " x |> sprintf "#(%s)  "
        and op s d a =
            let a'' = a
            let jp (a, b) =
                let a' = a
                let b' = b
                let args = args b
                match a with
                | JPMethod(a,b) -> sprintf "method%i(%s)" (method (a,b)).tag args
                | JPClosure(a,b) ->
                    let code =
                        [
                            "closure"
                            (a, b) |> closure |> _.tag |> string
                            "("
                            if args = "" then "" else $")(#({args})"
                            ")"
                            // if args = "" || args |> SpiralSm.contains ", "
                            // then ""
                            // else "( Nil )"
                        ]
                        |> SpiralSm.concat ""
                    if args = ""
                    then $"fn (x) {{ {code}(#(x))(   Nil) }}"
                    else code
                    |> fun code ->
                        let comment =
                            $"// args: %A{args} / d: %A{d} / b': %A{b'} / b: %A{b}"
                            |> SpiralSm.replace "\r\n" ""
                            |> SpiralSm.replace "\n" ""
                            |> fun comment -> $"{comment |> SpiralSm.ellipsis 1000}\n"
                        $"{code} {comment}"
            let free_vars do_annot x =
                let f (L(i,t)) = if do_annot then sprintf "v%i :  %s" i (tyv t) else sprintf "v%i" i
                match data_free_vars x with
                | [||] -> "Nil   "
                | [|x|] -> f x
                | x -> Array.map f x |> String.concat ", " |> sprintf "#(%s)   "
            let simple x = 
                match d with
                | None -> x
                | Some d ->
                    match free_vars false d |> SpiralSm.trim with
                    | "Nil" -> x
                    | d -> sprintf "let %s = %s" d x
                |> line s
            let complex f =
                match d with
                | None -> f s : unit
                | Some d ->
                    match free_vars false d |> SpiralSm.trim with
                    | "Nil" -> f s
                    | d ->
                        line s (sprintf "let %s =" d)
                        f (indent s)
            let layout_vars a =
                let f i x =
                    match x with
                    | WV(L(i',_)) -> sprintf "l%i :  v%i" i i'
                    | WLit x -> sprintf "l%i :  %s" i (litGleam x)
                a |> data_term_vars |> Array.mapi f |> String.concat ", "
            let layout_index i x =
                x |> Array.map (fun (L(i',_)) -> sprintf "v%i.l%i " i i')
                |> String.concat ", "
                |> function "" -> () | x -> simple x
            let length (a,b) =
                global' "import gleam/string"
                sprintf "string.length(%s)" (tup b)
                |> simple
            let listToArray panic x =
                global' "import gary/array"
                global' "import gleam/option"
                global' "import gleam/list"
                $"{x} " +
                $"|> list.map(option.Some) " +
                $"|> array.from_list(option.None) " +
                $"|> array.map(fn(_, x) {{ " +
                $"     case x {{ " +
                $"       option.Some(x) -> x " +
                $"       _ -> panic as \"{panic}\" " +
                $"     }} " +
                $"   }}) "
            match a with
            | TyMacro a -> a |> List.map (function CMText x -> x | CMTerm (x,inl) -> (if inl then args' x else tup x) | CMType x -> tup_ty x | CMTypeLit x -> type_litGleam x) |> String.concat "" |> simple
            | TySizeOf t -> simple $"0"
            | TyIf(cond,tr,fl) ->
                complex <| fun s ->
                // line s (sprintf "if %s then" (tup cond))
                line s (sprintf "case %s {" (tup cond))
                line (indent s) "True -> {"
                binds (indent (indent s)) tr
                line (indent s) "}"
                line (indent s) "False -> {"
                match fl with
                | [|TyLocalReturnData(DB,_)|] ->
                    line (indent s) "Nil"
                | _ ->
                    binds (indent (indent s)) fl
                line (indent s) "}"
                line s "}"
            | TyJoinPoint(a,args) -> simple (jp (a, args))
            | TyBackend(_,_,r) -> raise_codegen_error_backend r "The Gleam backend does not support nesting other backends."
            | TyWhile(a,b) ->
                complex <| fun s ->
                line s (sprintf "while %s {" (jp a))
                binds (indent s) b
                line s "}"
            | TyDo a ->
                complex <| fun s ->
                line s "{"
                binds (indent s) a
                line s "}"
            | TyIndent a ->
                complex <| fun s ->
                binds (indent s) a
            | TyIntSwitch(L(i,_),on_succ,on_fail) ->
                complex <| fun s ->
                line s (sprintf "case v%i {" i)
                Array.iteri (fun i x ->
                    line (indent s) (sprintf "%i -> {" i)
                    binds (indent (indent s)) x
                    line (indent s) "}"
                    ) on_succ
                line (indent s) "_ -> {"
                binds (indent (indent s)) on_fail
                line (indent s) "}"
            | TyUnionUnbox(is,x,on_succs,on_fail) ->
                complex <| fun s ->
                let case_tags = x.Item.tags
                line s (sprintf "case %s {" (is |> List.map (fun (L(i,_)) -> $"v{i}") |> String.concat ", "))
                let prefix = 
                    let x = x.Item
                    match x.layout with
                    | UHeap -> sprintf "Uh%i" (uheap x.cases).tag
                    | UStack -> sprintf "Us%i" (ustack x.cases).tag
                Map.iter (fun k (a,b) ->
                    let i = case_tags.[k]
                    let cases = 
                        a |> List.map (fun a ->
                            match data_free_vars a with
                            | [||] -> ""
                            | x -> sprintf "(%s)" (args x)
                            |> sprintf "%si%i%s" prefix i
                            )
                        |> String.concat ", "
                    line (indent s) (sprintf "%s -> { // %s" cases k)
                    binds (indent (indent s)) b
                    line (indent s) "}"
                    ) on_succs
                on_fail |> Option.iter (fun b ->
                    line (indent s) "_ -> {"
                    binds (indent (indent s)) b
                    line (indent s) "}"
                    )
                line s "}"
            | TyUnionBox(a,b,c) ->
                let c = c.Item
                let i = c.tags.[a]
                let vars =
                    match data_term_vars b with
                    | [||] -> ""
                    | x -> Array.map show_w x |> String.concat ", " |> sprintf "(%s)"
                match c.layout with
                | UHeap -> sprintf "Uh%ii%i%s" (uheap c.cases).tag i vars
                | UStack -> sprintf "Us%ii%i%s" (ustack c.cases).tag i vars
                |> simple
            | TyToLayout(a,b) -> 
                let a = layout_vars a
                match b with
                | YLayout(_,layout) -> 
                    match layout with
                    | Heap -> if a = "" then sprintf "Heap%i()" (heap b).tag else sprintf "Heap%i(%s)" (heap b).tag a
                    | HeapMutable -> if a = "" then sprintf "Mut%i()" (mut b).tag else sprintf "Mut%i(%s)" (mut b).tag a
                    | StackMutable -> raise_codegen_error "The F# backend doesn't support stack mutable layout types."
                | _ -> raise_codegen_error $"Compiler error: Expected a layout type (4).\nGot: %s{show_ty b}"
                |> simple
            | TyLayoutIndexAll(L(i,YLayout(_,lay) & a)) -> 
                match lay with
                | Heap -> heap a 
                | HeapMutable -> mut a 
                | StackMutable -> raise_codegen_error "The Gleam backend doesn't support indexing into stack mutable layout types."
                |> fun x -> x.free_vars |> layout_index i
            | TyLayoutIndexByKey(L(i,YLayout(_,lay) & a),key) -> 
                match lay with
                | Heap -> heap a
                | HeapMutable -> mut a 
                | StackMutable -> raise_codegen_error "The Gleam backend doesn't support indexing into stack mutable layout types."
                |> fun x ->
                    x.free_vars_by_key
                    |> Map.tryPick (fun (_, k) v -> if k = key then Some v else None)
                    |> Option.iter (layout_index i)
            | TyLayoutIndexAll _ | TyLayoutIndexByKey _ -> raise_codegen_error "Compiler error: Expected the TyV in layout index to be a layout type."
            | TyLayoutMutableSet(L(i,t),b,c) ->
                let a = List.fold (fun s k ->
                    match s with
                    | DRecord l -> l |> Map.pick (fun (_,k') v -> if k' = k then Some v else None)
                    | _ -> raise_codegen_error "Compiler error: Expected a record.") (mut t).data b
                let a_vars = data_free_vars a
                Array.iter2 (fun (L(i',_)) b ->
                    if a_vars |> Array.length > 1
                    then line s (sprintf "let v%i = %s(..v%i, l%i: %s)" i (tup_ty t) i i' (show_w b))
                    else line s (sprintf "let v%i = %s(l%i: %s)" i (tup_ty t) i' (show_w b))
                    ) a_vars (data_term_vars c)
            | TyArrayLiteral(a,b) ->
                $"""[ {List.map tup b |> String.concat ", "} ]"""
                |> listToArray "spiral_compiler..TyArrayLiteral"
                |> simple
            | TyArrayCreate(a,b) -> $"[]" |> listToArray "spiral_compiler..TyArrayCreate" |> simple
            | TyArrayLength(a,b) ->
                global' "import gary/array"
                sprintf "array.get_size(%s)" (tup b)
                |> simple
            | TyStringLength(a,b) -> length (a,b)
            | TyFailwith(a,b) -> simple (sprintf "panic as %s" (tup b))
            | TyConv(a,b) ->
                let b = tup b
                match a with
                | YPrim Int8T -> $"{b}"
                | YPrim Int16T -> $"{b}"
                | YPrim Int32T -> $"{b}"
                | YPrim Int64T -> $"{b}"
                | YPrim UInt8T -> $"{b}"
                | YPrim UInt16T -> $"{b}"
                | YPrim UInt32T -> $"{b}"
                | YPrim UInt64T -> $"{b}"
                | YPrim Float32T -> $"{b}"
                | YPrim Float64T -> $"{b}"
                | _ -> raise_codegen_error $"Compiler error: Unexpected type in Conv. Got: {show_ty a}"
                |> simple
            | TyApply(L(i,t),b) ->
                match tup b with
                // | "Nil " when tup_ty t |> SpiralSm.starts_with "fn(Nil  ) -> " -> $"    v{i}    "
                | "Nil " when tup_ty t |> SpiralSm.starts_with "fn(Nil  ) -> " -> $"    v{i}( Nil      )"
                | "Nil " -> $"v{i} "
                | b' when tup_ty t |> SpiralSm.starts_with "fn(Nil  ) -> " -> $"v{i}( {b'}(      Nil)  ) "
                | b' -> $"v{i}( {b'}  )"
                |> fun code ->
                    let comment =
                        $"// tup_ty t: {tup_ty t} / b: %A{b} / d: %A{d} / a'': %A{a''}"
                        |> SpiralSm.replace "\r\n" ""
                        |> SpiralSm.replace "\n" ""
                        |> fun comment -> $"{comment |> SpiralSm.ellipsis 1000}\n"
                    $"{code} {comment}"
                |> simple
            | TyOp(Global, [DLit (LitString x)]) -> global' x
            | TyOp(op,l) ->
                match op, l with
                | Dyn,[a] -> tup a
                | TypeToVar, _ -> raise_codegen_error "The use of `` should never appear in generated code."
                | StringIndex, [a;b] ->
                    global' "import gleam/string"
                    sprintf "%s |> string.slice(%s, 1)" (tup a) (tup b)
                | StringSlice, [a;b;c] ->
                    global' "import gleam/string"
                    sprintf "%s |> string.slice(%s, %s)" (tup a) (tup b) (tup c)
                | ArrayIndex, [a;b] ->
                    global' "import gary/array"
                    $"{tup a} " +
                    $"|> array.get({tup b}) " +
                    $"|> fn(x) -> _ {{ " +
                    $"     case x {{ " +
                    $"       Ok(x) -> x " +
                    $"       Error(_) -> panic as \"spiral_compiler..ArrayIndex / i: {tup b}\" " +
                    $"     }} " +
                    $"   }} "
                | ArrayIndexSet, [a;b;c] ->
                    global' "import gary/array"
                    global' "import gleam/result"
                    sprintf "%s |> array.set(%s, %s) |> result.unwrap" (tup a) (tup b) (tup c)

                // Math
                | Add, [a;b] -> sprintf "%s + %s" (tup a) (tup b)
                | Sub, [a;b] -> sprintf "%s - %s" (tup a) (tup b)
                | Mult, [a;b] -> sprintf "%s * %s" (tup a) (tup b)
                | Div, [a;b] -> sprintf "%s / %s" (tup a) (tup b)
                | Mod, [a;b] -> sprintf "%s %% %s" (tup a) (tup b)
                | Pow, [a;b] -> sprintf "%s ** %s" (tup a) (tup b)
                | LT, [a;b] -> sprintf "%s < %s" (tup a) (tup b)
                | LTE, [a;b] -> sprintf "%s <= %s" (tup a) (tup b)
                | EQ, [a;b] -> sprintf "%s == %s" (tup a) (tup b)
                | NEQ, [a;b] -> sprintf "%s != %s" (tup a) (tup b)
                | GT, [a;b] -> sprintf "%s > %s" (tup a) (tup b)
                | GTE, [a;b] -> sprintf "%s >= %s" (tup a) (tup b)
                | BoolAnd, [a;b] -> sprintf "%s && %s" (tup a) (tup b)
                | BoolOr, [a;b] -> sprintf "%s || %s" (tup a) (tup b)
                | BitwiseAnd, [a;b] -> sprintf "%s &&& %s" (tup a) (tup b)
                | BitwiseOr, [a;b] -> sprintf "%s ||| %s" (tup a) (tup b)
                | BitwiseXor, [a;b] -> sprintf "%s ^^^ %s" (tup a) (tup b)
                | BitwiseComplement, [a] -> sprintf "~~~%s" (tup a)

                | ShiftLeft, [a;b] -> sprintf "%s <<< %s" (tup a) (tup b)
                | ShiftRight, [a;b] -> sprintf "%s >>> %s" (tup a) (tup b)

                | Neg, [x] -> sprintf " -%s" (tup x)
                | Log, [x] -> sprintf "log %s" (tup x)
                | Exp, [x] -> sprintf "exp %s" (tup x)
                | Tanh, [x] -> sprintf "tanh %s" (tup x)
                | Sqrt, [x] -> sprintf "sqrt %s" (tup x)
                | Sin, [x] -> sprintf "sin %s" (tup x)
                | Cos, [x] -> sprintf "cos %s" (tup x)
                | NanIs, [x] -> 
                    match x with
                    | DLit(LitFloat32 _) | DV(L(_,YPrim Float32T)) -> sprintf "Single.IsNaN(%s)" (tup x)
                    | DLit(LitFloat64 _) | DV(L(_,YPrim Float64T)) -> sprintf "Double.IsNaN(%s)" (tup x)
                    | _ -> raise_codegen_error "Compiler error: Invalid type in NanIs."
                | UnionTag, [DV(L(i,YUnion h))] -> 
                    let h = h.Item
                    let ty =
                        match h.layout with
                        | UHeap -> sprintf "Uh%i" (uheap h.cases).tag
                        | UStack -> sprintf "Us%i" (ustack h.cases).tag
                    let items =
                        h.cases
                        |> Seq.map (fun (KeyValue ((i, _), _)) ->
                            $"#({ty}i{i}, {i})"
                        )
                        |> String.concat ", "
                    global' "import gleam/dict"
                    global' "import gleam/result"
                    $"[ {items} ] |> dict.from_list |> dict.get(v{i}) |> result.unwrap(0)"
                | _ -> raise_codegen_error <| sprintf "Compiler error: %A with %i args not supported" op l.Length
                |> simple
        and heap : _ -> LayoutRecGleam = layout (fun s x ->
            let b = x.free_vars |> Array.map (fun (L(i,t)) -> sprintf "l%i : %s" i (tyv t)) |> String.concat ", "
            if b = "" then line s (sprintf "Heap%i { Heap%i() }" x.tag x.tag)
            else line s (sprintf "Heap%i { Heap%i(%s) }" x.tag x.tag b)
            )
        and mut : _ -> LayoutRecGleam = layout (fun s x ->
            let b = x.free_vars |> Array.map (fun (L(i,t)) -> sprintf "l%i : %s" i (tyv t)) |> String.concat ", "
            if b = "" then line s (sprintf "Mut%i { Mut%i() }" x.tag x.tag)
            else line s (sprintf "Mut%i { Mut%i(%s) }" x.tag x.tag b)
            )
        and uheap : _ -> UnionRecGleam = union (fun s x ->
            line s (sprintf "Uh%i {" x.tag)
            let mutable i = 0
            x.free_vars |> Map.iter (fun _ a ->
                match a with
                | [||] -> line (indent s) (sprintf "Uh%ii%i" x.tag i)
                | a -> line (indent s) (sprintf "Uh%ii%i(%s)" x.tag i (a |> Array.map (fun (L(_,t)) -> tyv t) |> String.concat ", "))
                i <- i+1
                )
            line s "}"
            )
        and ustack : _ -> UnionRecGleam = union (fun s x ->
            line s (sprintf "Us%i {" x.tag)
            let mutable i = 0
            x.free_vars |> Map.iter (fun _ a ->
                match a with
                | [||] -> line (indent s) (sprintf "Us%ii%i" x.tag i)
                | a -> line (indent s) (sprintf "Us%ii%i(%s)" x.tag i (a |> Array.mapi (fun i' (L(_,t)) -> sprintf "f%ii%i : %s" i i' (tyv t)) |> String.concat ", "))
                i <- i+1
                )
            line s "}"
            )
        and method : _ -> MethodRecGleam =
            jp (fun ((jp_body,key & (C(args,_))),i) ->
                match (fst env.join_point_method.[jp_body]).[key] with
                | Some a, Some range, _ -> {tag=i; free_vars=rdata_free_vars args; range=range; body=a}
                | _ -> raise_codegen_error "Compiler error: The method dictionary is malformed"
                ) (fun s x ->
                let range_ty = tup_ty x.range
                let is_fn = range_ty |> SpiralSm.starts_with "fn(Nil  ) -> "
                let ret =
                    if is_fn
                    then $"{range_ty} {{ fn(_)"
                    else range_ty
                line s $"method{x.tag} ({args_tys x.free_vars}) -> {ret} {{"
                binds (indent s) x.body
                if is_fn
                then line s "(    Nil  )}}"
                else line s "}"
                )
        and closure : _ -> ClosureRecGleam =
            jp (fun ((jp_body,key & (C(args,_,fun_ty))),i) ->
                match fun_ty with
                | YFun(domain,range,FT_Vanilla) ->
                    match (fst env.join_point_closure.[jp_body]).[key] with
                    | Some(domain_args, body) -> {tag=i; free_vars=rdata_free_vars args; domain_args=data_free_vars domain_args; range=range; body=body}
                    | _ -> raise_codegen_error "Compiler error: The method dictionary is malformed"
                | YFun(_,_,_) -> raise_codegen_error "Non-standard functions are not supported in the F# backend."
                | _ -> raise_codegen_error "Compiler error: Unexpected type in the closure join point."
                ) (fun s x ->
                let domain, nil =
                    let domain_args, nil =
                        let t () =
                            x.domain_args
                            |> Array.map (fun (L(_,t)) -> $"{tyv t}")
                            |> String.concat ", "
                        if x.domain_args |> Array.length > 1 then
                            [| $"x : #(#( {t ()}))" |], false
                        elif x.free_vars |> Array.length > 1 then
                            let t =
                                x.free_vars
                                |> Array.map (fun (L(_,t)) -> $"{tyv t}")
                                |> String.concat ", "
                            [| $"x : #(  {t})" |], false
                        elif x.domain_args |> Array.length = 0
                        then [||], false
                        else
                            let t = t ()
                            if t = "Nil" && x.free_vars |> Array.length = 1
                            then [||], true
                            else [| $"x : #(   {t})" |], false
                    match domain_args with
                    | [||] -> ""
                    | [|x|] -> x
                    | x -> String.concat ", " x
                    , nil
                let domain' =
                    if x.domain_args |> Array.length <> 1
                    then "      Nil"
                    elif x.free_vars |> Array.length > 1 then
                        x.domain_args
                        |> Array.map (fun (L(_,t)) -> $"{tyv t}")
                        |> String.concat ", "
                    else "       Nil"
                let free_vars_tys =
                    if x.free_vars |> Array.length > 1
                    then ""
                    elif x.domain_args |> Array.length = 0 then
                        let t =
                            x.free_vars
                            |> Array.map (fun (L(_,t)) -> tup_ty t)
                            |> String.concat ", "
                        let t =
                            if t = ""
                            then "Nil    "
                            else t
                        $"x : #(  {t})"
                    elif nil && x.free_vars |> Array.length = 1 then
                        match x.free_vars.[0] with
                        | L(i,t) -> $"v{i} :    #({tup_ty t}) "
                    else args_tys x.free_vars
                let args =
                    [| free_vars_tys; domain |]
                    |> Array.filter ((<>) "")
                    |> String.concat ", "
                let args' =
                    let args =
                        if x.domain_args |> Array.isEmpty || x.free_vars |> Array.length > 1
                        then x.free_vars
                        else x.domain_args
                        |> Array.map (fun (L(i,_)) -> $"v{i}")
                        |> String.concat ", "
                    let args =
                        if args = ""
                        then "Nil     "
                        else args
                    if x.domain_args |> Array.length > 1
                    then $"let #(#(   {args} )) = x"
                    elif nil
                    then $"let #(v0) = v0 let {args} = Nil"
                    else $"let #(   {args} ) = x"
                let domain'' =
                    if x.domain_args |> Array.length <> 1 || x.free_vars |> Array.length <= 1
                    then "_"
                    else
                        x.domain_args
                        |> Array.map (fun (L(i,_)) -> $"v{i}")
                        |> String.concat ", "
                let domain_args' =
                    $"%A{x.domain_args}"
                    |> SpiralSm.replace "\r\n" ""
                    |> SpiralSm.replace "\n" ""
                let free_vars' =
                    $"%A{x.free_vars}"
                    |> SpiralSm.replace "\r\n" ""
                    |> SpiralSm.replace "\n" ""
                let comment =
                    $"// free_vars_tys: %A{free_vars_tys} / domain: %A{domain} / x.domain_args: %A{domain_args'} / free_vars': %A{free_vars'}"
                line
                    s
                    $"closure{x.tag} () -> fn(_) -> fn({domain'}) -> {tup_ty x.range} {{ fn({args}) {{ {args'}\nfn ({domain''}) {{ {comment}"
                binds (indent s) x.body
                line s "}}}"
                )

        let main = StringBuilder()
        binds {text=main; indent=0} x

        let program = StringBuilder()
        env.globals |> Seq.distinct |> Seq.iter (fun (x : string) -> program.AppendLine(x) |> ignore)
        types |> Seq.iteri (fun i x -> program.Append("pub type ").Append(x) |> ignore)
        functions |> Seq.iteri (fun i x -> program.Append("pub fn ").Append(x) |> ignore)
        program.Append($"pub fn main () {{ {main} }}").ToString()

    /// ## RefCounting
    // Here are the reference counting analysis passes.
    open System.Collections.Generic

    /// ### varc_add
    let varc_add x i v =
        let c = Option.defaultValue 0 (Map.tryFind x v) + i
        if c = 0 then Map.remove x v else Map.add x c v

    /// ### varc_union
    let varc_union a b = Map.foldBack varc_add a b

    /// ### varc_data
    let varc_data call_data =
        let mutable v = Map.empty
        let rec f = function
            | DPair(a,b) -> f a; f b
            | DForall(_,a,_,_,_) | DFunction(_,_,a,_,_,_) -> Array.iter f a
            | DRecord l -> Map.iter (fun _ -> f) l
            | DV x -> v <- varc_add x 1 v
            | DExists(_,a) | DUnion(a,_) | DNominal(a,_) -> f a
            | DLit _ | DTLit _ | DSymbol _ | DB -> ()
            | DHashSet x -> Seq.iter f x
            | DHashMap(x,_) -> x |> Seq.iter (fun kv -> f kv.Value)
        f call_data
        v

    /// ### varc_set
    let varc_set x i = Set.fold (fun s v -> Map.add v i s) Map.empty x

    /// ### refc_used_vars
    let refc_used_vars (x : TypedBind []) =
        let g_bind : Dictionary<TypedBind, TyV Set> = Dictionary(HashIdentity.Reference)
        let fv x = x |> data_free_vars |> Set
        let jp (x : JoinPointCall) = snd x |> Set
        let rec binds x =
            Array.foldBack (fun k vs ->
                match k with
                | TyLet(d,_,o) -> vs + op o - fv d
                | TyLocalReturnOp(_,o,_) -> vs + op o
                | TyLocalReturnData(d,_) -> vs + fv d
                |> fun vs -> g_bind.Add(k,vs); vs
                ) x Set.empty
        and op (x : TypedOp) : TyV Set =
            match x with
            | TySizeOf _ -> Set.empty
            | TyMacro l -> List.fold (fun s -> function CMTerm (d,_) -> s + fv d | _ -> s) Set.empty l
            | TyArrayLiteral(_,l) | TyOp(_,l) -> List.fold (fun s x -> s + fv x) Set.empty l
            | TyToLayout(x,_) | TyUnionBox(_,x,_) | TyFailwith(_,x) | TyConv(_,x) | TyArrayCreate(_,x) | TyArrayLength(_,x) | TyStringLength(_,x) -> fv x
            | TyWhile(cond,body) -> jp cond + binds body
            | TyDo body | TyIndent body -> binds body
            | TyLayoutIndexAll(i) | TyLayoutIndexByKey(i,_) -> Set.singleton i
            | TyApply(i,d) | TyLayoutMutableSet(i,_,d) -> Set.singleton i + fv d
            | TyJoinPoint x -> jp x
            | TyBackend(_,_,_) -> Set.empty
            | TyIf(cond,tr',fl') -> fv cond + binds tr' + binds fl'
            | TyUnionUnbox(vs,_,on_succs',on_fail') ->
                let vs = vs |> Set
                let on_fail = 
                    match on_fail' with
                    | Some x -> binds x
                    | None -> Set.empty
                Map.fold (fun s k (lets,body) -> 
                    let lets = List.fold (fun s x -> s + fv x) Set.empty lets
                    s + (binds body - lets)
                    ) (vs + on_fail) on_succs'
            | TyIntSwitch(tag,on_succs',on_fail') ->
                let vs = Set.singleton tag
                let on_fail = binds on_fail'
                Array.fold (fun s body -> s + binds body) (vs + on_fail) on_succs'
        binds x |> ignore
        g_bind

    /// ### RefcVars
    type RefcVars = {g_incr : Dictionary<TypedBind,TyV Set>; g_decr : Dictionary<TypedBind,TyV Set>; g_op : Dictionary<TypedBind,Map<TyV, int>>; g_op_decr : Dictionary<TypedBind,TyV Set>}

    /// ### refc_prepass
    let refc_prepass (new_vars : TyV Set) (increfed_vars : TyV Set) (x : TypedBind []) =
        let used_vars = refc_used_vars x
        let g_incr : Dictionary<TypedBind, TyV Set> = Dictionary(HashIdentity.Reference)
        let g_decr : Dictionary<TypedBind, TyV Set> = Dictionary(HashIdentity.Reference)
        let g_op : Dictionary<TypedBind, _> = Dictionary(HashIdentity.Reference)
        let g_op_decr : Dictionary<TypedBind, TyV Set> = Dictionary(HashIdentity.Reference)

        let add (d : Dictionary<TypedBind, TyV Set>) k x = if Set.isEmpty x then () else d.Add(k,x)
        let add' (d : Dictionary<TypedBind, Map<TyV,int>>) k x = if Map.isEmpty x then () else d.Add(k,x)
        let fv x = x |> data_free_vars |> Set
        let rec binds (new_vars : TyV Set) (increfed_vars : TyV Set) (k : TypedBind []) =
            Array.fold (fun (new_vars, increfed_vars) k ->
                add g_incr k new_vars
                let increfed_vars = new_vars + increfed_vars

                let used_vars = used_vars.[k]
                let decref_vars = increfed_vars - used_vars
                add g_decr k decref_vars
                let r = increfed_vars - decref_vars
                match k with
                | TyLet(d,_,o) ->
                    op k Set.empty o
                    let new_vars = fv d
                    match o with
                    | TyLayoutIndexAll _ | TyLayoutIndexByKey _ | TyOp(ArrayIndex,_) -> new_vars, r
                    | _ -> Set.empty, r + new_vars
                | TyLocalReturnOp(_,o,_) -> 
                    op k r o
                    Set.empty, r
                | TyLocalReturnData(d,_) ->
                    add' g_op k (varc_data d)
                    add g_op_decr k r
                    Set.empty, r
                ) (new_vars, increfed_vars) k
            |> ignore
        and op k increfed_vars (x : TypedOp) : unit =
            let fun_call q = add' g_op k q; add g_op_decr k increfed_vars
            match x with
            | TyApply(a,b) -> varc_add a 1 (varc_data b) |> fun_call
            | TyJoinPoint(_,x) -> Array.fold (fun s x -> varc_add x 1 s) Map.empty x |> fun_call
            | TyArrayLiteral(_,x) -> List.fold (fun s x -> varc_union s (varc_data x)) Map.empty x |> fun_call
            | TyUnionBox(_,x,_) | TyToLayout(x,_) -> varc_data x |> fun_call
            | TySizeOf _ | TyLayoutIndexAll _ | TyLayoutIndexByKey _ | TyMacro _ | TyOp _ | TyFailwith _ | TyConv _ 
            | TyArrayCreate _ | TyArrayLength _ | TyStringLength _ | TyLayoutMutableSet _ | TyBackend _ -> ()
            | TyWhile(_,body) -> binds Set.empty Set.empty body
            | TyDo body | TyIndent body -> binds Set.empty Set.empty body
            | TyIf(_,tr',fl') -> binds Set.empty increfed_vars tr'; binds Set.empty increfed_vars fl'
            | TyUnionUnbox(_,_,on_succs',on_fail') ->
                Map.iter (fun _ (lets,body) -> 
                    binds (List.fold (fun s x -> s + fv x) Set.empty lets) increfed_vars body
                    ) on_succs'
                Option.iter (binds Set.empty increfed_vars) on_fail'
            | TyIntSwitch(_,on_succs',on_fail') ->
                Array.iter (binds Set.empty increfed_vars) on_succs'
                binds Set.empty increfed_vars on_fail'
        binds new_vars increfed_vars x

        {g_incr=g_incr; g_op=g_op; g_decr=g_decr; g_op_decr=g_op_decr}

    /// ## CodegenC
    module CodegenC =
        // open System
        // open System.Text
        open System.Collections.Generic

        let sizeof_tyvC = function
            | YPrim (Int64T | UInt64T | Float64T) -> 8
            | YPrim (Int32T | UInt32T | Float32T) -> 4
            | YPrim (Int16T | UInt16T) -> 2
            | YPrim (Int8T | UInt8T | CharT | BoolT) -> 1
            | _ -> 8
        let order_argsC v = v |> Array.sortWith (fun (L(_,t)) (L(_,t')) -> compare (sizeof_tyvC t') (sizeof_tyvC t))
        let lineC x s = if s <> "" then x.text.Append(' ', x.indent).AppendLine s |> ignore
        let line' x s = line x (String.concat " " s)

        let rec is_heap f x = 
            Array.exists (fun (L(i,t)) -> 
                match t with
                | YUnion a when a.Item.layout = UStack -> Array.exists (snd >> f >> is_heap f) a.Item.tag_cases
                | YPrim StringT -> true
                | YPrim _ -> false
                | _ -> true
                ) x
        let is_stringC = function DV(L(_,YPrim StringT)) | DLit(LitString _) -> true | _ -> false

        type BindsReturnC =
            | BindsTailEnd
            | BindsLocal of TyV []

        let term_vars_to_tysC x = x |> Array.map (function WV(L(_,t)) -> t | WLit x -> YPrim (lit_to_primitive_type x))
        let binds_last_dataC x = x |> Array.last |> function TyLocalReturnData(x,_) | TyLocalReturnOp(_,_,x) -> x | TyLet _ -> raise_codegen_error "Compiler error: Cannot find the return data of the last bind."

        type UnionRecC = {tag : int; free_vars : Map<int * string, TyV[]>}
        type LayoutRecC = {tag : int; data : Data; free_vars : TyV[]; free_vars_by_key : Map<int * string, TyV[]>}
        type MethodRecC = {tag : int; free_vars : L<Tag,Ty>[]; range : Ty; body : TypedBind[]; name : string option}
        type ClosureRecC = {tag : int; free_vars : L<Tag,Ty>[]; domain : Ty; domain_args : TyV[]; range : Ty; body : TypedBind[]}
        type TupleRecC = {tag : int; tys : Ty []}
        type ArrayRecC = {tag : int; ty : Ty; tyvs : TyV[]}
        type CFunRecC = {tag : int; domain_args_ty : Ty[]; range : Ty}

        let size_t = UInt32T

        let lit_stringC x =
            let strb = StringBuilder(String.length x + 2)
            strb.Append '"' |> ignore
            String.iter (function
                | '"' -> strb.Append "\\\"" 
                | '\b' -> strb.Append @"\b"
                | '\t' -> strb.Append @"\t"
                | '\n' -> strb.Append @"\n"
                | '\r' -> strb.Append @"\r"
                | '\\' -> strb.Append @"\\"
                | x -> strb.Append x
                >> ignore 
                ) x
            strb.Append '"' |> ignore
            strb.ToString()

        let codegenC (env : PartEvalResult) (x : TypedBind []) =
            let globals = ResizeArray()
            let fwd_dcls = ResizeArray()
            let types = ResizeArray()
            let functions = ResizeArray()

            let malloc, free = "malloc", "free"

            let print_decref s_fun name_fun type_arg name_decref =
                line s_fun (sprintf "void %s(%s * x){" name_fun type_arg)
                let _ =
                    let s_fun = indent s_fun
                    line s_fun (sprintf "if (x != NULL && --(x->refc) == 0) { %s(x); %s(x); }" name_decref free)
                line s_fun "}"

            let print show r =
                let s_typ_fwd = {text=StringBuilder(); indent=0}
                let s_typ = {text=StringBuilder(); indent=0}
                let s_fun = {text=StringBuilder(); indent=0}
                show s_typ_fwd s_typ s_fun r
                let f (a : _ ResizeArray) (b : CodegenEnv) = 
                    let text = b.text.ToString()
                    if text <> "" then a.Add(text)
                f fwd_dcls s_typ_fwd
                f types s_typ
                f functions s_fun

            let layout show =
                let dict' = Dictionary(HashIdentity.Structural)
                let dict = Dictionary(HashIdentity.Reference)
                let f x : LayoutRecC = 
                    match x with
                    | YLayout(x,_) ->
                        let x = env.ty_to_data x
                        let a, b =
                            match x with
                            | DRecord a -> let a = Map.map (fun _ -> data_free_vars) a in a |> Map.toArray |> Array.collect snd, a
                            | _ -> data_free_vars x, Map.empty
                        {data=x; free_vars=a; free_vars_by_key=b; tag=dict'.Count}
                    | _ -> raise_codegen_error $"Compiler error: Expected a layout type (7).\nGot: %s{show_ty x}"
                fun x ->
                    let mutable dirty = false
                    let r = memoize dict (memoize dict' (fun x -> dirty <- true; f x)) x
                    if dirty then print show r
                    r

            let union show =
                let dict = Dictionary(HashIdentity.Reference)
                let f (a : Union) : UnionRecC = 
                    let free_vars = a.Item.cases |> Map.map (fun _ -> env.ty_to_data >> data_free_vars)
                    {free_vars=free_vars; tag=dict.Count}
                fun x ->
                    let mutable dirty = false
                    let r = memoize dict (fun x -> dirty <- true; f x) x
                    if dirty then print show r
                    r

            let jp f show =
                let dict = Dictionary(HashIdentity.Structural)
                let f x = f (x, dict.Count)
                fun x ->
                    let mutable dirty = false
                    let r = memoize dict (fun x -> dirty <- true; f x) x
                    if dirty then print show r
                    r

            let tuple show =
                let dict = Dictionary(HashIdentity.Structural)
                let f x = {tag=dict.Count; tys=x}
                fun x ->
                    let mutable dirty = false
                    let r = memoize dict (fun x -> dirty <- true; f x) x
                    if dirty then print show r
                    r

            let carray' show =
                let dict = Dictionary(HashIdentity.Structural)
                let f x = {tag=dict.Count; ty=x; tyvs = env.ty_to_data x |> data_free_vars}
                fun x ->
                    let mutable dirty = false
                    let r = memoize dict (fun x -> dirty <- true; f x) x
                    if dirty then print show r
                    r

            let cstring' show =
                let mutable dirty = true
                fun () ->
                    if dirty then print show ()
                    dirty <- false

            let cfun' show =
                let dict = Dictionary(HashIdentity.Structural)
                let f (a : Ty, b : Ty) = {tag=dict.Count; domain_args_ty=a |> env.ty_to_data |> data_free_vars |> Array.map (fun (L(_,t)) -> t); range=b}
                fun x ->
                    let mutable dirty = false
                    let r = memoize dict (fun x -> dirty <- true; f x) x
                    if dirty then print show r
                    r

            let args x = x |> Array.map (fun (L(i,_)) -> sprintf "v%i" i) |> String.concat ", "

            let tmp =
                let mutable i = 0u
                fun () -> let x = i in i <- i + 1u; x

            let global' =
                let has_added = HashSet env.globals
                fun x -> if has_added.Add(x) then globals.Add x

            let import x = global' $"#include <{x}>"
            let import' x = global' $"#include \"{x}\""

            let tyvs_to_tys (x : TyV []) = Array.map (fun (L(i,t)) -> t) x

            let rec binds_start (args : TyV []) (s : CodegenEnv) (x : TypedBind []) = binds (refc_prepass Set.empty (Set args) x) s BindsTailEnd x
            and return_local s ret (x : string) = 
                match ret with
                | [||] -> line s $"{x};"
                | [|L(i,_)|] -> line s $"v{i} = {x};"
                | ret ->
                    let tmp_i = tmp()
                    line s $"{tup_ty_tyvs ret} tmp{tmp_i} = {x};"
                    Array.mapi (fun i (L(i',_)) -> $"v{i'} = tmp{tmp_i}.v{i};") ret |> line' s
            and binds (vars : RefcVars) (s : CodegenEnv) (ret : BindsReturnC) (stmts : TypedBind []) = 
                let tup_destruct (a,b) =
                    Array.map2 (fun (L(i,_)) b -> 
                        match b with
                        | WLit b -> $"v{i} = {lit b};"
                        | WV (L(i',_)) -> $"v{i} = v{i'};"
                        ) a b
                Array.iter (fun x ->
                    // This complicated looking piece of code is responsible for putting the incref and decref statements at the beginning of every
                    // statement. It's actually the only place where ref counting code is outputted in the codegen.
                    let _ =
                        let f k = get_default k x (fun () -> Set.empty)
                        let f' k = get_default k x (fun () -> Map.empty)
                        let incr, decr, op, op_decr = varc_set (f vars.g_incr) 1, varc_set (f vars.g_decr) -1, f' vars.g_op, varc_set (f vars.g_op_decr) -1
                        let incr, decr = varc_union incr decr |> varc_union op |> varc_union op_decr |> Map.partition (fun _ v -> 0 < v)
                        refc_varc incr |> line' s; refc_varc decr |> line' s
                    match x with
                    | TyLet(d,trace,a) ->
                        try let d = data_free_vars d
                            let decl_vars = Array.map (fun (L(i,t)) -> $"{tyv t} v{i};") d
                            match a with
                            | TyMacro a ->
                                let m = a |> List.map (function CMText x -> x | CMTerm (x,inl) -> (if inl then args' x else tup_data x) | CMType x -> tup_ty x | CMTypeLit x -> type_lit x) |> String.concat ""
                                let q = m.Split("\\v")
                                if q.Length = 1 then 
                                    decl_vars |> line' s
                                    return_local s d m 
                                else
                                    if d.Length = q.Length-1 then
                                        let w = StringBuilder(m.Length+8)
                                        let tag (L(i,_)) = i : int
                                        Array.iteri (fun i v -> w.Append(q.[i]).Append('v').Append(tag v) |> ignore) d
                                        w.Append(q.[d.Length]).Append(';').ToString() |> line s
                                    else
                                        raise_codegen_error "The special \\v macro requires the same number of free vars in its binding as there are \\v in the code."
                            | _ ->
                                decl_vars |> line' s
                                op vars s (BindsLocal d) a
                        with :? CodegenError as e -> raise_codegen_error' trace (e.Data0, e.Data1)
                    | TyLocalReturnOp(trace,a,_) ->
                        try op vars s ret a
                        with :? CodegenError as e -> raise_codegen_error' trace (e.Data0, e.Data1)
                    | TyLocalReturnData(d,trace) ->
                        try match ret with
                            | BindsLocal l -> line' s (tup_destruct (l,data_term_vars d))
                            | BindsTailEnd -> line s $"return {tup_data d};"
                        with :? CodegenError as e -> raise_codegen_error' trace (e.Data0, e.Data1)
                    ) stmts
            and refc_change'' (f : int * Ty -> string) count (L(i,t')) =
                let v = i,t'
                let inline g decref =
                    if count = -1 then Some (decref())
                    elif count = 1 then Some $"{f v}->refc++;"
                    elif 1 < count then Some $"{f v}->refc += {count};"
                    else raise_codegen_error $"Compiler error: Invalid count in refc_change''. Got: {count}"
                match t' with
                | YUnion t -> 
                    match t.Item.layout with
                    | UStack -> 
                        if count = -1 then Some $"USDecref{(ustack t).tag}(&({f v}));"
                        elif 0 < count then Some (String.replicate count $"USIncref{(ustack t).tag}(&({f v}));")
                        else raise_codegen_error $"Compiler error: Invalid count in refc_change''. UStack case. Got: {count}"
                    | UHeap -> g (fun () -> $"UHDecref{(uheap t).tag}({f v});")
                | YArray t -> g (fun () -> $"ArrayDecref{(carray t).tag}({f v});")
                | YFun(a,b,FT_Vanilla) -> g (fun () ->  $"{f v}->decref_fptr({f v});")
                | YPrim StringT -> g (fun () ->  $"StringDecref({f v});" )
                | YLayout(_,Heap) as a -> g (fun () ->  $"HeapDecref{(heap a).tag}({f v});")
                | YLayout(_,HeapMutable) as a -> g (fun () ->  $"MutDecref{(mut a).tag}({f v});")
                | _ -> None
            and refc_change' (f : int * Ty -> string) count (x : TyV []) : string [] = Array.choose (refc_change'' f count) x
            and refc_change f c x = refc_change' (fun (i,t) -> f i) c x
            and refc_varc x = 
                let ar = ResizeArray(Map.count x)
                Map.iter (fun k v -> refc_change'' (fun (i,_) -> $"v{i}") v k |> Option.iter ar.Add) x
                ar
            //and refc_incr x : string [] = refc_change (fun i -> $"v{i}") 1 x
            //and refc_decr x : string [] = refc_change (fun i -> $"v{i}") -1 x
            and show_w = function WV(L(i,_)) -> sprintf "v%i" i | WLit a -> lit a
            and args' b = data_term_vars b |> Array.map show_w |> String.concat ", "
            and tup_term_vars x =
                let args = Array.map show_w x |> String.concat ", "
                if 1 < x.Length then sprintf "TupleCreate%i(%s)" (tup (term_vars_to_tysC x)).tag args else args
            and tup_data x = tup_term_vars (data_term_vars x)
            and tup_ty_tys = function
                | [||] -> "void"
                | [|x|] -> tyv x
                | x -> sprintf "Tuple%i" (tup x).tag
            and tup_ty_tyvs (x : TyV []) = tup_ty_tys (tyvs_to_tys x)
            and tup_ty x = env.ty_to_data x |> data_free_vars |> tup_ty_tyvs
            and tyv x =
                match x with
                | YUnion a ->
                    match a.Item.layout with
                    | UStack -> sprintf "US%i" (ustack a).tag
                    | UHeap -> sprintf "UH%i *" (uheap a).tag
                | YLayout(_,lay) as a -> 
                    match lay with
                    | Heap -> sprintf "Heap%i *" (heap a).tag
                    | HeapMutable -> sprintf "Mut%i *" (mut a).tag
                    | StackMutable -> raise_codegen_error "Compiler error: The C backend doesn't support stack mutable layout types."
                | YMacro a -> a |> List.map (function Text a -> a | Type a -> tup_ty a | TypeLit a -> type_lit a) |> String.concat ""
                | YPrim a -> prim a
                | YArray a -> sprintf "Array%i *" (carray a).tag
                | YFun(a,b,FT_Vanilla) -> sprintf "Fun%i *" (cfun (a,b)).tag
                | YExists -> raise_codegen_error "Existentials are not supported at runtime. They are a compile time feature only."
                | YForall -> raise_codegen_error "Foralls are not supported at runtime. They are a compile time feature only."
                | a -> raise_codegen_error (sprintf "Compiler error: Type not supported in the codegen.\nGot: %A" a)
            and prim = function
                | Int8T -> "int8_t" 
                | Int16T -> "int16_t"
                | Int32T -> "int32_t"
                | Int64T -> "int64_t"
                | UInt8T -> "uint8_t"
                | UInt16T -> "uint16_t"
                | UInt32T -> "uint32_t"
                | UInt64T -> "uint64_t" // are defined in stdint.h
                | Float32T -> "float"
                | Float64T -> "double"
                | BoolT -> "bool" // is defined in stdbool.h
                | CharT -> "char"
                | StringT -> cstring(); "String *"
            and lit = function
                | LitInt8 x -> sprintf "%i" x
                | LitInt16 x -> sprintf "%i" x
                | LitInt32 x -> sprintf "%il" x
                | LitInt64 x -> sprintf "%ill" x
                | LitUInt8 x -> sprintf "%iu" x
                | LitUInt16 x -> sprintf "%iu" x
                | LitUInt32 x -> sprintf "%iul" x
                | LitUInt64 x -> sprintf "%iull" x
                | LitFloat32 x -> 
                    if x = infinityf then "HUGE_VALF" // nan/inf macros are defined in math.h
                    elif x = -infinityf then "-HUGE_VALF"
                    elif Single.IsNaN x then "NAN"
                    else x.ToString("R") |> add_dec_point |> sprintf "%sf"
                | LitFloat64 x ->
                    if x = infinity then "HUGE_VAL"
                    elif x = -infinity then "-HUGE_VAL"
                    elif Double.IsNaN x then "NAN"
                    else x.ToString("R") |> add_dec_point
                | LitString x ->
                    cstring()
                    lit_stringC x |> sprintf "StringLit(%i, %s)" (x.Length + 1)
                | LitChar x -> 
                    match x with
                    | '\b' -> @"\b"
                    | '\n' -> @"\n"
                    | '\t' -> @"\t"
                    | '\r' -> @"\r"
                    | '\\' -> @"\\"
                    | x -> string x
                    |> sprintf "'%s'"
                | LitBool x -> if x then "true" else "false" // true and false are defined in stddef.h
            and type_lit = function
                | YLit x -> lit x
                | YSymbol x -> x
                | YNominal _ | YApply _ as x -> type_lit (env.nominal_apply x)
                | x -> raise_codegen_error "Compiler error: Expecting a type literal in the macro." 
            and op (vars : RefcVars) s (ret : BindsReturnC) a =
                let binds a b = binds vars a b
                let return' (x : string) =
                    match ret with
                    | BindsLocal ret -> return_local s ret x
                    | BindsTailEnd -> line s $"return {x};"
                let layout_index (x'_i : int) (x' : TyV []) =
                    match ret with
                    | BindsLocal x -> Array.map2 (fun (L(i,_)) (L(i',_)) -> $"v{i} = v{x'_i}->v{i'};") x x' |> line' s
                    | BindsTailEnd -> raise_codegen_error "Compiler error: Layout index should never come in end position."
                let jp (a,b') =
                    let args = args b'
                    match a with
                    | JPMethod(a,b) -> 
                        let x = method (a,b)
                        sprintf "%s%i(%s)" (Option.defaultValue "method" x.name) x.tag args
                    | JPClosure(a,b) -> sprintf "ClosureCreate%i(%s)" (closure (a,b)).tag args
                let string_in_op = function DLit (LitString b) -> lit_stringC b | b -> $"{tup_data b}->ptr"
                match a with
                | TySizeOf t -> return' $"sizeof({tup_ty t})"
                | TyMacro _ -> raise_codegen_error "Macros are supposed to be taken care of in the `binds` function."
                | TyIf(cond,tr,fl) ->
                    line s (sprintf "if (%s){" (tup_data cond))
                    binds (indent s) ret tr
                    line s "} else {"
                    binds (indent s) ret fl
                    line s "}"
                | TyJoinPoint(a,args) -> return' (jp (a, args))
                | TyBackend(_,_,r) -> raise_codegen_error_backend r "The C backend does not support nesting of other backends."
                | TyWhile(a,b) ->
                    let cond =
                        match a with
                        | JPMethod(a,b),b' -> sprintf "method_while%i(%s)" (method_while (a,b)).tag (args b')
                        | _ -> raise_codegen_error "Expected a regular method rather than closure create in the while conditional."
                    line s (sprintf "while (%s){" cond)
                    binds (indent s) (BindsLocal [||]) b
                    line s "}"
                | TyDo a | TyIndent a ->
                    binds s ret a
                | TyIntSwitch(L(v_i,_),on_succ,on_fail) ->
                    line s (sprintf "switch (v%i) {" v_i)
                    let _ =
                        let s = indent s
                        Array.iteri (fun i x ->
                            line s (sprintf "case %i: {" i)
                            binds (indent s) ret x
                            line (indent s) "break;"
                            line s "}"
                            ) on_succ
                        line s "default: {"
                        binds (indent s) ret on_fail
                        line s "}"
                    line s "}"
                | TyUnionUnbox(is,x,on_succs,on_fail) ->
                    let case_tags = x.Item.tags
                    let acs = match x.Item.layout with UHeap -> "->" | UStack -> "."
                    let head = List.head is |> fun (L(i,_)) -> $"v{i}{acs}tag"
                    List.pairwise is
                    |> List.map (fun (L(i,_), L(i',_)) -> $"v{i}{acs}tag == v{i'}{acs}tag")
                    |> String.concat " && "
                    |> function "" -> head | x -> $"{x} ? {head} : -1"
                    |> sprintf "switch (%s) {" |> line s
                    let _ =
                        let s = indent s
                        Map.iter (fun k (a,b) ->
                            let union_i = case_tags.[k]
                            let decr = get_default vars.g_decr (Array.head b) (fun () -> Set.empty)
                            line s (sprintf "case %i: { // %s" union_i k)
                            List.iter2 (fun (L(data_i,_)) a ->
                                let a, s = data_free_vars a, indent s
                                let qs = ResizeArray(a.Length)
                                Array.iteri (fun field_i (L(v_i,t) as v) -> 
                                    if Set.contains v decr = false then qs.Add $"{tyv t} v{v_i} = v{data_i}{acs}case{union_i}.v{field_i};"
                                    ) a 
                                line' s qs
                                ) is a
                            binds (indent s) ret b
                            line (indent s) "break;"
                            line s "}"
                            ) on_succs
                        on_fail |> Option.iter (fun b ->
                            line s "default: {"
                            binds (indent s) ret b
                            line s "}"
                            )
                    line s "}"
                | TyUnionBox(a,b,c') ->
                    let c = c'.Item
                    let i = c.tags.[a]
                    let vars = args' b
                    match c.layout with
                    | UHeap -> sprintf "UH%i_%i(%s)" (uheap c').tag i vars
                    | UStack -> sprintf "US%i_%i(%s)" (ustack c').tag i vars
                    |> return'
                | TyToLayout(a,b) -> 
                    match b with
                    | YLayout(_,layout) -> 
                        match layout with
                        | Heap -> sprintf "HeapCreate%i(%s)" (heap b).tag (args' a)
                        | HeapMutable -> sprintf "MutCreate%i(%s)" (mut b).tag (args' a)
                        | StackMutable -> raise_codegen_error "The C backend doesn't support stack mutable layout types."
                    | _ -> raise_codegen_error $"Compiler error: Expected a layout type (8).\nGot: %s{show_ty b}"
                    |> return'
                | TyLayoutIndexAll(L(i,YLayout(_,lay) & a)) ->
                    match lay with
                    | Heap -> heap a 
                    | HeapMutable -> mut a
                    | StackMutable -> raise_codegen_error "The C backend doesn't support indexing into stack mutable layout types."
                    |> fun x -> x.free_vars |> layout_index i 
                | TyLayoutIndexByKey(L(i,YLayout(_,lay) & a),key) ->
                    match lay with
                    | Heap -> heap a 
                    | HeapMutable -> mut a
                    | StackMutable -> raise_codegen_error "The C backend doesn't support indexing into stack mutable layout types."
                    |> fun x ->
                        x.free_vars_by_key
                        |> Map.tryPick (fun (_, k) v -> if k = key then Some v else None)
                        |> Option.iter (layout_index i)
                | TyLayoutIndexAll _ | TyLayoutIndexByKey _ -> raise_codegen_error "Compiler error: Expected the TyV in layout index to be a layout type."
                | TyLayoutMutableSet(L(i,t),b,c) ->
                    let q = mut t // `mut t` is correct here, peval strips the YLayout.
                    let a = List.fold (fun s k ->
                        match s with
                        | DRecord l -> l |> Map.pick (fun (_,k') v -> if k' = k then Some v else None)
                        | _ -> raise_codegen_error "Compiler error: Expected a record.") q.data b 
                    Array.map2 (fun (L(i',_)) b -> $"&(v{i}->v{i'}), {show_w b}") (data_free_vars a) (data_term_vars c) |> String.concat ", " 
                    |> sprintf "AssignMut%i(%s)" (assign_mut (tyvs_to_tys q.free_vars)).tag |> return'
                | TyArrayLiteral(a,b') ->
                    let b = List.map tup_data b' |> String.concat "," |> sprintf "{%s}"
                    $"ArrayLit{(carray a).tag}({b'.Length}, ({tup_ty a} []){b})" |> return'
                | TyArrayCreate(a,b) -> 
                    let a = carray a
                    let is_heap : string = is_heap (env.ty_to_data >> data_free_vars) a.tyvs |> sprintf "%b"
                    $"ArrayCreate{a.tag}({tup_data b}, {is_heap})" |> return'
                | TyFailwith(a,b) -> 
                    let fmt = @"%s\n"
                    line s $"fprintf(stderr, \"{fmt}\", {string_in_op b});"
                    line s "exit(EXIT_FAILURE);" // TODO: Print out the error traces as well.
                | TyConv(a,b) -> return' $"({tyv a}){tup_data b}"
                | TyApply(L(i,_),b) -> 
                    match args' b with
                    | "" -> $"v{i}->fptr(v{i})"
                    | b -> $"v{i}->fptr(v{i}, {b})"
                    |> return'
                | TyArrayLength(_,b) -> return' $"{tup_data b}->len"
                | TyStringLength(_,b) -> return' $"{tup_data b}->len-1"
                | TyOp(Global,[DLit (LitString x)]) -> global' x
                | TyOp(op,l) ->
                    let float_suffix = function
                        | DV(L(_,YPrim Float32T)) | DLit(LitFloat32 _) -> "f"
                        | _ -> ""
                    match op, l with
                    | Dyn,[a] -> tup_data a
                    | TypeToVar, _ -> raise_codegen_error "The use of `` should never appear in generated code."
                    | StringIndex, [a;b] -> sprintf "%s->ptr[%s]" (tup_data a) (tup_data b)
                    | StringSlice, [a;b;c] -> raise_codegen_error "String slice is not supported natively in the C backend. Use a library implementation instead."
                    | ArrayIndex, [DV(L(_,YArray t)) & a;b] -> 
                        match tup_ty t with
                        | "void" -> "/* void array index */"
                        | _ -> sprintf "%s->ptr[%s]" (tup_data a) (tup_data b)
                    | ArrayIndexSet, [DV(L(_,YArray t)) as a;b;c] -> 
                        let a',b',c' = tup_data a, tup_data b, tup_data c
                        match c' with
                        | "" -> "/* void array set */"
                        | _ -> $"AssignArray{(assign_array (tyvs_to_tys (carray t).tyvs)).tag}(&({a'}->ptr[{b'}]), {c'})"
                    // Math
                    | Add, [a;b] -> sprintf "%s + %s" (tup_data a) (tup_data b)
                    | Sub, [a;b] -> sprintf "%s - %s" (tup_data a) (tup_data b)
                    | Mult, [a;b] -> sprintf "%s * %s" (tup_data a) (tup_data b)
                    | Div, [a;b] -> sprintf "%s / %s" (tup_data a) (tup_data b)
                    | Mod, [a;b] -> sprintf "%s %% %s" (tup_data a) (tup_data b)
                    | Pow, [a;b] -> sprintf "pow%s(%s,%s)" (float_suffix a) (tup_data a) (tup_data b)
                    | LT, [a;b] -> sprintf "%s < %s" (tup_data a) (tup_data b)
                    | LTE, [a;b] -> sprintf "%s <= %s" (tup_data a) (tup_data b)
                    | EQ, [a;b] when is_stringC a -> import "string.h"; sprintf "strcmp(%s->ptr, %s->ptr) == 0" (string_in_op a) (string_in_op b) // TODO: Optimize string structural comparison in the real_core
                    | NEQ, [a;b] when is_stringC a -> import "string.h"; sprintf "strcmp(%s->ptr, %s->ptr) != 0" (string_in_op a) (string_in_op b)
                    | GT, [a;b] when is_stringC a -> import "string.h"; sprintf "strcmp(%s->ptr, %s->ptr) > 0" (string_in_op a) (string_in_op b)
                    | GTE, [a;b] when is_stringC a -> import "string.h"; sprintf "strcmp(%s->ptr, %s->ptr) >= 0" (string_in_op a) (string_in_op b)
                    | EQ, [a;b] -> sprintf "%s == %s" (tup_data a) (tup_data b)
                    | NEQ, [a;b] -> sprintf "%s != %s" (tup_data a) (tup_data b)
                    | GT, [a;b] -> sprintf "%s > %s" (tup_data a) (tup_data b)
                    | GTE, [a;b] -> sprintf "%s >= %s" (tup_data a) (tup_data b)
                    | BoolAnd, [a;b] -> sprintf "%s && %s" (tup_data a) (tup_data b)
                    | BoolOr, [a;b] -> sprintf "%s || %s" (tup_data a) (tup_data b)
                    | BitwiseAnd, [a;b] -> sprintf "%s & %s" (tup_data a) (tup_data b)
                    | BitwiseOr, [a;b] -> sprintf "%s | %s" (tup_data a) (tup_data b)
                    | BitwiseXor, [a;b] -> sprintf "%s ^ %s" (tup_data a) (tup_data b)
                    | BitwiseComplement, [a] -> sprintf "~%s" (tup_data a)

                    | ShiftLeft, [a;b] -> sprintf "%s << %s" (tup_data a) (tup_data b)
                    | ShiftRight, [a;b] -> sprintf "%s >> %s" (tup_data a) (tup_data b)

                    | Neg, [x] -> sprintf "-%s" (tup_data x)
                    | Log, [x] -> import "math.h"; sprintf "log%s(%s)" (float_suffix x) (tup_data x)
                    | Exp, [x] -> import "math.h"; sprintf "exp%s(%s)" (float_suffix x) (tup_data x)
                    | Tanh, [x] -> import "math.h"; sprintf "tanh%s(%s)" (float_suffix x) (tup_data x)
                    | Sqrt, [x] -> import "math.h"; sprintf "sqrt%s(%s)" (float_suffix x) (tup_data x)
                    | NanIs, [x] -> import "math.h"; sprintf "isnan(%s)" (tup_data x)
                    | UnionTag, [DV(L(i,YUnion l)) as x] -> 
                        match l.Item.layout with
                        | UHeap -> "->tag"
                        | UStack -> ".tag"
                        |> sprintf "v%i%s" i
                    | _ -> raise_codegen_error <| sprintf "Compiler error: %A with %i args not supported" op l.Length
                    |> return'
            and print_ordered_args s v = // Unlike C# for example, C keeps the struct fields in input order. To reduce padding, it is best to order the fields from largest to smallest.
                order_argsC v |> Array.iter (fun (L(i,x)) -> line s $"{tyv x} v{i};")
            and method_templ is_while fun_name : _ -> MethodRecC =
                jp (fun ((jp_body,key & (C(args,_))),i) ->
                    match (fst env.join_point_method.[jp_body]).[key] with
                    | Some a, Some range, name -> {tag=i; free_vars=rdata_free_vars args; range=range; body=a; name=name}
                    | _ -> raise_codegen_error "Compiler error: The method dictionary is malformed"
                    ) (fun _ s_typ s_fun x ->
                    let ret_ty = tup_ty x.range
                    let args = x.free_vars |> Array.mapi (fun i (L(_,x)) -> $"{tyv x} v{i}") |> String.concat ", "
                    let fun_name = Option.defaultValue fun_name x.name
                    line s_fun (sprintf "%s %s%i(%s){" ret_ty fun_name x.tag args)
                    binds_start (if is_while then [||] else x.free_vars) (indent s_fun) x.body
                    line s_fun "}"
                    )
            and method_while : _ -> MethodRecC = method_templ true "method_while"
            and method : _ -> MethodRecC = method_templ false "method"
            and closure : _ -> ClosureRecC =
                jp (fun ((jp_body,key & (C(args,_,fun_ty))),i) ->
                    match fun_ty with
                    | YFun(domain,range,FT_Vanilla) ->
                        match (fst env.join_point_closure.[jp_body]).[key] with
                        | Some(domain_args, body) -> {tag=i; free_vars=rdata_free_vars args; domain=domain; domain_args=data_free_vars domain_args; range=range; body=body}
                        | _ -> raise_codegen_error "Compiler error: The method dictionary is malformed"
                    | YFun(_,_,_)-> raise_codegen_error "Non-standard functions are not supported in the C backend."
                    | _ -> raise_codegen_error "Compiler error: Unexpected type in the closure join point."
                    ) (fun _ s_typ s_fun x ->
                    let i, range = x.tag, tup_ty x.range
                    line s_typ (sprintf "typedef struct Closure%i Closure%i;" i i)
                    line s_typ (sprintf "struct Closure%i {" i)
                    let _ =
                        let s_typ = indent s_typ
                        line s_typ $"int refc;"
                        line s_typ $"void (*decref_fptr)(Closure{i} *);"
                        match x.domain_args |> Array.map (fun (L(_,t)) -> tyv t) |> String.concat ", " with
                        | "" -> $"{range} (*fptr)(Closure{i} *);"
                        | domain_args_ty -> $"{range} (*fptr)(Closure{i} *, {domain_args_ty});"
                        |> line s_typ
                        print_ordered_args s_typ x.free_vars
                    line s_typ "};"

                    line s_fun (sprintf "static inline void ClosureDecrefBody%i(Closure%i * x){" i i)
                    let _ =
                        let s_fun = indent s_fun
                        x.free_vars |> refc_change (fun i -> $"x->v{i}") -1 |> line' s_fun
                    line s_fun "}"

                    print_decref s_fun $"ClosureDecref{i}" $"Closure{i}" $"ClosureDecrefBody{i}"

                    match x.domain_args |> Array.map (fun (L(i,t)) -> $"{tyv t} v{i}") |> String.concat ", " with
                    | "" -> sprintf "%s ClosureMethod%i(Closure%i * x){" range i i
                    | domain_args -> sprintf "%s ClosureMethod%i(Closure%i * x, %s){" range i i domain_args
                    |> line s_fun
                    let _ =
                        let s_fun = indent s_fun
                        x.free_vars |> Array.map (fun (L(i,t)) -> $"{tyv t} v{i} = x->v{i};") |> line' s_fun
                        line s_fun $"ClosureDecref{i}(x);"
                        binds_start x.domain_args s_fun x.body
                    line s_fun "}"

                    let fun_tag = (cfun (x.domain,x.range)).tag
                    let free_vars = x.free_vars |> Array.map (fun (L(i,t)) -> $"{tyv t} v{i}")
                    line s_fun (sprintf "Fun%i * ClosureCreate%i(%s){" fun_tag i (String.concat ", " free_vars))
                    let _ =
                        let s_fun = indent s_fun
                        line s_fun $"Closure{i} * x = {malloc}(sizeof(Closure{i}));"
                        line s_fun "x->refc = 1;"
                        line s_fun $"x->decref_fptr = ClosureDecref{i};"
                        line s_fun $"x->fptr = ClosureMethod{i};"
                        x.free_vars |> Array.map (fun (L(i,_)) -> $"x->v{i} = v{i};")  |> line' s_fun
                        line s_fun $"return (Fun{fun_tag} *) x;"
                    line s_fun "}"
                    )
            and cfun : _ -> CFunRecC =
                cfun' (fun _ s_typ s_fun x ->
                    let i, range = x.tag, tup_ty x.range
                    line s_typ $"typedef struct Fun{i} Fun{i};"
                    line s_typ (sprintf "struct Fun%i{" i)
                    let _ =
                        let s_typ = indent s_typ
                        line s_typ $"int refc;"
                        line s_typ $"void (*decref_fptr)(Fun{i} *);"
                        match x.domain_args_ty |> Array.map tyv |> String.concat ", " with
                        | "" -> $"{range} (*fptr)(Fun{i} *);"
                        | domain_args_ty -> $"{range} (*fptr)(Fun{i} *, {domain_args_ty});"
                        |> line s_typ
                    line s_typ "};"
                    )
            and tup : _ -> TupleRecC =
                tuple (fun _ s_typ s_fun x ->
                    let name = sprintf "Tuple%i" x.tag
                    line s_typ "typedef struct {"
                    x.tys |> Array.mapi (fun i x -> L(i,x)) |> print_ordered_args (indent s_typ)
                    line s_typ (sprintf "} %s;" name)

                    let args = x.tys |> Array.mapi (fun i x -> $"{tyv x} v{i}")
                    line s_fun (sprintf "static inline %s TupleCreate%i(%s){" name x.tag (String.concat ", " args))
                    let _ =
                        let s_fun = indent s_fun
                        line s_fun $"{name} x;"
                        Array.init args.Length (fun i -> $"x.v{i} = v{i};") |> line' s_fun
                        line s_fun $"return x;"
                    line s_fun "}"
                    )
            and assign_mut : _ -> TupleRecC = 
                tuple (fun _ s_typ s_fun x ->
                    let tyvs = Array.mapi (fun i t -> L(i,t)) x.tys
                    let args = Array.mapi (fun i t -> let t = tyv t in $"{t} * a{i}, {t} b{i}") x.tys |> String.concat ", "
                    line s_fun (sprintf "static inline void AssignMut%i(%s){" x.tag args)
                    let _ =
                        let s_fun = indent s_fun
                        refc_change (fun i -> $"b{i}") 1 tyvs |> line' s_fun
                        refc_change (fun i -> $"*a{i}") -1 tyvs |> line' s_fun
                        Array.init tyvs.Length (fun i -> $"*a{i} = b{i};") |> line' s_fun
                    line s_fun "}"
                    )
            and assign_array : _ -> TupleRecC = 
                tuple (fun _ s_typ s_fun x ->
                    let tyvs, t = Array.mapi (fun i t -> L(i,t)) x.tys, tup_ty_tys x.tys
                    line s_fun (sprintf "static inline void AssignArray%i(%s * a, %s b){" x.tag t t)
                    let _ =
                        let s_fun = indent s_fun
                        match tyvs with
                        | [||] -> raise_codegen_error "Compiler error: Void types not allowed in assign."
                        | [|t|] -> 
                            refc_change (fun i -> "b") 1 tyvs |> line' s_fun
                            refc_change (fun i -> "*a") -1 tyvs |> line' s_fun
                            $"*a = b;" |> line s_fun
                        | _ ->
                            refc_change (fun i -> $"b.v{i}") 1 tyvs |> line' s_fun
                            refc_change (fun i -> $"a->v{i}") -1 tyvs |> line' s_fun
                            $"*a = b;" |> line s_fun
                    line s_fun "}"
                    )
            and layout_tmpl name : _ -> LayoutRecC =
                layout (fun _ s_typ s_fun (x : LayoutRecC) ->
                    let i = x.tag
                    let name' = sprintf "%s%i" name i

                    line s_typ "typedef struct {"
                    let _ =
                        let s_typ = indent s_typ
                        line s_typ "int refc;"
                        print_ordered_args s_typ x.free_vars
                    line s_typ (sprintf "} %s;" name')

                    line s_fun (sprintf "static inline void %sDecrefBody%i(%s * x){" name i name')
                    let _ =
                        let s_fun = indent s_fun
                        x.free_vars |> refc_change (fun i -> $"x->v{i}") -1 |> line' s_fun
                    line s_fun "}"

                    print_decref s_fun $"{name}Decref{i}" name' $"{name}DecrefBody{i}"

                    let args = x.free_vars |> Array.map (fun (L(i,x)) -> $"{tyv x} v{i}")
                    line s_fun (sprintf "%s * %sCreate%i(%s){" name' name i (String.concat ", " args))
                    let _ =
                        let s_fun = indent s_fun
                        line s_fun $"{name'} * x = {malloc}(sizeof({name'}));"
                        line s_fun "x->refc = 1;"
                        Array.init args.Length (fun i -> $"x->v{i} = v{i};") |> line' s_fun
                        line s_fun $"return x;"
                    line s_fun "}"
                    )
            and heap : _ -> LayoutRecC = layout_tmpl "Heap"
            and mut : _ -> LayoutRecC = layout_tmpl "Mut"
            and union_tmpl is_stack : Union -> UnionRecC = 
                let inline map_iteri f x = Map.fold (fun i k v -> f i k v; i+1) 0 x |> ignore
                union (fun s_fwd s_typ s_fun x ->
                    let i = x.tag
                    match is_stack with
                    | true  -> line s_typ "typedef struct {"
                    | false -> 
                        line s_fwd (sprintf "typedef struct UH%i UH%i;" i i)
                        line s_typ (sprintf "struct UH%i {" i)
                    let _ =
                        let s_typ = indent s_typ
                        match is_stack with
                        | true -> ()
                        | false -> line s_typ "int refc;"
                        line s_typ "int tag;"
                        line s_typ "union {"
                        let _ =
                            let s_typ = indent s_typ
                            map_iteri (fun tag (_, k) v -> 
                                if Array.isEmpty v = false then
                                    line s_typ "struct {"
                                    print_ordered_args (indent s_typ) v
                                    line s_typ (sprintf "} case%i; // %s" tag k)
                                ) x.free_vars
                        line s_typ "};"
                    match is_stack with
                    | true  -> line s_typ (sprintf "} US%i;" i)
                    | false -> line s_typ "};"

                    let print_refc name typ q =
                        line s_fun (sprintf "static inline void %s(%s * x){" name typ)
                        let _ =
                            let s_fun = indent s_fun
                            line s_fun "switch (x->tag) {"
                            map_iteri (fun tag k v -> 
                                let s_fun = indent s_fun
                                let refc = v |> refc_change (fun i -> $"x->case{tag}.v{i}") q
                                if refc.Length <> 0 then
                                    line s_fun (sprintf "case %i: {" tag)
                                    let _ =
                                        let s_fun = indent s_fun
                                        refc |> line' s_fun
                                        line s_fun "break;"
                                    line s_fun "}"
                                ) x.free_vars
                            line s_fun "}"
                        line s_fun "}"

                    match is_stack with
                    | true  -> 
                        print_refc $"USIncrefBody{i}" $"US{i}" 1
                        print_refc $"USDecrefBody{i}" $"US{i}" -1
                    | false -> print_refc $"UHDecrefBody{i}" $"UH{i}" -1

                    match is_stack with
                    | true  -> 
                        line s_fun (sprintf "void USIncref%i(US%i * x){ USIncrefBody%i(x); }" i i i)
                        line s_fun (sprintf "void USDecref%i(US%i * x){ USDecrefBody%i(x); }" i i i)
                    | false -> 
                        line s_fwd (sprintf "void UHDecref%i(UH%i * x);" i i)
                        print_decref s_fun $"UHDecref{i}" $"UH{i}" $"UHDecrefBody{i}"

                    map_iteri (fun tag (_, k) v -> 
                        let args = v |> Array.map (fun (L(i,t)) -> $"{tyv t} v{i}") |> String.concat ", "
                        if is_stack then
                            line s_fun (sprintf "US%i US%i_%i(%s) { // %s" i i tag args k)
                            let _ =
                                let s_fun = indent s_fun
                                line s_fun $"US{i} x;"
                                line s_fun $"x.tag = {tag};"
                                if v.Length <> 0 then
                                    v |> Array.map (fun (L(i,t)) -> $"x.case{tag}.v{i} = v{i};") |> line' s_fun
                                line s_fun "return x;"
                            line s_fun "}"
                        else
                            line s_fun (sprintf "UH%i * UH%i_%i(%s) { // %s" i i tag args k)
                            let _ =
                                let s_fun = indent s_fun
                                line s_fun $"UH{i} * x = {malloc}(sizeof(UH{i}));"
                                line s_fun $"x->tag = {tag};"
                                line s_fun "x->refc = 1;"
                                if v.Length <> 0 then
                                    v |> Array.map (fun (L(i,t)) -> $"x->case{tag}.v{i} = v{i};") |> line' s_fun
                                line s_fun $"return x;"
                            line s_fun "}"
                        ) x.free_vars
                    )
            and ustack : _ -> UnionRecC = union_tmpl true
            and uheap : _ -> UnionRecC = union_tmpl false
            and carray : _ -> ArrayRecC =
                carray' (fun _ s_typ s_fun x ->
                    let i, len_t, ptr_t = x.tag, prim size_t, tup_ty_tyvs x.tyvs
                    line s_typ "typedef struct {"
                    let _ =
                        let s_typ = indent s_typ
                        line s_typ "int refc;"
                        line s_typ $"{len_t} len;"
                        if ptr_t <> "void" then line s_typ $"{ptr_t} ptr[];" // flexible array member
                    line s_typ (sprintf "} Array%i;" i)


                    let print_body p s_fun q =
                        let refcs = x.tyvs |> refc_change (fun i -> if 1 < x.tyvs.Length then $"v.v{i}" else "v") q
                        if refcs.Length <> 0 then
                            p()
                            line s_fun (sprintf "for (%s i=0; i < len; i++){" len_t)
                            let _ =
                                let s_fun = indent s_fun
                                line s_fun $"{ptr_t} v = ptr[i];"
                                refcs |> line' s_fun
                            line s_fun "}"

                    line s_fun (sprintf "static inline void ArrayDecrefBody%i(Array%i * x){" i i)
                    let _ =
                        let s_fun = indent s_fun
                        print_body (fun () ->
                            line s_fun $"{len_t} len = x->len;"
                            line s_fun $"{ptr_t} * ptr = x->ptr;"
                            ) s_fun -1
                    line s_fun "}"

                    print_decref s_fun $"ArrayDecref{i}" $"Array{i}" $"ArrayDecrefBody{i}"

                    line s_fun (sprintf "Array%i * ArrayCreate%i(%s len, bool init_at_zero){" i i len_t)
                    let _ =
                        let s_fun = indent s_fun
                        match ptr_t with
                        | "void" -> line s_fun $"{len_t} size = sizeof(Array{i});"
                        | _ -> line s_fun $"{len_t} size = sizeof(Array{i}) + sizeof({ptr_t}) * len;"
                        line s_fun $"Array{i} * x = {malloc}(size);"
                        line s_fun "if (init_at_zero) { memset(x,0,size); }"
                        line s_fun "x->refc = 1;"
                        line s_fun "x->len = len;"
                        line s_fun "return x;"
                    line s_fun "}"

                    line s_fun (sprintf "Array%i * ArrayLit%i(%s len, %s * ptr){" i i len_t ptr_t)
                    let _ =
                        let s_fun = indent s_fun
                        line s_fun $"Array{i} * x = ArrayCreate{i}(len, false);"
                        if ptr_t <> "void" then 
                            line s_fun $"memcpy(x->ptr, ptr, sizeof({ptr_t}) * len);"
                            print_body (fun () -> ()) (indent s_fun) 1
                        line s_fun "return x;"
                    line s_fun "}"
                    )
            and cstring : unit -> unit =
                cstring' (fun _ s_typ s_fun () ->
                    let char = YPrim CharT
                    let size_t, ptr_t, tag = prim size_t, tyv char, (carray char).tag
                    line s_typ $"typedef Array{tag} String;"

                    line s_fun "static inline void StringDecref(String * x){"
                    line (indent s_fun) $"return ArrayDecref{tag}(x);"
                    line s_fun "}"

                    line s_fun (sprintf "static inline String * StringLit(%s len, %s * ptr){" size_t ptr_t)
                    line (indent s_fun) $"return ArrayLit{tag}(len, ptr);"
                    line s_fun "}"
                    )

            match binds_last_dataC x |> data_term_vars |> term_vars_to_tysC with
            | [|YPrim Int32T|] ->
                import "stdbool.h"
                import "stdint.h"
                import "stdio.h"
                import "stdlib.h"

                let main_defs = {text=StringBuilder(); indent=0}
                import "string.h" // for memcpy

                line main_defs (sprintf "%s main(){" (prim Int32T))
                binds_start [||] (indent main_defs) x
                line main_defs "}"

                let program = StringBuilder()

                globals |> Seq.iter (fun x -> program.AppendLine(x) |> ignore)
                fwd_dcls |> Seq.iter (fun x -> program.Append(x) |> ignore)
                types |> Seq.iter (fun x -> program.Append(x) |> ignore)
                functions |> Seq.iter (fun x -> program.Append(x) |> ignore)
                program.Append(main_defs.text).ToString()
            | _ ->
                raise_codegen_error "The return type of main in the C backend should be a 32-bit int."

    /// ## CodegenCpp
    module CodegenCpp =
        // open System
        // open System.Text
        open System.Collections.Generic

        type backend_type =
            | Cuda of args : L<int,Ty>[] * binds : TypedBind[]
            | Cpp of binds : TypedBind[]

        type codegen_env =
            {
                globals : string ResizeArray
                fwd_dcls : string ResizeArray
                types : string ResizeArray
                functions : string ResizeArray
                main_defs : string ResizeArray
                backend_name : string
                __device__ : string
            }

            static member Create(backend_name,__device__) =
                {
                    globals = ResizeArray()
                    fwd_dcls = ResizeArray()
                    types = ResizeArray()
                    functions = ResizeArray()
                    main_defs = ResizeArray()
                    backend_name = backend_name
                    __device__ = __device__
                }

        let backend_nameCpp = "Cpp"
        let private max_tag = 255uy

        let prim = function
            | Int8T -> "char" 
            | Int16T -> "short"
            | Int32T -> "int"
            | Int64T -> "long long"
            | UInt8T -> "unsigned char"
            | UInt16T -> "unsigned short"
            | UInt32T -> "unsigned int"
            | UInt64T -> "unsigned long long"
            | Float32T -> "float"
            | Float64T -> "double"
            | BoolT -> "bool" // part of c++ standard
            | CharT -> "char"
            | StringT -> "const char *"

        /// Replaces the default types in the corelib.cuh library.
        let replace_default_types (default_env : DefaultEnv) (x : string) =
            let opts = System.Text.RegularExpressions.RegexOptions.Multiline
            System.Text.RegularExpressions.Regex.Replace(x, @"(^using default_int = )(.*?)(;)", $"$1{prim default_env.default_int}$3", opts)
            |> fun x -> System.Text.RegularExpressions.Regex.Replace(x, @"(^using default_uint = )(.*?)(;)", $"$1{prim default_env.default_uint}$3", opts)

        let is_stringCpp = function DV(L(_,YPrim StringT)) | DLit(LitString _) -> true | _ -> false
        let sizeof_tyvCpp = function
            | YPrim (Int64T | UInt64T | Float64T) -> 8
            | YPrim (Int32T | UInt32T | Float32T) -> 4
            | YPrim (Int16T | UInt16T) -> 2
            | YPrim (Int8T | UInt8T | CharT | BoolT) -> 1
            | _ -> 8
        let order_args v = v |> Array.sortWith (fun (L(_,t)) (L(_,t')) -> compare (sizeof_tyvCpp t') (sizeof_tyvCpp t))
        let lineCpp x s = if s <> "" then x.text.Append(' ', x.indent).AppendLine s |> ignore
        let lineCpp' x s = line x (String.concat " " s)

        type BindsReturnCpp =
            | BindsTailEnd
            | BindsLocal of TyV []

        let term_vars_to_tysCpp x = x |> Array.map (function WV(L(_,t)) -> t | WLit x -> YPrim (lit_to_primitive_type x))
        let binds_last_dataCpp x = x |> Array.last |> function TyLocalReturnData(x,_) | TyLocalReturnOp(_,_,x) -> x | TyLet _ -> raise_codegen_error "Compiler error: Cannot find the return data of the last bind."

        type LayoutRecCpp = {tag : int; data : Data; free_vars : TyV[]; free_vars_by_key : Map<int * string, TyV[]>}
        type UnionRecCpp = {tag : int; free_vars : Map<int * string, TyV[]>; is_heap : bool}
        type MethodRecCpp = {tag : int; free_vars : TyV[]; range : Ty; body : TypedBind[]; name : string option}
        type ClosureRecCpp = {tag : int; free_vars : TyV[]; domain : Ty; range : Ty; funtype : FunType; body : TypedBind[]}
        type TupleRecCpp = {tag : int; tys : Ty []}
        type CFunRecCpp = {tag : int; domain : Ty; range : Ty; funtype : FunType}

        // Replaces the invalid symbols in Spiral method names for the C backend.
        let fix_method_name (x : string) = x.Replace(''','_') + "_"

        let unroll_pop (s : Stack<int>) = if s.Count > 0 then s.Pop() else -1
        let unroll_peek (s : Stack<int>) = if s.Count > 0 then s.Peek() else -1

        let lit_stringCpp x =
            let strb = StringBuilder(String.length x + 2)
            strb.Append '"' |> ignore
            String.iter (function
                | '"' -> strb.Append "\\\"" 
                | '\b' -> strb.Append @"\b"
                | '\t' -> strb.Append @"\t"
                | '\n' -> strb.Append @"\n"
                | '\r' -> strb.Append @"\r"
                | '\\' -> strb.Append @"\\"
                | x -> strb.Append x
                >> ignore 
                ) x
            strb.Append '"' |> ignore
            strb.ToString()

        let codegen' backend_handler (part_eval_env : PartEvalResult) (code_env : codegen_env) =
            let print show r =
                let s_typ_fwd = {text=StringBuilder(); indent=0}
                let s_typ = {text=StringBuilder(); indent=0}
                let s_fun = {text=StringBuilder(); indent=0}
                show s_typ_fwd s_typ s_fun r
                let f (a : _ ResizeArray) (b : CodegenEnv) = 
                    let text = b.text.ToString()
                    if text <> "" then a.Add(text)
                f code_env.fwd_dcls s_typ_fwd
                f code_env.types s_typ
                f code_env.functions s_fun

            let layout show =
                let dict' = Dictionary(HashIdentity.Structural)
                let dict = Dictionary(HashIdentity.Reference)
                let f x : LayoutRecCpp = 
                    match x with
                    | YLayout(x,_) ->
                        let x = part_eval_env.ty_to_data x
                        let a, b =
                            match x with
                            | DRecord a -> let a = Map.map (fun _ -> data_free_vars) a in a |> Map.toArray |> Array.collect snd, a
                            | _ -> data_free_vars x, Map.empty
                        {data=x; free_vars=a; free_vars_by_key=b; tag=dict'.Count}
                    | _ -> raise_codegen_error $"Compiler error: Expected a layout type (1).\nGot: %s{show_ty x}"
                fun x ->
                    let mutable dirty = false
                    let r = Utils.memoize dict (Utils.memoize dict' (fun x -> dirty <- true; f x)) x
                    if dirty then print show r
                    r

            let union show =
                let dict = Dictionary(HashIdentity.Reference)
                let f (a : Union) : UnionRecCpp = 
                    let free_vars = a.Item.cases |> Map.map (fun _ -> part_eval_env.ty_to_data >> data_free_vars)
                    {free_vars=free_vars; tag=dict.Count; is_heap=a.Item.layout = UHeap}
                fun x ->
                    let mutable dirty = false
                    let r = Utils.memoize dict (fun x -> dirty <- true; f x) x
                    if dirty then print show r
                    r

            let jp f show =
                let dict = Dictionary(HashIdentity.Structural)
                let f x = f (x, dict.Count)
                fun x ->
                    let mutable dirty = false
                    let r = Utils.memoize dict (fun x -> dirty <- true; f x) x
                    if dirty then print show r
                    r

            let tuple show =
                let dict = Dictionary(HashIdentity.Structural)
                let f x = {tag=dict.Count; tys=x}
                fun x ->
                    let mutable dirty = false
                    let r = Utils.memoize dict (fun x -> dirty <- true; f x) x
                    if dirty then print show r
                    r

            let cfun' show =
                let dict = Dictionary(HashIdentity.Structural)
                let f (a : Ty, b : Ty, t : FunType) = {tag=dict.Count; domain=a; range=b; funtype=t}
                fun x ->
                    let mutable dirty = false
                    let r = Utils.memoize dict (fun x -> dirty <- true; f x) x
                    if dirty then print show r
                    r

            let args x = x |> Array.map (fun (L(i,_)) -> sprintf "v%i" i) |> String.concat ", "

            let tmp =
                let mutable i = 0u
                fun () -> let x = i in i <- i + 1u; x

            let global' =
                let has_added = HashSet code_env.globals
                fun x -> if has_added.Add(x) then code_env.globals.Add x

            let import x = global' $"#include <{x}>"
            let import' x = global' $"#include \"{x}\""

            let tyvs_to_tys (x : TyV []) = Array.map (fun (L(i,t)) -> t) x

            let rec binds_start (s : CodegenEnv) (x : TypedBind []) = binds (Stack()) s BindsTailEnd x
            and return_local s ret (x : string) = 
                match ret with
                | [||] -> line s $"{x};"
                | [|L(i,_)|] -> line s $"v{i} = {x};"
                | ret ->
                    let tmp_i = tmp()
                    line s $"{tup_ty_tyvs ret} tmp{tmp_i} = {x};"
                    Array.mapi (fun i (L(i',_)) -> $"v{i'} = tmp{tmp_i}.v{i};") ret |> lineCpp' s
            and get_layout_rec lay a =
                match lay with 
                | Heap -> heap a 
                | HeapMutable -> mut a
                | StackMutable -> stack_mut a
            and binds (unroll : Stack<int>) (s : CodegenEnv) (ret : BindsReturnCpp) (stmts : TypedBind []) =
                let tup_destruct (a,b) =
                    Array.map2 (fun (L(i,_)) b ->
                        match b with
                        | WLit b -> $"v{i} = {lit b};"
                        | WV (L(i',_)) -> $"v{i} = v{i'};"
                        ) a b
                Array.forall (fun x ->
                    match x with
                    | TyLet(d,trace,a) ->
                        try let d = data_free_vars d
                            let decl_vars () = Array.map (fun (L(i,t)) -> $"{tyv t} v{i};") d
                            let layout_index layout (x'_i : int) (x' : TyV []) = 
                                match layout with
                                | Heap | HeapMutable -> Array.map2 (fun (L(i,t)) (L(i',_)) -> $"{tyv t} & v{i} = v{x'_i}.base->v{i'};") d x' |> lineCpp' s
                                | StackMutable -> Array.map2 (fun (L(i,t)) (L(i',_)) -> $"{tyv t} & v{i} = v{x'_i}.v{i'};") d x' |> lineCpp' s
                            match a with
                            | TyToLayout(a,YLayout(_,StackMutable) & b) ->
                                match d with
                                | [|L(i,YLayout(_,StackMutable))|] -> // For the regular arrays.
                                    let tag = (stack_mut b).tag
                                    line s $"StackMut{tag} v{i}{{{args' a}}};"
                                    true
                                | _ ->
                                    raise_codegen_error "Compiler error: Expected a stack mutable layout type."
                            | TyLayoutIndexAll(x) -> 
                                match x with 
                                | L(i,YLayout(_,lay) & a) -> (get_layout_rec lay a).free_vars |> layout_index lay i 
                                | _ -> raise_codegen_error "Compiler error: Expected the TyV in layout index to be a layout type."
                                true
                            | TyLayoutIndexByKey(x,key) -> 
                                match x with 
                                | L(i,YLayout(_,lay) & a) -> (get_layout_rec lay a).free_vars_by_key |> Map.pick (fun (_, k') v' -> if key = k' then Some v' else None) |> layout_index lay i 
                                | _ -> raise_codegen_error "Compiler error: Expected the TyV in layout index by key to be a layout type."
                                true
                            | TyMacro a ->
                                let m = a |> List.map (function CMText x -> x | CMTerm (x,inl) -> (if inl then args' x else tup_data x) | CMType x -> tup_ty x | CMTypeLit x -> type_lit x) |> String.concat ""
                                if m.StartsWith("#pragma") then 
                                    line s m
                                    true
                                elif m = "break" then
                                    line s "break;"
                                    false
                                elif m.StartsWith("return") then
                                    line s $"{m};"
                                    false
                                else
                                    let q = m.Split("\\v")
                                    if q.Length = 1 then 
                                        decl_vars() |> lineCpp' s
                                        return_local s d m 
                                        true
                                    else
                                        if d.Length = q.Length-1 then
                                            let w = StringBuilder(m.Length+8)
                                            let tag (L(i,_)) = i : int
                                            Array.iteri (fun i v -> w.Append(q.[i]).Append('v').Append(tag v) |> ignore) d
                                            w.Append(q.[d.Length]).Append(';').ToString() |> line s
                                            true
                                        else
                                            raise_codegen_error "The special \\v macro requires the same number of free vars in its binding as there are \\v in the code."
                            | TyArrayLiteral(a,b') -> 
                                let inits = List.map tup_data b' |> String.concat "," |> sprintf "{%s}"
                                match d with
                                | [|L(i,YArray t)|] -> // For the regular arrays.
                                    line s $"%s{tup_ty t} v{i}[] = %s{inits};"
                                    true
                                | _ ->
                                    raise_codegen_error "Compiler error: Expected a single variable on the left side of an array literal op."
                            | TyArrayCreate(a,b) ->  
                                match d with
                                | [|L(i,YArray t)|] -> 
                                    match tup_ty t with
                                    | "void" -> line s "/* void array create */"
                                    | t -> line s $"{t} v{i}[{tup_data b}];"
                                    true
                                | _ -> raise_codegen_error "Compiler error: Expected a single variable on the left side of an array create op."
                            | TyJoinPoint(JPClosure(a,b),b') ->
                                match d with
                                | [|L(i,_)|] -> 
                                    let x = closure (a,b)
                                    match x.funtype with
                                    | FT_Pointer ->
                                        let y = cfun (x.domain,x.range,x.funtype)
                                        line s $"Fun{y.tag} v{i} = FunPointerMethod{x.tag};"
                                    | FT_Vanilla ->
                                        let args = args b'
                                        line s $"Closure{x.tag} v{i}{{{args}}};"
                                    | FT_Closure -> 
                                        let y = cfun (x.domain,x.range,x.funtype)
                                        let args = args b'
                                        line s $"Fun{y.tag} v{i}{{new Closure{x.tag}{{{args}}}}};"
                                    true
                                | _ -> raise_codegen_error "Compiler error: Expected a single variable on the left side of a closure join point."
                            | _ ->
                                decl_vars() |> lineCpp' s
                                op unroll s (BindsLocal d) a
                                true
                        with :? CodegenError as e -> raise_codegen_error' trace (e.Data0, e.Data1)
                    | TyLocalReturnOp(trace,a,_) ->
                        try op unroll s ret a
                            true
                        with :? CodegenError as e -> raise_codegen_error' trace (e.Data0, e.Data1)
                    | TyLocalReturnData(d,trace) ->
                        try match ret with
                            | BindsLocal l -> lineCpp' s (tup_destruct (l,data_term_vars d))
                            | BindsTailEnd -> line s $"return {tup_data d};"
                            true
                        with :? CodegenError as e -> raise_codegen_error' trace (e.Data0, e.Data1)
                    ) stmts
                |> ignore
            and show_w = function WV(L(i,_)) -> sprintf "v%i" i | WLit a -> lit a
            and args' b = data_term_vars b |> Array.map show_w |> String.concat ", "
            and tup_term_vars x =
                let args = Array.map show_w x |> String.concat ", "
                if 1 < x.Length then sprintf "Tuple%i{%s}" (tup (term_vars_to_tysCpp x)).tag args else args
            and tup_data x = tup_term_vars (data_term_vars x)
            and tup_ty_tys = function
                | [||] -> "void"
                | [|x|] -> tyv x
                | x -> sprintf "Tuple%i" (tup x).tag
            and tup_ty_tyvs (x : TyV []) = tup_ty_tys (tyvs_to_tys x)
            and tup_ty x = part_eval_env.ty_to_data x |> data_free_vars |> tup_ty_tyvs
            and tyv = function
                | YUnion a ->
                    match a.Item.layout with
                    | UStack -> sprintf "Union%i" (unions a).tag
                    | UHeap -> sprintf "sptr<Union%i>" (unions a).tag
                | YLayout(_,lay) as a -> 
                    match lay with
                    | Heap -> sprintf "sptr<Heap%i>" (heap a).tag
                    | HeapMutable -> sprintf "sptr<Mut%i>" (mut a).tag
                    | StackMutable -> sprintf "StackMut%i &" (stack_mut a).tag
                | YMacro [Text "backend_switch "; Type (YRecord r)] ->
                    match r |> Map.tryPick (fun (_, k) v -> if k = backend_nameCpp then Some v else None) with
                    | Some x -> tup_ty x
                    | None -> raise_codegen_error $"In the backend_switch, expected a record with the '{code_env.backend_name}' field."
                | YMacro a -> a |> List.map (function Text a -> a | Type a -> tup_ty a | TypeLit a -> type_lit a) |> String.concat ""
                | YPrim a -> prim a
                | YArray a -> sprintf "%s *" (tup_ty a)
                | YFun(a,b,t) -> $"Fun%i{(cfun (a,b,t)).tag}"
                | YExists -> raise_codegen_error "Existentials are not supported at runtime. They are a compile time feature only."
                | YForall -> raise_codegen_error "Foralls are not supported at runtime. They are a compile time feature only."
                | a -> raise_codegen_error (sprintf "Compiler error: Type not supported in the codegen.\nGot: %A" a)
            and lit = function
                | LitInt8 x -> sprintf "%i" x
                | LitInt16 x -> sprintf "%i" x
                | LitInt32 x -> sprintf "%i" x
                | LitInt64 x -> sprintf "%ill" x
                | LitUInt8 x -> sprintf "%iu" x
                | LitUInt16 x -> sprintf "%iu" x
                | LitUInt32 x -> sprintf "%iu" x
                | LitUInt64 x -> sprintf "%iull" x
                | LitFloat32 x -> 
                    if x = infinityf then "1.0f / 0.0f"
                    elif x = -infinityf then "-1.0f / 0.0f"
                    elif Single.IsNaN x then "0.0f / 0.0f"
                    else x.ToString("R") |> add_dec_point |> sprintf "%sf"
                | LitFloat64 x ->
                    if x = infinity then "1.0 / 0.0"
                    elif x = -infinity then "-1.0 / 0.0"
                    elif Double.IsNaN x then "0.0 / 0.0"
                    else x.ToString("R") |> add_dec_point
                | LitString x -> lit_stringCpp x
                | LitChar x -> 
                    match x with
                    | '\b' -> @"\b"
                    | '\n' -> @"\n"
                    | '\t' -> @"\t"
                    | '\r' -> @"\r"
                    | '\\' -> @"\\"
                    | x -> string x
                    |> sprintf "'%s'"
                | LitBool x -> if x then "true" else "false" // true and false are defined in stddef.h
            and type_lit = function
                | YLit x -> lit x
                | YSymbol x -> x
                | x -> raise_codegen_error "Compiler error: Expecting a type literal in the macro." 
            and op (unroll : Stack<int>)s (ret : BindsReturnCpp) a =
                let binds a b = binds unroll a b
                let return' (x : string) =
                    match ret with
                    | BindsLocal ret -> return_local s ret x
                    | BindsTailEnd -> line s $"return {x};"
                let jp (a,b') =
                    let args = args b'
                    match a with
                    | JPMethod(a,b) -> 
                        let x = method (a,b)
                        let method_name = Option.defaultValue "method_" x.name
                        $"{method_name}{x.tag}({args})"
                    | JPClosure(a,b) ->
                        let x = closure (a,b)
                        match x.funtype with
                        | FT_Vanilla -> raise_codegen_error "Compiler error: The vanilla function case should have been blocked elsewhere."
                        | FT_Pointer -> $"FunPointerMethod{x.tag}"
                        | FT_Closure -> $"csptr<ClosureBase{x.tag}>{{new Closure{x.tag}{{{args}}}}}"
                match a with
                | TyMacro _ -> raise_codegen_error "Macros are supposed to be taken care of in the `binds` function."
                | TyIf(cond,tr,fl) ->
                    line s (sprintf "if (%s){" (tup_data cond))
                    binds (indent s) ret tr
                    line s "} else {"
                    binds (indent s) ret fl
                    line s "}"
                | TyJoinPoint(a,args) -> return' (jp (a, args))
                | TyBackend(a,b,c) -> line s $"auto kernel = {backend_handler (a,b,c)};"
                | TyWhile(a,b) ->
                    let cond =
                        match a with
                        | JPMethod(a,b),b' -> sprintf "while_method_%i(%s)" (method_while (a,b)).tag (args b')
                        | _ -> raise_codegen_error "Expected a regular method rather than closure create in the while conditional."
                    match unroll_peek unroll with
                    | -1 -> ()
                    | 0 -> line s $"#pragma unroll"
                    | i -> line s $"#pragma unroll %i{i}"
                    line s (sprintf "while (%s){" cond)
                    binds (indent s) (BindsLocal [||]) b
                    line s "}"
                | TyDo a ->
                    line s "do"
                    binds (indent s) ret a
                | TyIndent a ->
                    binds (indent s) ret a
                | TyIntSwitch(L(v_i,_),on_succ,on_fail) ->
                    line s (sprintf "switch (v%i) {" v_i)
                    let _ =
                        let s = indent s
                        Array.iteri (fun i x ->
                            line s (sprintf "case %i: {" i)
                            binds (indent s) ret x
                            line (indent s) "break;"
                            line s "}"
                            ) on_succ
                        line s "default: {"
                        binds (indent s) ret on_fail
                        line s "}"
                    line s "}"
                | TyUnionUnbox(is,x,on_succs,on_fail) ->
                    let case_tags = x.Item.tags
                    let acs = match x.Item.layout with UHeap -> ".base->" | UStack -> "."
                    let head = List.head is |> fun (L(i,_)) -> $"v{i}{acs}tag"
                    List.pairwise is
                    |> List.map (fun (L(i,_), L(i',_)) -> $"v{i}{acs}tag == v{i'}{acs}tag")
                    |> String.concat " && "
                    |> function "" -> head | x -> $"{x} ? {head} : {max_tag}"
                    |> sprintf "switch (%s) {" |> line s
                    let _ =
                        let s = indent s
                        Map.iter (fun k (a,b) ->
                            let union_i = case_tags.[k]
                            line s (sprintf "case %i: { // %s" union_i k)
                            List.iter2 (fun (L(data_i,_)) a ->
                                let a, s = data_free_vars a, indent s
                                let qs = ResizeArray(a.Length)
                                Array.iteri (fun field_i (L(v_i,t) as v) -> 
                                    qs.Add $"{tyv t} v{v_i} = v{data_i}{acs}case{union_i}.v{field_i};"
                                    ) a 
                                lineCpp' s qs
                                ) is a
                            binds (indent s) ret b
                            line (indent s) "break;"
                            line s "}"
                            ) on_succs
                        line s "default: {"
                        let _ =
                            let s = indent s
                            match on_fail with
                            | Some b -> binds s ret b
                            | None -> line s "assert(\"Invalid tag.\" && false); __trap();"
                        line s "}"
                    line s "}"
                | TyUnionBox(a,b,c') ->
                    let c = c'.Item
                    let i = c.tags.[a]
                    let vars = args' b
                    let tag = (unions c').tag
                    match c.layout with
                    | UHeap -> $"sptr<Union{tag}>{{new Union{tag}{{Union{tag}_{i}{{{vars}}}}}}}"
                    | UStack -> $"Union{tag}{{Union{tag}_{i}{{{vars}}}}}"
                    |> return'
                | TyToLayout(a,b) -> 
                    match b with
                    | YLayout(_,layout) -> 
                        match layout with
                        | Heap ->
                            let tag = (heap b).tag
                            $"sptr<Heap{tag}>{{new Heap{tag}{{{args' a}}}}}"
                        | HeapMutable ->
                            let tag = (mut b).tag
                            $"sptr<Mut{tag}>{{new Mut{tag}{{{args' a}}}}}"
                        | StackMutable -> raise_codegen_error "The Cpp backend doesn't support stack mutable layout types."
                    | _ -> raise_codegen_error "Compiler error: Expected a layout type (2)."
                    |> return'
                | TyLayoutIndexAll(x) -> raise_codegen_error "Compiler error: TyLayoutIndexAll should have been taken care of in TyLet."
                | TyLayoutIndexByKey(x,key) -> raise_codegen_error "Compiler error: TyLayoutIndexByKey should have been taken care of in TyLet."
                | TyLayoutMutableSet(L(i,t),b,c) ->
                    match t with
                    | YLayout(_,lay) ->
                        match lay with
                        | HeapMutable -> 
                            let a =
                                List.fold
                                    (fun s k ->
                                        match s with
                                        | DRecord l -> l |> Map.pick (fun (_, k') v' -> if k = k' then Some v' else None)
                                        | _ -> raise_codegen_error "Compiler error: Expected a record.")
                                    (mut t).data b
                            Array.map2 (fun (L(i',_)) b -> $"v{i}.base->v{i'} = {show_w b};") (data_free_vars a) (data_term_vars c)
                        | StackMutable -> 
                            let a = List.fold (fun s k -> match s with DRecord l -> l |> Map.pick (fun (_, k') v' -> if k = k' then Some v' else None) | _ -> raise_codegen_error "Compiler error: Expected a record.") (stack_mut t).data b
                            Array.map2 (fun (L(i',_)) b -> $"v{i}.v{i'} = {show_w b};") (data_free_vars a) (data_term_vars c)
                        | Heap -> raise_codegen_error "Compiler error (1): TyLayoutMutableSet should only be HeapMutable or StackMutable."
                    | _ -> raise_codegen_error "Compiler error (2): TyLayoutMutableSet should only be HeapMutable or StackMutable."
                    |> String.concat " " |> line s
                | TyArrayLiteral(a,b') -> raise_codegen_error "Compiler error: TyArrayLiteral should have been taken care of in TyLet."
                | TyArrayCreate(a,b) ->  raise_codegen_error "Compiler error: TyArrayCreate should have been taken care of in TyLet."
                | TyFailwith(a,b) ->
                    let string_in_op = function DLit (LitString b) -> lit_stringCpp b | b -> raise_codegen_error "In the Cuda backend, the exception string must be a literal."
                    let fmt = @"%s\n"
                    line s $"printf(\"{fmt}\", {string_in_op b});"
                    line s "__trap();" // TODO: Print out the error traces as well.
                | TyConv(a,b) -> return' $"({tyv a}){tup_data b}"
                | TyApply(L(i,_),b) -> 
                    let rec loop = function
                        | DPair(a,b) -> tup_data a :: loop b
                        | a -> [tup_data a]
                    let args = loop b |> List.filter ((<>) "") |> String.concat ", "
                    $"v{i}({args})" |> return'
                | TyArrayLength(_,b) -> raise_codegen_error "Array length is not supported in the Cuda C++ backend as they are bare pointers."
                | TyStringLength(_,b) -> raise_codegen_error "String length is not supported in the Cuda C++ backend."
                | TySizeOf t -> return' $"sizeof({tup_ty t})"
                | TyOp(Global,[DLit (LitString x)]) -> global' x
                | TyOp(PragmaUnrollPush,[DLit (LitInt32 x)]) -> unroll.Push(x); line s $"// Pushing the loop unrolling to: {x}"
                | TyOp(PragmaUnrollPop,[]) -> line s $"// Poping the loop unrolling to: {unroll_pop unroll}"
                | TyOp(op,l) ->
                    match op, l with
                    | Dyn,[a] -> tup_data a
                    | TypeToVar, _ -> raise_codegen_error "The use of `` should never appear in generated code."
                    | StringIndex, [a;b] -> sprintf "%s[%s]" (tup_data a) (tup_data b)
                    | StringSlice, [a;b;c] -> raise_codegen_error "String slice is not supported natively in the C backend. Use a library implementation instead."
                    | ArrayIndex, [DV(L(_,YArray t)) & a;b] -> 
                        match tup_ty t with
                        | "void" -> "/* void array index */"
                        | _ -> sprintf "%s[%s]" (tup_data a) (tup_data b)
                    | ArrayIndexSet, [DV(L(_,YArray t)) as a;b;c] -> 
                        let a',b',c' = tup_data a, tup_data b, tup_data c
                        match c' with
                        | "" -> "/* void array set */"
                        | _ -> $"{a'}[{b'}] = {c'}"
                    // Math
                    | Add, [a;b] -> sprintf "%s + %s" (tup_data a) (tup_data b)
                    | Sub, [a;b] -> sprintf "%s - %s" (tup_data a) (tup_data b)
                    | Mult, [a;b] -> sprintf "%s * %s" (tup_data a) (tup_data b)
                    | Div, [a;b] -> sprintf "%s / %s" (tup_data a) (tup_data b)
                    | Mod, [a;b] -> sprintf "%s %% %s" (tup_data a) (tup_data b)
                    | Pow, [a;b] -> sprintf "pow(%s,%s)" (tup_data a) (tup_data b)
                    | LT, [a;b] -> sprintf "%s < %s" (tup_data a) (tup_data b)
                    | LTE, [a;b] -> sprintf "%s <= %s" (tup_data a) (tup_data b)
                    | EQ, [a;b] | NEQ, [a;b] | GT, [a;b] | GTE, [a;b] when is_stringCpp a -> raise_codegen_error "String comparison operations are not supported in the Cuda C++ backend."
                    | EQ, [a;b] -> sprintf "%s == %s" (tup_data a) (tup_data b)
                    | NEQ, [a;b] -> sprintf "%s != %s" (tup_data a) (tup_data b)
                    | GT, [a;b] -> sprintf "%s > %s" (tup_data a) (tup_data b)
                    | GTE, [a;b] -> sprintf "%s >= %s" (tup_data a) (tup_data b)
                    | BoolAnd, [a;b] -> sprintf "%s && %s" (tup_data a) (tup_data b)
                    | BoolOr, [a;b] -> sprintf "%s || %s" (tup_data a) (tup_data b)
                    | BitwiseAnd, [a;b] -> sprintf "%s & %s" (tup_data a) (tup_data b)
                    | BitwiseOr, [a;b] -> sprintf "%s | %s" (tup_data a) (tup_data b)
                    | BitwiseXor, [a;b] -> sprintf "%s ^ %s" (tup_data a) (tup_data b)
                    | BitwiseComplement, [a] -> sprintf "~%s" (tup_data a)

                    | ShiftLeft, [a;b] -> sprintf "%s << %s" (tup_data a) (tup_data b)
                    | ShiftRight, [a;b] -> sprintf "%s >> %s" (tup_data a) (tup_data b)

                    | Neg, [x] -> sprintf "-%s" (tup_data x)
                    | Log, [x] -> sprintf "log(%s)" (tup_data x)
                    | Exp, [x] -> sprintf "exp(%s)" (tup_data x)
                    | Tanh, [x] -> sprintf "tanh(%s)" (tup_data x)
                    | Sqrt, [x] -> sprintf "sqrt(%s)" (tup_data x)
                    | Sin, [x] -> sprintf "sin(%s)" (tup_data x)
                    | Cos, [x] -> sprintf "cos(%s)" (tup_data x)
                    | NanIs, [x] -> sprintf "isnan(%s)" (tup_data x)
                    | Printf, [fmt;str] -> 
                        match args' str with
                        | "" -> sprintf "printf(%s)" (tup_data fmt)
                        | str -> sprintf "printf(%s,%s)" (tup_data fmt) str
                    | UnionTag, [DV(L(i,YUnion l)) as x] -> 
                        match l.Item.layout with
                        | UHeap -> ".base->tag"
                        | UStack -> ".tag"
                        |> sprintf "v%i%s" i
                    | _ -> raise_codegen_error <| sprintf "Compiler error: %A with %i args not supported" op l.Length
                    |> return'
            and print_ordered_args s v = // Unlike C# for example, C keeps the struct fields in input order. To reduce padding, it is best to order the fields from largest to smallest.
                order_args v |> Array.iter (fun (L(i,x)) -> line s $"{tyv x} v{i};")
            and method_template is_while : _ -> MethodRecCpp =
                jp (fun ((jp_body,key & (C(args,_))),i) ->
                    match (fst part_eval_env.join_point_method.[jp_body]).[key] with
                    | Some a, Some range, name -> {tag=i; free_vars=rdata_free_vars args; range=range; body=a; name=Option.map fix_method_name name}
                    | _ -> raise_codegen_error "Compiler error: The method dictionary is malformed"
                    ) (fun s_fwd s_typ s_fun x ->
                    let ret_ty = tup_ty x.range
                    let fun_name = Option.defaultValue (if is_while then "while_method_" else "method_") x.name
                    let args = x.free_vars |> Array.mapi (fun i (L(_,x)) -> $"{tyv x} v{i}") |> String.concat ", "
                    let inline_ = 
                        if is_while then "inline "
                        else 
                            line s_fwd $"{code_env.__device__}{ret_ty} {fun_name}{x.tag}({args});"
                            if fun_name.StartsWith "noinline" then "__noinline__ " else ""
                    line s_fun $"{code_env.__device__}{inline_}{ret_ty} {fun_name}{x.tag}({args}){{"
                    binds_start (indent s_fun) x.body
                    line s_fun "}"
                    )
            and method : _ -> MethodRecCpp = method_template false
            and method_while : _ -> MethodRecCpp = method_template true
            and closure_args domain count_start =
                let rec loop = function
                    | YPair(a,b) -> a :: loop b
                    | a -> [a]
                let mutable count = count_start
                let rename x = Array.map (fun (L(i,t)) -> let x = L(count,t) in count <- count+1; x) x
                let mutable i = 0
                loop domain |> List.choose (fun x -> 
                    let n = part_eval_env.ty_to_data x |> data_free_vars 
                    let x = if n.Length <> 0 then Some(i, tup_ty_tyvs n, n |> rename) else None
                    i <- i+1
                    x
                    )
            and closure : _ -> ClosureRecCpp =
                jp (fun ((jp_body,key & (C(args,_,fun_ty))),i) ->
                    match fun_ty with
                    | YFun(domain,range,t) ->
                        match (fst part_eval_env.join_point_closure.[jp_body]).[key] with
                        | Some(domain_args, body) -> {tag=i; domain=domain; range=range; body=body; free_vars=rdata_free_vars args; funtype=t}
                        | _ -> raise_codegen_error "Compiler error: The method dictionary is malformed"
                    | _ -> raise_codegen_error "Compiler error: Unexpected type in the closure join point."
                    ) (fun _ s_typ s_fun x ->
                    let i, range = x.tag, tup_ty x.range
                    let closure_args = closure_args x.domain x.free_vars.Length
                    let args = closure_args |> List.map (fun (i,ty,_) -> $"{ty} tup{i}") |> String.concat ", "
                    let print_body s_fun =
                        let s_fun = indent s_fun
                        x.free_vars |> Array.map (fun (L(i,t)) ->
                            $"{tyv t} & v{i} = this->v{i};"
                            ) |> String.concat " " |> line s_fun
                        closure_args |> List.map (fun (i'',_,vars) ->
                            Array.mapi (fun i' (L(i,t)) -> 
                                if vars.Length <> 1 then $"{tyv t} v{i} = tup{i''}.v{i'};"
                                else $"{tyv t} v{i} = tup{i''};"
                                ) vars
                            |> String.concat " "
                            ) |> String.concat " " |> line s_fun
                        binds_start s_fun x.body
                    match x.funtype with
                    | FT_Pointer ->
                        $"{code_env.__device__}{range} FunPointerMethod{i}({args}){{" |> line s_fun
                        print_body s_fun
                        line s_fun "}"
                    | FT_Vanilla | FT_Closure ->
                        match x.funtype with
                        | FT_Pointer -> raise_codegen_error "Compiler error: The pointer case have been taken care of (1)."
                        | FT_Closure ->
                            let i' = (cfun (x.domain,x.range,x.funtype)).tag
                            line s_typ $"struct Closure{i} : public ClosureBase{i'} {{"
                        | FT_Vanilla ->
                            line s_typ $"struct Closure{i} {{"
                        let () =
                            let s_typ = indent s_typ
                            let () = // free vars in the environment
                                print_ordered_args s_typ x.free_vars
                            let () = // operator()
                                match x.funtype with
                                | FT_Pointer -> raise_codegen_error "Compiler error: The pointer case have been taken care of (2)."
                                | FT_Vanilla -> line s_typ $"{code_env.__device__}{range} operator()({args}){{"
                                | FT_Closure -> line s_typ $"{code_env.__device__}{range} operator()({args}) override {{"
                                print_body s_typ
                                line s_typ "}"
                            let () = // constructor
                                match x.free_vars with
                                | [||] -> ()
                                | _ ->
                                    let constructor_args = 
                                        x.free_vars 
                                        |> Array.map (fun (L(i,t)) -> $"{tyv t} _v{i}")
                                        |> String.concat ", "
                                    let initializer_args = 
                                        x.free_vars 
                                        |> Array.map (fun (L(i,t)) -> $"v{i}(_v{i})")
                                        |> String.concat ", "
                                    line s_typ $"{code_env.__device__}Closure{i}({constructor_args}) : {initializer_args} {{ }}"
                            let () = // destructor
                                match x.funtype with
                                | FT_Pointer | FT_Vanilla -> ()
                                | FT_Closure -> 
                                    let destructor_calls =
                                        x.free_vars 
                                        |> Array.choose (fun (L(i,t)) -> 
                                            if is_numeric t || is_char t then None else
                                            Some $"destroy(v{i});" 
                                            )
                                        |> String.concat " "
                                    line s_typ $"{code_env.__device__}~Closure{i}() override {{ {destructor_calls} }}"
                            ()
                        line s_typ "};"
                    )
            and cfun : _ -> CFunRecCpp =
                cfun' (fun s_fwd s_typ s_fun x ->
                    let i, range = x.tag, tup_ty x.range
                    let domain_args_ty = closure_args x.domain 0 |> List.map (fun (_,ty,_) -> ty) |> String.concat ", "
                    match x.funtype with
                    | FT_Vanilla -> raise_codegen_error "Regular functions do not have a composable type in the Cuda backend. Consider explicitly converting them to either closures or pointers using `to_closure` or `to_fptr` if you want to pass them through boundaries."
                    | FT_Pointer -> line s_fwd $"typedef {range} (* Fun{i})({domain_args_ty});"
                    | FT_Closure ->
                        line s_fwd $"struct ClosureBase{i} {{ int refc{{0}}; {code_env.__device__}virtual {range} operator()({domain_args_ty}) = 0; {code_env.__device__}virtual ~ClosureBase{i}(){{}}; }};"
                        line s_fwd $"typedef csptr<ClosureBase{i}> Fun{i};"
                    )
            and tup : _ -> TupleRecCpp = 
                tuple (fun s_fwd s_typ s_fun x ->
                    let name = sprintf "Tuple%i" x.tag
                    line s_fwd $"struct {name};"
                    line s_typ $"struct {name} {{"
                    x.tys |> Array.mapi (fun i x -> L(i,x)) |> print_ordered_args (indent s_typ)
                    let concat x = String.concat ", " x
                    let args = x.tys |> Array.mapi (fun i x -> $"{tyv x} t{i}")
                    let con_init = x.tys |> Array.mapi (fun i x -> $"v{i}(t{i})")
                    if args.Length <> 0 then
                        line (indent s_typ) $"{code_env.__device__}{name}() = default;"
                        line (indent s_typ) $"{code_env.__device__}{name}({concat args}) : {concat con_init} {{}}"
                    line s_typ "};"
                    )
            and unions : _ -> UnionRecCpp = 
                let inline map_iteri f x = Map.fold (fun i k v -> f i k v; i+1) 0 x |> ignore
                union (fun s_fwd s_typ s_fun x ->
                    let i = x.tag
                    line s_fwd $"struct Union{i};" // Forward declaration for the union.
                    map_iteri (fun tag k v -> // The individual union cases.
                        line s_typ $"struct Union{i}_{tag} {{ // {k}"
                        // The free vars in the env.
                        print_ordered_args (indent s_typ) v
                        let () = // constructors
                            let s_typ = indent s_typ
                            let concat x = String.concat ", " x
                            let args = v |> Array.map (fun (L(i,x)) -> $"{tyv x} t{i}")
                            let con_init = v |> Array.map (fun (L(i,x)) -> $"v{i}(t{i})")
                            if v.Length <> 0 then 
                                line s_typ $"{code_env.__device__}Union{i}_{tag}({concat args}) : {concat con_init} {{}}" 
                                line s_typ $"{code_env.__device__}Union{i}_{tag}() = delete;" 
                        line s_typ "};"
                        ) x.free_vars

                    line s_typ $"struct Union{i} {{" // The union definition.
                    let _ = // Union cases inside the union.
                        let s_typ = indent s_typ
                        line s_typ $"union {{"
                        let _ =
                            let s_typ = indent s_typ
                            map_iteri (fun tag k v -> line s_typ $"Union{i}_{tag} case{tag}; // {k}") x.free_vars
                        line s_typ "};"

                        if x.is_heap then line s_typ "int refc{0};"
                        if x.free_vars.Count > int max_tag then raise_codegen_error $"Too many union cases. They should not be more than {max_tag}."
                        line s_typ $"unsigned char tag{{{max_tag}}};"
                        line s_typ $"{code_env.__device__}Union{i}() {{}}" // default constructor, the refc and tag have def value so we don't have to do anything here.

                        map_iteri (fun tag k v -> // The constructors for all the union cases.
                            line s_typ $"{code_env.__device__}Union{i}(Union{i}_{tag} t) : tag({tag}), case{tag}(t) {{}} // {k}"
                            ) x.free_vars

                        line s_typ $"{code_env.__device__}Union{i}(Union{i} & x) : tag(x.tag) {{" // copy constructor
                        let () =
                            let s_typ = indent s_typ
                            line s_typ "switch(x.tag){"
                            let () = // copy constructor cases
                                let s_typ = indent s_typ
                                map_iteri (fun tag k v -> 
                                    line s_typ $"case {tag}: new (&this->case{tag}) Union{i}_{tag}(x.case{tag}); break; // {k}"
                                    ) x.free_vars
                            line s_typ "}"
                        line s_typ "}"
                        line s_typ $"{code_env.__device__}Union{i}(Union{i} && x) : tag(x.tag) {{" // move constructor
                        let () =
                            let s_typ = indent s_typ
                            line s_typ "switch(x.tag){"
                            let () = // move constructor cases
                                let s_typ = indent s_typ
                                map_iteri (fun tag k v -> 
                                    line s_typ $"case {tag}: new (&this->case{tag}) Union{i}_{tag}(std::move(x.case{tag})); break; // {k}"
                                    ) x.free_vars
                            line s_typ "}"
                        line s_typ "}"
                        line s_typ $"{code_env.__device__}Union{i} & operator=(Union{i} & x) {{" // copy assignment operator
                        let () =
                            let s_typ = indent s_typ
                            line s_typ "if (this->tag == x.tag) {" 
                            let () =
                                let s_typ = indent s_typ
                                line s_typ "switch(x.tag){"
                                let () = // copy assignment cases
                                    let s_typ = indent s_typ
                                    map_iteri (fun tag k v -> 
                                        line s_typ $"case {tag}: this->case{tag} = x.case{tag}; break; // {k}"
                                        ) x.free_vars
                                line s_typ "}"
                            line s_typ "} else {"
                            let () =
                                let s_typ = indent s_typ
                                line s_typ $"this->~Union{i}();"
                                line s_typ $"new (this) Union{i}{{x}};"
                            line s_typ "}"
                            line s_typ "return *this;"
                        line s_typ "}"
                        line s_typ $"{code_env.__device__}Union{i} & operator=(Union{i} && x) {{" // move assignment operator
                        let () =
                            let s_typ = indent s_typ
                            line s_typ "if (this->tag == x.tag) {" 
                            let () =
                                let s_typ = indent s_typ
                                line s_typ "switch(x.tag){"
                                let () = // move assignment cases
                                    let s_typ = indent s_typ
                                    map_iteri (fun tag k v -> 
                                        line s_typ $"case {tag}: this->case{tag} = std::move(x.case{tag}); break; // {k}"
                                        ) x.free_vars
                                line s_typ "}"
                            line s_typ "} else {"
                            let () =
                                let s_typ = indent s_typ
                                line s_typ $"this->~Union{i}();"
                                line s_typ $"new (this) Union{i}{{std::move(x)}};"
                            line s_typ "}"
                            line s_typ "return *this;"
                        line s_typ "}"
                        line s_typ $"{code_env.__device__}~Union{i}() {{"
                        let () = // destructor
                            let s_typ = indent s_typ
                            line s_typ "switch(this->tag){"
                            let () = // destructor cases
                                let s_typ = indent s_typ
                                map_iteri (fun tag k v -> 
                                    line s_typ $"case {tag}: this->case{tag}.~Union{i}_{tag}(); break; // {k}"
                                    ) x.free_vars
                            line s_typ "}"
                            line s_typ $"this->tag = {max_tag};"
                        line s_typ "}"
                    line s_typ "};"
                    )
            and layout_tmpl is_heap name : _ -> LayoutRecCpp =
                layout (fun s_fwd s_typ s_fun (x : LayoutRecCpp) ->
                    let name = sprintf "%s%i" name x.tag
                    line s_fwd $"struct {name};"
                    line s_typ $"struct {name} {{"
                    let () =
                        let s_typ = indent s_typ
                        if is_heap then line s_typ "int refc{0};"
                        x.free_vars |> print_ordered_args s_typ
                        let concat x = String.concat ", " x
                        let args = x.free_vars |> Array.map (fun (L(i,x)) -> $"{tyv x} t{i}")
                        let con_init = x.free_vars |> Array.map (fun (L(i,x)) -> $"v{i}(t{i})")
                        if args.Length <> 0 then
                            line s_typ $"{code_env.__device__}{name}() = default;"
                            line s_typ $"{code_env.__device__}{name}({concat args}) : {concat con_init} {{}}" 
                    line s_typ "};"
                    )
            and heap : _ -> LayoutRecCpp = layout_tmpl true "Heap"
            and mut : _ -> LayoutRecCpp = layout_tmpl true "Mut"
            and stack_mut : _ -> LayoutRecCpp = layout_tmpl false "StackMut"

            function
            | Cpp x ->
                let ret_ty =
                    let er() = raise_codegen_error "The return type of main function in the Cuda host backend should be a i32."
                    match binds_last_dataCpp x with
                    | DLit(LitInt32 _) | DV(L(_, YPrim Int32T)) -> "int"
                    | _ -> er()

                let s = {text=StringBuilder(); indent=0}
                line s $"{ret_ty} main_body() {{"
                binds_start (indent s) x
                line s "}"
                line s $"{ret_ty} main(){{"
                line (indent s) "auto r = main_body();"
                line (indent s) "gpuErrchk(cudaDeviceSynchronize()); // This line is here so the `__trap()` calls on the kernel aren't missed."
                line (indent s) "return r;"
                line s "}"
                code_env.main_defs.Add(s.text.ToString())
            | Cuda(vs,x) ->
                let ret_ty =
                    let er() = raise_codegen_error "The return type of the __global__ kernel in the Cuda backend should be a void type or a record of type {cluster_dims : {x : int; y : int; z : int}}."
                    match binds_last_dataCpp x with
                    | DRecord m when m.Count = 1 ->
                        match m |> Map.tryPick (fun (_, k) v -> if k = "cluster_dims" then Some v else None) with
                        | Some(DRecord m) when m.Count = 3 ->
                            let x = m |> Map.tryPick (fun (_, k) v -> if k = "x" then Some v else None)
                            let y = m |> Map.tryPick (fun (_, k) v -> if k = "y" then Some v else None)
                            let z = m |> Map.tryPick (fun (_, k) v -> if k = "z" then Some v else None)
                            match x, y, z with
                            | Some(DSymbol x), Some(DSymbol y), Some(DSymbol z) ->  $"void __cluster_dims__({x},{y},{z})"
                            | Some(DV _), _, _
                            | _, Some(DV _), _
                            | _, _, Some(DV _) ->  raise_codegen_error "All the variables have to be known at compile time."
                            | _ -> er()
                        | _ -> er()
                    | DB -> "void"
                    | _ -> er()
                let s = {text=StringBuilder(); indent=0}
                let args = vs |> Array.mapi (fun i (L(_,x)) -> $"{tyv x} v{i}") |> String.concat ", "
                line s $"extern \"C\" __global__ {ret_ty} entry%i{code_env.main_defs.Count}(%s{args}) {{"
                binds_start (indent s) x
                line s "}"
                code_env.main_defs.Add(s.text.ToString())

        let codegen (default_env : DefaultEnv) (file_path : string) part_eval_env x = 
            let g = Dictionary HashIdentity.Structural
            let host_code_env = codegen_env.Create("Cpp", "")
            let device_code_env = codegen_env.Create("Cuda", "__device__ ")

            let cuda_codegen = 
                codegen' (fun (jp_body,key,r') -> 
                    raise_codegen_error_backend r' $"The Cuda backend does not support nesting of backends."
                    ) part_eval_env device_code_env
            codegen' (fun (jp_body,key,r') ->
                let backend_name = (fst jp_body).node
                match backend_name with
                | "Cuda" ->
                    Utils.memoize g (fun (jp_body,key & C(args,_)) ->
                        let args = rdata_free_vars args
                        match (fst part_eval_env.join_point_method.[jp_body]).[key] with
                        | Some a, Some _, _ -> cuda_codegen (Cuda(args, a))
                        | _ -> raise_codegen_error "Compiler error: The method dictionary is malformed"
                        $"Device::entry{g.Count}"
                        ) (jp_body,key)
                | x -> raise_codegen_error_backend r' $"The Python + Cuda backend does not support the {x} backend."
                ) part_eval_env host_code_env (Cpp x)

            let append_lines (l : string seq) = (StringBuilder(), l) ||> Seq.fold (fun s -> s.AppendLine)
            let indent_lines (x : string) =
                x.Split('\n')
                |> Array.map (fun x -> if x <> "" then $"    {x}" else x)
                |> fun x -> StringBuilder().AppendJoin("", x)    

            let aux_library_code =
                let dir f =
                    SpiralFileSystem.get_workspace_root ()
                    + "/deps/The-Spiral-Language/The Spiral Language 2"
                    |> fun x -> System.IO.Path.Join (x, f)
                    |> System.IO.File.ReadAllText
                (dir "corelib.cuh").Replace("__host__", "__host__ __device__")
                |> replace_default_types default_env

            let code =
                let file_name = System.IO.Path.GetFileNameWithoutExtension file_path
                StringBuilder()
                    .AppendLine($"#include \"{file_name}.auto.cu\"")
                    .Append(append_lines host_code_env.globals)
                    .Append(append_lines device_code_env.globals)
                    .Append(
                        StringBuilder()
                            .AppendLine("namespace Device {")
                            .Append(
                                StringBuilder()
                                    .AppendJoin("", device_code_env.fwd_dcls)
                                    .AppendJoin("", device_code_env.types)
                                    .AppendJoin("", device_code_env.functions)
                                    .AppendJoin("", device_code_env.main_defs)
                                    .ToString()
                                |> indent_lines
                            )
                    )
                    .AppendLine("}")
                    .AppendJoin("", host_code_env.fwd_dcls)
                    .AppendJoin("", host_code_env.types)
                    .AppendJoin("", host_code_env.functions)
                    .AppendJoin("", host_code_env.main_defs)
                    .ToString()

            [
                {|code = aux_library_code; file_extension = ".auto.cu"|}
                {|code = code.ToString(); file_extension = ".cu"|}
            ]

    /// ## CodegenPython
    module CodegenPython =
        // open System
        // open System.Text
        open System.Collections.Generic

        let backend_namePython = "Python"

        let litPython = function
            | LitInt8 x -> sprintf "%i" x
            | LitInt16 x -> sprintf "%i" x
            | LitInt32 x -> sprintf "%i" x
            | LitInt64 x -> sprintf "%i" x
            | LitUInt8 x -> sprintf "%i" x
            | LitUInt16 x -> sprintf "%i" x
            | LitUInt32 x -> sprintf "%i" x
            | LitUInt64 x -> sprintf "%i" x
            | LitFloat32 x -> 
                if x = infinityf then "float('inf')"
                elif x = -infinityf then "float('-inf')"
                elif Single.IsNaN x then "float()"
                else x.ToString("R") |> add_dec_point
            | LitFloat64 x ->
                if x = infinity then "float('inf')"
                elif x = -infinity then "float('-inf')"
                elif Double.IsNaN x then "float()"
                else x.ToString("R") |> add_dec_point
            | LitString x -> 
                let strb = StringBuilder(x.Length+2)
                strb.Append '"' |> ignore
                String.iter (function
                    | '"' -> strb.Append "\\\"" 
                    | '\b' -> strb.Append @"\b"
                    | '\t' -> strb.Append @"\t"
                    | '\n' -> strb.Append @"\n"
                    | '\r' -> strb.Append @"\r"
                    | '\\' -> strb.Append @"\\"
                    | x -> strb.Append x
                    >> ignore 
                    ) x
                strb.Append '"' |> ignore
                strb.ToString()
            | LitChar x -> 
                match x with
                | '\b' -> @"\b"
                | '\n' -> @"\n"
                | '\t' -> @"\t"
                | '\r' -> @"\r"
                | '\\' -> @"\\"
                | ''' -> @"\'"
                | x -> string x
                |> sprintf "'%s'"
            | LitBool x -> if x then "True" else "False"

        let type_litPython = function
            | YLit x -> litPython x
            | YSymbol x -> x
            | x -> raise_codegen_error "Compiler error: Expecting a type literal in the macro." 

        let show_w = function WV(L(i,_)) -> sprintf "v%i" i | WLit a -> litPython a
        let args x = x |> Array.map (fun (L(i,_)) -> sprintf "v%i" i) |> String.concat ", "
        let args' b = data_term_vars b |> Array.map show_w |> String.concat ", "
        let primPython x = show_primt x
        let cupy_ty x =
            match x with
            | [|L(_,x)|] ->
                match x with
                | YPrim x ->
                    match x with
                    | Int8T -> "cp.int8"
                    | Int16T -> "cp.int16"
                    | Int32T -> "cp.int32"
                    | Int64T -> "cp.int64"
                    | UInt8T -> "cp.uint8"
                    | UInt16T -> "cp.uint16"
                    | UInt32T -> "cp.uint32"
                    | UInt64T -> "cp.uint64"
                    | Float32T -> "cp.float32"
                    | Float64T -> "cp.float64"
                    | BoolT -> "cp.bool_"
                    | _ -> "object"
                | _ -> "object"
            | _ -> "object"

        type UnionRecPython = {tag : int; free_vars : Map<int * string, TyV[]>}
        type LayoutRecPython = {tag : int; data : Data; free_vars : TyV[]; free_vars_by_key : Map<int * string, TyV[]>}
        type MethodRecPython = {tag : int; free_vars : L<Tag,Ty>[]; range : Ty; body : TypedBind[]}
        type ClosureRecPython = {tag : int; free_vars : L<Tag,Ty>[]; domain : Ty; domain_args : TyV[]; range : Ty; body : TypedBind[]}

        type BindsReturnPython =
            | BindsTailEnd
            | BindsLocal of TyV []

        let linePython x s = if s <> "" then x.text.Append(' ', x.indent).AppendLine s |> ignore

        let codegen' backend_handler (part_eval_env : PartEvalResult) (code_env : CodegenCpp.codegen_env) =
            let global' =
                let has_added = HashSet code_env.globals
                fun x -> if has_added.Add(x) then code_env.globals.Add x

            let import x = global' $"import {x}"
            let from x = global' $"from {x}"

            let print is_type show r =
                let s = {text=StringBuilder(); indent=0}
                show s r
                let text = s.text.ToString()
                if is_type then code_env.types.Add(text) else code_env.functions.Add(text)

            let union show =
                let dict = Dictionary(HashIdentity.Reference)
                let f (a : Union) : UnionRecPython =
                    let free_vars = a.Item.cases |> Map.map (fun _ -> part_eval_env.ty_to_data >> data_free_vars)
                    {free_vars=free_vars; tag=dict.Count}
                fun x ->
                    let mutable dirty = false
                    let r = Utils.memoize dict (fun x -> dirty <- true; f x) x
                    if dirty then print true show r
                    r

            let layout show =
                let dict' = Dictionary(HashIdentity.Structural)
                let dict = Dictionary(HashIdentity.Reference)
                let f x : LayoutRecPython = 
                    match x with
                    | YLayout(x,_) ->
                        let x = part_eval_env.ty_to_data x
                        let a, b =
                            match x with
                            | DRecord a -> let a = Map.map (fun _ -> data_free_vars) a in a |> Map.toArray |> Array.collect snd, a
                            | _ -> data_free_vars x, Map.empty
                        {data=x; free_vars=a; free_vars_by_key=b; tag=dict'.Count}
                    | _ -> raise_codegen_error $"Compiler error: Expected a layout type (5).\nGot: %s{show_ty x}"
                fun x ->
                    let mutable dirty = false
                    let r = Utils.memoize dict (Utils.memoize dict' (fun x -> dirty <- true; f x)) x
                    if dirty then print true show r
                    r

            let jp is_type f show =
                let dict = Dictionary(HashIdentity.Structural)
                let f x = f (x, dict.Count)
                fun x ->
                    let mutable dirty = false
                    let r = Utils.memoize dict (fun x -> dirty <- true; f x) x
                    if dirty then print is_type show r
                    r

            let cupy_ty x = part_eval_env.ty_to_data x |> data_free_vars |> cupy_ty
            let rec binds_start (args : TyV []) (s : CodegenEnv) (x : TypedBind []) = binds (refc_prepass Set.empty (Set args) x).g_decr s BindsTailEnd x
            and binds g_decr (s : CodegenEnv) (ret : BindsReturnPython) (stmts : TypedBind []) = 
                let s_len = s.text.Length
                let tup_destruct (a,b) =
                    if 0 < Array.length a then
                        let a = args a
                        let b = Array.map show_w (data_term_vars b) |> String.concat ", "
                        sprintf "%s = %s" a b |> line s
                Array.iter (fun x ->
                    let _ =
                        let f (g : Dictionary<_,_>) = match g.TryGetValue(x) with true, x -> Seq.toArray x | _ -> [||]
                        match args (f g_decr) with "" -> () | x -> sprintf "del %s" x |> line s
                    match x with
                    | TyLet(d,trace,a) ->
                        try op g_decr s (BindsLocal (data_free_vars d)) a
                        with :? CodegenError as e -> raise_codegen_error' trace (e.Data0,e.Data1)
                    | TyLocalReturnOp(trace,a,_) ->
                        try op g_decr s ret a
                        with :? CodegenError as e -> raise_codegen_error' trace (e.Data0,e.Data1)
                    | TyLocalReturnData(d,trace) ->
                        try match ret with
                            | BindsLocal l -> tup_destruct (l, d) 
                            | BindsTailEnd -> line s $"return {tup_data' d}"
                        with :? CodegenError as e -> raise_codegen_error' trace (e.Data0,e.Data1)
                    ) stmts
                if s.text.Length = s_len then line s "pass"
            and tup_data' x = 
                match Array.map show_w (data_term_vars x) with
                | [||] -> ""
                | [|x|] -> x
                | args -> String.concat ", " args
            and tup_data x = 
                match Array.map show_w (data_term_vars x) with
                | [||] -> "None"
                | [|x|] -> x
                | args -> sprintf "(%s)" (String.concat ", " args)
            and tyv = function
                | YUnion a ->
                    match a.Item.layout with
                    | UHeap -> sprintf "UH%i" (uheap a).tag
                    | UStack -> sprintf "US%i" (ustack a).tag
                | YLayout(_,lay) as a -> 
                    match lay with
                    | Heap -> sprintf "Heap%i" (heap a).tag
                    | HeapMutable -> sprintf "Mut%i" (mut a).tag
                    | StackMutable -> raise_codegen_error "Compiler error: The Python backend doesn't support stack mutable layout types."
                | YMacro [Text "backend_switch "; Type (YRecord r)] ->
                    match r |> Map.tryPick (fun (_, k) v -> if k = backend_namePython then Some v else None) with
                    | Some x -> tup_ty x
                    | None -> raise_codegen_error $"In the backend_switch, expected a record with the '{backend_namePython}' field."
                | YMacro a -> a |> List.map (function Text a -> a | Type a -> tup_ty a | TypeLit a -> type_litPython a) |> String.concat ""
                | YPrim a -> primPython a
                | YArray a -> "(cp if cuda else np).ndarray"
                | YFun(a,b,FT_Vanilla) -> 
                    let a = part_eval_env.ty_to_data a |> data_free_vars |> Array.map (fun (L(_,t)) -> tyv t) |> String.concat ", "
                    $"Callable[[{a}], {tup_ty b}]"
                | YExists -> raise_codegen_error "Existentials are not supported at runtime. They are a compile time feature only."
                | YForall -> raise_codegen_error "Foralls are not supported at runtime. They are a compile time feature only."
                | a -> raise_codegen_error $"Complier error: Type not supported in the codegen.\nGot: %A{a}"
            and tup_ty x =
                match part_eval_env.ty_to_data x |> data_free_vars |> Array.map (fun (L(_,t)) -> tyv t) with
                | [||] -> "None"
                | [|x|] -> x
                | x -> String.concat ", " x |> sprintf "Tuple[%s]"
            and op g_decr s (ret : BindsReturnPython) a =
                let return' (x : string) =
                    match ret with
                    | BindsTailEnd -> line s $"return {x}"
                    | BindsLocal ret -> line s (if ret.Length = 0 then x else sprintf "%s = %s" (args ret) x)
                let jp (a,b) =
                    let args = args b
                    match a with
                    | JPMethod(a,b) -> sprintf "method%i(%s)" (method (a,b)).tag args
                    | JPClosure(a,b) -> sprintf "Closure%i(%s)" (closure (a,b)).tag args
                let layout_index i x' =
                    x' |> Array.map (fun (L(i',_)) -> $"v{i}.v{i'}")
                    |> String.concat ", "
                    |> return'

                match a with
                | TySizeOf t -> raise_codegen_error $"The following type in `sizeof` is not supported in the Python back end.\nGot: {show_ty t}"
                | TyMacro a ->
                    // System.Console.WriteLine $"CodegenPython.TyMacro / a: %A{a}"
                    a
                    |> List.map (function
                        | CMText x when x |> SpiralSm.starts_with "$\"" ->
                            let x = x |> SpiralSm.replace "%A{" "{"
                            $"f\"{x.[2..]}"
                        | CMText x -> x
                        | CMTerm (x,inl) -> if inl then args' x else tup_data x
                        | CMType x -> tup_ty x
                        | CMTypeLit a -> type_litPython a
                    )
                    |> String.concat ""
                    |> return'
                | TyIf(cond,tr,fl) ->
                    line s (sprintf "if %s:" (tup_data cond))
                    binds g_decr (indent s) ret tr
                    line s "else:"
                    binds g_decr (indent s) ret fl
                | TyJoinPoint(a,args) -> return' (jp (a, args))
                | TyBackend(a,b,c) -> line s $"kernel = \"{backend_handler (a,b,c)}\""
                | TyWhile(a,b) ->
                    line s (sprintf "while %s:" (jp a))
                    binds g_decr (indent s) (BindsLocal [||]) b
                | TyDo a ->
                    line s "do"
                    binds g_decr (indent s) ret a
                | TyIndent a ->
                    binds g_decr (indent s) ret a
                | TyIntSwitch(L(v_i,_),on_succ,on_fail) ->
                    Array.iteri (fun i x ->
                        if i = 0 then line s $"if v{v_i} == {i}:"
                        else line s $"elif v{v_i} == {i}:"
                        binds g_decr (indent s) ret x
                        ) on_succ
                    line s "else:"
                    binds g_decr (indent s) ret on_fail
                | TyUnionUnbox(is,x,on_succs,on_fail) ->
                    let case_tags = x.Item.tags
                    line s (sprintf "match %s:" (is |> List.map (fun (L(i,_)) -> $"v{i}") |> String.concat ", "))
                    let s = indent s
                    let prefix = 
                        match x.Item.layout with
                        | UHeap -> sprintf "UH%i" (uheap x).tag
                        | UStack -> sprintf "US%i" (ustack x).tag
                    Map.iter (fun k (a,b) ->
                        let i = case_tags.[k]
                        let cases = 
                            a |> List.map (fun a ->
                                let x = data_free_vars a
                                let g_decr' = Utils.get_default g_decr (Array.head b) (fun () -> Set.empty)
                                let x,g_decr' = Array.mapFold (fun g_decr (L(i,_) as v) -> if Set.contains v g_decr then "_", Set.remove v g_decr else sprintf "v%i" i, g_decr) g_decr' x
                                g_decr.[Array.head b] <- g_decr'
                                sprintf "%s_%i(%s)" prefix i (String.concat ", " x)
                                )
                            |> String.concat ", "
                        line s (sprintf "case %s: # %s" cases k)
                        binds g_decr (indent s) ret b
                        ) on_succs
                    line s "case t:"
                    match on_fail with
                    | Some b -> binds g_decr (indent s) ret b
                    | None -> line (indent s) "raise Exception(f'Pattern matching miss. Got: {t}')"
                | TyUnionBox(a,b,c') ->
                    let c = c'.Item
                    let i = c.tags.[a]
                    let vars = tup_data' b
                    match c.layout with
                    | UHeap -> sprintf "UH%i_%i(%s)" (uheap c').tag i vars
                    | UStack -> sprintf "US%i_%i(%s)" (ustack c').tag i vars
                    |> return'
                | TyToLayout(a,b) -> 
                    match b with
                    | YLayout(_,layout) -> 
                        match layout with
                        | Heap -> sprintf "Heap%i(%s)" (heap b).tag (tup_data' a)
                        | HeapMutable -> sprintf "Mut%i(%s)" (mut b).tag (tup_data' a)
                        | StackMutable -> raise_codegen_error "The Python backend doesn't support stack mutable layout types."
                    | _ -> raise_codegen_error "Compiler error: Expected a layout type (6)."
                    |> return'
                | TyLayoutIndexAll(L(i,YLayout(_,lay) & a)) -> 
                    match lay with
                    | Heap -> heap a 
                    | HeapMutable -> mut a
                    | StackMutable -> raise_codegen_error "The Python backend doesn't support indexing into stack mutable layout types."
                    |> fun x -> x.free_vars |> layout_index i
                | TyLayoutIndexByKey(L(i,YLayout(_,lay) & a),key) ->
                    match lay with
                    | Heap -> heap a 
                    | HeapMutable -> mut a
                    | StackMutable -> raise_codegen_error "The Python backend doesn't support indexing into stack mutable layout types."
                    |> fun x ->
                        x.free_vars_by_key
                        |> Map.tryPick (fun (_, k) v -> if k = key then Some v else None)
                        |> Option.iter (layout_index i)
                | TyLayoutIndexAll _ | TyLayoutIndexByKey _ -> raise_codegen_error "Compiler error: Expected the TyV in layout index to be a layout type."
                | TyLayoutMutableSet(L(i,t),b,c) ->
                    let a = List.fold (fun s k ->
                        match s with
                        | DRecord l -> l |> Map.pick (fun (_,k') v -> if k = k' then Some v else None)
                        | _ -> raise_codegen_error "Compiler error: Expected a record.") (mut t).data b
                    Array.iter2 (fun (L(i',_)) b -> line s $"v{i}.v{i'} = {show_w b}") (data_free_vars a) (data_term_vars c)
                | TyArrayLiteral(a,b) -> return' <| sprintf "(cp if cuda else np).array([%s],dtype=%s)" (List.map tup_data' b |> String.concat ", ") (cupy_ty a)
                | TyArrayCreate(a,b) -> return' $"(cp if cuda else np).empty({tup_data b},dtype={cupy_ty a})" 
                | TyFailwith(a,b) -> line s $"raise Exception({tup_data' b})"
                | TyConv(a,b) -> return' $"{tyv a}({tup_data b})"
                | TyApply(L(i,_),b) -> return' $"v{i}({tup_data' b})"
                | TyArrayLength(a,b) -> return' $"{tup_data b}.__len__()"
                | TyStringLength(a,b) -> return' $"len({tup_data b})"
                | TyOp(Global,[DLit (LitString x)]) -> global' x
                | TyOp(op,l) ->
                    match op, l with
                    | ToPythonRecord,[DRecord x] -> Map.foldBack (fun k v l -> $"'{k}': {tup_data v}" :: l) x [] |> String.concat ", " |> sprintf "{%s}"
                    | ToPythonNamedTuple,[n;DRecord x] -> 
                        import "collections"
                        let field_names = Map.foldBack (fun k v l -> $"'{k}'" :: l) x [] |> String.concat ", "
                        let args = Map.foldBack (fun k v l -> tup_data v :: l) x [] |> String.concat ", "
                        $"collections.namedtuple({tup_data n},[{field_names}])({args})"
                    | Dyn,[a] -> tup_data a
                    | TypeToVar, _ -> raise_codegen_error "The use of `` should never appear in generated code."
                    | StringIndex, [a;b] -> sprintf "%s[%s]" (tup_data a) (tup_data b)
                    | StringSlice, [a;b;c] -> sprintf "%s[%s:%s]" (tup_data a) (tup_data b) (tup_data c)
                    | ArrayIndex, [a;b] -> sprintf "%s[%s].item()" (tup_data a) (tup_data b)
                    | ArrayIndexSet, [a;b;c] -> 
                        match tup_data' c with
                        | "" -> "pass # void array set"
                        | c -> sprintf "%s[%s] = %s" (tup_data a) (tup_data b) c
                    // Math
                    | Add, [a;b] -> sprintf "%s + %s" (tup_data a) (tup_data b)
                    | Sub, [a;b] -> sprintf "%s - %s" (tup_data a) (tup_data b)
                    | Mult, [a;b] -> sprintf "%s * %s" (tup_data a) (tup_data b)
                    | Div, [(DV(L(_,YPrim (Float32T | Float64T))) | DLit(LitFloat32 _ | LitFloat64 _)) & a;b] -> sprintf "%s / %s" (tup_data a) (tup_data b)
                    | Div, [a;b] -> sprintf "%s // %s" (tup_data a) (tup_data b)
                    | Mod, [a;b] -> sprintf "%s %% %s" (tup_data a) (tup_data b)
                    | Pow, [a;b] -> sprintf "pow(%s,%s)" (tup_data a) (tup_data b)
                    | LT, [a;b] -> sprintf "%s < %s" (tup_data a) (tup_data b)
                    | LTE, [a;b] -> sprintf "%s <= %s" (tup_data a) (tup_data b)
                    | EQ, [a;b] -> sprintf "%s == %s" (tup_data a) (tup_data b)
                    | NEQ, [a;b] -> sprintf "%s != %s" (tup_data a) (tup_data b)
                    | GT, [a;b] -> sprintf "%s > %s" (tup_data a) (tup_data b)
                    | GTE, [a;b] -> sprintf "%s >= %s" (tup_data a) (tup_data b)
                    | BoolAnd, [a;b] -> sprintf "%s and %s" (tup_data a) (tup_data b)
                    | BoolOr, [a;b] -> sprintf "%s or %s" (tup_data a) (tup_data b)
                    | BitwiseAnd, [a;b] -> sprintf "%s & %s" (tup_data a) (tup_data b)
                    | BitwiseOr, [a;b] -> sprintf "%s | %s" (tup_data a) (tup_data b)
                    | BitwiseXor, [a;b] -> sprintf "%s ^ %s" (tup_data a) (tup_data b)
                    | BitwiseComplement, [a] -> sprintf "~%s" (tup_data a)

                    | ShiftLeft, [a;b] -> sprintf "%s << %s" (tup_data a) (tup_data b)
                    | ShiftRight, [a;b] -> sprintf "%s >> %s" (tup_data a) (tup_data b)

                    | Neg, [x] -> sprintf "-%s" (tup_data x)
                    | Log, [x] -> import "math"; sprintf "math.log(%s)" (tup_data x)
                    | Exp, [x] -> import "math"; sprintf "math.exp(%s)" (tup_data x)
                    | Tanh, [x] -> import "math"; sprintf "math.tanh(%s)" (tup_data x)
                    | Sqrt, [x] -> import "math"; sprintf "math.sqrt(%s)" (tup_data x)
                    | Sin, [x] -> import "math"; sprintf "math.sin(%s)" (tup_data x)
                    | Cos, [x] -> import "math"; sprintf "math.cos(%s)" (tup_data x)
                    | NanIs, [x] -> import "math"; sprintf "math.isnan(%s)" (tup_data x)
                    | UnionTag, [DUnion(_,l) | DV(L(_,YUnion l)) as x] -> sprintf "%s.tag" (tup_data x) 
                    | _ -> raise_codegen_error <| sprintf "Compiler error: %A with %i args not supported" op l.Length
                    |> return'
            and uheap : _ -> UnionRecPython = union (fun s x ->
                let cases = Array.init x.free_vars.Count (fun i -> $"\"UH{x.tag}_{i}\"") |> function [|x|] -> x | x -> x |> String.concat ", " |> sprintf "Union[%s]"
                code_env.fwd_dcls.Add $"UH{x.tag} = {cases}"
                let mutable i = 0
                x.free_vars |> Map.iter (fun k a ->
                    line s $"class UH{x.tag}_{i}(NamedTuple): # {k}"
                    let s = indent s
                    a |> Array.iter (fun (L(i,t)) -> line s $"v{i} : {tyv t}")
                    line s $"tag = {i}"
                    i <- i+1
                    )
                )
            and ustack : _ -> UnionRecPython = union (fun s x ->
                let mutable i = 0
                x.free_vars |> Map.iter (fun k a ->
                    line s $"class US{x.tag}_{i}(NamedTuple): # {k}"
                    let s = indent s
                    a |> Array.iter (fun (L(i,t)) -> line s $"v{i} : {tyv t}")
                    line s $"tag = {i}"
                    i <- i+1
                    )
                let cases = Array.init x.free_vars.Count (fun i -> $"US{x.tag}_{i}") |> function [|x|] -> x | x -> x |> String.concat ", " |> sprintf "Union[%s]"
                line s $"US{x.tag} = {cases}"
                )
            and heap : _ -> LayoutRecPython = layout (fun s x -> 
                line s $"class Heap{x.tag}(NamedTuple):"
                let s = indent s
                if x.free_vars.Length = 0 then line s "pass" 
                else x.free_vars |> Array.iter (fun (L(i,t)) -> line s $"v{i} : {tyv t}")
                )
            and mut : _ -> LayoutRecPython = layout (fun s x -> 
                line s "@dataclass"
                line s $"class Mut{x.tag}:"
                let s = indent s
                if x.free_vars.Length = 0 then line s "pass" 
                else x.free_vars |> Array.iter (fun (L(i,t)) -> line s $"v{i} : {tyv t}")
                )
            and method : _ -> MethodRecPython =
                jp false (fun ((jp_body,key & (C(args,_))),i) ->
                    match (fst part_eval_env.join_point_method.[jp_body]).[key] with
                    | Some a, Some range, _ -> {tag=i; free_vars=rdata_free_vars args; range=range; body=a}
                    | _ -> raise_codegen_error "Compiler error: The method dictionary is malformed"
                    ) (fun s x ->
                    let method_args = x.free_vars |> Array.map (fun (L(i,t)) -> $"v{i} : {tyv t}") |> String.concat ", "
                    line s $"def method{x.tag}({method_args}) -> {tup_ty x.range}:"
                    binds_start x.free_vars (indent s) x.body
                    )
            and closure : _ -> ClosureRecPython =
                jp true (fun ((jp_body,key & (C(args,_,fun_ty))),i) ->
                    match fun_ty with
                    | YFun(domain,range,FT_Vanilla) ->
                        match (fst part_eval_env.join_point_closure.[jp_body]).[key] with
                        | Some(domain_args, body) -> {tag=i; free_vars=rdata_free_vars args; domain=domain; domain_args=data_free_vars domain_args; range=range; body=body}
                        | _ -> raise_codegen_error "Compiler error: The method dictionary is malformed"
                    | YFun _ -> raise_codegen_error "Non-standard functions are not supported in the Python backend."
                    | _ -> raise_codegen_error "Compiler error: Unexpected type in the closure join point."
                    ) (fun s x ->
                    let env_args = x.free_vars |> Array.map (fun (L(i,t)) -> $"env_v{i} : {tyv t}") |> String.concat ", "
                    line s $"def Closure{x.tag}({env_args}):"
                    let s = indent s
                    let inner_args = x.domain_args |> Array.map (fun (L(i,t)) -> $"v{i} : {tyv t}") |> String.concat ", "
                    line s $"def inner({inner_args}) -> {tup_ty x.range}:"
                    let _ =
                        let s = indent s
                        if x.free_vars.Length > 0 then 
                            let nonlocal_args = x.free_vars |> Array.map (fun (L(i,t)) -> $"env_v{i}") |> String.concat ", "
                            line s $"nonlocal {nonlocal_args}"
                            x.free_vars |> Array.map (fun (L(i,t)) -> $"v{i} = env_v{i}") |> String.concat "; " |> line s
                        binds_start x.free_vars s x.body
                    line s "return inner"
                    )

            fun (x : TypedBind []) ->
            import "cupy as cp"
            import "numpy as np"
            from "dataclasses import dataclass"
            from "typing import NamedTuple, Union, Callable, Tuple"
            code_env.globals.Add "i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str"
            code_env.globals.Add "cuda = False"
            code_env.globals.Add ""

            let s = {text=StringBuilder(); indent=0}

            line s "def main_body():"
            binds_start [||] (indent s) x
            s.text.AppendLine() |> ignore

            line s "def main():"
            line (indent s) "r = main_body()"
            line (indent s) "if cuda: cp.cuda.get_current_stream().synchronize() # This line is here so the `__trap()` calls on the kernel aren't missed."
            line (indent s) "return r"
            s.text.AppendLine() |> ignore

            line s "if __name__ == '__main__': result = main(); None if result is None else print(result)"
            code_env.main_defs.Add(s.text.ToString())

        let codegen (default_env : DefaultEnv) (file_path : string) part_eval_env (x : TypedBind[]) = 
            let cuda_kernels = StringBuilder().AppendLine("kernel = r\"\"\"")
            let g = Dictionary(HashIdentity.Structural)

            let host_code_env = CodegenCpp.codegen_env.Create("Python", "")
            let device_code_env = CodegenCpp.codegen_env.Create("Cuda", "__device__ ")

            let cuda_codegen = 
                CodegenCpp.codegen' (fun (jp_body,key,r') -> 
                    raise_codegen_error_backend r' $"The Cuda backend does not support nesting of backends."
                    ) part_eval_env device_code_env
            let python_code =
                codegen' (fun (jp_body,key,r') ->
                    let backend_name = (fst jp_body).node
                    match backend_name with
                    | "Cuda" -> 
                        Utils.memoize g (fun (jp_body,key & C(args,_)) ->
                            let args = rdata_free_vars args
                            match (fst part_eval_env.join_point_method.[jp_body]).[key] with
                            | Some a, Some _, _ -> cuda_codegen (CodegenCpp.Cuda(args,a))
                            | _ -> raise_codegen_error "Compiler error: The method dictionary is malformed"
                            $"entry{g.Count}"
                            ) (jp_body,key)
                    | x -> raise_codegen_error_backend r' $"The Python + Cuda backend does not support the {x} backend."
                    ) part_eval_env host_code_env x

            let append_lines (l : string seq) = (StringBuilder(), l) ||> Seq.fold (fun s -> s.AppendLine)

            let file_name = System.IO.Path.GetFileNameWithoutExtension file_path

            let aux_library_code =
                let dir f =
                    SpiralFileSystem.get_workspace_root ()
                    + "/deps/The-Spiral-Language/The Spiral Language 2"
                    |> fun x -> System.IO.Path.Join (x, f)
                    |> System.IO.File.ReadAllText
                let aux_library_code_python = dir "corelib.py"
                let aux_library_code_cuda =
                    (dir "corelib.cuh").Replace("__host__", "__device__")
                    |> CodegenCpp.replace_default_types default_env

                StringBuilder()
                    .AppendLine("kernels_aux = r\"\"\"")
                    .AppendLine(aux_library_code_cuda)
                    .AppendLine("\"\"\"")
                    .AppendLine(aux_library_code_python)
                    .ToString()
            let code_main = 
                StringBuilder()
                    .AppendLine("kernels_main = r\"\"\"")
                    .Append(append_lines device_code_env.globals)
                    .AppendJoin("", device_code_env.fwd_dcls)
                    .AppendJoin("", device_code_env.types)
                    .AppendJoin("", device_code_env.functions)
                    .AppendJoin("", device_code_env.main_defs)
                    .AppendLine("\"\"\"")
                    .AppendLine($"from {file_name}_auto import *")
                    .AppendLine("kernels = kernels_aux + kernels_main")
                    .AppendLine(
                        part_eval_env.globals
                        |> Seq.append host_code_env.globals
                        |> Seq.distinct
                        |> append_lines
                        |> _.ToString()
                    )
                    .AppendLine("# fwd_dcls")
                    .AppendJoin("\n", host_code_env.fwd_dcls)
                    .AppendLine("# types")
                    .AppendJoin("", host_code_env.types)
                    .AppendLine("# functions")
                    .AppendJoin("", host_code_env.functions)
                    .AppendLine("# main_defs")
                    .AppendJoin("", host_code_env.main_defs)
                    .ToString()

            [
                {|code = aux_library_code; file_extension = "_auto.py"|}
                {|code = code_main; file_extension = ".py"|}
            ]

    /// ## WDiff
    // open System
    open System.IO
    open System.Collections.Generic

    // Full name: Microsoft.FSharp.Core.Result<_,_>.Ok

    open FSharp.Core

    open Hopac
    open Hopac.Infixes
    open Hopac.Extensions
    open Hopac.Stream

    /// ### process_errors
    let process_errors line (ers : LineTokenErrors list) : RString list =
        ers |> List.mapi (fun i l -> 
            let i = line + i
            l |> List.map (fun (r,x) -> x, ({|line=i; character=r.from|}, {|line=i; character=r.nearTo|}))
            )
        |> List.concat
        |> List.groupBy snd
        |> List.map (fun (k,v) -> k, process_error (List.map fst v))

    /// ### tokenize_replace
    /// Replaces the token lines and updates the errors given the edit.
    let tokenize_replace (lines : _ PersistentVector PersistentVector, errors : _ list) (edit : SpiEdit) =
        let toks, ers = Array.map tokenize edit.lines |> Array.unzip
        let lines = replace edit.from edit.nearTo toks lines
        let errors = 
            let adj = edit.lines.Length - (edit.nearTo - edit.from)
            errors |> List.choose (fun ((a : VSCPos,b),c as x) -> 
                if edit.from <= a.line && a.line < edit.nearTo then None
                elif edit.nearTo <= a.line && adj <> 0 then Some (add_line_to_range adj (a,b),c)
                else Some x
                )
        let errors = List.append errors (process_errors edit.from (Array.toList ers))
        lines, errors

    type [<ReferenceEquality>] TokenizerState = {
        lines_text : string PersistentVector
        lines_token : LineTokens
        blocks : LineTokens Block list
        errors : RString list
        }

    /// ### wdiff_tokenizer_init
    let wdiff_tokenizer_init = { lines_text = PersistentVector.empty; lines_token = PersistentVector.empty; blocks = []; errors = [] }

    /// ### replace'
    /// Immutably updates the state based on the request. Does diffing to make the operation efficient.
    /// It is possible for the server to go out of sync, in which case an error is returned.
    let replace' (state : TokenizerState) (edit : SpiEdit) =
        let lines_text = replace edit.from edit.nearTo edit.lines state.lines_text
        let lines_token, errors = tokenize_replace (state.lines_token, state.errors) edit
        let blocks = wdiff_block_all state.blocks (lines_token, edit.lines.Length, edit.from, edit.nearTo)
        {lines_text=lines_text; lines_token=lines_token; errors=errors; blocks=blocks}

    /// ### wdiff_tokenizer_all
    let wdiff_tokenizer_all (state : TokenizerState) text = 
        let text = lines text
        let text' = state.lines_text |> Seq.toArray
        let rec loop (index,text : string [] as x) i = if i < min text.Length state.lines_text.Length && index text i = index text' i then loop x (i+1) else i
        let from = loop ((fun text i -> text.[i]),text) 0
        if from = text.Length then state else
        let text = text.[from..]
        let fromRev = loop ((fun text i -> text.[text.Length-1-i]),text) 0
        replace' state {|from=from; nearTo=text'.Length-fromRev; lines=text.[..text.Length-1-fromRev]|}

    /// ### wdiff_tokenizer_edit
    let wdiff_tokenizer_edit (state : TokenizerState) (edit : SpiEdit) = 
        if edit.nearTo <= state.lines_text.Length then Ok (replace' state edit)
        else Error "The edit is out of bounds and cannot be applied. The language server and the editor are out of sync. Try reopening the file being edited."

    /// ### semantic_updates_apply
    let semantic_updates_apply (block : LineTokens) updates =
        Seq.fold (fun block (c : VectorCord, l) -> 
            let x =
                let r, x = PersistentVector.nthNth c.row c.col block
                let x =
                    match x with
                    | TokVar(a,_) -> TokVar(a,l)
                    | TokSymbol(a,_) -> TokSymbol(a,l)
                    | TokOperator(a,_) -> TokOperator(a,l)
                    | TokUnaryOperator(a,_) -> TokUnaryOperator(a,l)
                    | x -> failwithf "Compiler error: Cannot change the semantic legend for the %A token." x
                r, x
            PersistentVector.updateNth c.row c.col x block
            ) block updates

    /// ### parse_block
    let parse_block default_env is_top_down (block : LineTokens) =
        let comments, cords_tokens = 
            Array.init block.Length (fun line ->
                let x = block.[line]
                let comment, len = match PersistentVector.tryLast x with Some (r, TokComment c) -> Some (r, c), x.Length-1 | _ -> None, x.Length
                let tokens = Array.init len (fun i ->
                    let r, x = x.[i] 
                    {|row=line; col=i|}, (({| line=line; character=r.from |}, {| line=line; character=r.nearTo |}), x)
                    )
                comment, tokens
                )
            |> Array.unzip
        let cords, tokens = Array.unzip (Array.concat cords_tokens)

        let semantic_updates = ResizeArray()
        let env = {
            tokens_cords = cords; semantic_updates = semantic_updates
            comments = comments; tokens = tokens; i = ref 0; is_top_down = is_top_down
            default_env = default_env
            }
        {result=blockParsingParse env; semantic_tokens=semantic_updates_apply block semantic_updates}

    /// ### wdiff_parse_init
    let wdiff_parse_init is_top_down : ParserState = {is_top_down=is_top_down; blocks=[]}

    /// ### wdiff_parse
    let wdiff_parse default_env (state : ParserState) (unparsed_blocks : LineTokens Block list) =
        let dict = Dictionary(HashIdentity.Reference)
        // Offset should be ignored when memoizing the results of parsing.
        List.iter (fun (a,b) -> dict.Add(a,b.block)) state.blocks
        let blocks = unparsed_blocks |> List.map (fun x -> 
            x.block, {block=memoize dict (fun a -> Hopac.memo(Job.thunk <| fun () -> (parse_block default_env state.is_top_down) a)) x.block; offset=x.offset}
            )  
        {state with blocks = blocks }

    /// ### ModuleState
    type ModuleState = { tokenizer : TokenizerState; bundler : BlockBundleState; parser : ParserState }

    /// ### wdiff_module_init
    let wdiff_module_init is_top_down = {tokenizer = wdiff_tokenizer_init; bundler = wdiff_block_bundle_init; parser = wdiff_parse_init is_top_down}

    /// ### wdiff_module_body
    let wdiff_module_body default_env state tokenizer =
        if state.tokenizer = tokenizer then state else
        let parser = wdiff_parse default_env state.parser tokenizer.blocks
        let bundler = wdiff_block_bundle state.bundler parser
        {tokenizer=tokenizer; parser=parser; bundler=bundler}

    /// ### wdiff_module_edit
    let wdiff_module_edit default_env (state : ModuleState) x = wdiff_tokenizer_edit state.tokenizer x |> Result.map (wdiff_module_body default_env state)

    /// ### wdiff_module_all
    let wdiff_module_all default_env state x = wdiff_tokenizer_all state.tokenizer x |> wdiff_module_body default_env state

    /// ### wdiff_module_init_all
    let wdiff_module_init_all default_env is_top_down x = wdiff_module_all default_env (wdiff_module_init is_top_down) x

    /// ### FileState<'input,'result,'state>
    type [<ReferenceEquality>] FileState<'input,'result,'state> = { input : 'input; result : 'result; state : 'state }

    /// ### FileFuns<'a,'b,'state>
    type FileFuns<'a,'b,'state> =
        abstract member eval : 'state * 'a -> 'b
        abstract member diff : 'state * 'b * 'a -> 'b
        abstract member init : 'a -> FileState<'a,'b,'state>

    /// ### TypecheckerStateValue
    type TypecheckerStateValue = Bundle option * InferResult * TopEnv

    /// ### TypecheckerStatePropagated
    type TypecheckerStatePropagated = (bool * TopEnv) Promise

    /// ### TypecheckerState
    type TypecheckerState = FileState<PackageId * ModuleId * BlockBundleState, TypecheckerStateValue Stream, TypecheckerStatePropagated>

    /// ### typecheck
    let rec typecheck (package_id,module_id,env : TopEnv) x = x >>=* function
        | Cons((_,b : BlockBundleValue), ls) ->
            match b.bundle with
            | Some bundle ->
                let x = infer package_id module_id env bundle
                let adds = match x.top_env_additions with AOpen x | AInclude x -> x
                let env = inferUnion adds env
                Job.result (Cons((b.bundle,x,env),typecheck (package_id,module_id,env) ls))
            | None ->
                typecheck (package_id,module_id,env) ls :> _ Job
        | Nil ->
            Job.result Nil

    /// ### diff
    let rec diff (package_id,module_id,env) (result,input : BlockBundleState) = 
        let tc () = typecheck (package_id,module_id,env) input
        if Promise.Now.isFulfilled result then
            input >>** fun input ->
            match Promise.Now.get result,input with
            | Cons((b',_,env as x),next), Cons((_,b),bs) when b' = b.bundle -> Promise.Now.withValue (Cons(x,diff (package_id,module_id,env) (next,bs)))
            | _ -> tc()
        else tc()

    /// ### funs_file_tc
    let funs_file_tc = {new FileFuns<PackageId * ModuleId * BlockBundleState, TypecheckerStateValue Stream, TypecheckerStatePropagated> with
        member _.eval(state,(pid,mid,x)) = 
            state >>=* fun (_,env) -> 
            typecheck (pid,mid,env) x
        member _.diff(state,b,(pid,mid,a)) =
            state >>=* fun (_,env) -> diff (pid,mid,env) (b,a)
        member _.init x = {
            input = x
            result = Promise.Now.never()
            state = Promise.Now.never()
            }
        }

    /// ### wdiff_file_update_state
    let wdiff_file_update_state (funs : FileFuns<'a,'b,'state>) (state : FileState<'a,'b,'state>) (x : 'state) =
        if state.state = x then state else {state with state=x; result=funs.eval(x,state.input)}

    /// ### wdiff_file_update_input
    let wdiff_file_update_input (funs : FileFuns<'a,'b,'state>) (state : FileState<'a,'b,'state>) (x : 'a) =
        if state.input = x then state else {state with input=x; result=funs.diff(state.state,state.result,x)}

    /// ### wdiff_file
    let wdiff_file (funs : FileFuns<'a,'b,'state>) (state : FileState<'a,'b,'state>) (a,b) =
        if state.state = a then wdiff_file_update_input funs state b else {state=a; input=b; result=funs.eval(a,b)}

    /// ### ProjFilesTree
    type ProjFilesTree =
        | File of module_id: ModuleId * path: string * name: string option
        | Directory of dir_id: DirId * name: string * ProjFilesTree list

    /// ### ProjFiles
    type ProjFiles = { tree : ProjFilesTree list; num_dirs : int; num_files : int }

    /// ### ProjFileFuns<'a,'state>
    type ProjFileFuns<'a,'state> =
        abstract member file : string option * 'state * 'a -> 'a * 'state
        abstract member union : 'state * 'state -> 'state
        abstract member in_module : string * 'state -> 'state
        abstract member default' : DefaultEnv -> 'state
        abstract member empty : 'state

    /// ### ProjFilesState<'a,'state>
    type [<ReferenceEquality>] ProjFilesState<'a,'state> = {
        init : 'state
        uids_file : ('a * 'state) []
        uids_directory : 'state []
        files : ProjFiles
        result : 'state
        }

    /// ### proj_files_diff
    let proj_files_diff (uids_file : ('a * 'b) [], uids_directory : 'b [], files) (uids, files') =
        let uids_file' = Array.zeroCreate (Array.length uids)
        let uids_directory' = Array.zeroCreate files'.num_dirs
        // Ref equality is done first for performance. Most of the time the strings will be the same.
        let eq a b = System.Object.ReferenceEquals(a,b) || a = b
        let rec loop = function
            | File(mid,path,name), File(mid',path',name') when mid = mid' && eq path path' && eq name name' -> 
                let x = uids_file.[mid]
                if uids.[mid] = fst x then uids_file'.[mid] <- x; true else false
            | Directory(uid,name,l), Directory(uid',name',l') when uid = uid' && eq name name' && list (l,l') -> 
                uids_directory'.[uid] <- uids_directory.[uid]; true
            | _ -> false
        and list = function
            | x :: xs, y :: ys -> loop (x,y) && list (xs,ys)
            | _ -> false
        if list (files.tree, files'.tree) then None else Some (uids_file',uids_directory')

    /// ### proj_files
    let proj_files (funs : ProjFileFuns<'a,'state>) uids_file uids_directory uids s l =
        let inline memo (uids : _ []) uid f = 
            let x = uids.[uid]
            if isNull (box x) then let x = f() in uids.[uid] <- x; x
            else x
        let rec loop state = function
            | File(mid,_,name) -> memo uids_file mid (fun () -> funs.file(name,state,Array.get uids mid)) |> snd
            | Directory(uid,name,l) -> memo uids_directory uid (fun () -> funs.in_module(name,list state l))
        and list s l = 
            List.fold (fun (empty,big) x -> 
                let small = loop big x
                funs.union(small,empty), funs.union(small,big)
                ) (funs.empty, s) l |> fst
        list s l.tree

    /// ### wdiff_proj_files_update_files
    let wdiff_proj_files_update_files (funs : ProjFileFuns<'a,'state>) (state : ProjFilesState<'a,'state >) (uids,files : ProjFiles) =
        match proj_files_diff (state.uids_file,state.uids_directory,state.files) (uids,files) with
        | Some (uids_file, uids_directory) -> {state with files=files; uids_file=uids_file; uids_directory=uids_directory; result=proj_files funs uids_file uids_directory uids state.init files}
        | None -> state

    /// ### wdiff_proj_files_update_packages
    let wdiff_proj_files_update_packages (funs : ProjFileFuns<'a,'state>) (state : ProjFilesState<'a,'state >) (init : 'state) =
        if state.init = init then state else
        let uids_file, uids_directory = Array.zeroCreate state.uids_file.Length, Array.zeroCreate state.uids_directory.Length
        let uids = Array.map fst state.uids_file
        {state with init=init; uids_file=uids_file; uids_directory=uids_directory; result=proj_files funs uids_file uids_directory uids init state.files}

    /// ### wdiff_proj_files
    let wdiff_proj_files (funs : ProjFileFuns<'a,'state>) (state : ProjFilesState<'a,'state >) (init,(uids,files)) =
        if state.init = init then wdiff_proj_files_update_files funs state (uids,files)
        else
            let uids_file, uids_directory = Array.zeroCreate files.num_files, Array.zeroCreate files.num_dirs
            {files=files; init=init; uids_file=uids_file; uids_directory=uids_directory; result=proj_files funs uids_file uids_directory uids init files}

    /// ### typechecker_results_summary
    let typechecker_results_summary l =
        Stream.foldFun (fun (has_error,big) (_,x : InferResult,_) -> 
            has_error || List.isEmpty x.errors = false,
            match x.top_env_additions with 
            | AOpen _ -> big 
            | AInclude small -> inferUnion small big
            ) (false,inferTop_env_empty) l

    /// ### funs_proj_file_tc
    let funs_proj_file_tc = {new ProjFileFuns<TypecheckerState,TypecheckerStatePropagated> with
        member _.file(name,state,x) = 
            let x = wdiff_file_update_state funs_file_tc x state
            let env = 
                typechecker_results_summary x.result >>-* fun (has_error,env) -> 
                has_error, match name with None -> env | Some name -> inferIn_module name env
            x,env
        member _.union(small,big) = small >>=* fun small -> big >>- fun big -> fst small || fst big, inferUnion (snd small) (snd big)
        member _.in_module(name,small) = small >>-* fun (has_error,env) -> has_error, inferIn_module name env
        member _.default' default_env = Promise.Now.withValue (false,inferTop_env_default default_env)
        member _.empty = Promise.Now.withValue (false,inferTop_env_empty)
        }

    /// ### PackageEnv
    type PackageEnv = {
        nominals_aux : Map<PackageId,Map<GlobalId, {|name : string; kind : TT|}>>
        nominals : Map<PackageId,Map<GlobalId, {|vars : Var list; body : T|}>>
        prototypes_instances : Map<PackageId,Map<GlobalId * GlobalId, Constraint Set list>>
        prototypes : Map<PackageId,Map<GlobalId, {|name : string; signature : T; kind : TT|}>>
        ty : Map<string,T>
        term : Map<string,T>
        constraints : Map<string,ConstraintOrModule>
        }

    /// ### union
    let union small big = {
        nominals_aux = Map.foldBack Map.add small.nominals_aux big.nominals_aux
        nominals = Map.foldBack Map.add small.nominals big.nominals
        prototypes_instances = Map.foldBack Map.add small.prototypes_instances big.prototypes_instances
        prototypes = Map.foldBack Map.add small.prototypes big.prototypes
        ty = Map.foldBack Map.add small.ty big.ty
        term = Map.foldBack Map.add small.term big.term
        constraints = Map.foldBack Map.add small.constraints big.constraints
        }

    /// ### in_moduleWDiff
    let in_moduleWDiff m (a : PackageEnv) =
        {a with 
            ty = Map.add m (TyModule a.ty) Map.empty
            term = Map.add m (TyModule a.term) Map.empty
            constraints = Map.add m (M a.constraints) Map.empty
            }

    /// ### package_to_file
    let package_to_file (x : PackageEnv) = {
        nominals_next_tag = 0
        nominals_aux = Map.foldBack (fun _ -> Map.foldBack Map.add) x.nominals_aux Map.empty
        nominals = Map.foldBack (fun _ -> Map.foldBack Map.add) x.nominals Map.empty
        prototypes_next_tag = 0
        prototypes_instances = Map.foldBack (fun _ -> Map.foldBack Map.add) x.prototypes_instances Map.empty
        prototypes = Map.foldBack (fun _ -> Map.foldBack Map.add) x.prototypes Map.empty
        ty = x.ty
        term = x.term
        constraints = x.constraints
        }

    /// ### add_file_to_package
    let add_file_to_package package_id (small : TopEnv) (big : PackageEnv): PackageEnv = {
        nominals_aux = Map.add package_id small.nominals_aux big.nominals_aux
        nominals = Map.add package_id small.nominals big.nominals
        prototypes_instances = Map.add package_id small.prototypes_instances big.prototypes_instances
        prototypes = Map.add package_id small.prototypes big.prototypes
        ty = small.ty
        term = small.term
        constraints = small.constraints
        }

    /// ### package_env_empty
    let package_env_empty = {
        nominals_aux = Map.empty
        nominals = Map.empty
        prototypes_instances = Map.empty
        prototypes = Map.empty
        ty = Map.empty
        term = Map.empty
        constraints = Map.empty
        }

    /// ### package_env_default
    let package_env_default default_env = 
        let x = inferTop_env_default default_env
        {package_env_empty with ty = x.ty; term = x.term; constraints = x.constraints}

    /// ### ProjPackagesState<'a>
    type ProjPackagesState<'a> = {
        packages : (string option * 'a) list
        result : 'a
        }

    /// ### ProjState<'file_inputs,'files,'packages>
    type ProjState<'file_inputs,'files,'packages> = {
        package_id : PackageId
        packages : 'packages ProjPackagesState
        files : ProjFilesState<'file_inputs,'files>
        result : 'packages
        }

    /// ### TypecheckerStateTop
    type TypecheckerStateTop = (bool * PackageEnv) Promise

    /// ### ProjStateTC
    type ProjStateTC = ProjState<TypecheckerState,TypecheckerStatePropagated,TypecheckerStateTop>

    /// ### ProjEnvTC
    type ProjEnvTC = Map<PackageId,ProjStateTC>

    /// ### ProjPackageFuns<'file,'package>
    type ProjPackageFuns<'file,'package> =
        abstract member unions : DefaultEnv -> (string option * 'package) list -> 'package
        abstract member union : 'package * 'package -> 'package
        abstract member in_module : string * 'package -> 'package
        abstract member package_to_file : 'package -> 'file
        abstract member add_file_to_package : PackageId * 'file * 'package -> 'package
        abstract member default' : DefaultEnv -> 'package
        abstract member empty : 'package

    /// ### funs_proj_package_tc
    let funs_proj_package_tc = {new ProjPackageFuns<TypecheckerStatePropagated,TypecheckerStateTop> with
        member funs.unions default_env l = 
            let f = function Some name, small -> funs.in_module(name,small) | None, small -> small
            List.fold (fun big x -> funs.union(f x,big)) (funs.default' default_env) l
        member _.union(small,big) = 
            Job.delay <| fun () ->
                Hopac.queueIgnore big
                small >>= fun a ->
                big >>- fun b ->
                fst a || fst b, union (snd a) (snd b)
            |> Hopac.memo
        member _.in_module(name,x) = x >>-* fun (has_error,env) -> has_error, in_moduleWDiff name env
        member _.package_to_file(x) = x >>-* fun (has_error,env) -> has_error, package_to_file env
        member _.add_file_to_package(pid,a,b) = 
            a >>=* fun (has_error,env) ->
            b >>-* fun (has_error',env') ->
            has_error || has_error', add_file_to_package pid env env'
        member _.default' default_env = Promise.Now.withValue (false, package_env_default default_env)
        member _.empty = Promise.Now.withValue (false, package_env_empty)
        }

    /// ### wdiff_proj_init
    let wdiff_proj_init default_env (funs_packages : ProjPackageFuns<'file,'package>) (funs_files : ProjFileFuns<'file_input,'file>) package_id : ProjState<'file_input,'file,'package> = 
        let packages = { packages = []; result = funs_packages.default' default_env}
        let files = {
            files={tree=[]; num_dirs=0; num_files=0}
            uids_file=[||]; uids_directory=[||]
            init=funs_files.default' default_env; result=funs_files.empty
            }
        let result = funs_packages.empty
        { package_id = package_id; packages = packages; files = files; result = result}

    /// ### wdiff_proj_packages
    let wdiff_proj_packages default_env (funs : ProjPackageFuns<_,'a>) (state : 'a ProjPackagesState) x =
        if state.packages = x then state else {packages = x; result = funs.unions default_env x }

    /// ### wdiff_proj_update_packages
    let wdiff_proj_update_packages default_env funs_packages funs_files (state : ProjState<'a,'b,'state>) x =
        let packages = wdiff_proj_packages default_env funs_packages state.packages x
        if state.packages = packages then state else
        let files = wdiff_proj_files_update_packages funs_files state.files (funs_packages.package_to_file(packages.result))
        let result = funs_packages.add_file_to_package(state.package_id,files.result,packages.result)
        {state with packages=packages; files=files; result=result}

    /// ### wdiff_proj_update_files
    let wdiff_proj_update_files (funs_packages : ProjPackageFuns<_,_>) funs_files (state : ProjState<'a,'b,'state>) x =
        let files = wdiff_proj_files_update_files funs_files state.files x
        if state.files = files then state else
        let result = funs_packages.add_file_to_package(state.package_id,files.result,state.packages.result)
        {state with files=files; result=result}

    /// ### wdiff_proj
    let wdiff_proj default_env (funs_packages : ProjPackageFuns<_,_>) funs_files (state : ProjState<'file_input,'file,'state>) (packages,files) =
        let packages = wdiff_proj_packages default_env funs_packages state.packages packages
        if state.packages = packages then wdiff_proj_update_files funs_packages funs_files state files
        else
            let files = wdiff_proj_files funs_files state.files (funs_packages.package_to_file(packages.result),files)
            let result = funs_packages.add_file_to_package(state.package_id,files.result,packages.result)
            {state with packages=packages; files=files; result=result}

    /// ### ProjEnvUpdate<'a>
    type ProjEnvUpdate<'a> =
        | UpdatePackageModule of PackageId * (string option * PackageId) list * ('a [] * ProjFiles)
        | UpdatePackage of PackageId * (string option * PackageId) list

    /// ### map_packages
    let map_packages s packages = packages |> List.map (fun (a,b) -> a, (Map.find b s).result)

    /// ### wdiff_projenv
    let wdiff_projenv default_env funs_packages funs_files (s : Map<PackageId,ProjState<'a,'b,'state>>) l =
        List.fold (fun s -> function
            | UpdatePackageModule(uid,packages,files) -> Map.add uid (wdiff_proj default_env funs_packages funs_files s.[uid] (map_packages s packages,files)) s
            | UpdatePackage(uid,packages) -> Map.add uid (wdiff_proj_update_packages default_env funs_packages funs_files s.[uid] (map_packages s packages)) s
            ) s l

    /// ## WDiffPrepass
    open Hopac
    open Hopac.Infixes
    open Hopac.Extensions
    open Hopac.Stream

    /// ### PrepassStateValue
    type PrepassStateValue = InferResult * PrepassTopEnv AdditionType * PrepassTopEnv

    /// ### PrepassStatePropagated
    type PrepassStatePropagated = PrepassTopEnv Promise

    /// ### PrepassState
    type PrepassState = FileState<PackageId * ModuleId * string * TypecheckerStateValue Stream, PrepassStateValue Stream, PrepassStatePropagated>

    /// ### prepass
    let rec prepass (package_id,module_id,path,env) = function
        | Cons((_,r,_) : TypecheckerStateValue, ls) ->
            r.filled_top >>- fun filled_top -> 
            let x = (prepassPrepass package_id module_id path env).filled_top filled_top
            let adds = match x with AOpen x | AInclude x -> x
            let env = prepassUnion adds env
            Cons((r,x,env),ls >>=* prepass (package_id,module_id,path,env))
        | Nil ->
            Job.result Nil

    /// ### diffWDiffPrepass
    let rec diffWDiffPrepass (package_id,module_id,path,env) (result,input : TypecheckerStateValue Stream) = 
        input >>** fun input ->
        let tc () = prepass (package_id,module_id,path,env) input |> Hopac.memo
        if Promise.Now.isFulfilled result then
            match Promise.Now.get result,input with
            | Cons((b',_,env as x),next), Cons((_,b,_),bs) when b' = b -> Cons(x,diffWDiffPrepass (package_id,module_id,path,env) (next,bs)) |> Promise.Now.withValue
            | _ -> tc()
        else tc()

    /// ### funs_file_prepass
    let funs_file_prepass = {new FileFuns<PackageId * ModuleId * string * TypecheckerStateValue Stream, PrepassStateValue Stream, PrepassStatePropagated> with
        member _.eval(state,(pid,mid,path,x)) = 
            state >>=* fun env -> 
            x >>= prepass (pid,mid,path,env)
        member _.diff(state,b,(pid,mid,path,a)) =
            state >>=* fun env -> diffWDiffPrepass (pid,mid,path,env) (b,a)
        member _.init x = {
            input = x
            result = Promise.Now.never()
            state = Promise.Now.never()
            }
        }

    /// ### prepass_results_summary
    let prepass_results_summary l =
        Stream.foldFun (fun big (_,x,_) ->
            match x with
            | AOpen _ -> big
            | AInclude small -> prepassUnion small big
            ) (prepassTop_env_empty) l

    /// ### funs_proj_file_prepass
    let funs_proj_file_prepass = {new ProjFileFuns<PrepassState,PrepassStatePropagated> with
        member _.file(name,state,x) = 
            let x = wdiff_file_update_state funs_file_prepass x state
            let env = 
                prepass_results_summary x.result >>-* fun env -> 
                match name with None -> env | Some name -> in_modulePrepass name env
            x,env
        member _.union(small,big) = small >>=* fun small -> big >>- fun big -> prepassUnion small big
        member _.in_module(name,small) = small >>-* in_modulePrepass name
        member _.default' default_env = Promise.Now.withValue (prepassTop_env_default default_env)
        member _.empty = Promise.Now.withValue prepassTop_env_empty
        }

    /// ### PrepassPackageEnv
    type PrepassPackageEnv = {
        prototypes_instances : Map<int, Map<GlobalId * GlobalId,E>>
        nominals : Map<int, Map<GlobalId,{|body : TPrepass; name : string|}>>
        term : Map<string,E>
        ty : Map<string,TPrepass>
        }

    /// ### unionWDiffPrepass
    let unionWDiffPrepass small big = {
        prototypes_instances = Map.foldBack Map.add small.prototypes_instances big.prototypes_instances
        nominals = Map.foldBack Map.add small.nominals big.nominals
        term = Map.foldBack Map.add small.term big.term
        ty = Map.foldBack Map.add small.ty big.ty
        }

    /// ### in_module
    let in_module m (a : PrepassPackageEnv) =
        {a with 
            ty = Map.add m (TModule a.ty) Map.empty
            term = Map.add m (EModule a.term) Map.empty
            }

    /// ### package_env_emptyWDiffPrepass
    let package_env_emptyWDiffPrepass = {
        prototypes_instances = Map.empty
        nominals = Map.empty
        term = Map.empty
        ty = Map.empty
        }

    /// ### package_to_fileWDiffPrepass
    let package_to_fileWDiffPrepass (x : PrepassPackageEnv) = {
        nominals_next_tag = 0
        nominals = Map.foldBack (fun _ -> Map.foldBack Map.add) x.nominals Map.empty
        prototypes_next_tag = 0
        prototypes_instances = Map.foldBack (fun _ -> Map.foldBack Map.add) x.prototypes_instances Map.empty
        ty = x.ty
        term = x.term
        }

    /// ### add_file_to_packageWDiffPrepass
    let add_file_to_packageWDiffPrepass package_id (small : PrepassTopEnv) (big : PrepassPackageEnv): PrepassPackageEnv = {
        nominals = Map.add package_id small.nominals big.nominals
        prototypes_instances = Map.add package_id small.prototypes_instances big.prototypes_instances
        ty = small.ty
        term = small.term
        }

    /// ### package_env_defaultWDiffPrepass
    let package_env_defaultWDiffPrepass default_env = { package_env_emptyWDiffPrepass with ty = (prepassTop_env_default default_env).ty }

    /// ### ProjStatePrepass
    type ProjStatePrepass = ProjState<PrepassState,PrepassStatePropagated,PrepassPackageEnv Promise>

    /// ### funs_proj_package_prepass
    let funs_proj_package_prepass = {new ProjPackageFuns<PrepassStatePropagated,PrepassPackageEnv Promise> with
        member funs.unions default_env l = 
            let f = function Some name, small -> funs.in_module(name,small) | None, small -> small
            List.fold (fun big x -> funs.union(f x,big)) (funs.default' default_env) l
        member _.union(small,big) = 
            Job.delay <| fun () ->
                Hopac.queueIgnore big
                small >>= fun a -> big >>- unionWDiffPrepass a
            |> Hopac.memo
        member _.in_module(name,x) = x >>-* fun env -> in_module name env
        member _.package_to_file(x) = x >>-* package_to_fileWDiffPrepass
        member _.add_file_to_package(pid,a,b) = 
            a >>=* fun env ->
            b >>-* add_file_to_packageWDiffPrepass pid env
        member _.default' default_env = Promise.Now.withValue (package_env_defaultWDiffPrepass default_env)
        member _.empty = Promise.Now.withValue package_env_emptyWDiffPrepass
        }

    /// ## SpiProj
    // Everything that deals with Spiral project files themselves goes here
    open FParsec
    // open Common

    /// ### RawFileHierarchy
    type RawFileHierarchy =
        | Directory of VSCRange * RString * RawFileHierarchy list
        | File of VSCRange * RString * is_top_down : bool * is_include : bool

    /// ### ConfigResumableError
    type ConfigResumableError =
        | DuplicateFiles of VSCRange [] []
        | DuplicateRecordFields of VSCRange [] []
        | MissingNecessaryRecordFields of string [] * VSCRange

    /// ### ConfigFatalError
    type ConfigFatalError =
        | Tabs of VSCRange []
        | ParserError of string * VSCRange

    /// ### ConfigException
    exception ConfigException of ConfigFatalError

    /// ### spaces_template
    let rec spaces_template s = (spaces >>. optional (followedByString "//" >>. skipRestOfLine true >>. spaces_template)) s

    /// ### spacesSpiProj
    let spacesSpiProj s = spaces_template s

    /// ### raise'
    let raise' x = raise (ConfigException x)

    /// ### raise_if_not_empty
    let raise_if_not_empty exn l = if Array.isEmpty l = false then raise' (exn l)

    /// ### add_to_exception_list'
    let add_to_exception_list' (p: CharStream<ResizeArray<ConfigResumableError>>) = p.State.UserState.Add

    /// ### add_to_exception_list
    let add_to_exception_list (p: CharStream<ResizeArray<ConfigResumableError>>) exn l = if Array.isEmpty l = false then p.State.UserState.Add (exn l)

    /// ### column
    let column (p : CharStream<_>) = p.Column

    /// ### pos
    let pos (p : CharStream<_>) : VSCPos = {|line=int p.Line - 1; character=int p.Column - 1|}

    /// ### pos'
    let pos' p = Reply(pos p)

    /// ### rangeSpiProj
    let rangeSpiProj f p = pipe3 pos' f pos' (fun a b c -> ((a, c) : VSCRange), b) p

    /// ### is_small_var_char_startingSpiProj
    let is_small_var_char_startingSpiProj c = isAsciiLower c

    /// ### is_var_charSpiProj
    let is_var_charSpiProj c = isAsciiLetter c || c = '_' || c = ''' || isDigit c

    /// ### file'
    let file' p = many1Satisfy2L is_small_var_char_startingSpiProj is_var_charSpiProj "lowercase variable name" p

    /// ### fileSpiProj
    let fileSpiProj p = (rangeSpiProj file' .>> spacesSpiProj) p

    /// ### file_verify
    let file_verify p = (skipMany1Satisfy2L is_small_var_char_startingSpiProj is_var_charSpiProj "lowercase variable name" .>> spacesSpiProj .>> eof) p

    /// ### file_hierarchy
    let rec file_hierarchy p =
        let i = column p
        let expr p = if i = column p then file_or_directory p else Reply(ReplyStatus.Error,expected "file or directory on the same or greater indentation as the first one")
        (many expr |>> fun l ->
            let _ = 
                l |> List.toArray
                |> Array.choose (function | File(_,(a,b),_,_) -> Some (b,a) | _ -> None)
                |> Array.groupBy fst
                |> Array.choose (fun (a,b) -> if b.Length > 1 then Some (Array.map snd b) else None)
                |> add_to_exception_list p DuplicateFiles
            l
            ) p

    and file_or_directory p =
        let i = column p
        let file_hierarchy p = if i < column p then file_hierarchy p else Reply([])
        (rangeSpiProj (rangeSpiProj file' >>= fun (r,name) p ->
            let adjust_range ((a,b) : VSCRange) : VSCRange = if b.character < a.character then a,{|line=b.line-1; character=Int32.MaxValue|} else a,b
            let x = p.Peek2()
            match x.Char0, x.Char1 with
            | '/',_ -> p.Skip(); (spacesSpiProj >>. file_hierarchy |>> fun files r' -> Directory(adjust_range r',(r,name),files)) p
            | '-',_ -> p.Skip(); (spacesSpiProj >>% fun r' -> File(adjust_range r',(r,name),true,true)) p
            | '*','-' -> p.Skip(2); (spacesSpiProj >>% fun r' -> File(adjust_range r',(r,name),false,true)) p
            | '*',_ -> p.Skip(); (spacesSpiProj >>% fun r' -> File(adjust_range r',(r,name),false,false)) p
            | _ -> (spacesSpiProj >>% fun r' -> File(adjust_range r',(r,name),true,false)) p
            )
        |>> fun (r',f) -> f r') p

    /// ### RawSchemaPackages
    type RawSchemaPackages = {range : VSCRange; name : string; is_in_compiler_dir : bool; is_include : bool}

    /// ### packages
    let packages p =
        let i = column p
        let file = rangeSpiProj (((skipChar '|' >>% true) <|>% false) .>>.  file') >>= fun (r,(is_in_compiler_dir,name)) p ->
            match p.Peek() with
            | '-' -> p.Skip(); (spacesSpiProj >>% {range=r; name=name; is_in_compiler_dir=is_in_compiler_dir; is_include=true}) p
            | _ -> (spacesSpiProj >>% {range=r; name=name; is_in_compiler_dir=is_in_compiler_dir; is_include=false}) p
        let file p = if i <= column p then file p else Reply(ReplyStatus.Error,expected "directory on the same or greater indentation as the first one")
        many file p

    /// ### tab_positions
    let tab_positions (str : string): VSCRange [] =
        let mutable line = -1
        lines str |> Array.choose (fun x -> 
            line <- line + 1
            let x = {|line=line; character=x.IndexOf("\t")|}
            if x.character <> -1 then Some(x,{|x with character=x.character+1|}) else None
            )

    /// ### record_reduce
    let record_reduce (field: Parser<'schema -> 'schema, _>) s p =
        let record_body p =
            let i = column p
            let indent expr p = if i = column p then expr p else Reply(ReplyStatus.Error,expected "record field on the same indentation as the first one")
            many (indent field) p
        (rangeSpiProj record_body |>> fun (r,l) -> r, List.fold (|>) s l) p

    /// ### record_field
    let record_field (name, p) = 
        (skipString name >>. skipChar ':' >>. spacesSpiProj >>. rangeSpiProj p)
        |>> (fun (r,f) (s,l) -> f s, (r, name) :: l)

    /// ### record
    let record fields fields_necessary schema =
        let fields = choice (List.map record_field fields)
        record_reduce fields (schema, []) >>= fun (range,(schema,l)) p ->
            let l = List.toArray l
            let _ =
                let names = Array.map snd l
                Set fields_necessary - Set names
                |> Set.toArray
                |> add_to_exception_list p (fun fields -> MissingNecessaryRecordFields(fields,range))
            let _ =
                Array.groupBy snd l
                |> Array.choose (fun (k, v) -> if v.Length > 1 then Some (Array.map fst v) else None)
                |> add_to_exception_list p DuplicateRecordFields

            Reply(schema)

    /// ### RawSchema
    type RawSchema = {
        name : RString option
        version : RString option
        moduleDir : RString option
        modules : RawFileHierarchy list
        packageDir : RString option
        packages : RawSchemaPackages list
        }

    /// ### schema_def
    let schema_def: RawSchema = {
        name=None
        version=None
        moduleDir=None
        modules=[]
        packageDir=None
        packages=[]
        }

    /// ### ConfigError
    type ConfigError = ResumableError of ConfigResumableError [] | ConfigFatalError of ConfigFatalError

    /// ### config
    let config text =
        try 
            let _ = tab_positions text |> raise_if_not_empty Tabs

            let directory p = (rangeSpiProj (restOfLine false) .>> spacesSpiProj |>> fun (r,x) -> Some(r,x.Trim())) p

            let fields = [
                "version", rangeSpiProj (restOfLine true .>> spacesSpiProj) |>> fun (r,x) s -> {s with version=Some (r,x.TrimEnd())}
                "name", fileSpiProj |>> fun x s -> {s with name=Some x}
                "moduleDir", directory |>> fun x s -> {s with moduleDir=x}
                "modules", file_hierarchy |>> fun x s -> {s with modules=x}
                "packageDir", directory |>> fun x s -> {s with packageDir=x}
                "packages", packages |>> fun x s -> {s with packages=x}
                ]
            let necessary = []

            match runParserOnString (spacesSpiProj >>. record fields necessary schema_def .>> eof) (ResizeArray()) "spiral.config" text with
            | Success(a,userstate,_) -> 
                if userstate.Count > 0 then userstate.ToArray() |> ResumableError |> Result.Error else Result.Ok a
            | Failure(messages,error,_) ->
                let x = {|line=int error.Position.Line - 1; character=int error.Position.Column - 1|}
                ParserError(messages, (x,{|x with character=x.character+1|})) |> ConfigFatalError |> Result.Error
        with 
            | :? ConfigException as e -> e.Data0 |> ConfigFatalError |> Result.Error

        |> Result.mapError (fun x ->
            let fatal_error = function
                | Tabs l -> l |> Array.map (fun r -> r, "Tab not allowed.")
                | ParserError(x,r) -> [|r, (lines x).[3..] |> String.concat "\n"|]
            let inline duplicate er = Array.collect (fun l -> let er = er (Array.length l) in Array.map (fun r -> r, er) l)
            let resumable_error = function
                | DuplicateFiles l -> duplicate (sprintf "Duplicate name. Count: %i") l
                | DuplicateRecordFields l -> duplicate (sprintf "Duplicate record field. Count: %i") l
                | MissingNecessaryRecordFields (l,r) -> [|r, sprintf "Record is missing the fields: %s" (String.concat ", " l)|]
            match x with
            | ResumableError x -> Array.collect resumable_error x
            | ConfigFatalError x -> fatal_error x
            |> Array.toList
            )

    /// ### FileHierarchy
    type FileHierarchy =
        | Directory of VSCRange * path: RString * name : string * FileHierarchy list
        | File of VSCRange * path: RString * string option

    /// ### SchemaPackages
    type SchemaPackages = {dir : RString; name : string option}

    /// ### Schema
    type Schema = {
        moduleDir : VSCRange option * string
        modules : FileHierarchy list
        packageDir : VSCRange option * string 
        packages : SchemaPackages list
        }

    /// ### SchemaException
    exception SchemaException of RString

    /// ### SchemaResult
    type SchemaResult = Result<Schema,RString list>

    open Microsoft.FSharp.Core

    /// ### schema
    let schema (pdir,text) : SchemaResult = config text |> Result.bind (fun x ->
        try
            let combine a (r,b) =
                try
                    Path.Combine(a,b)
                    |> Path.GetFullPath
                    |> fun result ->
                        let result' = result |> SpiralFileSystem.standardize_path
                        // trace Verbose (fun () -> $"""SpiProj.schema.combine / a: {a} / b: {b} / result: {result |> SpiralSm.replace "\\" "|"} / result': {result'}""") _locals
                        result'
                with e ->
                    raise (SchemaException(r,e.Message))
            let module_dir =
                match x.moduleDir with
                | Some(r,_ as x) -> Some r, combine pdir x
                | None -> None, pdir
            let package_dir = 
                match x.packageDir with
                | Some(r,_ as x) -> Some r, combine pdir x
                | None -> None, Path.Combine(pdir,"..") |> Path.GetFullPath
            // trace Verbose (fun () -> $"""SpiProj.schema / pdir: {pdir} / module_dir: {module_dir |> snd} / package_dir: {package_dir |> snd |> SpiralSm.replace "\\" "|"}""") _locals
            let modules =
                let rec loop prefix = function
                    | RawFileHierarchy.Directory(r,(r',a),l) -> 
                        let prefix = Path.Combine(prefix,a)
                        let prefix' = prefix |> SpiralFileSystem.standardize_path
                        trace Verbose (fun () -> $"SpiProj.schema.modules.loop | RawFileHierarchy.Directory(r,(r',a),l) / prefix: {prefix} / prefix': {prefix'}") _locals
                        let prefix = prefix'
                        Directory(r,(r',prefix),a,List.map (loop prefix) l)
                    | RawFileHierarchy.File(r,(r',a),is_top_down,is_include) ->
                        let path = Path.Combine(prefix,a + if is_top_down then ".spi" else ".spir")
                        let path' = path |> SpiralFileSystem.standardize_path
                        // trace Verbose (fun () -> $"SpiProj.schema.modules.loop | RawFileHierarchy.File(r,(r',a),is_top_down,is_include) / path: {path} / path': {path'}") _locals
                        let path = path'
                        File(r,(r',path),if is_include then None else Some a)
                List.map (loop (snd module_dir)) x.modules
            let packages =
                let cdir =
#if !INTERACTIVE
                    // Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory,"..")
                    Path.Combine (SpiralFileSystem.get_workspace_root (), "deps/The-Spiral-Language/VS Code Plugin")
#else
                    Path.Combine (SpiralFileSystem.get_workspace_root (), "deps/The-Spiral-Language/VS Code Plugin")
#endif
                    |> Path.GetFullPath
                x.packages |> List.map (fun x ->
                    let name = if x.is_include then None else Some x.name
                    let dir = Path.Combine((if x.is_in_compiler_dir then cdir else snd package_dir),x.name)
                    let dir' = dir |> SpiralFileSystem.standardize_path
                    let dir'' = dir' |> SpiralFileSystem.standardize_path
                    trace Verbose (fun () -> $"""SpiProj.schema.packages / dir: {dir |> SpiralSm.replace "\\" "|"} / dir': {dir'} / dir'': {dir''}""") _locals
                    let dir = dir''
                    {name = name; dir = x.range, dir}
                    )
            Ok {moduleDir = module_dir; modules = modules; packageDir = package_dir; packages = packages}
        with :? SchemaException as e -> Error [e.Data0]
        )

    /// ## Graph
    open System.Collections.Generic

    /// ### Graph
    type Graph = Map<string,string Set>

    /// ### MirroredGraph
    type MirroredGraph = Graph * Graph

    /// ### mirrored_graph_empty
    let mirrored_graph_empty : MirroredGraph = Map.empty, Map.empty

    /// ### link_add'
    let link_add' (abs : Graph) a b: Graph = 
        match Map.tryFind a abs with
        | Some bs -> Map.add a (Set.add b bs) abs
        | None -> Map.add a (Set.singleton b) abs

    /// ### link_add
    let link_add (s : MirroredGraph) a b: MirroredGraph = link_add' (fst s) a b, link_add' (snd s) b a

    /// ### link_remove'
    let link_remove' (abs : Graph) a b = 
        match Map.tryFind a abs with
        | Some bs -> 
            let bs = Set.remove b bs
            if Set.isEmpty bs then Map.remove a abs else Map.add a bs abs
        | None -> abs

    /// ### link_remove
    let link_remove (s : MirroredGraph) a b: MirroredGraph = link_remove' (fst s) a b, link_remove' (snd s) b a

    /// ### links_remove
    let links_remove ((abs,bas as s) : MirroredGraph) a: MirroredGraph = 
        match Map.tryFind a abs with
        | Some bs -> Map.remove a abs, Set.fold (fun bas b -> link_remove' bas b a) bas bs
        | None -> s

    /// ### links_add
    let links_add s a bs = List.fold (fun s b -> link_add s a b) s bs

    /// ### links_replace
    let links_replace (s : MirroredGraph) a bs = links_add (links_remove s a) a bs

    /// ### links_get
    let links_get (abs : Graph) a = Map.tryFind a abs |> Option.defaultValue Set.empty

    /// ### link_exists
    let link_exists ((abs,bas) : MirroredGraph) x = Map.containsKey x abs || Map.containsKey x bas

    /// ### topological_sort_template
    let inline topological_sort_template add bas dirty_nodes =
        let sort_visited = HashSet()
        let rec dfs_rev a = if sort_visited.Add(a) then Seq.iter dfs_rev (links_get bas a); add a
        Seq.iter dfs_rev dirty_nodes
        sort_visited

    /// ### topological_sort'
    // Returns the order end -> mid -> start.
    let topological_sort' bas start_nodes = let sort_order = Queue() in sort_order, topological_sort_template sort_order.Enqueue bas start_nodes

    /// ### topological_sort
    // Returns the order start -> mid -> end.
    let topological_sort bas start_nodes = let sort_order = Stack() in sort_order, topological_sort_template sort_order.Push bas start_nodes

    /// ### circular_nodes
    let circular_nodes ((abs,bas) : MirroredGraph) dirty_nodes =
        let sort_order, sort_visited = topological_sort bas dirty_nodes
        let order = sort_order.ToArray()
        let visited = HashSet()
        let circular_nodes = Dictionary()
        Array.fold (fun i a ->
            let sc = ResizeArray() // This array stores the strongly connected components.
            let rec dfs a = if sort_visited.Contains(a) && visited.Add(a) then Seq.iter dfs (links_get abs a); sc.Add a
            dfs a
            if 1 < sc.Count then 
                sc |> Seq.iter (fun x -> circular_nodes.Add(x,i) |> ignore)
                i+1
            else 
                i
            ) 0 order |> ignore
        order, circular_nodes

    /// ## ServerUtils
    // open System
    open System.IO
    open System.Collections.Generic

    open Microsoft.FSharp.Core

    // open Common

    /// ### ProjectCodeAction
    type ProjectCodeAction = 
        | CreateFile of {|filePath : string|}
        | DeleteFile of {|range: VSCRange; filePath : string|} // The range here includes the postfix operators.
        | RenameFile of {|filePath : string; target : string|}
        | CreateDirectory of {|dirPath : string|}
        | DeleteDirectory of {|range: VSCRange; dirPath : string|} // The range here is for the whole tree, not just the code action activation.
        | RenameDirectory of {|dirPath : string; target : string; validate_as_file : bool|}

    /// ### code_action_execute
    let code_action_execute a =
        try match a with
            | CreateDirectory a -> Directory.CreateDirectory(a.dirPath) |> ignore; Ok null
            | DeleteDirectory a -> Directory.Delete(a.dirPath,true); Ok a.dirPath
            | RenameDirectory a ->
                if a.validate_as_file then
                    match FParsec.CharParsers.run file_verify a.target with
                    | FParsec.CharParsers.ParserResult.Success _ -> Directory.Move(a.dirPath,Path.Combine(a.dirPath,"..",a.target)); Ok a.dirPath
                    | FParsec.CharParsers.ParserResult.Failure(er,_,_) -> Error er
                else
                    Directory.Move(a.dirPath,Path.Combine(a.dirPath,"..",a.target)); Ok a.dirPath
            | CreateFile a ->
                if File.Exists(a.filePath) then Error "File already exists."
                else 
                    Directory.GetParent(a.filePath).Create()
                    File.Create(a.filePath).Dispose()
                    Ok null
            | DeleteFile a -> File.Delete(a.filePath); Ok a.filePath
            | RenameFile a ->
                match FParsec.CharParsers.run file_verify a.target with
                | FParsec.CharParsers.ParserResult.Success _ -> File.Move(a.filePath,Path.Combine(a.filePath,"..",a.target+Path.GetExtension(a.filePath)),false); Ok a.filePath
                | FParsec.CharParsers.ParserResult.Failure(er,_,_) -> Error er
        with e -> Error e.Message

    /// ### RAction
    type RAction = VSCRange * ProjectCodeAction

    /// ### SchemaState
    type SchemaState = { schema : Schema; errors_parse : RString list; errors_modules : RString list; errors_packages : RString list}

    /// ### SchemaEnv
    type SchemaEnv = Map<string,SchemaState>

    /// ### ModuleEnv
    type ModuleEnv = Map<string,ModuleState>

    /// ### ss_empty
    let ss_empty = {
        schema = {moduleDir = None, null; modules = []; packageDir = None, null; packages = []}
        errors_parse = []; errors_modules = []; errors_packages = []
        }

    /// ### ss_from_result
    let ss_from_result = function
        | Ok schema -> {ss_empty with schema = schema}
        | Error ers -> {ss_empty with errors_parse = ers}

    /// ### ss_validate_module
    let ss_validate_module (packages : SchemaEnv) (modules : ModuleEnv) (x : SchemaState) =
        let errors = ResizeArray()
        let rec loop = function
            | FileHierarchy.Directory(_,(r,path),_,l) -> 
                trace Verbose (fun () -> $"ss_validate_module / dir path: {path}") _locals
                if Map.containsKey path packages then errors.Add(r,"Module directory has a package file in it.")
                list l
            | FileHierarchy.File(_,(r,path),_) ->
                let path' = path |> SpiralFileSystem.standardize_path
                trace Verbose (fun () -> $"ss_validate_module / file / path: {path} / path': {path'}") _locals
                if Map.containsKey path' modules = false then errors.Add(r,"Module not loaded.")
        and list l = List.iter loop l
        list x.schema.modules
        Seq.toList errors

    /// ### ss_validate_modules
    let ss_validate_modules (packages : SchemaEnv) modules order = 
        Array.fold (fun s x ->
            match Map.tryFind x s with
            | Some v -> Map.add x {v with errors_modules = ss_validate_module packages modules v} s
            | None -> s
            ) packages order

    /// ### ss_has_error
    let ss_has_error x =
        (List.isEmpty x.errors_parse && List.isEmpty x.errors_modules && List.isEmpty x.errors_packages) = false

    /// ### ss_validate_packages
    let ss_validate_packages (packages : SchemaEnv) (order : string [], socs : Dictionary<string,int>) : SchemaEnv =
        Array.fold (fun s path ->
            match Map.tryFind path s with
            | Some (x : SchemaState) -> 
                let c p = match socs.TryGetValue(p) with true,b -> b | false,_ -> -1
                let is_circular x = x <> -1
                let are_in_same_strong_component a b = is_circular a && is_circular b && a = b
                let ers =
                    let cpath = c path
                    (x.schema.packages, []) ||> List.foldBack (fun {dir=r,p} ers ->
                        let cp = c p
                        if are_in_same_strong_component cpath cp then (r,"Package is circular and loops through the current one.") :: ers
                        elif path = p then (r,"Self referential links are not allowed.") :: ers
                        else
                            match Map.tryFind p s with
                            | Some s' when ss_has_error s' -> (r,"Package has an error.") :: ers
                            | Some _ -> ers
                            | None -> (r,"Package not loaded.") :: ers
                        ) 
                Map.add path {x with errors_packages=ers} s
            | _ -> s
            ) packages order

    /// ### ss_validate
    let ss_validate packages modules (order,socs) =
        let packages = ss_validate_modules packages modules order
        ss_validate_packages packages (order,socs)

    /// ### ResultMap<'a,'b>
    type ResultMap<'a,'b> when 'a : comparison = {ok : Map<'a,'b>; error: Map<'a,'b>}

    /// ### ProjEnvTCResult
    type ProjEnvTCResult = ResultMap<PackageId,ProjStateTC>

    /// ### wdiff_projenvr_sync_schema
    let wdiff_projenvr_sync_schema default_env funs_packages funs_files (ids : Map<string, PackageId>) (packages : SchemaEnv) 
            (state : ResultMap<PackageId,ProjState<'file_input,'file,'package>>) order =
        Array.fold (fun (s : ResultMap<_,_>) x ->
            let x' = x |> SpiralFileSystem.standardize_path
            trace Verbose (fun () -> $"ServerUtils.wdiff_projenvr_sync_schema / x: {x} / x': {x'}") _locals
            match Map.tryFind x' ids with
            | Some pid ->
                match Map.tryFind x' packages with
                | Some schema ->
                    match Map.tryFind pid s.ok, Map.tryFind pid s.error, ss_has_error schema with
                    | Some _, Some _,_ -> failwith "Compiler error: The ok and error maps should be disjoint."
                    | Some x, None, true -> {ok=Map.remove pid s.ok; error=Map.add pid x s.error}
                    | None, Some x, false -> {ok=Map.add pid x s.ok; error=Map.remove pid s.error}
                    | None, None, c -> 
                        let x = wdiff_proj_init default_env funs_packages funs_files pid
                        if c then {s with error=Map.add pid x s.error} else {s with ok=Map.add pid x s.ok}
                    | _ -> s
                | None -> {ok=Map.remove pid s.ok; error=Map.remove pid s.error}
            | None -> s
            ) state order

    /// ### projenv_update_packages
    let projenv_update_packages default_env funs_packages funs_files (ids : Map<string, PackageId>) (packages : SchemaEnv)
            (state : Map<PackageId,ProjState<'a,'b,'state>>)  (dirty_packages : Dictionary<_,_>, order : string []) =
        Array.foldBack (fun x l ->
            let x' = x |> SpiralFileSystem.standardize_path
            trace Verbose (fun () -> $"ServerUtils.projenv_update_packages / x: {x} / x': {x'}") _locals
            match Map.tryFind x' packages with
            | None -> l
            | Some schema when ss_has_error schema -> l
            | Some schema ->
                let pid = ids.[x']
                let packages = schema.schema.packages |> List.map (fun x -> x.name, ids.[snd x.dir])
                match dirty_packages.TryGetValue(x') with
                | true, x -> UpdatePackageModule(pid,packages,x) :: l
                | false, _ -> UpdatePackage(pid,packages) :: l
            ) order []
        |> wdiff_projenv default_env funs_packages funs_files state

    /// ### proj_file_iter_file
    let inline proj_file_iter_file f (files : ProjFiles) =
        let rec loop = function
            | ProjFilesTree.File(module_id,path,_) -> f module_id path
            | ProjFilesTree.Directory(_,_,l) -> list l
        and list l = List.iter loop l
        list files.tree

    /// ### proj_file_get_input
    let proj_file_get_input uids_file (x : ProjFiles) =
        let d = Dictionary(Array.length uids_file)
        proj_file_iter_file (fun mid path -> d.Add(path, Array.get uids_file mid |> fst)) x
        d

    /// ### proj_file_from_schema
    let proj_file_from_schema (x : Schema) : ProjFiles =
        let mutable num_files = 0
        let mutable num_dirs = 0
        let rec loop = function
            | FileHierarchy.File(_,(_,path),name) -> 
                let uid = num_files
                num_files <- num_files + 1
                let path' = path |> SpiralFileSystem.standardize_path
                trace Verbose (fun () -> $"ServerUtils.proj_file_from_schema / path: {path} / path': {path'}") _locals
                ProjFilesTree.File(uid,path',name)
            | FileHierarchy.Directory(_,_,name,l) ->
                let uid = num_dirs
                num_dirs <- num_dirs + 1
                ProjFilesTree.Directory(uid,name,list l)
        and list l = List.map loop l
        let tree = list x.modules
        { tree = tree; num_files = num_files; num_dirs = num_dirs }

    /// ### proj_file_make_input
    let inline proj_file_make_input f (files : ProjFiles) =
        let ar = Array.zeroCreate files.num_files
        proj_file_iter_file (fun mid path -> ar.[mid] <- f mid path) files
        ar

    /// ### dirty_nodes_template
    let inline dirty_nodes_template funs (ids : Map<string, PackageId>) (packages : SchemaEnv) modules
            (state : Map<PackageId,_>) (dirty_packages : string HashSet) =
        let d = Dictionary<string,_ [] * ProjFiles>()
        dirty_packages |> Seq.iter (fun path ->
            let path' = path |> SpiralFileSystem.standardize_path
            trace Verbose (fun () -> $"ServerUtils.dirty_nodes_template / path: {path} / path': {path'}") _locals
            match Map.tryFind path' ids with
            | Some pid ->
                match Map.tryFind pid state with
                | Some x -> 
                    let modules = modules pid
                    let files = proj_file_from_schema packages.[path'].schema
                    let state = 
                        let state = proj_file_get_input x.files.uids_file x.files.files
                        proj_file_make_input (fun mid path ->
                            trace Verbose (fun () -> $"ServerUtils.dirty_nodes_template / proj_file_make_input / path: {path} / path': {path'}") _locals
                            match state.TryGetValue(path) with
                            | true, x -> wdiff_file_update_input funs x (modules mid path)
                            | false, _ -> funs.init (modules mid path)
                            ) files
                    d.Add(path',(state,files))
                | None -> ()
            | None -> ()
            )
        d

    /// ### dirty_nodes_tc
    let dirty_nodes_tc (ids : Map<string, PackageId>) (packages : SchemaEnv) (modules : ModuleEnv)
            (state : Map<PackageId,ProjStateTC>) (dirty_packages : string HashSet) =
        dirty_nodes_template funs_file_tc ids packages (fun pid mid path -> pid, mid, modules.[path].bundler) state dirty_packages

    /// ### dirty_nodes_prepass
    let dirty_nodes_prepass (ids : Map<string, PackageId>) (packages : SchemaEnv) (modules : Map<PackageId,ProjStateTC>)
            (state : Map<PackageId,ProjStatePrepass>) (dirty_packages : string HashSet) =
        let modules pid =
            let x = modules.[pid]
            let state = proj_file_get_input x.files.uids_file x.files.files
            fun (mid : ModuleId) path -> pid, mid, path, state.[path].result
        dirty_nodes_template funs_file_prepass ids packages modules state dirty_packages

    /// ### wdiff_projenvr
    let wdiff_projenvr default_env dirty_nodes funs_proj_package funs_proj_file 
            ids packages modules (state : ResultMap<PackageId,_>) (dirty_packages, order) =
        let state = wdiff_projenvr_sync_schema default_env funs_proj_package funs_proj_file ids packages state order
        let dirty_packages = dirty_nodes ids packages modules state.ok dirty_packages
        {state with ok=projenv_update_packages default_env funs_proj_package funs_proj_file ids packages state.ok (dirty_packages, order)}

    /// ### wdiff_projenvr_tc
    let wdiff_projenvr_tc default_env ids packages modules state (dirty_packages, order) =
        wdiff_projenvr default_env dirty_nodes_tc funs_proj_package_tc funs_proj_file_tc 
            ids packages modules state (dirty_packages, order)

    /// ### wdiff_projenvr_prepass
    let wdiff_projenvr_prepass default_env ids packages modules state (dirty_packages, order) =
        wdiff_projenvr default_env dirty_nodes_prepass funs_proj_package_prepass funs_proj_file_prepass 
            ids packages modules state (dirty_packages, order)

    /// ### LoadResult
    type LoadResult =
        | LoadModule of path: string * ModuleState option
        | LoadPackage of package_dir: string * SchemaState option

    /// ### is_top_down
    open System.Threading.Tasks

    let is_top_down (x : string) = Path.GetExtension x = ".spi"

    /// ### spiproj_suffix
    let spiproj_suffix x = Path.Combine(x,"package.spiproj")

    /// ### loader_package
    let loader_package default_env (packages : SchemaEnv) (modules : ModuleEnv) (pdir, text) =
        let pdir' = pdir |> SpiralFileSystem.standardize_path
        trace Verbose (fun () -> $"ServerUtils.loader_package / pdir: {pdir} / pdir': {pdir'}") _locals
        let pdir = pdir'
        let queue = Queue()
        let load_module modules path =
            match Map.tryFind path modules with
            | Some _ -> ()
            | None ->
                task {
                    if File.Exists path then
                        try let! x = File.ReadAllTextAsync(path)
                            return LoadModule(path,wdiff_module_init_all default_env (is_top_down path) x |> Some)
                        with _ -> return LoadModule(path,None)
                    else return LoadModule(path,None) // Note: We need this case otherwise 'con' might cause the file read to deadlock. https://superuser.com/questions/86999/why-cant-i-name-a-folder-or-file-con-in-windows
                } |> queue.Enqueue

        let schema (pdir,text) = schema (pdir,text) |> fun x -> LoadPackage(pdir,Some (ss_from_result x))
        let load_package_from_disk packages pdir =
            trace Verbose (fun () -> $"ServerUtils.loader_package.load_package_from_disk / pdir: {pdir}") _locals
            task {
                if Directory.Exists pdir then
                    try
                        let! x = File.ReadAllTextAsync(spiproj_suffix pdir)
                        return schema (pdir,x)
                    with _ ->
                        return LoadPackage(pdir,None)
                else return LoadPackage(pdir,None) // Ditto.
            } |> queue.Enqueue
        let load_package_some (pdir,text) =
            trace Verbose (fun () -> $"ServerUtils.loader_package.load_package_some / pdir: {pdir}") _locals
            schema (pdir,text) |> Task.FromResult |> queue.Enqueue
        let load_package_none packages pdir =
            let pdir' = pdir |> SpiralFileSystem.standardize_path
            trace Verbose (fun () -> $"ServerUtils.loader_package.load_package_none / pdir: {pdir} / pdir': {pdir'}") _locals
            let pdir = pdir'
            match Map.tryFind pdir packages with
            | Some _ -> ()
            | None -> load_package_from_disk packages pdir

        let dirty_packages = HashSet()
        let rec invalidate_parent packages (x : DirectoryInfo) =
            if x <> null then
                let x' = x.FullName |> SpiralFileSystem.standardize_path
                // trace Verbose (fun () -> $"""ServerUtils.loader_package.invalidate_parent / x.FullName: {x.FullName |> SpiralSm.replace "\\" "|"} / x': {x'} / packages: %A{packages |> Map.keys} / pdir: {pdir}""") _locals
                let x_ = x
                let x = {| FullName = x' |}
                if Map.containsKey x.FullName packages then dirty_packages.Add(x.FullName) |> ignore
                else invalidate_parent packages x_.Parent

        let mutable packages = packages
        let mutable modules = modules

        match text with
        | Some text -> load_package_some (pdir,text)
        | None ->
            // trace Verbose (fun () -> $"ServerUtils.loader_package / pdir: {pdir}") _locals
            match Map.tryFind pdir packages with
            | Some x -> LoadPackage(pdir,Some x) |> Task.FromResult |> queue.Enqueue
            | None -> load_package_from_disk packages pdir

        while 0 < queue.Count do
            match queue.Dequeue().Result with
            | LoadPackage(pdir,Some x) -> 
                let pdir' = pdir |> SpiralFileSystem.standardize_path
                // trace Verbose (fun () -> $"ServerUtils.loader_package.LoadPackage / pdir: {pdir} / pdir': {pdir'}") _locals
                packages <- Map.add pdir' x packages; dirty_packages.Add(pdir') |> ignore; invalidate_parent packages (Directory.GetParent(pdir'))
                x.schema.packages |> List.iter (fun x -> load_package_none packages (snd x.dir))
                let rec loop = function
                    | FileHierarchy.Directory(_,_,_,l) -> list l
                    | FileHierarchy.File(_,(_,path),_) ->
                        let path' = path |> SpiralFileSystem.standardize_path
                        trace Verbose (fun () -> $"ServerUtils.loader_package.LoadPackage | FileHierarchy.File(_,(_,path),_) / path: {path} / path': {path'}") _locals
                        load_module modules path'
                and list l = List.iter loop l
                list x.schema.modules
            | LoadPackage(pdir,None) -> packages <- Map.remove pdir packages; dirty_packages.Add(pdir) |> ignore; invalidate_parent packages (Directory.GetParent(pdir))
            | LoadModule(mdir,Some x) ->
                let mdir' = mdir |> SpiralFileSystem.standardize_path
                trace Verbose (fun () -> $"ServerUtils.loader_package.LoadModule / mdir: {mdir} / mdir': {mdir'}") _locals
                modules <- Map.add mdir' x modules
            | LoadModule(mdir,None) -> modules <- Map.remove mdir modules
        packages, dirty_packages, modules

    /// ### graph_update
    let graph_update (packages : SchemaEnv) (g : MirroredGraph) (dirty_packages : string HashSet) =
        Seq.fold (fun g x ->
            match Map.tryFind x packages with
            | Some v -> links_replace g x (v.schema.packages |> List.map (fun x -> snd x.dir))
            | None -> links_remove g x
            ) g dirty_packages

    /// ### package_ids_update
    let package_ids_update (packages : SchemaEnv) package_ids (dirty_packages : string HashSet) =
        let adds,removals = dirty_packages |> Seq.toArray |> Array.partition (fun x -> Map.containsKey x packages)
        let adds = adds |> Array.filter (fun x -> Map.containsKey x (fst package_ids) = false) |> Array.mapi (fun i x -> (i,x))
        let package_ids, removed_pids = removals |> Array.fold (fun ((a,b),l as s) x -> match Map.tryFind x a with Some x' -> (Map.remove x a, Map.remove x' b), x' :: l | None -> s) (package_ids,[])
        removed_pids,
        if Array.isEmpty adds then package_ids else
        Map.fold (fun s x _ ->
            Array.mapFold (fun s x -> if s = fst x then (s+1, snd x),s+1 else x,s) x s |> fst
            ) adds (snd package_ids)
        |> Array.fold (fun (a,b) (k,v) -> Map.add v k a, Map.add k v b) package_ids

    /// ### package_ids_remove
    let package_ids_remove (s : ResultMap<PackageId,_>) l =
        List.fold (fun s x -> {ok=Map.remove x s.ok; error=Map.remove x s.error}) s l

    /// ## SignalRSupervisor
    // #r @"../../../../../../../.nuget/packages/microsoft.aspnetcore.app.ref/7.0.11/ref/net7.0/Microsoft.AspNetCore.SignalR.Core.dll"
    // #r @"../../../../../../../.nuget/packages/argu/6.2.4/lib/netstandard2.0/Argu.dll"
    // #r @"../../../../../../../.nuget/packages/microsoft.aspnetcore.http.connections.common/7.0.0/lib/net7.0/Microsoft.AspNetCore.Http.Connections.Common.dll"
    // #r @"../../../../../../../.nuget/packages/microsoft.aspnetcore.http.connections.client/7.0.0/lib/net7.0/Microsoft.AspNetCore.Http.Connections.Client.dll"
    // #r @"../../../../../../../.nuget/packages/microsoft.aspnetcore.signalr.common/7.0.0/lib/net7.0/Microsoft.AspNetCore.SignalR.Common.dll"
    // #r @"../../../../../../../.nuget/packages/microsoft.aspnetcore.signalr.client/7.0.0/lib/net7.0/Microsoft.AspNetCore.SignalR.Client.dll"
    // #r @"../../../../../../../.nuget/packages/microsoft.aspnetcore.signalr.client.core/7.0.0/lib/net7.0/Microsoft.AspNetCore.SignalR.Client.Core.dll"
    // #r @"../../../../../../../.nuget/packages/fsharp.json/0.4.1/lib/netstandard2.0/FSharp.Json.dll"

    // open System
    open System.IO
    open System.Collections.Generic

    open Hopac
    open Hopac.Infixes
    open Hopac.Extensions
    open Hopac.Stream

    // open Common
    open SpiralFileSystem.Operators

    /// ### LocalizedErrors
    type LocalizedErrors = {|uri : string; errors : RString list|}

    /// ### TracedError
    type TracedError = {|trace : string list; message : string|}

    /// ### SupervisorErrorSources
    type SupervisorErrorSources = {
        fatal : string Ch
        tokenizer : LocalizedErrors Ch
        parser : LocalizedErrors Ch
        typer : LocalizedErrors Ch
        package : LocalizedErrors Ch
        traced : TracedError Ch
        }

    /// ### SupervisorReq
    type SupervisorReq =
        | ProjectFileOpen of {|uri : string; spiprojText : string|}
        | ProjectFileChange of {|uri : string; spiprojText : string|}
        | ProjectFileLinks of {|uri : string|} * RString list IVar
        | ProjectCodeActions of {|uri : string|} * RAction list IVar
        | ProjectCodeActionExecute of {|uri : string; action : ProjectCodeAction|} * {|result : string option|} IVar
        | FileOpen of {|uri : string; spiText : string|}
        | FileChange of {|uri : string; spiEdit : SpiEdit|}
        | FileDelete of {|uris : string []|}
        | FileTokenRange of {|uri : string; range : VSCRange|} * int [] IVar
        | HoverAt of {|uri : string; pos : VSCPos|} * string option IVar
        | BuildFile of {|uri : string; backend : string|} * string option IVar

    /// ### SupervisorState
    type SupervisorState = {
        packages : SchemaEnv
        modules : ModuleEnv
        packages_infer : ResultMap<PackageId,ProjStateTC>
        packages_prepass : ResultMap<PackageId,ProjStatePrepass>
        graph : MirroredGraph
        package_ids : Map<string,int> * Map<int,string>
        }

    /// ### proj_validate
    let proj_validate default_env s dirty_packages =
        let order,socs = circular_nodes s.graph dirty_packages
        let packages = ss_validate s.packages s.modules (order,socs)
        let packages_infer = wdiff_projenvr_tc default_env (fst s.package_ids) packages s.modules s.packages_infer (dirty_packages, order)
        order, {s with packages_infer = packages_infer; packages=packages}

    /// ### proj_graph_update
    let proj_graph_update default_env s dirty_packages =
        let removed_pids,package_ids = package_ids_update s.packages s.package_ids dirty_packages
        let packages_infer, packages_prepass = package_ids_remove s.packages_infer removed_pids, package_ids_remove s.packages_prepass removed_pids
        let graph = graph_update s.packages s.graph dirty_packages
        proj_validate default_env {s with graph = graph; package_ids = package_ids; packages_infer = packages_infer; packages_prepass = packages_prepass} dirty_packages

    /// ### proj_open
    let proj_open default_env s (dir, text) =
        let packages,dirty_packages,modules = loader_package default_env s.packages s.modules (dir,text)
        proj_graph_update default_env {s with packages = packages; modules = modules} dirty_packages

    /// ### proj_revalidate_owner
    let proj_revalidate_owner default_env s file =
        let rec loop (x : DirectoryInfo) =
            if x = null then [||], s
            else
                let x' = x.FullName |> SpiralFileSystem.standardize_path
                // trace Verbose (fun () -> $"""Supervisor.proj_revalidate_owner / x.FullName: {x.FullName |> SpiralSm.replace "\\" "|"} / x': {x'}""") _locals
                let x_ = x
                let x = {| FullName = x' |}
                if Map.containsKey x.FullName s.packages then proj_validate default_env s (HashSet [x.FullName])
                elif File.Exists(spiproj_suffix x.FullName) then proj_open default_env s (x.FullName,None)
                else loop x_.Parent
        loop (Directory.GetParent(file))

    /// ### file_delete
    let file_delete default_env s (files : string []) =
        let deleted_modules = HashSet()
        let deleted_packages = HashSet()
        files |> Array.iter (fun k ->
            s.packages |> Map.iter (fun k' _ -> if (spiproj_suffix k').StartsWith(k) then deleted_packages.Add(k') |> ignore)
            s.modules |> Map.iter (fun k' _ -> if k'.StartsWith(k) then deleted_modules.Add(k') |> ignore)
            )
        let modules = Seq.foldBack Map.remove deleted_modules s.modules
        let packages = Seq.foldBack Map.remove deleted_packages s.packages
        let dirty_packages = HashSet(deleted_packages)
        let revalidate_parent (x : string) =
            trace Verbose (fun () -> $"Supervisor.file_delete.revalidate_parent.loop / x.FullName: {x}") _locals
            let rec loop (x : DirectoryInfo) =
                if x <> null then
                    let x' = x.FullName |> SpiralFileSystem.standardize_path
                    let x = DirectoryInfo x'
                    if Map.containsKey x.FullName s.packages then dirty_packages.Add(x.FullName) |> ignore
                    else loop x.Parent
            loop(Directory.GetParent x)
        Seq.iter revalidate_parent deleted_modules; Seq.iter revalidate_parent deleted_packages
        Seq.toArray deleted_modules, proj_graph_update default_env {s with modules = modules; packages = packages} dirty_packages

    /// ### AttentionState
    type AttentionState = {
        modules : string Set * string list
        packages : string Set * string list
        old_packages : SchemaEnv
        supervisor : SupervisorState
        }

    /// ### attention_server
    let attention_server (errors : SupervisorErrorSources) (req : _ Ch) =
        let push path (s,o) = Set.add path s, path :: o
        let add (s,o) l = Array.foldBack (fun x (s,o as z) -> if Set.contains x s then z else Set.add x s, x :: o) l (s,o)
        let update (s : AttentionState) (modules,packages,supervisor) = {modules = add s.modules modules; packages = add s.packages packages; supervisor = supervisor; old_packages = s.supervisor.packages}
        let rec loop (s : AttentionState) =
            let clear uri =
                Hopac.start (Ch.send errors.tokenizer {|uri=uri; errors=[]|})
                Hopac.start (Ch.send errors.parser {|uri=uri; errors=[]|})
                Hopac.start (Ch.send errors.typer {|uri=uri; errors=[]|})
            let send_tokenizer uri x = Hopac.start (Ch.send errors.tokenizer {|uri=uri; errors=x|})
            let clear_parse uri = Hopac.start (Ch.send errors.parser {|uri=uri; errors=[]|})
            let clear_typer uri = Hopac.start (Ch.send errors.typer {|uri=uri; errors=[]|})
            let clear_old_package x = Map.tryFind x s.old_packages |> Option.iter (fun x ->
                let rec loop = function
                    | FileHierarchy.File(_,(_,pdir),_) -> clear (file_uri pdir)
                    | FileHierarchy.Directory(_,_,_,l) -> list l
                and list l = List.iter loop l
                list x.schema.modules
                )

            let inline body uri interrupt ers ers' src next =
                Ch.Try.take req >>= function
                | Some x -> interrupt x
                | None ->
                    if List.isEmpty ers then next ers'
                    else
                        let ers = List.append ers ers'
                        Hopac.start (Ch.send src {|uri=uri; errors=ers|})
                        next ers

            let loop_module (s : AttentionState) mpath (m : ModuleState) =
                let uri = file_uri mpath
                let interrupt x = loop (update {s with modules=push mpath s.modules} x)
                let rec bundler (r : BlockBundleState) ers' = r >>= function
                    | Cons((_,x),rs) -> body uri interrupt x.errors ers' errors.parser (bundler rs)
                    | Nil -> loop s
                send_tokenizer uri m.tokenizer.errors
                clear_parse uri
                clear_typer uri
                bundler m.bundler []

            let rec loop_package (s : AttentionState) pdir = function
                | (mpath,l) :: ls ->
                    let mpath' = mpath |> SpiralFileSystem.standardize_path
                    let uri = file_uri mpath
                    let pdir' = pdir |> SpiralFileSystem.standardize_path
                    trace Verbose (fun () -> $"Supervisor.attention_server.loop.loop_package / mpath: {mpath} / mpath': {mpath'} / uri: {uri} / pdir: {pdir} / pdir': {pdir'}") _locals
                    let interrupt x = loop (update {s with packages=push pdir s.packages} x)
                    let rec typer (r : TypecheckerStateValue Stream) ers' = r >>= function
                        | Cons((_,x,_),rs) -> body uri interrupt x.errors ers' errors.typer (typer rs)
                        | Nil -> loop_package s pdir' ls
                    let rec bundler (r : BlockBundleState) ers' = r >>= function
                        | Cons((_,x),rs) -> body uri interrupt x.errors ers' errors.parser (bundler rs)
                        | Nil -> clear_typer uri; typer l []
                    let m = s.supervisor.modules.[mpath']
                    send_tokenizer uri m.tokenizer.errors
                    clear_parse uri
                    bundler m.bundler []
                | [] -> loop s

            let package s =
                match s.packages with
                | se,x :: xs ->
                    let x' = x |> SpiralFileSystem.standardize_path
                    trace Verbose (fun () -> $"Supervisor.attention_server.loop.package / x: {x} / x': {x'}") _locals
                    let x = x'
                    let s = {s with packages=Set.remove x se,xs}
                    let package_errors =
                        match Map.tryFind x s.supervisor.packages with
                        | Some v -> List.concat [v.errors_parse; v.errors_modules; v.errors_packages]
                        | None -> []
                    Hopac.start (Ch.send errors.package ({|uri=file_uri(spiproj_suffix x); errors=package_errors|}))
                    clear_old_package x
                    match Map.tryFind x (fst s.supervisor.package_ids) with
                    | Some uid ->
                        match Map.tryFind uid s.supervisor.packages_infer.ok with
                        | Some v ->
                            let path_tcvals =
                                let uids_file = v.files.uids_file
                                let rec loop x s =
                                    match x with
                                    | ProjFilesTree.File(mid,path,_) ->
                                        let path' = path |> SpiralFileSystem.standardize_path
                                        trace Verbose (fun () -> $"Supervisor.attention_server.loop | WDiff.File(mid,path,_) / path: {path} / path': {path'}") _locals
                                        (path', (fst uids_file.[mid]).result) :: s
                                    | ProjFilesTree.Directory(_,_,l) -> list l s
                                and list l s = List.foldBack loop l s
                                list v.files.files.tree []
                            loop_package s x path_tcvals
                        | None -> loop s
                    | None -> loop s
                | _, [] -> req >>= (update s >> loop)

            match s.modules with
            | se,x :: xs ->
                let s = {s with modules=Set.remove x se,xs}
                let x' = x |> SpiralFileSystem.standardize_path
                trace Verbose (fun () -> $"Supervisor.attention_server.loop / x: {x} / x': {x'}") _locals
                match Map.tryFind x s.supervisor.modules with
                | Some v ->
                    let codeDir = x |> System.IO.Path.GetDirectoryName
                    let tokensPath = codeDir </> "tokens.json"
                    if tokensPath |> System.IO.File.Exists |> not
                    then loop_module s x v
                    else
                        trace Verbose (fun () -> $"Supervisor.attention_server.loop / tokens found, skipping / x: {x}") _locals
                        package s
                | None -> clear (file_uri x); package s
            | _,[] -> package s

        (req >>= fun (modules,packages,supervisor) ->
            loop {modules = Set.ofArray modules, Array.toList modules; packages = Set.ofArray packages, Array.toList packages; supervisor = supervisor; old_packages = Map.empty}
            )

    /// ### show_position
    let show_position (s : SupervisorState) (x : Range) =
        let line = (fst x.range).line
        let col = (fst x.range).character
        let er_code = s.modules.[x.path].tokenizer.lines_text.[line]
        StringBuilder()
            .AppendLine(sprintf "Error trace on line: %i, column: %i in module: %s ." (line+1) (col+1) x.path)
            .AppendLine(er_code)
            .Append(' ',col)
            .AppendLine("^")
            .ToString()

    /// ### show_trace
    let show_trace s (x : Trace) (msg : string) =
        let rec loop (l : Trace) = function
            | (x : Range) :: xs ->
                match l with
                | x' :: _ when x.path = x'.path && fst x.range = fst x'.range -> loop l xs
                | _ -> loop (x :: l) xs
            | _ -> l
        List.map (show_position s) (loop [] x), msg

    /// ### BuildResult
    type BuildResult =
        | BuildOk of {|code: string; file_extension : string|} list
        | BuildErrorTrace of string list * string
        | BuildFatalError of string
        | BuildSkip

    /// ### workspaceRoot
    let workspaceRoot = SpiralFileSystem.get_workspace_root ()

    /// ### targetDir
    let targetDir = workspaceRoot </> "target/spiral_Eval"

    /// ### traceDir
    let traceDir = targetDir </> "supervisor_trace"

    /// ### dir
    let dir uri =
        let result = System.IO.FileInfo(System.Uri(uri).LocalPath).Directory.FullName
        let result' = result |> SpiralFileSystem.standardize_path
        trace Verbose (fun () -> $"Supervisor.dir / uri: {uri} / result: {result} / result': {result'}") _locals
        result'

    /// ### file
    let file uri =
        let result =
            try
                System.IO.FileInfo(System.Uri(uri).LocalPath).FullName
            with ex ->
                trace Verbose (fun () -> $"Supervisor.file / uri: {uri} / ex: %A{ex}") _locals
                uri
        let result' = result |> SpiralFileSystem.standardize_path
        // let result = result |> SpiralSm.replace "\\" "|"
        // trace Verbose (fun () -> $"Supervisor.file / uri: {uri} / result: {result} / result': {result'}") _locals
        result'

    /// ### supervisor_server
    let supervisor_server (default_env : DefaultEnv) atten (errors : SupervisorErrorSources) req =
        let fatal x = Hopac.start (Ch.send errors.fatal x)
        let handle_packages (dirty_packages,s) = Hopac.start (Ch.send atten ([||],dirty_packages,s)); s
        let handle_file_packages file (dirty_packages,s) = Hopac.start (Ch.send atten ([|file|],dirty_packages,s)); s
        let handle_files_packages (dirty_files,(dirty_packages,s)) = Hopac.start (Ch.send atten (dirty_files,dirty_packages,s)); s
        let loop (s : SupervisorState) = req >>- function
            | ProjectFileChange x | ProjectFileOpen x -> proj_open default_env s (dir x.uri,Some x.spiprojText) |> handle_packages
            | FileOpen x ->
                let file = file x.uri
                // trace Verbose (fun () -> $"Supervisor.supervisor_server.loop.FileOpen / x: %A{x} / file: {file}") _locals
                match Map.tryFind file s.modules with
                | Some m -> wdiff_module_all default_env m x.spiText
                | None -> wdiff_module_init_all default_env (is_top_down file) x.spiText
                |> fun v -> proj_revalidate_owner default_env {s with modules = Map.add file v s.modules} file
                |> handle_file_packages file
            | FileChange x ->
                let file = file x.uri
                trace Verbose (fun () -> $"Supervisor.supervisor_server.loop.FileChange / x: %A{x} / file: {file}") _locals
                match Map.tryFind file s.modules with
                | None -> fatal "It is not possible to apply a change to a file that is not present in the environment. Try reopening it in the editor."; s
                | Some m ->
                    match wdiff_module_edit default_env m x.spiEdit with
                    | Ok v -> proj_revalidate_owner default_env {s with modules = Map.add file v s.modules} file |> handle_file_packages file
                    | Error er -> fatal er; s
            | FileDelete x ->
                trace Verbose (fun () -> $"Supervisor.supervisor_server.loop.FileDelete / x: {x}") _locals
                file_delete default_env s (Array.map file x.uris) |> handle_files_packages
            | ProjectFileLinks(x,res) ->
                let l =
                    match Map.tryFind (dir x.uri) s.packages with
                    | None -> []
                    | Some x ->
                        let mutable l = []
                        x.schema.packages |> List.iter (fun x ->
                            let r,dir = x.dir
                            trace Verbose (fun () -> $"Supervisor.supervisor_server.ProjectFileLinks / x.schema.packages |> List.iter / dir: {dir}") _locals
                            if Map.containsKey dir s.packages then l <- (r,file_uri (spiproj_suffix dir)) :: l
                            )
                        let rec loop = function
                            | FileHierarchy.Directory(_,_,_,l) -> list l
                            | FileHierarchy.File(_,(r,path),_) ->
                                trace Verbose (fun () -> $"Supervisor.supervisor_server.ProjectFileLinks.loop | SpiProj.FileHierarchy.File(_,(r,path),_) / path: {path}") _locals
                                if Map.containsKey path s.modules then l <- (r,file_uri path) :: l
                        and list l = List.iter loop l
                        list x.schema.modules
                        l
                Hopac.start (IVar.fill res l)
                s
            | ProjectCodeActions(x,res) ->
                let z =
                    match Map.tryFind (dir x.uri) s.packages with
                    | None -> []
                    | Some x ->
                        let mutable z = []
                        let actions_dir (r,path) =
                            match r with
                            | None -> ()
                            | Some r ->
                                if Directory.Exists(path) then
                                    z <- (r,RenameDirectory {|dirPath=path; target=null; validate_as_file=false|}) :: (r,DeleteDirectory {|dirPath=path; range=r|}) :: z
                                else
                                    z <- (r,CreateDirectory {|dirPath=path|}) :: z
                        actions_dir x.schema.moduleDir
                        actions_dir x.schema.packageDir

                        let rec actions_module = function
                            | FileHierarchy.Directory(r',(r,path),_,l) ->
                                trace Verbose (fun () -> $"Supervisor.supervisor_server.ProjectCodeActions.actions_module | SpiProj.FileHierarchy.Directory(r',(r,path),_,l) / path: {path}") _locals
                                if Directory.Exists(path) then
                                    z <- (r,RenameDirectory {|dirPath=path; target=null; validate_as_file=true|}) :: (r,DeleteDirectory {|dirPath=path; range=r'|}) :: z
                                else
                                    z <- (r,CreateDirectory {|dirPath=path|}) :: z
                                actions_modules l
                            | FileHierarchy.File(r',(r,path),_) ->
                                trace Verbose (fun () -> $"Supervisor.supervisor_server.ProjectCodeActions.actions_module | SpiProj.FileHierarchy.File(r',(r,path),_) / path: {path}") _locals
                                if Map.containsKey path s.modules then
                                    z <- (r,RenameFile {|filePath=path; target=null|}) :: (r,DeleteFile {|range=r'; filePath=path|}) :: z
                                else
                                    z <- (r,CreateFile {|filePath=path|}) :: z
                        and actions_modules l = List.iter actions_module l
                        actions_modules x.schema.modules
                        z
                Hopac.start (IVar.fill res z)
                s
            | ProjectCodeActionExecute(x,res) ->
                let error, s =
                    match code_action_execute x.action with
                    | Error x -> Some x, s
                    | Ok null -> None, proj_open default_env s (dir x.uri,None) |> handle_packages
                    | Ok path -> None, file_delete default_env s [|path|] |> handle_files_packages
                Hopac.start (IVar.fill res {|result=error|})
                s
            | FileTokenRange(x, res) ->
                let v =
                    match Map.tryFind (file x.uri) s.modules with
                    | Some v -> Some v
                    | None when x.uri |> SpiralSm.ends_with ".dib" ->
                        x.uri
                        |> SpiralSm.replace "file:///" ""
                        |> File.ReadAllText
                        |> wdiff_module_init_all default_env (is_top_down x.uri)
                        |> Some
                    | None -> None

                match v with
                | Some v ->
                    Hopac.start (semantic_tokens v.parser >>= (vscode_tokens x.range >> IVar.fill res))
                | None ->
                    if x.uri |> SpiralSm.starts_with "vscode-notebook-cell" |> not then
                        trace Debug
                            (fun () -> $"Supervisor.supervisor_server.FileTokenRange")
                            (fun () -> $"module=None / x.uri: {x.uri} / {_locals ()}")

                    Hopac.start (IVar.fill res [||])
                s
            | HoverAt(x,res) ->
                let file = file x.uri
                let pos = x.pos
                let _locals () = $"x: %A{x} / file: {file} / res: %A{res}"
                trace Verbose (fun () -> $"Supervisor.supervisor_server.HoverAt") _locals
                let go_hover x =
                    match x with
                    | None -> None
                    | Some (x : InferResult) ->
                        x.hovers |> Array.tryPick (fun ((a,b),r) ->
                            if pos.line = a.line && (a.character <= pos.character && pos.character < b.character) then Some r else None
                            )
                    |> (fun x ->
                        let _locals () = $"x: %A{x}"
                        trace Verbose (fun () -> $"Supervisor.supervisor_server.HoverAt.go_hover") _locals
                        x
                    )
                    |> IVar.fill res
                let go_block (x : TypecheckerState) =
                    let rec loop s (x : TypecheckerStateValue Stream) =
                        x >>= function
                        | Nil -> go_hover s
                        | Cons((_,x,_),b) ->
                            let _locals () = $"b: {b}"
                            trace Verbose (fun () -> $"Supervisor.supervisor_server.HoverAt.go_block.loop Cons") _locals
                            if x.offset <= pos.line then loop (Some x) b
                            // If the block is over the offset that means the previous one must be the right choice.
                            else go_hover s
                    Hopac.start (loop None x.result)
                let rec go_file uids_file trees =
                    let rec loop = function
                        | ProjFilesTree.File(uid,file',_) -> if file = file' then go_block (Array.get uids_file uid |> fst); true else false
                        | ProjFilesTree.Directory(_,_,l) -> list l
                    and list l = List.exists loop l
                    list trees
                let rec go_parent (x : DirectoryInfo) =
                    trace Verbose (fun () -> $"Supervisor.supervisor_server.HoverAt.go_parent / x: %A{x}") _locals
                    if x = null then false
                    else
                        let path = x.FullName |> SpiralFileSystem.standardize_path
                        if Map.containsKey path s.packages then
                            let pid = (fst s.package_ids).[path]
                            match Map.tryFind pid s.packages_infer.ok with
                            | None -> false
                            | Some x -> go_file x.files.uids_file x.files.files.tree
                        else
                            go_parent x.Parent
                if go_parent (Directory.GetParent(file)) = false then Hopac.start (IVar.fill res None)
                s
            | BuildFile (x, res) ->
                let backend = x.backend
                let file = file x.uri
                let _locals () = $"x: %A{x} / file: {file}"
                trace Verbose (fun () -> $"Supervisor.supervisor_server.BuildFile") _locals
                let handle_build_result = function
                    | BuildOk l ->
                        Job.fromAsync (async {
                            for x in l do
                                let file = Path.ChangeExtension(file,null) // null removes the extension from path.
                                do! System.IO.File.WriteAllTextAsync(file + x.file_extension, x.code) |> Async.AwaitTask
                        })
                        |> Hopac.start
                        l
                        |> List.map (fun x -> x.code)
                        |> String.concat "\n"
                        |> Some
                        |> IVar.fill res
                    | BuildFatalError x as x' ->
                        trace Info (fun () -> $"Supervisor.supervisor_server.BuildFile.handle_build_result / BuildFatalError x: %A{x}") _locals
                        Hopac.start (Ch.send errors.fatal x)
                        IVar.fill res None
                    | BuildErrorTrace(a,b) as x' ->
                        trace Info (fun () -> $"Supervisor.supervisor_server.BuildFile.handle_build_result / BuildErrorTrace x': %A{x'}") _locals
                        Hopac.start (Ch.send errors.traced {|trace=a; message=b|})
                        IVar.fill res None
                    | BuildSkip ->
                        trace Info (fun () -> $"Supervisor.supervisor_server.BuildFile.handle_build_result.BuildSkip") _locals
                        IVar.fill res None
                let file_build (s : SupervisorState) mid (tc : ProjStateTC, prepass : ProjStatePrepass) =
                    trace Verbose (fun () -> $"""Supervisor.supervisor_server.BuildFile.file_build / modules: %A{s.modules.Keys |> SpiralSm.concat ", "} / packages: %A{s.packages.Keys |> SpiralSm.concat ", "} / package_ids: %A{s.package_ids |> fst |> fun x -> x.Keys |> SpiralSm.concat ", "}""") _locals
                    let a,b = tc.files.uids_file.[mid]
                    let x,_x = prepass.files.uids_file.[mid]
                    Hopac.start (a.state >>= fun (has_error',_) ->
                        b >>= fun (has_error,_) ->
                        if has_error || has_error' then fatal $"File {Path.GetFileNameWithoutExtension file} has a type error somewhere in its path."; Job.unit() else
                        Stream.foldFun (fun _ (_,_,env) -> env) prepassTop_env_empty x.result >>= fun env ->
                        let body() =
                            match Map.tryFind "main" env.term with
                            | Some main ->
                                let prototypes_instances = Dictionary(env.prototypes_instances)
                                let nominals = 
                                    let t = HashConsTable()
                                    let d = Dictionary()
                                    env.nominals |> Map.iter (fun k v -> d.Add(k, t.Add {|v with id=k|}))
                                    d
                                try 
                                    let inline build_many codegen backend =
                                        let (a,_),b = peval {prototypes_instances=prototypes_instances; nominals=nominals; backend=backend} main
                                        BuildOk (codegen file b a)
                                    let build codegen backend file_extension =
                                        build_many (fun file b a -> [{|code = codegen b a; file_extension = file_extension|}]) backend
                                    match backend with
                                    | "Gleam" -> build codegenGleam "Gleam" ".gleam"
                                    | "Fsharp" -> build codegenFsharp "Fsharp" ".fsx"
                                    | "C" -> build CodegenC.codegenC "C" ".c"
                                    | "Python + Cuda" -> build_many (CodegenPython.codegen default_env) "Python"
                                    | "Cpp + Cuda" -> build_many (CodegenCpp.codegen default_env) "Cpp"

                                    | "Cuda C++" -> BuildFatalError "The host C++ backend originally made for FPGAs, and then ported to Cuda has been removed in v2.10.0 of Spiral. Please use an earlier version to access it." // Date: 5/8/2024
                                    | "Python" -> BuildFatalError "The prototype Python backend has been replaced by the Python + Cuda one in v2.5.0 of Spiral. Please use an earlier version to access it." // Date: 11/3/2023
                                    | "UPMEM: Python + C" -> BuildFatalError "The UPMEM Python + C backend has been replaced by the Python + Cuda one in v2.5.0 of Spiral. Please use an earlier version to access it." // Date: 11/3/2023
                                    | "HLS C++" -> BuildFatalError "The HLS C++ backend has been replaced by the Cuda one in v2.5.0 of Spiral. Please use an earlier version to access it." // Date: 10/17/2023
                                    | "Cython*" | "Cython" -> BuildFatalError "The Cython backend has been replaced by the Python one in v2.3.1 of Spiral. Please use an earlier version to access it." // Date: 12/27/2022
                                    | _ -> BuildFatalError $"Cannot recognize the backend: {backend}"
                                with
                                    | :? PartEvalTypeError as e -> BuildErrorTrace(show_trace s e.Data0 e.Data1)
                                    | :? CodegenError as e -> BuildFatalError(e.Data1)
                                    | :? CodegenErrorWithPos as e -> BuildErrorTrace(show_trace s e.Data0 e.Data1)
                                    | ex ->
                                        if System.IO.Directory.Exists traceDir then
                                            let guid = System.DateTime.Now |> SpiralDateTime.new_guid_from_date_time
                                            let trace_file = traceDir </> $"{guid}_error.json"
                                            async {
                                                try
                                                    do! $"{ex}" |> SpiralFileSystem.write_all_text_async trace_file
                                                with ex ->
                                                    trace Critical (fun () -> $"Supervisor.supervisor_server.BuildFile.file_build / ex: {ex |> SpiralSm.format_exception}") _locals
                                            }
                                            |> Async.Start
                                        trace Critical (fun () -> $"Supervisor.supervisor_server.BuildFile.file_build / ex: %A{ex}") _locals
                                        BuildFatalError(ex.Message)
                            | None -> BuildFatalError $"Cannot find `main` in file {Path.GetFileNameWithoutExtension file}."

                        // The partial evaluator is using too much stack space, so as a temporary fix, I am running it on a separate thread with much more of it.
                        let result = IVar()
                        let thread = new System.Threading.Thread(System.Threading.ThreadStart(body >> IVar.fill result >> Hopac.start), 1 <<< 28) // Stack space = 2 ** 28 = 256mb.
                        thread.Start()
                        result >>= handle_build_result
                        )
                let file_find (s : SupervisorState) pdir =
                    trace Verbose (fun () -> $"Supervisor.supervisor_server.BuildFile.file_find / pdir: {pdir}") _locals
                    let uid = (fst s.package_ids).[pdir]
                    match Map.tryFind uid s.packages_infer.ok, Map.tryFind uid s.packages_prepass.ok with
                    | Some a, Some b ->
                        let rec loop = function
                            | ProjFilesTree.Directory(_,_,l) -> list l
                            | ProjFilesTree.File(mid,path,_) ->
                                trace Verbose (fun () -> $"Supervisor.supervisor_server.BuildFile.file_find.loop | File(mid,path,_) / path: {path}") _locals
                                if file = path then file_build s mid (a, b); true else false
                        and list l = List.exists loop l
                        if list b.files.files.tree = false then fatal $"File {Path.GetFileNameWithoutExtension file} cannot be found in the project {spiproj_suffix pdir}"

                        s
                    | None, None -> fatal $"Owner of file {Path.GetFileNameWithoutExtension file} has an error. Location: {spiproj_suffix pdir}"; s
                    | _ -> failwith "Compiler error: The project status should be the same in both infer and prepass."
                let update_owner pdir =
                    let order,dirty_packages = topological_sort' (fst s.graph) [pdir]
                    let packages_prepass = wdiff_projenvr_prepass default_env (fst s.package_ids) s.packages s.packages_infer.ok s.packages_prepass (dirty_packages, order.ToArray())
                    file_find {s with packages_prepass = packages_prepass} pdir
                let rec find_owner (x : DirectoryInfo) =
                    if x = null then fatal $"Cannot find the package file of {file}"; s
                    else
                        let x' = x.FullName |> SpiralFileSystem.standardize_path
                        trace Verbose (fun () -> $"""Supervisor.supervisor_server.BuildFile.find_owner / x.FullName: {x.FullName |> SpiralSm.replace "\\" "|"} / x': {x'}""") _locals
                        let x_ = x
                        let x = {| FullName = x' |}
                        if Map.containsKey x.FullName s.packages then update_owner x.FullName
                        else find_owner x_.Parent
                find_owner (Directory.GetParent(file))

        Job.iterateServer {
            packages = Map.empty
            modules = Map.empty
            packages_infer = {ok=Map.empty; error=Map.empty}
            packages_prepass = {ok=Map.empty; error=Map.empty}
            graph = mirrored_graph_empty
            package_ids = Map.empty, Map.empty
            } loop

    /// ### ClientReq
    type ClientReq =
        | ProjectFileOpen of {|uri : string; spiprojText : string|}
        | ProjectFileChange of {|uri : string; spiprojText : string|}
        | ProjectFileLinks of {|uri : string|}
        | ProjectCodeActionExecute of {|uri : string; action : ProjectCodeAction|}
        | ProjectCodeActions of {|uri : string|}
        | FileOpen of {|uri : string; spiText : string|}
        | FileChange of {|uri : string; spiEdit : SpiEdit|}
        | FileDelete of {|uris : string []|} // Also works for project files and directories.
        | FileTokenRange of {|uri : string; range : VSCRange|}
        | HoverAt of {|uri : string; pos : VSCPos|}
        | BuildFile of {|uri : string; backend : string|}
        | Ping of bool
        | Exit of bool

    /// ### ClientErrorsRes
    type ClientErrorsRes =
        | FatalError of string
        | TracedError of TracedError
        | PackageErrors of {|uri : string; errors : RString list|}
        | TokenizerErrors of {|uri : string; errors : RString list|}
        | ParserErrors of {|uri : string; errors : RString list|}
        | TypeErrors of {|uri : string; errors : RString list|}

    /// ### Supervisor
    type Supervisor = {
        supervisor_ch : SupervisorReq Ch
        }

    /// ## new_server
    // #!import ../../../polyglot/apps/builder/Builder.fs
    // #!import ../../../polyglot/apps/spiral/Supervisor.fs

#if _LINUX
#else
#endif

#if _LINUX
#else
#endif

#if _LINUX
#else
#endif

#if _LINUX
#else
#endif

#if _LINUX
#else
#endif

#if _LINUX
#else
#endif

#if _LINUX
#else
#endif

#if _LINUX
#else
#endif

#if _LINUX
#else
#endif

    open Hopac
    open Hopac.Infixes
    // open Common

    let new_server () =
        let event = Event<ClientErrorsRes> ()
        // let disposable' = connection.On<string> ("ServerToClientMsg", event.Trigger)
        let stream =
            FSharp.Control.AsyncSeq.unfoldAsync
                (fun () -> async {
                    let! msg = event.Publish |> Async.AwaitEvent
                    return Some (msg, ())
                })
                ()

        let error_ch_create msg =
            let x = Ch()
            Hopac.server (Job.forever (Ch.take x >>= (
                msg >> fun (x : ClientErrorsRes) ->
                    Hopac.Job.awaitUnitTask (
                        task {
                            event.Trigger x
                            trace Verbose (fun () -> $"spiral_compiler.new_server / error_ch_create / x: %A{x}") (fun () -> "")
                            ()
                        }
                        |> (fun (x : System.Threading.Tasks.Task<unit>) -> x :> System.Threading.Tasks.Task)
                    )
            )))
            x

        let errors : SupervisorErrorSources = {
            fatal = error_ch_create FatalError
            package = error_ch_create PackageErrors
            tokenizer = error_ch_create TokenizerErrors
            parser = error_ch_create ParserErrors
            typer = error_ch_create TypeErrors
            traced = error_ch_create TracedError
            }
        let supervisor = Ch()
        let atten = Ch()

        do Hopac.server (attention_server errors atten)

        let args = [| "--port"; "0" |]
        let env = startupParse args
        do Hopac.start (supervisor_server env atten errors supervisor)

        let job_null job =
            job
            |> Hopac.start
            task { return null }
        let serialize (x : obj) =
            match x with
            | null -> null
            | :? Option<string> as x -> x.Value
            | _ -> FSharp.Json.Json.serialize x
        let job_val job =
            let res = IVar()
            let job' =
                job res
            Hopac.queueAsTask (job' >>=. IVar.read res >>- serialize)
        {|
            job_null = job_null
            job_val = job_val
            errors = stream
            supervisor = supervisor
        |}

    /// ## getParentProcessId
    let getParentProcessId () =
        if SpiralPlatform.is_windows () |> not
        then 0u
        else
            let pid = System.Diagnostics.Process.GetCurrentProcess().Id
            let query = $"SELECT ParentProcessId FROM Win32_Process WHERE ProcessId = {pid}"
            use searcher = new System.Management.ManagementObjectSearcher (query)
            use results = searcher.Get ()
            let data = results |> Seq.cast<System.Management.ManagementObject>
            if data |> Seq.isEmpty
            then 0u
            else data |> Seq.head |> (fun mo -> mo.["ParentProcessId"] :?> uint32)

    /// ## assemblyName
    let assemblyName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name

    /// ## startParentWatcher
    let inline startParentWatcher () =
        if [ "dotnet-repl" ] |> List.contains assemblyName |> not then
            let parentAsyncChild = async {
                let parentProcessId = getParentProcessId ()
                trace Verbose
                    (fun () -> "spiral_compiler.startParentWatcher")
                    (fun () -> $"parentProcessId: {parentProcessId} / {_locals ()}")

                if parentProcessId > 0u then
                    let parentProcess = parentProcessId |> int |> System.Diagnostics.Process.GetProcessById
                    do! parentProcess.WaitForExitAsync () |> Async.AwaitTask
                    trace Debug
                        (fun () -> "spiral_compiler.startParentWatcher / Parent process has exited. Performing cleanup...")
                        (fun () -> $"{_locals ()}")
                    System.Threading.Thread.Sleep 1000
                    System.Environment.Exit 1
            }

            parentAsyncChild |> Async.Start

    /// ## SpiralHub
    // open System
    open System.IO
    open System.Collections.Generic

    open Hopac
    open Hopac.Infixes
    open Hopac.Extensions
    open Hopac.Stream

    // open Common
    open SpiralFileSystem.Operators

    open Microsoft.AspNetCore.SignalR
    open Microsoft.AspNetCore.SignalR.Client

    type SpiralHub(supervisor : Supervisor) =
        inherit Hub()

        member _.ClientToServerMsg (x : string) =
            let job_null job = Hopac.start job; task { return null }

            let serialize (x : obj) =
                match x with
                | null -> null
                | :? Option<string> as x -> x.Value
                | _ -> FSharp.Json.Json.serialize x

            let job_val job = let res = IVar() in Hopac.queueAsTask (job res >>=. IVar.read res >>- serialize)
            let supervisor = supervisor.supervisor_ch

            let client_req = FSharp.Json.Json.deserialize x

            if Directory.Exists traceDir then
                match client_req with
                | Ping _ -> ()
                | _ ->
                    let req_name = client_req.GetType().Name
                    let guid = System.DateTime.Now |> SpiralDateTime.new_guid_from_date_time
                    let trace_file = traceDir </> $"{guid}_{req_name}.json"

                    async {
                        do! Async.Sleep 500
                        try
                            do! x |> SpiralFileSystem.write_all_text_async trace_file
                        with ex ->
                            trace Critical (fun () -> $"SpiralHub.ClientToServerMsg / ex: {ex |> SpiralSm.format_exception}") _locals
                    }
                    |> Async.Start

            match client_req with
            | ProjectFileOpen x -> job_null (supervisor *<+ SupervisorReq.ProjectFileOpen x)
            | ProjectFileChange x -> job_null (supervisor *<+ SupervisorReq.ProjectFileChange x)
            | ProjectCodeActionExecute x -> job_val (fun res -> supervisor *<+ SupervisorReq.ProjectCodeActionExecute(x,res))
            | ProjectFileLinks x -> job_val (fun res -> supervisor *<+ SupervisorReq.ProjectFileLinks(x,res))
            | ProjectCodeActions x -> job_val (fun res -> supervisor *<+ SupervisorReq.ProjectCodeActions(x,res))
            | FileOpen x -> job_null (supervisor *<+ SupervisorReq.FileOpen x)
            | FileChange x -> job_null (supervisor *<+ SupervisorReq.FileChange x)
            | FileDelete x -> job_null (supervisor *<+ SupervisorReq.FileDelete x)
            | FileTokenRange x -> job_val (fun res -> supervisor *<+ SupervisorReq.FileTokenRange(x,res))
            | HoverAt x -> job_val (fun res -> supervisor *<+ SupervisorReq.HoverAt(x,res))
            | BuildFile x -> job_val (fun res -> supervisor *<+ SupervisorReq.BuildFile(x,res))
            | Ping _ -> task { return null }
            | Exit _ ->
                async {
                    trace Debug (fun () -> "Supervisor.SpiralHub.ClientToServerMsg / exiting...") _locals
                    async {
                        do! Async.Sleep 300
                        System.Diagnostics.Process.GetCurrentProcess().Kill ()
                    }
                    |> Async.Start
                    return null
                }
                |> Async.StartAsTask

    /// ## main
    open Microsoft.AspNetCore.Builder
    open Microsoft.AspNetCore.Hosting
    open Microsoft.Extensions.DependencyInjection
    open Microsoft.Extensions.Logging

    let main args =
        SpiralTrace.TraceLevel.US0_1 |> set_trace_level
        // Scheduler.Global.setCreate { Scheduler.Create.Def with MaxStackSize = 1024 * 8192 |> Some }

        let env = startupParse args

        let uri_server = $"http://localhost:{env.port}"

        printfn "Server bound to: %s" uri_server
        trace Debug (fun () -> $"pwd: {System.Environment.CurrentDirectory}") _locals
        let dllPath = System.Reflection.Assembly.GetExecutingAssembly().Location |> System.IO.Path.GetDirectoryName
        trace Debug (fun () -> $"dllPath: {dllPath}") _locals
        trace Debug (fun () -> $"targetDir: {targetDir}") _locals
        let builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder()
        builder.Logging.SetMinimumLevel LogLevel.Warning |> ignore
        builder.Services
            .AddCors()
            .AddSignalR(fun x -> 
                x.MaximumReceiveMessageSize <- 1 <<< 20 // 1mb
                x.EnableDetailedErrors <- true
                ) |> ignore

        builder.Services
            .AddSingleton<Supervisor>(fun s ->
                let hub = s.GetService<IHubContext<SpiralHub>>()
                let broadcast x =
                    hub.Clients.All.SendCoreAsync("ServerToClientMsg",[|FSharp.Json.Json.serialize x|])

                let server = new_server ()

                server.errors
                |> FSharp.Control.AsyncSeq.mapAsync (fun x ->
                    broadcast x |> Async.AwaitTask
                )
                |> FSharp.Control.AsyncSeq.iterAsyncParallel (fun x -> async { () })
                |> Async.StartChild
                |> Async.RunSynchronously
                |> ignore

                {supervisor_ch=server.supervisor}
                ) |> ignore
        builder.WebHost.UseUrls [|uri_server|] |> ignore
        builder.Logging.SetMinimumLevel(LogLevel.Warning) |> ignore

        let app = builder.Build()
        app.UseCors(fun x ->
            x.SetIsOriginAllowed(fun _ -> true)
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials() |> ignore
            ) |> ignore
        app.MapHub<SpiralHub> "" |> ignore

        // use _ = Eval.startTokenRangeWatcher ()
        startParentWatcher ()
        // use _ = Eval.startCommandsWatcher uri_server

        printfn $"Starting the Spiral Server. It is bound to: {uri_server}"
        app.Run()
        0
