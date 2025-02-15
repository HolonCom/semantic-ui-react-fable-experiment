namespace Semantic.Elements.Api
open Fable.Core
open Fable.React

[<RequireQualifiedAccess>]
module Header = 
  module Content =
    type Options = 
    | As of string
    | ClassName of string
    ///Other React props
    | Props of Fable.React.Props.IHTMLProp list
    with interface Fable.React.Props.IHTMLProp

  module Subheader =
    type Options =
    | As of string
    | ClassName of string
    ///Other React props
    | Props of Fable.React.Props.IHTMLProp list
    with interface Fable.React.Props.IHTMLProp

  [<StringEnum>]
  type Attached = | Top | Bottom
  [<StringEnum>]
  type Size = Tiny | Small | Medium | Large | Huge
  type Options = 
  | As of string
  | IsAttached of bool
  | Attached of Attached
  | Block of bool
  | ClassName of bool
  | Color of Semantic.Color
  | Disabled of bool
  | Dividing of bool
  | Floated of bool
  | [<CompiledNameAttribute "icon">]IsIcon of bool
  | Icon of Semantic.Elements.Icons.IIcon
  | Inverted of bool
  | Size of Size
  | Sub of bool
  | TextAlign of Semantic.TextAlignments
  ///Other React props
  | Props of Fable.React.Props.IHTMLProp list
    with interface Fable.React.Props.IHTMLProp
  
  let header (props: Options list)  =
        let p = props |> List.fold ( fun s x -> match x with 
                                                | Props x -> s @ x 
                                                | a -> (a :> Fable.React.Props.IHTMLProp ) :: s  ) [] 
        ofImport "Header" "semantic-ui-react" (JsInterop.keyValueList CaseRules.LowerFirst p)
  let content (props : Content.Options list) =
        let p = props |> List.fold ( fun s x -> match x with 
                                                | Content.Props x -> s @ x 
                                                | a -> (a :> Fable.React.Props.IHTMLProp ) :: s  ) [] 
        ofImport "Header.Content" "semantic-ui-react" (JsInterop.keyValueList CaseRules.LowerFirst p)

  let subheader (props : Subheader.Options list) =
        let p = props |> List.fold ( fun s x -> match x with 
                                                | Subheader.Props x -> s @ x 
                                                | a -> (a :> Fable.React.Props.IHTMLProp ) :: s  ) [] 
        ofImport "Header.Subheader" "semantic-ui-react" (JsInterop.keyValueList CaseRules.LowerFirst p)
