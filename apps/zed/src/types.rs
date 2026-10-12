
use std::marker::PhantomData;


pub trait TypeTag: 'static + Send + Sync {
    type Value: Clone + PartialEq + std::fmt::Debug + 'static;
    fn type_name() -> &'static str;
}

#[derive(Debug, Clone, Copy, PartialEq, Eq)]
pub struct IntTag;
impl TypeTag for IntTag {
    type Value = i64;
    fn type_name() -> &'static str {
        "i64"
    }
}

#[derive(Debug, Clone, Copy, PartialEq, Eq)]
pub struct FloatTag;
impl TypeTag for FloatTag {
    type Value = f64;
    fn type_name() -> &'static str {
        "f64"
    }
}

#[derive(Debug, Clone, Copy, PartialEq, Eq)]
pub struct BoolTag;
impl TypeTag for BoolTag {
    type Value = bool;
    fn type_name() -> &'static str {
        "bool"
    }
}

#[derive(Debug, Clone, Copy, PartialEq, Eq)]
pub struct StringTag;
impl TypeTag for StringTag {
    type Value = String;
    fn type_name() -> &'static str {
        "string"
    }
}

#[derive(Debug, Clone, Copy, PartialEq, Eq)]
pub struct UnitTag;
impl TypeTag for UnitTag {
    type Value = ();
    fn type_name() -> &'static str {
        "unit"
    }
}

#[derive(Debug, Clone)]
enum ExprRaw {
    LitInt(i64),
    LitFloat(f64),
    LitBool(bool),
    LitString(String),
    LitUnit,
    Add(Box<ExprRaw>, Box<ExprRaw>),
    Mul(Box<ExprRaw>, Box<ExprRaw>),
    Equals(Box<ExprRaw>, Box<ExprRaw>),
    IfThenElse(Box<ExprRaw>, Box<ExprRaw>, Box<ExprRaw>),
}

pub struct GadtExpr<T: TypeTag> {
    raw: ExprRaw,
    _phantom: PhantomData<fn() -> T>,
}

impl<T: TypeTag> Clone for GadtExpr<T> {
    fn clone(&self) -> Self {
        Self {
            raw: self.raw.clone(),
            _phantom: PhantomData,
        }
    }
}

impl<T: TypeTag> std::fmt::Debug for GadtExpr<T> {
    fn fmt(&self, f: &mut std::fmt::Formatter<'_>) -> std::fmt::Result {
        f.debug_struct("GadtExpr")
            .field("type", &T::type_name())
            .field("raw", &self.raw)
            .finish()
    }
}

impl GadtExpr<IntTag> {
    pub fn lit_int(value: i64) -> Self {
        Self {
            raw: ExprRaw::LitInt(value),
            _phantom: PhantomData,
        }
    }

    pub fn add(lhs: GadtExpr<IntTag>, rhs: GadtExpr<IntTag>) -> Self {
        Self {
            raw: ExprRaw::Add(Box::new(lhs.raw), Box::new(rhs.raw)),
            _phantom: PhantomData,
        }
    }

    pub fn mul(lhs: GadtExpr<IntTag>, rhs: GadtExpr<IntTag>) -> Self {
        Self {
            raw: ExprRaw::Mul(Box::new(lhs.raw), Box::new(rhs.raw)),
            _phantom: PhantomData,
        }
    }
}

impl GadtExpr<FloatTag> {
    pub fn lit_float(value: f64) -> Self {
        Self {
            raw: ExprRaw::LitFloat(value),
            _phantom: PhantomData,
        }
    }
}

impl GadtExpr<BoolTag> {
    pub fn lit_bool(value: bool) -> Self {
        Self {
            raw: ExprRaw::LitBool(value),
            _phantom: PhantomData,
        }
    }

    pub fn equals<A: TypeTag>(lhs: GadtExpr<A>, rhs: GadtExpr<A>) -> Self {
        Self {
            raw: ExprRaw::Equals(Box::new(lhs.raw), Box::new(rhs.raw)),
            _phantom: PhantomData,
        }
    }
}

impl GadtExpr<StringTag> {
    pub fn lit_string(value: impl Into<String>) -> Self {
        Self {
            raw: ExprRaw::LitString(value.into()),
            _phantom: PhantomData,
        }
    }
}

impl GadtExpr<UnitTag> {
    pub fn unit() -> Self {
        Self {
            raw: ExprRaw::LitUnit,
            _phantom: PhantomData,
        }
    }
}

impl<A: TypeTag> GadtExpr<A> {
    pub fn if_then_else(
        cond: GadtExpr<BoolTag>,
        then_branch: GadtExpr<A>,
        else_branch: GadtExpr<A>,
    ) -> Self {
        Self {
            raw: ExprRaw::IfThenElse(
                Box::new(cond.raw),
                Box::new(then_branch.raw),
                Box::new(else_branch.raw),
            ),
            _phantom: PhantomData,
        }
    }

