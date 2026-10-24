pub type Us0 {
    Us0BitZero
    Us0BitOne
}

pub type Uh0 {
    Uh0SymbolListNil
    Uh0SymbolListCons(Us0, Uh0)
}

pub type Uh2 {
    Uh2InputEmpty
    Uh2InputCons(Us0, Uh2)
}

pub type Uh1 {
    Uh1InputListNil
    Uh1InputListCons(Uh2, Uh1)
}

pub type Us1 {
    Us1TriA
    Us1TriB
    Us1TriC
}

pub type Uh3 {
    Uh3SymbolListNil
    Uh3SymbolListCons(Us1, Uh3)
}

pub type Uh5 {
    Uh5InputEmpty
    Uh5InputCons(Us1, Uh5)
}

pub type Uh4 {
    Uh4InputListNil
    Uh4InputListCons(Uh5, Uh4)
}

pub type Us2 {
    Us2ModelA
    Us2ModelB
    Us2ModelC
}

pub type Uh6 {
    Uh6InputEmpty
    Uh6InputCons(Us2, Uh6)
}

pub type Uh7 {
    Uh7RegexEmpty
    Uh7RegexEpsilon
    Uh7RegexChar(Us0)
    Uh7RegexAlt(Uh7, Uh7)
    Uh7RegexCat(Uh7, Uh7)
    Uh7RegexStar(Uh7)
}

pub type Us3 {
    Us3InventoryDfaAccepted
    Us3InventoryDfaRejected
    Us3InventoryDfaInputOutsideInventory
}

pub type Us4 {
    Us4SymbolLess
    Us4SymbolSame
    Us4SymbolGreater
}

pub type Us5 {
    Us5Nullable
    Us5NonNullable
}

pub type Uh8 {
    Uh8RegexEmpty
    Uh8RegexEpsilon
    Uh8RegexChar(Us1)
    Uh8RegexAlt(Uh8, Uh8)
    Uh8RegexCat(Uh8, Uh8)
    Uh8RegexStar(Uh8)
}
