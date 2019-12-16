namespace Semantic.Elements.Api

open Fable.Core
open Fable.React
open Fable.React.Props
open System.Drawing

[<RequireQualifiedAccessAttribute>]
module Image = 
  module Group =
    type Options =
      | As of string
      | ClassName of string
      | Size of Semantic.Sizes

  type Options = 
   ///An element type to render as. Default <img>
   | As of string
   | Avatar of bool
   | Bordered of bool
   | Centered of bool
   | Circular of bool
   | Disabled of bool
   | Floated of Semantic.Floats
   | Fluid of bool
   | Hidden of bool
   | Href of string
   | Inline of bool
   | Label of ReactElement
   | Rounded of bool
   | Size of Semantic.Sizes
   | Spaced of Semantic.Floats
   | IsSpaced of bool
   | Src of string
   | Ui of bool 
   | VerticalAlign of Semantic.VerticalAlignments
   | Wrapped of bool
   | Props of IHTMLProp list
    with interface IHTMLProp
 
  let image (props: Options list) =
        let p = props |> List.fold ( fun s q -> match q with 
                                                    | Options.Props x -> s @ x 
                                                    | a -> (a :> IHTMLProp ) :: s  ) [] 
        ofImport "Image" "semantic-ui-react" (JsInterop.keyValueList CaseRules.LowerFirst p) []
  let groupp (props: Options list) =
        let p = props |> List.fold ( fun s q -> match q with 
                                                    | Options.Props x -> s @ x 
                                                    | a -> (a :> IHTMLProp ) :: s  ) [] 
        ofImport "Image.Group" "semantic-ui-react" (JsInterop.keyValueList CaseRules.LowerFirst p) 