    pub fn eval(&self) -> A::Value
    where
        A::Value: FromDyn,
    {
        eval_raw::<A>(&self.raw)
    }
}

#[derive(Debug, Clone, PartialEq)]
pub enum DynVal {
    Int(i64),
    Float(f64),
    Bool(bool),
    String(String),
    Unit,
}

fn eval_dyn(raw: &ExprRaw) -> DynVal {
    match raw {
        ExprRaw::LitInt(v) => DynVal::Int(*v),
        ExprRaw::LitFloat(v) => DynVal::Float(*v),
        ExprRaw::LitBool(v) => DynVal::Bool(*v),
        ExprRaw::LitString(v) => DynVal::String(v.clone()),
        ExprRaw::LitUnit => DynVal::Unit,
        ExprRaw::Add(l, r) => {
            if let (DynVal::Int(a), DynVal::Int(b)) = (eval_dyn(l), eval_dyn(r)) {
                DynVal::Int(a + b)
            } else {
                DynVal::Int(0)
            }
        }
        ExprRaw::Mul(l, r) => {
            if let (DynVal::Int(a), DynVal::Int(b)) = (eval_dyn(l), eval_dyn(r)) {
                DynVal::Int(a * b)
            } else {
                DynVal::Int(0)
            }
        }
        ExprRaw::Equals(l, r) => DynVal::Bool(eval_dyn(l) == eval_dyn(r)),
        ExprRaw::IfThenElse(cond, tb, eb) => {
            if let DynVal::Bool(true) = eval_dyn(cond) {
                eval_dyn(tb)
            } else {
                eval_dyn(eb)
            }
        }
    }
}

pub trait FromDyn: Sized {
    fn from_dyn(value: DynVal) -> Self;
}

impl FromDyn for i64 {
    fn from_dyn(value: DynVal) -> Self {
        match value {
            DynVal::Int(value) => value,
            other => panic!("spiral expression evaluated to {other:?}, expected i64"),
        }
    }
}

impl FromDyn for f64 {
    fn from_dyn(value: DynVal) -> Self {
        match value {
            DynVal::Float(value) => value,
            other => panic!("spiral expression evaluated to {other:?}, expected f64"),
        }
    }
}

impl FromDyn for bool {
    fn from_dyn(value: DynVal) -> Self {
        match value {
            DynVal::Bool(value) => value,
            other => panic!("spiral expression evaluated to {other:?}, expected bool"),
        }
    }
}

impl FromDyn for String {
    fn from_dyn(value: DynVal) -> Self {
        match value {
            DynVal::String(value) => value,
            other => panic!("spiral expression evaluated to {other:?}, expected string"),
        }
    }
}

impl FromDyn for () {
    fn from_dyn(value: DynVal) -> Self {
        match value {
            DynVal::Unit => (),
            other => panic!("spiral expression evaluated to {other:?}, expected unit"),
        }
    }
}

fn eval_raw<T: TypeTag>(raw: &ExprRaw) -> T::Value
where
    T::Value: FromDyn,
{
    T::Value::from_dyn(eval_dyn(raw))
}


pub trait TokenKindTag: 'static + Send + Sync {
    fn kind_name() -> &'static str;
    fn zed_capture() -> &'static str;
}

#[derive(Debug, Clone, Copy)]
pub struct KeywordTag;
impl TokenKindTag for KeywordTag {
    fn kind_name() -> &'static str {
        "keyword"
    }
    fn zed_capture() -> &'static str {
        "keyword"
    }
}

#[derive(Debug, Clone, Copy)]
pub struct SymbolTag;
impl TokenKindTag for SymbolTag {
    fn kind_name() -> &'static str {
        "symbol"
    }
    fn zed_capture() -> &'static str {
        "string.special.symbol"
    }
}

#[derive(Debug, Clone, Copy)]
pub struct TypeVarTag;
impl TokenKindTag for TypeVarTag {
    fn kind_name() -> &'static str {
        "type_variable"
    }
    fn zed_capture() -> &'static str {
        "type"
    }
}

#[derive(Debug, Clone, Copy)]
pub struct OperatorTag;
impl TokenKindTag for OperatorTag {
    fn kind_name() -> &'static str {
        "operator"
    }
    fn zed_capture() -> &'static str {
        "operator"
    }
}

#[derive(Debug, Clone, Copy)]
pub struct LiteralTag;
impl TokenKindTag for LiteralTag {
    fn kind_name() -> &'static str {
        "literal"
    }
    fn zed_capture() -> &'static str {
        "number"
    }
}

#[derive(Debug, Clone, Copy)]
pub struct CommentTag;
impl TokenKindTag for CommentTag {
    fn kind_name() -> &'static str {
        "comment"
    }
    fn zed_capture() -> &'static str {
        "comment"
    }
}

