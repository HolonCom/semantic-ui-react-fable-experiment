namespace rec Semantic.Elements.Api 

open Fable.Core
open Fable.React.Props
open Fable.React

[<RequireQualifiedAccessAttribute>]
module Label =
    
  module Detail = 
    type Options = 
    | As of string 
    | ClassName of string
    | Props of IHTMLProp list
    with interface IHTMLProp
  let detail (props: Detail.Options list) = 
    let p = props |> List.fold ( fun s x -> match x with 
                                                | Detail.Props x -> s @ x 
                                                | a -> (a :> IHTMLProp ) :: s  ) []
    ofImport "Label.Detail" "semantic-ui-react" (JsInterop.keyValueList CaseRules.LowerFirst p)  
  [<StringEnum>] 
  type Attached = 
  | Top
  | Bottom
  | [<CompiledName "top right">]TopRight
  | [<CompiledName "top left">]TopLeft
  | [<CompiledName "bottom right">]BottomRight
  | [<CompiledName "bottom left">]BottomLeft

  [<StringEnum>]
  type Corner = | [<CompiledName "left">]LeftCorner | [<CompiledName "right">] RightCorner
  [<StringEnum>]
  type Pointing = | AbovePointing | BelowPointing | LeftPointing | RightPointing 
  [<StringEnum>]
  type Ribbon = | [<CompiledName "right">]RightRibbon 
  type Options = 
  | Active of bool
  | As of string
  | Attached of Attached 
  | Basic of bool
  | Circular of bool
  | ClassName of string
  | Color of Semantic.Color
  | Corner of Corner
  | Detail of Detail.Options list
  | Empty of ReactElement
  | Floating of bool
  | Horizontal of bool
  | Icon of Semantic.Elements.Icons.IIcon
  | [<CompiledName "image">]IsImage of bool
  | Image of ReactElement //TODO create rec options
  | OnClick of (Browser.Types.MouseEvent * obj -> unit)
  | OnRemove of (Browser.Types.MouseEvent * obj -> unit)
  | [<CompiledName "pointing">]IsPointing of bool
  | Pointing of Pointing 
  | RemoveIcon of Semantic.Elements.Icons.IIcon
  | [<CompiledName "ribbon" >]IsRibbon of bool 
  | Ribbon of Ribbon
  | Size of Semantic.Sizes
  | Tag of bool
  | Props of IHTMLProp list
  with interface IHTMLProp

  let label (props: Options list) = 
    let p = props |> List.fold ( fun s x -> match x with 
                                                | Props x -> s @ x 
                                                | a -> (a :> IHTMLProp ) :: s  ) []
    ofImport "Label" "semantic-ui-react" (JsInterop.keyValueList CaseRules.LowerFirst p)  
  module Group =
    type Options =
    | As of string
    | Circular of string 
    | ClassName of string
    | Content of Semantic.Elements.Api.Label.Options list 
    | Color of Semantic.Color 
    | Size of Semantic.Sizes
    | Tag of bool
    | Props of IHTMLProp list
    with interface IHTMLProp
  let group (props: Group.Options list) = 
    let p = props |> List.fold ( fun s x -> match x with 
                                                | Group.Props x -> s @ x 
                                                | a -> (a :> IHTMLProp ) :: s  ) []
    ofImport "Label.Group" "semantic-ui-react" (JsInterop.keyValueList CaseRules.LowerFirst p)  
