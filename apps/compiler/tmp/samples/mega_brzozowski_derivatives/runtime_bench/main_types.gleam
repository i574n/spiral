pub type SpiralArrayKey


pub type SpiralArray(a) {
  SpiralArray(key: SpiralArrayKey, size: Int)
}


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

pub type Uh2 {
    Uh2RegexListNil
    Uh2RegexListCons(Uh0, Uh2)
}