#[derive(Debug, Clone, PartialEq, Eq)]
pub struct GadtToken<K: TokenKindTag> {
    pub text: String,
    pub line: u32,
    pub column: u32,
    _kind: PhantomData<K>,
}

impl<K: TokenKindTag> GadtToken<K> {
    pub fn new(text: impl Into<String>, line: u32, column: u32) -> Self {
        Self {
            text: text.into(),
            line,
            column,
            _kind: PhantomData,
        }
    }

    pub fn kind(&self) -> &'static str {
        K::kind_name()
    }

    pub fn zed_capture(&self) -> &'static str {
        K::zed_capture()
    }
}

pub trait ProtocolPhase: 'static + Send + Sync {
    fn phase_name() -> &'static str;
}

pub struct Idle;
impl ProtocolPhase for Idle {
    fn phase_name() -> &'static str {
        "idle"
    }
}

pub struct Connected;
impl ProtocolPhase for Connected {
    fn phase_name() -> &'static str {
        "connected"
    }
}

pub struct SessionActive;
impl ProtocolPhase for SessionActive {
    fn phase_name() -> &'static str {
        "session_active"
    }
}

pub struct ProtocolClient<P: ProtocolPhase> {
    pub server_uri: String,
    pub session_id: Option<String>,
    _phase: PhantomData<P>,
}

impl ProtocolClient<Idle> {
    pub fn new(server_uri: impl Into<String>) -> Self {
        Self {
            server_uri: server_uri.into(),
            session_id: None,
            _phase: PhantomData,
        }
    }

    pub fn connect(self) -> ProtocolClient<Connected> {
        ProtocolClient {
            server_uri: self.server_uri,
            session_id: None,
            _phase: PhantomData,
        }
    }
}

impl ProtocolClient<Connected> {
    pub fn start_session(self, session_id: impl Into<String>) -> ProtocolClient<SessionActive> {
        ProtocolClient {
            server_uri: self.server_uri,
            session_id: Some(session_id.into()),
            _phase: PhantomData,
        }
    }
}

impl ProtocolClient<SessionActive> {
    pub fn disconnect(self) -> ProtocolClient<Idle> {
        ProtocolClient {
            server_uri: self.server_uri,
            session_id: None,
            _phase: PhantomData,
        }
    }
}


pub trait AnyTokenView: Send + Sync {
    fn kind(&self) -> &'static str;
    fn zed_capture(&self) -> &'static str;
    fn text(&self) -> &str;
    fn line(&self) -> u32;
    fn column(&self) -> u32;
}

impl<K: TokenKindTag> AnyTokenView for GadtToken<K> {
    fn kind(&self) -> &'static str {
        K::kind_name()
    }

    fn zed_capture(&self) -> &'static str {
        K::zed_capture()
    }

    fn text(&self) -> &str {
        &self.text
    }

    fn line(&self) -> u32 {
        self.line
    }

    fn column(&self) -> u32 {
        self.column
    }
}

pub struct ExistentialToken {
    inner: Box<dyn AnyTokenView>,
    _witness: PhantomData<()>,
}

impl ExistentialToken {
    pub fn pack<K: TokenKindTag>(token: GadtToken<K>) -> Self {
        Self {
            inner: Box::new(token),
            _witness: PhantomData,
        }
    }

    pub fn kind(&self) -> &'static str {
        self.inner.kind()
    }

    pub fn zed_capture(&self) -> &'static str {
        self.inner.zed_capture()
    }

    pub fn text(&self) -> &str {
        self.inner.text()
    }

    pub fn line(&self) -> u32 {
        self.inner.line()
    }

    pub fn column(&self) -> u32 {
        self.inner.column()
    }
}


pub trait Hkt: 'static {
    type Applied<T>;
}

pub struct Brand<F: Hkt, T> {
    _family: PhantomData<F>,
    _elem: PhantomData<T>,
}

pub trait Functor: Hkt {
    fn fmap<A, B, Func>(fa: Self::Applied<A>, f: Func) -> Self::Applied<B>
    where
        Func: FnMut(A) -> B;
}

pub trait Applicative: Functor {
    fn pure<A>(val: A) -> Self::Applied<A>;
    fn zip_with<A, B, C, Func>(
        fa: Self::Applied<A>,
        fb: Self::Applied<B>,
        f: Func,
    ) -> Self::Applied<C>
    where
        Func: FnMut(A, B) -> C;
}

pub trait Monad: Applicative {
    fn flat_map<A, B, Func>(fa: Self::Applied<A>, f: Func) -> Self::Applied<B>
    where
        Func: FnMut(A) -> Self::Applied<B>;
}


pub struct VecFamily;
impl Hkt for VecFamily {
    type Applied<T> = Vec<T>;
}

