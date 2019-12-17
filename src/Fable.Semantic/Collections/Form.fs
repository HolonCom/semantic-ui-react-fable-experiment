namespace Semantic.Collections.Api

open Fable.Core
open Fable.React.Props
open Fable.React
open Semantic

[<RequireQualifiedAccess>]
module Form =
  [<StringEnum>]
  type Widths = | Equal
  type Options =
  | Action of string
  | As of string
  | ClassName of string
  | Error of bool
  | Inverted of bool
  | Loading of bool
  | OnSubmit of (unit -> unit)
  | Reply of bool
  | Size of Semantic.Sizes
  | Success of bool
  | Unstackable of bool
  | Warning of bool
  | Widths of Widths
  | Props of IHTMLProp list
  with interface  IHTMLProp

  let form (props: Options list) = 
    let p = props |> List.fold ( fun s x -> match x with 
                                                | Props x -> s @ x 
                                                | a -> (a :> IHTMLProp ) :: s  ) []
    ofImport "Form" "semantic-ui-react" (JsInterop.keyValueList CaseRules.LowerFirst p)  
  module Button =
    type Options =
    | As of string
    | Control of ReactElement
    | Props of IHTMLProp list
    with interface IHTMLProp
  let button (props: Button.Options list) = 
    let p = props |> List.fold ( fun s x -> match x with 
                                                | Button.Props x -> s @ x 
                                                | a -> (a :> IHTMLProp ) :: s  ) []
    ofImport "Form.Button" "semantic-ui-react" (JsInterop.keyValueList CaseRules.LowerFirst p)  
  
  module Checkbox =
    type Options =
    | As of string
    | Control of ReactElement
    | Props of IHTMLProp list
    with interface IHTMLProp
  let checkbox (props: Checkbox.Options list) = 
    let p = props |> List.fold ( fun s x -> match x with 
                                                | Checkbox.Props x -> s @ x 
                                                | a -> (a :> IHTMLProp ) :: s  ) []
    ofImport "Form.Checkbox" "semantic-ui-react" (JsInterop.keyValueList CaseRules.LowerFirst p)  

  module Dropdown =
    type Options =
    | As of string
    | Control of ReactElement
    | Props of IHTMLProp list
    with interface IHTMLProp
  let dropdown (props: Dropdown.Options list) = 
    let p = props |> List.fold ( fun s x -> match x with 
                                                | Dropdown.Props x -> s @ x 
                                                | a -> (a :> IHTMLProp ) :: s  ) []
    ofImport "Form.Dropdown" "semantic-ui-react" (JsInterop.keyValueList CaseRules.LowerFirst p)  

  module Input =
    type Options =
    | As of string
    | Control of ReactElement
    | Props of IHTMLProp list
    with interface IHTMLProp
  let input (props: Input.Options list) = 
    let p = props |> List.fold ( fun s x -> match x with 
                                                | Input.Props x -> s @ x 
                                                | a -> (a :> IHTMLProp ) :: s  ) []
    ofImport "Form.Input" "semantic-ui-react" (JsInterop.keyValueList CaseRules.LowerFirst p)  

  module Radio =
    type Options =
    | As of string
    | Control of ReactElement
    | Props of IHTMLProp list
    with interface IHTMLProp
  let radio (props: Radio.Options list) = 
    let p = props |> List.fold ( fun s x -> match x with 
                                                | Radio.Props x -> s @ x 
                                                | a -> (a :> IHTMLProp ) :: s  ) []
    ofImport "Form.Input" "semantic-ui-react" (JsInterop.keyValueList CaseRules.LowerFirst p)

  module TextArea =
    type Options =
    | As of string
    | Control of ReactElement
    | Props of IHTMLProp list
    with interface IHTMLProp
  let textArea (props: TextArea.Options list) = 
    let p = props |> List.fold ( fun s x -> match x with 
                                                | TextArea.Props x -> s @ x 
                                                | a -> (a :> IHTMLProp ) :: s  ) []
    ofImport "Form.TextArea" "semantic-ui-react" (JsInterop.keyValueList CaseRules.LowerFirst p)

  module Select =
    type Options =
    | As of string
    | Control of ReactElement
    | Options  of obj //TODO Array of Dropdown.Item props e.g. `{ text: '', value: '' }`
    | Props of IHTMLProp list
    with interface IHTMLProp
  let select (props: Select.Options list) = 
    let p = props |> List.fold ( fun s x -> match x with 
                                                | Select.Props x -> s @ x 
                                                | a -> (a :> IHTMLProp ) :: s  ) []
    ofImport "Form.Select" "semantic-ui-react" (JsInterop.keyValueList CaseRules.LowerFirst p)

  module Group =
    [<StringEnum>]
    type GroupWidth = | Equal
       with interface Semantic.IWidths    
    type Options =
    | As of string
    | ClassName of string
    | Grouped of bool 
    | Inline of bool 
    | Unstackable of bool
    | Widths of Semantic.IWidths
    | Props of IHTMLProp list
    with interface IHTMLProp
  let group (props: Group.Options list) = 
    let p = props |> List.fold ( fun s x -> match x with 
                                                | Group.Props x -> s @ x 
                                                | a -> (a :> IHTMLProp ) :: s  ) []
    ofImport "Form.Group" "semantic-ui-react" (JsInterop.keyValueList CaseRules.LowerFirst p)

  module Field =
    type Options =
    | As of string
    | ClassName of string
    | Control of ReactElement
    | Disabled of bool
    | Error of bool
    | Inline of bool
    | Label of ReactElement
    | Required of bool
    | Type of string // TODO Passed to the control component (i.e. <input type='password' />)
    | Widths of Semantic.Widths
    | Props of IHTMLProp list
    with interface IHTMLProp

  let field (props: Field.Options list) = 
    let p = props |> List.fold ( fun s x -> match x with 
                                                | Field.Props x -> s @ x 
                                                | a -> (a :> IHTMLProp ) :: s  ) []
    ofImport "Form.Field" "semantic-ui-react" (JsInterop.keyValueList CaseRules.LowerFirst p)
