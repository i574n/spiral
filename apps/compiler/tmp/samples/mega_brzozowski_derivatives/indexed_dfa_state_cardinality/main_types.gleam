pub type Us0 {
    Us0BitZero
    Us0BitOne
}

pub type Uh0 {
    Uh0RegexEmpty
    Uh0RegexEpsilon
    Uh0RegexChar(Us0)
    Uh0RegexAlt(Uh0, Uh0)
    Uh0RegexCat(Uh0, Uh0)
    Uh0RegexStar(Uh0)
}

pub type Uh1 {
    Uh1InputEmpty
    Uh1InputCons(Us0, Uh1)
}

pub type Us1 {
    Us1SymbolLess
    Us1SymbolSame
    Us1SymbolGreater
}

pub type Us2 {
    Us2Nullable
    Us2NonNullable
}

pub type Us3 {
    Us3TriA
    Us3TriB
    Us3TriC
}

pub type Uh2 {
    Uh2RegexEmpty
    Uh2RegexEpsilon
    Uh2RegexChar(Us3)
    Uh2RegexAlt(Uh2, Uh2)
    Uh2RegexCat(Uh2, Uh2)
    Uh2RegexStar(Uh2)
}

pub type Uh3 {
    Uh3InputEmpty
    Uh3InputCons(Us3, Uh3)
}
