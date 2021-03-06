﻿module BasicModel1
    open NUnit.Framework
    open FsUnit
    open EasyamParsingEngine
    open Types
    open SAModel
    open Lenses
    open Utils

    let setupCompilationScenario fileNumber incomingRawLineCount incomingLineCountWithEmptyLinesDeletedCount rawLineArray =
        initialProcessingOfIncomingFileLines fileNumber dummyFileInfo incomingRawLineCount incomingLineCountWithEmptyLinesDeletedCount rawLineArray

    let basicModel1 =
        let fileInfo1 = getFakeFileInfo()
        let fileInfo2 = getFakeFileInfo()
        let fileInfo3 = getFakeFileInfo()
        let fileInfo4 = getFakeFileInfo()
        let fileInfo5 = getFakeFileInfo()
        let fileInfo6 = getFakeFileInfo()
        let fileInfo7 = getFakeFileInfo()
        let testText1 = [|
                          ""
                        ; "Here's the initial master use case list based on our conversation last Monday"
                        ; ""
                        ; ""
                        ; "BEHAVIOR"
                        ; "    Order Goods"
                        ; "    Receive Order"
                        ; "    Receive Shipment"
                        ; "    Reject Shipment"
                        ; "    Reject Part Of Shipment"
                        ; "    Reconcile BOL"
                        ; "    Put Away New Shipment"
                        ; "    Conduct Spot Inventory"
                        ; "    Conduct Regular Inventory"
                        ; "    Create Shipment"
                        ; "    Pick Shipment"
                        ; "    Ship Goods"
                        ; "    Review Daily Warehouse Activity"
                        ; "    MISC"
                        ; "    ALL"
                        |]
        let testText2 = [|
                          ""
                        ; "Here's the intial master domain model last also based on last Monday's conversation"
                        ; ""
                        ; ""
                        ; "STRUCTURE"
                        ; "    Shipment"
                        ; "        QUESTIONS: "
                        ; "            Does this involve real ships?"
                        ; "            Do we get free mints?"
                        ; "            Are the ships full of mints?"
                        ; "    Order"
                        ; "    Bill Of Lading"
                        ; "    Inventory Item"
                        ; "    Employee"
                        ; "    Employee Type"
                        ; "    SKU"
                        ; "    Customer"
                        ; "    Invoice"
                        ; "    Invoice Line"
                        ; "    Invoice Line Item"
                        ; "    Vendor"
                        ; "        TODO:"
                        ; "            Meet some vendors"
                        ; "            Listen to stories about vendors"
                        ; ""
                        ; ""
                        ; "    Shipment HASA Bill Of Lading"
                        ; "    Order HASA Shipment"
                        ; "    Shipment HASA Bill Of Lading"
                        ; "    Vendor HASA Shipment"
                        ; "    Vendor HASA Invoice"
                        ; "    Customer HASA Order"
                        ; "    Vendor HASA Order"
                        ; "    Customer HASA Invoice"
                        ; "    Invoice HASA Invoice Line"
                        ; "    Invoice HASA Invoice Line Item"
                        ; "    SKU HASA Inventory Item"
                        ; "    Invoice Line Item HASA SKU"
                        ; ""
                        ; ""
                        ; "    Shipment CONTAINS Shipment Number, Shipment Date, Expected Arrival Date"
                        ; "    Order CONTAINS Order Number, Order Date, Customer Number, Total Amount"
                        ; "    Bill Of Lading CONTAINS Pallet List"
                        ; "    Inventory Item CONTAINS Inventory Item Description, Inventory Short Code, Inventory Long Code"
                        ; "    Employee CONTAINS First Name, Last Name, Social Security Number, Hire Date"
                        ; "    Employee Type CONTAINS Role Name, Salary Level"
                        ; "    SKU CONTAINS Item Number, Quantity"
                        ; "    Customer CONTAINS Customer Number, Address"
                        ; "    Invoice CONTAINS Invoice Number, Invoice Date, Invoice Total Amount"
                        ; "    Invoice Line CONTAINS Line Number, Line Total"
                        ; "    Invoice Line Item CONTAINS Long Description"
                        ; "    Vendor CONTAINS Vendor Number, Address, Last Order Date"
                        |]
        let testText3 = [|
                          ""
                        ; "From the initial talk, the master domain model items used by the master user stories"
                        ; "Note the only requirement at the _BIZ_ABST_ level is to include or exclude items based on how often they show up in conversation"
                        ; "(It's not a data model)"
                        ; "(Also note that we had to purposely mispell keywords in order to prevent the compiler from compiling the note wrong)"
                        ; ""
                        ; ""
                        ; "BEHAVIOR"
                        ; "    Order Goods USES Order, Vendor, Invoice, Shipment"
                        ; "    Receive Order USES Vendor, Order, Shipment, Bill Of Lading, Employee, Employee Type"
                        ; "    Receive Shipment USES Shipment, Order, Bill Of Lading, Inventory Item, Employee, SKU, Vendor, Invoice, Invoice Line, Invoice Line Item, Vendor"
                        ; "    Reject Shipment USES"
                        ; "        Order"
                        ; "        Shipment"
                        ; "        Vendor"
                        ; "    Reject Part Of Shipment USES Order, Shipment"
                        ; "    Reconcile BOL USES Order, Shipment, Bill Of Lading"
                        ; "    Put Away New Shipment USES Inventory Item, SKU"
                        ; "    Conduct Spot Inventory USES Inventory Item, SKU"
                        ; "    Conduct Regular Inventory USES Inventory Item, SKU"
                        ; "    Create Shipment"
                        ; "        USES"
                        ; "            Employee"
                        ; "            Employee Type"
                        ; "            Customer"
                        ; "            Order"
                        ; "            Invoice"
                        ; "            Shipment"
                        ; "            Invoice Line Item"
                        ; "    Pick Shipment USES Employee, Order, Invoice, Shipment"
                        ; "    Ship Goods USES Customer, Order, Shipment"
                        ; "    Review Daily Warehouse Activity USES Inventory Item"
                        ; "    "
                        ; "    "
                        |]
        let testText4 = [|
                          ""
                        ; "Here's our initial master supplemental list"
                        ; ""
                        ; ""
                        ; "SUPPLEMENTALS"
                        ; "    Always respond in a way that's easy for the user to understand"
                        ; "    Never make the user wait"
                        ; "    Never confuse the user"
                        ; "    Always keep track of the path users take to arrive on-site"
                        ; "    Continuously inform the team about everything the users do"
                        ; "    Make it as easy as possible for the user to provide negative feedback"
                        ; "    Always do the best we can to cheer the user up during any interaction"
                        |]
        let testText5 = [|
                          ""
                        ;  ""
                        ;  ""
                        ; "From our first talk, here's how the supps map to the MUS    "
                        ;  ""
                        ;  ""
                        ; "SUPPLEMENTALS"
                        ; "    Always respond in a way that's easy for the user to understand"
                        ; "        AFFECTS"
                        ; "            ALL"
                        ; "    Never make the user wait"
                        ; "        AFFECTS"
                        ; "            ALL"
                        ; "    Never confuse the user"
                        ; "        AFFECTS"
                        ; "            ALL"
                        ; "    Always keep track of the path users take to arrive on-site"
                        ; "        AFFECTS"
                        ; "            Order Goods, MISC"
                        ; "    Continuously inform the team about everything the users do"
                        ; "        AFFECTS"
                        ; "            ALL"
                        ; "    Make it as easy as possible for the user to provide negative feedback"
                        ; "        AFFECTS"
                        ; "            Reject Shipment, Reject Part Of Shipment"
                        ; "    Always do the best we can to cheer the user up during any interaction"
                        ; "        AFFECTS"
                        ; "            ALL"
                        ; "    "
                        ; "    "
                        ; "    "
                        |]
        let testText6 = [|
                          ""
                        ; ""
                        ; ""
                        ; ""
                        ; "BEHAVIOR"
                        ; "    Order Goods"
                        ; "    // Order Goods was specifically requested by the guy in the plaid sweater"
                        ; "    // It seems to be very important for some reason"
                        ; "        WHEN The inventory count for an item falls below its re-order point"
                        ; "        ASA Warehouse Worker"
                        ; "        INEEDTO Place an order with our suppliers to replenish needed items"
                        ; "        SOTHAT we don't run out of things and are able to fulfill our orders from our customers"
                        ; "    Receive Order"
                        ; "        WHEN I'm out of something I realize I need"
                        ; "        ASA Customer"
                        ; "        INEEDTO Place an order for new stuff"
                        ; "        SOTHAT I can be happy owning things I think I need"
                        ; "    Receive Shipment"
                        ; "        WHEN A truck arrives at the loading dock"
                        ; "        ASA Warehouse Worker"
                        ; "        INEEDTO Unload the truck"
                        ; "        SOTHAT "
                        ; "            We can get new trucks in"
                        ; "            We can have stuff to ship to other people"
                        ; "    Reject Shipment"
                        ; "        WHEN We are recieving a shipment and most of the goods are unsatisfactory"
                        ; "        ASA Warehouse Worker"
                        ; "        INEEDTO Reject the shipment"
                        ; "        SOTHAT We can get the goods we need from another vendor"
                        ; "    Reject Part Of Shipment"
                        ; "        WHEN We are recieving a shipment and a few of the items are unsatisfactory"
                        ; "        ASA Warehouse Worker"
                        ; "        INEEDTO Reject parts of the shipment that are unsatisfactory"
                        ; "        SOTHAT We can restock needed goods as soon as possible"
                        ; "    Reconcile BOL"
                        ; "        WHEN A truck arrives at the guard shack"
                        ; "        ASA Guard"
                        ; "        INEEDTO Reconcile the BOL with the paperwork"
                        ; "        SOTHAT Warehouse workers will know a vetted truck is waiting to unload"
                        ; "    Put Away New Shipment"
                        ; "        WHEN A shipment has been received approved and recorded // no commas allowed here"
                        ; "        ASA Warehouse Worker"
                        ; "        INEEDTO Put Away New Shipment"
                        ; "        SOTHAT The loading area is freed up to accept new shipments"
                        ; "    Conduct Spot Inventory //I love inventory"
                        ; "        WHEN "
                        ; "            A truck arrives at the gate // could be any kind of truck"
                        ; "            An accountant calls on the phone"
                        ; "            There's a break-in at the warehouse"
                        ; "        ASA // the actor list isn't complete yet"
                        ; "            Warehouse Worker"
                        ; "            Warehouse Supervisor"
                        ; "            Nightshift Guard Supervisor"
                        ; "        INEEDTO "
                        ; "            Conduct a formal spot inventory by hand using the older books"
                        ; "        SOTHAT"
                        ; "            The insurance company is notified in case of loss"
                        ; "            Incoming shipments will adequately update the running inventory"
                        ; "                Q: Is there such a thing as a 'walking inventory'"
                        ; "        Q: Do we differentiate between goods and services?"
                        ; "    Conduct Regular Inventory"
                        ; "        WHEN "
                        ; "            The first of the month rolls around"
                        ; "        ASA"
                        ; "            Warehouse Supervisor"
                        ; "        INEEDTO "
                        ; "            Conduct a formal inventory using an audited procedure"
                        ; "        SOTHAT"
                        ; "            Our accounting system stays coherent"
                        ; "            We know what to order"
                        ; "    Create Shipment "
                        ; "        WHEN "
                        ; "            An order has been picked and put in the staging area"
                        ; "        ASA"
                        ; "            Warehouse Worker"
                        ; "        INEEDTO "
                        ; "            Create a shipment to the customer"
                        ; "        SOTHAT"
                        ; "            The items customers want will arrive on-time for them"
                        ; "            The staging area is freed up to process shipments for customers"
                        ; "    Pick Shipment "
                        ; "        WHEN "
                        ; "            An order has been received and we have enough goods"
                        ; "        ASA"
                        ; "            Warehouse Worker"
                        ; "        INEEDTO "
                        ; "            Pick items from the warehouse to send to the customer"
                        ; "        SOTHAT"
                        ; "            We can put the items customers want on a truck and send it to them"
                        ; "    Ship Goods "
                        ; "        WHEN "
                        ; "            An order has been picked and the shipment created"
                        ; "        ASA"
                        ; "            Guard"
                        ; "        INEEDTO "
                        ; "            Approve the outgoing items and shipment"
                        ; "        SOTHAT"
                        ; "            The customer receives goods they want"
                        ; "    Review Daily Warehouse Activity "
                        ; "        WHEN "
                        ; "            The end of the working day occurs"
                        ; "        ASA"
                        ; "            Warehouse Manager"
                        ; "        INEEDTO "
                        ; "            Review all the activity in the warehouse"
                        ; "        SOTHAT"
                        ; "            The business is operating as it should"
                        |]
        let testText7 = [|
                            ""
                        ; "    "
                        ; "    "
                        ; "    "
                        ; "SUPPLEMENTALS"
                        ; "    Always respond in a way that's easy for the user to understand"
                        ; "        BECAUSE Most of our users are operating at a sixth-grade education"
                        ; "        WHENEVER We talk with them or have any interaction with them"
                        ; "        ITHASTOBETHAT They're never confused or made to feel inferior"
                        ; "    Never make the user wait"
                        ; "        BECAUSE The average business customer gets annoyed after having to wait six seconds"
                        ; "        WHENEVER Our customers ask us anything"
                        ; "        ITHASTOBETHAT We respond in some form within 100ms and with a reasonable answer in 3s"
                        ; "    Never confuse the user"
                        ; "        BECAUSE We deal in complicated logistics concepts"
                        ; "        WHENEVER We explain what we're doing to the user"
                        ; "        ITHASTOBETHAT The average 6-year-old barely paying attention to the transaction can understand what's going on"
                        ; "    Always keep track of the path users take to arrive on-site"
                        ; "        BECAUSE It's important for us to understand why people choose our business"
                        ; "        WHENEVER Somebody comes by to make a transaction, even people we know"
                        ; "        ITHASTOBETHAT We understand the journey people take to use us"
                        ; "    Continuously inform the team about everything the users do"
                        ; "        BECAUSE The team isn't as close to the users as they need to be"
                        ; "        WHENEVER Users interact with our business"
                        ; "        ITHASTOBETHAT We record everything that happened so that we can look back later and figure out what we might have done wrong"
                        ; "    Make it as easy as possible for the user to provide negative feedback"
                        ; "        BECAUSE People very rarely give any negative feedback"
                        ; "        WHENEVER Something happens that might make a user unhappy"
                        ; "        ITHASTOBETHAT WE do everything we can to help and encourage them to tell us what went wrong"
                        ; "    Always do the best we can to cheer the user up during any interaction"
                        ; "        BECAUSE Users don't like dealing with warehousing - inventory - and logistics // Note no commas"
                        ; "        WHENEVER We chat with our user friends"
                        ; "        ITHASTOBETHAT We make a special effort to cheer them up"
                        ; ""
                        ; ""
                        ; ""
                        |]
        [|(fileInfo1,testText1);(fileInfo2,testText2);(fileInfo3,testText3);(fileInfo4,testText4);(fileInfo5,testText5);(fileInfo6,testText6);(fileInfo7,testText7)|]

