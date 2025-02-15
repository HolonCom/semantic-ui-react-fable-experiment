module Client
open Elmish
open Elmish.React
open Semantic.Elements.Api
open Semantic.Elements
open Semantic.Collections.Api
open Fable.React.Props
open Fable.React
open Fable
open Semantic


type Counter = int
type Model = {
    counter : Counter option
    activeMenuItem : string
    text : string
    isMessageHidden : bool
    Visibility :  Semantic.Behaviors.Api.Visibility.Calculations option
    // StickyContext : Browser.Dom.Element option
} with static member Init () = {
                                  counter = Some 42
                                  activeMenuItem = ""
                                  text = "and React"
                                  isMessageHidden = false
                                  Visibility = None // Semantic.Behaviors.Api.Visibility.Calculations
                                //   StickyContext = None
                               }


type Msg = 
 | Increment 
 | Decrement  
 | SetActive of string 
 | NewText of string
 | DismissMessage
 | OnVisibilityUpdate of Semantic.Behaviors.Api.Visibility.Calculations
//  | SetStickyContext of Browser.Dom.Element
let init () : Model * Cmd<Msg> = 
    Model.Init () , Cmd.none
let update (msg : Msg) (model : Model) : Model * Cmd<Msg> =
    let model' =
        match model,  msg with
        | { counter = Some x}, Increment -> { model with counter = Some (x + 1) }
        | { counter = Some x} , Decrement -> { model with counter = Some (x - 1) }
        | _ , SetActive x -> { model with activeMenuItem = x }
        | _, NewText x -> { model with text = x }
        | _ , DismissMessage -> { model with isMessageHidden = true }
        // | _, SetStickyContext o -> { model with StickyContext = Some o }
        | _, OnVisibilityUpdate calc -> { model with Visibility = Some calc}
        | _ ->  model
    model', Cmd.none

open Semantic.Behaviors.Api

let renderMesage model dispatch = 
    if not model.isMessageHidden then 
      Message.message [ Message.OnDismiss ( fun _ _ -> dispatch DismissMessage )]
                      [ str "Welcome!" ]
      |> Some
    else None

let generateRow name (value:obj) = 
  Table.row [] [
      Table.cell [] [
          str name
      ]
      Table.cell [] [
          str (value.ToString())
      ]
  ] 
 
let generateRows:Semantic.Behaviors.Api.Visibility.Calculations option -> ReactElement list = function
                   | None -> []
                   | Some v -> [
                          generateRow "direction" v.direction
                          generateRow "pixelsPassed" (v.pixelsPassed.ToString() + "px")
                          generateRow "percentagePassed" (v.percentagePassed * 100.0)
                          generateRow "fits" v.fits
                          generateRow "width" v.width
                          generateRow "height" v.height
                          generateRow "onScreen" v.onScreen
                          generateRow "offScreen" v.offScreen
                          generateRow "passing" v.passing ]

