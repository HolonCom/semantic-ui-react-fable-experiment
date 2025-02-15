namespace Semantic.Elements.Api

open Fable.Import
open Fable.Core
open Fable
open Fable.React
open Fable.React.Props
open System
[<RequireQualifiedAccessAttribute>]
module Input =
  [<StringEnum>]
  type Position = | Left
  type Val = { value : string }
  type ActionType = | [<CompiledNameAttribute "action">] ActionPlaceholder of obj with interface IHTMLProp
  type Options =
      | [<CompiledName "action">]IsAction of bool
      | Action of ReactElement
      | ActionPosition of Position
      ///An element type to render as f.e. 'div', 'a', etc.
      | As  of string
      | ClassName of string
      ///An Input can show it is currently unable to be interacted with.
      | Disabled of bool
      | Error of bool
      ///An Input can take the width of its container.
      | Fluid of bool 
      ///  ?? TODO check is this need
      | [<CompiledName "icon">]IsIcon of bool
      | Icon of Semantic.Elements.Icons.IIcon
      | IconPosition of Position
      | Input of bool
      ///An Input can be formatted to appear on dark backgrounds.
      | Inverted of bool
      | [<CompiledName "label">]LabelText of string
      | Label of ReactElement
      ///A Label can appear outside an Input on the left or right.
      | LabelPosition of Semantic.Floats
      ///An Icon Input field can show that it is currently loading data.
      | Loading of bool 
      ///Called after user's click. 
      /// OnClick ( fun (event, data) -> .. ) 
      /// event - Browser.Types.MouseEvent.
      /// data - All props.
      | OnChange of  (Browser.Types.MouseEvent ->  Val -> unit)
      ///An Input can vary in size.
      | Size of Semantic.Sizes
      ///A button can receive focus.
      | TabIndex of int
      | Transparent of bool
      | Type of string
      | Placeholder of string
       ///Other React props
      | Props of IHTMLProp list
      with interface IHTMLProp

  let input (props: Options list )  s =
        let p = props |> List.fold ( fun s x -> match x with 
                                                | Props x -> s @ x 
                                                // | OnChange x -> 
                                                | a -> (a :> IHTMLProp ) :: s  ) []
        ofImport "Input" "semantic-ui-react" (JsInterop.keyValueList CaseRules.LowerFirst p)  s 
