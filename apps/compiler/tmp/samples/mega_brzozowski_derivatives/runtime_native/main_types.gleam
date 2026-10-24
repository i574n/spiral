pub type Us0 {
    Us0BitZero
    Us0BitOne
}

pub type Uh0 {
    Uh0InputEmpty
    Uh0InputCons(Us0, Uh0)
}

pub type Us1 {
    Us1TriA
    Us1TriB
    Us1TriC
}

pub type Uh1 {
    Uh1InputEmpty
    Uh1InputCons(Us1, Uh1)
}

pub type Uh2 {
    Uh2RegexEmpty
    Uh2RegexEpsilon
    Uh2RegexChar(Us0)
    Uh2RegexAlt(Uh2, Uh2)
    Uh2RegexCat(Uh2, Uh2)
    Uh2RegexStar(Uh2)
}

pub type Us2 {
    Us2SymbolLess
    Us2SymbolSame
    Us2SymbolGreater
}

pub type Us3 {
    Us3Nullable
    Us3NonNullable
}

pub type Uh3 {
    Uh3RegexEmpty
    Uh3RegexEpsilon
    Uh3RegexChar(Us1)
    Uh3RegexAlt(Uh3, Uh3)
    Uh3RegexCat(Uh3, Uh3)
    Uh3RegexStar(Uh3)
}

pub type Us4 {
    Us4BitMatcherRaw(f0i0 : Uh2, f0i1 : Uh0)
}

pub type Us5 {
    Us5BitMatcherDecided(f0i0 : Uh2, f0i1 : Uh0, f0i2 : Bool)
}