let view (model : Model) (dispatch : Msg -> unit) = 
  let mutable contextRef: Browser.Types.Element option = None
  div [] [
    Menu.menu [ 
        Menu.Inverted true
     ] [
        Menu.item [ 
            Menu.Item.Header true
        ] [ str "React.SemanticUI + Fable" ]

        Menu.item [ 
            Menu.Item.Active (model.activeMenuItem = "one")
            Menu.Item.OnClick (fun _ -> dispatch (SetActive "one"))
         ] [str "One"  ]
        Menu.item [ 
            Menu.Item.Active (model.activeMenuItem = "two")
            Menu.Item.OnClick (fun _ -> dispatch (SetActive "two"))
         ] [ str "Two"  ]
        Menu.item [ 
            Menu.Item.Active (model.activeMenuItem = "three")
            Menu.Item.OnClick (fun _ -> dispatch (SetActive "three"))
         ] [ str "Three" ]
        Menu.item [ 
            Menu.Item.Active (model.activeMenuItem = "four")
            Menu.Item.OnClick (fun _ -> dispatch (SetActive "four"))
            Menu.Item.Icon Semantic.Elements.Icons.Idea
         ] [ ]
    ]
    Container.container [ 
                          Container.TextAlign Semantic.CenterText
                          Container.Props [ OnClick (fun _ -> Browser.Dom.console.warn ("Hello!") ) ] ]  
                        [
                          renderMesage model dispatch |> Option.defaultValue (str "")
                          Header.header [ Header.Size <| Header.Huge] 
                                        [
                                            Header.content [] [ 
                                                a [ Href "http://react.semantic-ui.com/" ]  [ str  "React.Semanic UI + Fable" ]
                                                Header.subheader [] [
                                                    str "is awesome!"
                                                 ] ]
                                        ]
                          Divider.divider [ Divider.Horizontal true ] [
                              str "From "
                              Flag.flag [ Flag.Name Flags.Russia ]
                              str "with "
                              Icon.icon [ Icon.Name Icons.Heart
                                          Icon.Color Semantic.Red ]  ] 
                          Segment.segment [ Segment.Basic true ] [ 
                                  str "Press buttons to manipulate counter:"
                                  Icon.icon [ Icon.Name Icons.ArrowDown ] ]
                          Segment.segment [ Segment.Basic true ] [
                                Button.group [] [ 
                                                Button.button [
                                                            Button.OnClick  (fun _ -> dispatch Decrement)
                                                            Button.Toggle true
                                                            Button.IsAnimated true 
                                                            Button.Primary true ] 
                                                            [ 
                                                                Button.content [  Button.Content.Hidden  true  ] [
                                                                                     str "-1"
                                                                                 ]
                                                                Button.content [ Button.Content.Visible  true ] [
                                                                                     str "Decrement"
                                                                                 ]
                                                            ]
                                                Button.or'  [ Button.Or.Text  <| (match model.counter with | Some x -> string x | None -> "Loading...")
                                                              Button.Or.Props [ OnClick ( fun _ ->  Browser.Dom.window.alert ( model |> string ) ) ]  ]
                                                Button.button
                                                     [ Button.OnClick (fun _ -> dispatch Increment )
                                                       Button.Animated Button.Fade
                                                       Button.Negative true ] 
                                                     [ 
                                                         Button.content [ Button.Content.Hidden true ] [
                                                             str "+1"
                                                         ]
                                                         Button.content [ Button.Content.Visible true ] [
                                                            str "Increment"
                                                         ]
                                                     ]
                                             ]
                                  ]
                          Grid.grid [ 
                                    //   Grid.IsDivided true
                                    //   Grid.Relaxed Semantic.Very
                                    ] [
                                      Grid.row [ 
                                            //    Grid.Row.Centered true
                                               Grid.Row.Columns Semantic.N3
                                       ] [
                                                    Grid.column [] 
                                                          [
                                                            //   Container.container [] [
                                                                  Reveal.reveal [ Reveal.Animated Reveal.Fade ] 
                                                                         [
                                                                              Reveal.content [ Reveal.Content.Visible true ]
                                                                                             [
                                                                                               Image.image [    //Image.Centered true 
                                                                                                                //Image.VerticalAlign Semantic.Middle
                                                                                                                Image.Size Semantic.Tiny
                                                                                                                // Image.Href "https://react.semantic-ui.com/introduction"
                                                                                                                Image.Src  "https://react.semantic-ui.com/logo.png" ] ]
                                                                              Reveal.content [ Reveal.Content.Hidden true ] [
                                                                                               Image.image[ //Image.Centered true
                                                                                                            //Image.VerticalAlign Semantic.Middle
                                                                                                            Image.Size Semantic.Tiny
                                                                                                            // Image.Href "http://fable.io/" 
                                                                                                            Image.Src "http://fable.io/img/shared/fable_logo.png"]
                                                                              ]
                                                                         ]
                                                            //   ]
                                                      ]
                                                    Grid.column [] [
                                                                       Button.button [ Button.Text (model.text + " " + model.activeMenuItem)
                                                                                       Button.Icon Icons.React] []
                                                    ]
                                                    Grid.column [] [
                                                                    Input.input [ 
                                                                        Input.Placeholder "No reaction"
                                                                        Input.Action <| Button.button [ Button.Text model.text ] []  ] []
                                                    ]
                                      ]
                                      Grid.row [
                                        //   Grid.Row.Centered true
                                          Grid.Row.Columns Semantic.N2
                                      ] [
                                          Grid.column [] [ Label.label [] [ str "ama label"] ]
                                          Grid.column [] [ Label.label [] [ str "Placeholder For DropDownList, TODO"] ]
                                      ]
                                      Grid.row [
                                        //   Grid.Row.Centered true
                                          Grid.Row.Columns Semantic.N1
                                      ] [
                                          Grid.column [] [
                                               Input.input [ Input.Label <|  Button.button [  Button.OnClick (fun _ -> Browser.Dom.window.alert( model.text ) ) ] [ str model.text ]  
                                                             Input.Placeholder "Type here, its reactive!" 
                                                             Input.OnChange ( fun s a  -> (match a.value with | null | "" -> "with React" | a  -> a) |> NewText |> dispatch ) ] []

                                          ]
                                        ]
                                      Grid.row [
                                           Grid.Row.Columns Semantic.N1
                                       ] [
                                          Grid.column [] [
                                               Input.input [ Input.IsAction true
                                                             Input.Placeholder "No reaction" ] [
                                                   input []
                                                   Button.button [ Button.Icon Icons.Rub ] [ ]
                                                   Button.button [ Button.Icon Icons.Usd ] [ ]
                                                   Button.button [ Button.Icon Icons.Eur ] [ ]
                                               ]
                                          ] 
                                      ]
                                      Grid.row [
                                          Grid.Row.Columns Semantic.N2
                                      ] [
                                          Grid.column [] [
                                              Menu.menu [ Menu.Vertical true ] [
                                                  Menu.item [] [
                                                      Input.input [ Input.Placeholder "Search..." ] []
                                                  ]
                                                  Menu.item [] [
                                                      str "Home"
                                                      Menu.submenu [] [
                                                          Menu.item [ Menu.Item.Name "Search" ] [ str "Search" ]
                                                          Menu.item [ Menu.Item.Name "Add" ] [ str "Add"]
                                                          Menu.item [ Menu.Item.Name "Remove" ] [ str "Remove"]
                                                      ]
                                                  ]
                                                  Menu.item [ Menu.Item.Name "Browse"]  [
                                                      Icon.icon [ Icon.Name Semantic.Elements.Icons.GridLayout ]
                                                      str "Browse"
                                                  ]
                                                  Menu.item [ Menu.Item.Name "Messages" ] [
                                                      str "Messages"
                                                  ]
                                              ] 
                                          ]
                                          Grid.column [] [
                                             Breadcrumb.breadcrumb [] [
                                                  Breadcrumb.section [ Breadcrumb.Section.Link true ] [
                                                      str "Fst"
                                                  ]
                                                  Breadcrumb.divider [ Breadcrumb.Divider.Icon Semantic.Elements.Icons.ArrowRight ] 
                                                  Breadcrumb.section [ Breadcrumb.Section.Link true ] [
                                                      str "Snd"
                                                  ]
                                                  Breadcrumb.divider [ Breadcrumb.Divider.Icon Semantic.Elements.Icons.ArrowRight ] 
                                                  Breadcrumb.section [ Breadcrumb.Section.Active true ] [
                                                      str "Thrd"
                                                  ]
                                              ]
                                          ]
                                      ]
                          ]
                          Table.table [
                              Table.Celled true
                          ] [
                              Table.header [] [
                                  Table.headerCell [] [ str "Header"]
                                  Table.headerCell [] [ str "Header"]
                                  Table.headerCell [] [ str "Header"]
                              ]
                              Table.body [] [
                                  Table.row [] [
                                      Table.cell [] [
                                          Label.label [ Label.IsRibbon true ] [ str "First" ]
                                      ]
                                      Table.cell [] [
                                        str "Cell"
                                      ]
                                      Table.cell [] [
                                        str "Cell"
                                      ]
                                  ]
                                  Table.row [] [
                                      Table.cell [] [
                                          str "Cell"
                                      ]
                                      Table.cell [] [
                                        str "Cell"
                                      ]
                                      Table.cell [] [
                                        str "Cell"
                                      ]
                                  ]
                                  Table.row [] [
                                      Table.cell [] [
                                          str "Cell"
                                      ]
                                      Table.cell [] [
                                        str "Cell"
                                      ]
                                      Table.cell [] [
                                        str "Cell"
                                      ]
                                  ]
                              ]
                              Table.footer [] [
                                  Table.row [] [
                                      Table.headerCell [ Table.HeaderCell.Props [ ColSpan 3 ]  ] [
                                          Menu.menu [ Menu.Floated Menu.Right
                                                      Menu.Pagination true ] [
                                                          Menu.item [
                                                              Menu.Item.As "a"
                                                              Menu.Item.IsIcon true
                                                          ] [
                                                              Icon.icon [ Icon.Name Icons.ChevronLeft ]
                                                          ]
                                                          Menu.item [ Menu.Item.As "a" ] [ str "1" ]
                                                          Menu.item [ Menu.Item.As "a" ] [ str "2" ]
                                                          Menu.item [ Menu.Item.As "a" ] [ str "3" ]
                                                          Menu.item [ Menu.Item.As "a" ] [ str "4" ]
                                                          Menu.item [ Menu.Item.As "a"
                                                                      Menu.Item.IsIcon true ] [ 
                                                                          Icon.icon [ Icon.Name Icons.ChevronRight ]
                                                           ]
                                                      ]
                                      ]
                                  ]
                              ] 

                          ]
                ]
    div [
        Ref ( fun e -> Browser.Dom.console.log(e)
                       contextRef <- Some e)
    ] [
        Grid.grid [] [
        Grid.row [ 
            Grid.Row.Columns Semantic.N2
        ] [
            Grid.column [] [
                Visibility.visibility [
                     Visibility.OnUpdate (fun _ v -> OnVisibilityUpdate v.calculations |> dispatch )
                ] [
                   Wireframe.wireframe ()
                ]
            ]
            Grid.column [] [
                Semantic.Modules.Api.Sticky.sticky [
                    Semantic.Modules.Api.Sticky.Context contextRef
                ] [
                    Table.table [
                        Table.Celled true
                    ] [
                        Table.header [] [
                            Table.row [] [
                                Table.headerCell [] [
                                    str "Calculation"
                                ]
                                Table.headerCell [] [
                                    str "Value"
                                ]
                            ]
                        ]
                        Table.body [] (generateRows model.Visibility)
                        
                    ]
                ]
            ]
        ]
       ]
    ]             
  ]


#if DEBUG
open Elmish.Debug
open Elmish.HMR
#endif

Program.mkProgram init update view
#if DEBUG
|> Program.withConsoleTrace
//|> Program.withHMR
#endif
|> Program.withReactBatched "elmish-app"
#if DEBUG
|> Program.withDebugger
#endif
|> Program.run
