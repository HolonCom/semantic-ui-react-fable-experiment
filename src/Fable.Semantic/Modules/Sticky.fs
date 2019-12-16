namespace Semantic.Modules.Api


open Fable.React
open Fable.React.Props
open Fable.Core
[<RequireQualifiedAccess>]
module Sticky =
  type Options =
  | Active of bool
  | As of string
  | BottomOffset of int
  | ClassName of string
  | Context of obj
  | Offset of int
  | OnBottom of ( Browser.Types.MouseEvent -> obj -> unit)
  | OnSick of (Browser.Types.MouseEvent -> obj -> unit)
  | OnTop of (Browser.Types.MouseEvent -> obj -> unit)
  | OnUnstick of (Browser.Types.MouseEvent -> obj -> unit)
  | Pushing of bool
  | ScrollContext of obj
  | Props of IHTMLProp list
  with interface IHTMLProp

  let sticky (props: Options list) = 
    let p = props |> List.fold ( fun s x -> match x with 
                                                | Props x -> s @ x 
                                                | a -> (a :> IHTMLProp ) :: s  ) []
    ofImport "Sticky" "semantic-ui-react" (JsInterop.keyValueList CaseRules.LowerFirst p)
