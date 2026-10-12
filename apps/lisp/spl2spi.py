"""spl2spi: a Lisp surface for Spiral (.spl) -> ordinary Spiral source (.spi).

Usage: python spl2spi.py in.spl out.spi

Forms (top level):
  (nominal NAME TYPE) | (nominal (NAME p..) TYPE)      -> nominal NAME p.. = TYPE
  (type NAME TYPE)    | (type (NAME p..) TYPE)         -> type NAME p.. = TYPE
  (union [rec] (NAME p..) (Ctor [(forall a..)] TYPE)..) -> union rec NAME p.. = | Ctor :: forall a.. . TYPE
  (inl [rec] NAME [(forall a..)] ((x T)..) [RET] BODY)  -> inl rec NAME forall a.. . (x : T).. : RET = BODY
Types: (-> a b r) arrow, (tuple a b) product, (NAME args..) application.
Expressions: (then x f g) |> chain, (emit "..") $"..", (match e (PAT EXPR)..), (if c a b),
  (= a b) (+ a b) (- a b) (* a b) infix, (Ctor a b) -> Ctor (a, b), (f a b) -> f a b, () unit.
"""
import re, sys

TOKEN = re.compile(r'\s*(?:(;[^\n]*)|(\()|(\))|("(?:\\.|[^"\\])*")|([^\s()";]+))')
INFIX = {'=', '+', '-', '*', '<>', '<', '>', '<=', '>=', '&&', '||'}


def read(text):
    text = text.replace('\u201c', '"').replace('\u201d', '"')
    stack, top, pos = [], [], 0
    while pos < len(text):
        m = TOKEN.match(text, pos)
        if not m or m.end() == pos:
            if text[pos:].strip() == '':
                break
            raise SyntaxError(f'bad token at {pos}: {text[pos:pos + 20]!r}')
        pos = m.end()
        comment, lp, rp, string, atom = m.groups()
        if comment:
            continue
        if lp:
            stack.append(top); top = []
        elif rp:
            if not stack:
                raise SyntaxError(f'unbalanced ) at {pos}')
            done, top = top, stack.pop(); top.append(done)
        elif string:
            top.append(('str', string))
        elif atom:
            top.append(atom)
    if stack:
        raise SyntaxError('unbalanced (')
    return top


def is_list(x): return isinstance(x, list)
def is_str(x): return isinstance(x, tuple) and x[0] == 'str'
def is_ctor(x): return isinstance(x, str) and x[:1].isupper()


def ty(t, nested=False):
    if isinstance(t, str):
        return t
    if not t:
        return '()'
    head, args = t[0], t[1:]
    if head == '->':
        s = ' -> '.join(ty(a, True) if is_list(a) and a and a[0] == '->' else ty(a) for a in args)
    elif head == 'tuple':
        s = ' * '.join(ty(a, True) for a in args)
    else:
        s = ' '.join([head] + [ty(a, True) for a in args])
    return f'({s})' if nested and (head in ('->', 'tuple') or args) else s


def pat(p):
    if isinstance(p, str):
        return p
    head, args = p[0], p[1:]
    if not args:
        return head
    if len(args) == 1:
        return f'{head} {pat(args[0])}'
    return f'{head} ({", ".join(pat(a) for a in args)})'


def expr(e, ind, nested=False):
    if isinstance(e, str):
        return e
    if is_str(e):
        return e[1]
    if not e:
        return '()'
    head, args = e[0], e[1:]
    if head == 'emit':
        return '$' + args[0][1]
    if head == 'then':
        s = ' |> '.join(expr(a, ind, True) for a in args)
    elif head == 'if':
        s = f'if {expr(args[0], ind)} then {expr(args[1], ind)} else {expr(args[2], ind)}'
    elif head == 'match':
        pad = ' ' * ind
        arms = '\n'.join(f'{pad}| {pat(a[0])} => {expr(a[1], ind + 4)}' for a in args[1:])
        s = f'match {expr(args[0], ind)} with\n{arms}'
        return f'(\n{" " * (ind + 4)}{s})' if nested else s
    elif head in INFIX and len(args) == 2:
        s = f'{expr(args[0], ind, True)} {head} {expr(args[1], ind, True)}'
    elif is_ctor(head):
        if not args:
            return head
        if len(args) == 1:
            s = f'{head} {expr(args[0], ind, True)}'
        else:
            s = f'{head} ({", ".join(expr(a, ind) for a in args)})'
    else:
        s = ' '.join([expr(head, ind, True)] + [expr(a, ind, True) for a in args])
    return f'({s})' if nested else s


def name_params(x):
    return (x, []) if isinstance(x, str) else (x[0], x[1:])


def forall_clause(xs):
    if xs and is_list(xs[0]) and xs[0] and xs[0][0] == 'forall':
        return f'forall {" ".join(xs[0][1:])}. ', xs[1:]
    return '', xs


def top_form(f):
    head, args = f[0], f[1:]
    if head in ('nominal', 'type'):
        name, params = name_params(args[0])
        return f'{head} {" ".join([name] + params)} = {ty(args[1])}'
    if head == 'union':
        rec = args[0] == 'rec'
        if rec:
            args = args[1:]
        name, params = name_params(args[0])
        lines = [f'union {"rec " if rec else ""}{" ".join([name] + params)} =']
        for c in args[1:]:
            fa, rest = forall_clause(c[1:])
            lines.append(f'    | {c[0]} :: {fa}{ty(rest[0])}')
        return '\n'.join(lines)
    if head == 'inl':
        rec = args[0] == 'rec'
        if rec:
            args = args[1:]
        name, rest = args[0], args[1:]
        fa, rest = forall_clause(rest)
        params, rest = rest[0], rest[1:]
        ps = ' '.join(f'({p[0]} : {ty(p[1])})' for p in params) if params else '()'
        ret, body = (rest[0], rest[1]) if len(rest) == 2 else (None, rest[0])
        sig = f'inl {"rec " if rec else ""}{name} {fa}{ps}' + (f' : {ty(ret)}' if ret is not None else '')
        return f'{sig} =\n    {expr(body, 4)}'
    raise SyntaxError(f'unknown top-level form {head!r}')


def main():
    src, dst = sys.argv[1], sys.argv[2]
    forms = read(open(src, encoding='utf-8').read())
    out = '\n\n'.join(top_form(f) for f in forms) + '\n'
    with open(dst, 'w', encoding='utf-8', newline='\n') as h:
        h.write(out)
    print(f'{len(forms)} forms -> {dst}')


if __name__ == '__main__':
    main()