impl Functor for VecFamily {
    fn fmap<A, B, Func>(fa: Vec<A>, f: Func) -> Vec<B>
    where
        Func: FnMut(A) -> B,
    {
        fa.into_iter().map(f).collect()
    }
}

impl Applicative for VecFamily {
    fn pure<A>(val: A) -> Vec<A> {
        vec![val]
    }

    fn zip_with<A, B, C, Func>(fa: Vec<A>, fb: Vec<B>, mut f: Func) -> Vec<C>
    where
        Func: FnMut(A, B) -> C,
    {
        fa.into_iter().zip(fb).map(|(a, b)| f(a, b)).collect()
    }
}

impl Monad for VecFamily {
    fn flat_map<A, B, Func>(fa: Vec<A>, f: Func) -> Vec<B>
    where
        Func: FnMut(A) -> Vec<B>,
    {
        fa.into_iter().flat_map(f).collect()
    }
}

pub struct OptionFamily;
impl Hkt for OptionFamily {
    type Applied<T> = Option<T>;
}

impl Functor for OptionFamily {
    fn fmap<A, B, Func>(fa: Option<A>, f: Func) -> Option<B>
    where
        Func: FnMut(A) -> B,
    {
        fa.map(f)
    }
}

impl Applicative for OptionFamily {
    fn pure<A>(val: A) -> Option<A> {
        Some(val)
    }

    fn zip_with<A, B, C, Func>(fa: Option<A>, fb: Option<B>, mut f: Func) -> Option<C>
    where
        Func: FnMut(A, B) -> C,
    {
        fa.zip(fb).map(|(a, b)| f(a, b))
    }
}

impl Monad for OptionFamily {
    fn flat_map<A, B, Func>(fa: Option<A>, f: Func) -> Option<B>
    where
        Func: FnMut(A) -> Option<B>,
    {
        fa.and_then(f)
    }
}


#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test_gadt_evaluation() {
        let one = GadtExpr::lit_int(1);
        let two = GadtExpr::lit_int(2);
        let three = GadtExpr::add(one, two);
        assert_eq!(three.eval(), 3);

        let six = GadtExpr::mul(three, GadtExpr::lit_int(2));
        assert_eq!(six.eval(), 6);

        let is_six = GadtExpr::equals(six, GadtExpr::lit_int(6));
        assert!(is_six.eval());

        let result_str = GadtExpr::if_then_else(
            is_six,
            GadtExpr::lit_string("equals six"),
            GadtExpr::lit_string("not six"),
        );
        assert_eq!(result_str.eval(), "equals six");

        let other = GadtExpr::if_then_else(
            GadtExpr::lit_bool(false),
            GadtExpr::lit_string("taken"),
            GadtExpr::lit_string("else"),
        );
        assert_eq!(other.eval(), "else");
        assert_eq!(GadtExpr::lit_float(1.5).eval(), 1.5);
    }

    #[test]
    fn test_token_gadt_and_existential() {
        let kw: GadtToken<KeywordTag> = GadtToken::new("inl", 1, 1);
        assert_eq!(kw.kind(), "keyword");
        assert_eq!(kw.zed_capture(), "keyword");

        let op: GadtToken<OperatorTag> = GadtToken::new("->", 1, 5);
        assert_eq!(op.kind(), "operator");

        let stream: Vec<ExistentialToken> =
            vec![ExistentialToken::pack(kw), ExistentialToken::pack(op)];

        assert_eq!(stream.len(), 2);
        assert_eq!(stream[0].text(), "inl");
        assert_eq!(stream[0].kind(), "keyword");
        assert_eq!(stream[1].text(), "->");
        assert_eq!(stream[1].kind(), "operator");
    }

    #[test]
    fn test_protocol_state_machine() {
        let client = ProtocolClient::new("http://localhost:8000");
        let connected = client.connect();
        let session = connected.start_session("session_123");
        assert_eq!(session.session_id.as_deref(), Some("session_123"));
        let idle = session.disconnect();
        assert_eq!(idle.session_id, None);
    }

    #[test]
    fn test_hkt_functor_and_monad() {
        let numbers = vec![1, 2, 3, 4];
        let doubled = VecFamily::fmap(numbers, |x| x * 2);
        assert_eq!(doubled, vec![2, 4, 6, 8]);

        let zipped = VecFamily::zip_with(doubled.clone(), vec![1, 1, 1, 1], |a, b| a + b);
        assert_eq!(zipped, vec![3, 5, 7, 9]);

        let flat = VecFamily::flat_map(vec![1, 2], |x| vec![x, x * 10]);
        assert_eq!(flat, vec![1, 10, 2, 20]);

        let opt = Some(42);
        let mapped_opt = OptionFamily::fmap(opt, |x| x.to_string());
        assert_eq!(mapped_opt, Some("42".to_string()));
    }
}
