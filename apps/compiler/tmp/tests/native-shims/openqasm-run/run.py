# Classical simulator for the OpenQASM subset emitted by codegenOpenQasm.
# Integer wrap is 32-bit. Division and remainder go toward zero, matching C.
# Signed >> is arithmetic and unsigned >> is logical. The shift count keeps
# its low 5 bits. float[32] rounds after every operation. The process prints
# nothing and exits with spiral_io.

import math
import struct
import sys

MASK32 = 0xFFFFFFFF
SIGN32 = 0x80000000


class QasmError(Exception):
    pass


_BREAK = object()
_CONT = object()


class _Ret:
    __slots__ = ('value',)

    def __init__(self, value):
        self.value = value


def fail(msg):
    raise QasmError(msg)


def as_i32(n):
    n &= MASK32
    if n >= SIGN32:
        n -= 0x100000000
    return n


def as_u32(n):
    return n & MASK32


def f32(n):
    return struct.unpack('<f', struct.pack('<f', float(n)))[0]


def idiv(a, b):
    if b == 0:
        fail('division by zero')
    q = abs(a) // abs(b)
    if (a < 0) != (b < 0):
        q = -q
    return q


def imod(a, b):
    return a - idiv(a, b) * b


KEYWORDS = {
    'def', 'if', 'else', 'while', 'return', 'break', 'continue', 'output',
    'true', 'false', 'int', 'uint', 'bool', 'float',
}

TWOS = {
    '-': {'>': '->'},
    '<': {'=': '<=', '<': '<<'},
    '>': {'=': '>=', '>': '>>'},
    '=': {'=': '=='},
    '!': {'=': '!='},
    '&': {'&': '&&'},
    '|': {'|': '||'},
}

SINGLES = set('(){}[];,=!~+-*/%<>&|^')

BIN_PREC = {
    '||': 1,
    '&&': 2,
    '|': 3,
    '^': 4,
    '&': 5,
    '==': 6, '!=': 6,
    '<': 7, '<=': 7, '>': 7, '>=': 7,
    '<<': 8, '>>': 8,
    '+': 9, '-': 9,
    '*': 10, '/': 10, '%': 10,
}


def lex(text):
    tokens = []
    n = len(text)
    i = 0
    line = 1
    while i < n:
        c = text[i]
        if c in ' \t\r':
            i += 1
            continue
        if c == '\n':
            line += 1
            i += 1
            continue
        if c == '/' and i + 1 < n and text[i + 1] == '/':
            i += 2
            while i < n and text[i] != '\n':
                i += 1
            continue
        if c.isalpha() or c == '_':
            j = i + 1
            while j < n and (text[j].isalnum() or text[j] == '_'):
                j += 1
            word = text[i:j]
            if word in KEYWORDS:
                tokens.append((word, None, line))
            else:
                tokens.append(('ident', word, line))
            i = j
            continue
        if c.isdigit():
            j = i + 1
            while j < n and text[j].isdigit():
                j += 1
            is_real = False
            if j < n and text[j] == '.' and j + 1 < n and text[j + 1].isdigit():
                is_real = True
                j += 1
                while j < n and text[j].isdigit():
                    j += 1
            if j < n and text[j] in 'eE':
                k = j + 1
                if k < n and text[k] in '+-':
                    k += 1
                if k < n and text[k].isdigit():
                    is_real = True
                    while k < n and text[k].isdigit():
                        k += 1
                    j = k
            raw = text[i:j]
            if is_real:
                tokens.append(('real', float(raw), line))
            else:
                tokens.append(('num', int(raw), line))
            i = j
            continue
        if c in TWOS and i + 1 < n and text[i + 1] in TWOS[c]:
            kind = TWOS[c][text[i + 1]]
            tokens.append((kind, None, line))
            i += 2
            continue
        if c in SINGLES:
            tokens.append((c, None, line))
            i += 1
            continue
        fail(f'line {line}: unexpected character {c!r}')
    tokens.append(('eof', None, line))
    return tokens


class Parser:
    def __init__(self, tokens):
        self.tokens = tokens
        self.i = 0
        self.cur = tokens[0]

    def pop(self):
        tok = self.cur
        self.i += 1
        self.cur = self.tokens[self.i]
        return tok

    def match(self, kind):
        if self.cur[0] == kind:
            self.pop()
            return True
        return False

    def expect(self, kind):
        if self.cur[0] != kind:
            fail(f'line {self.cur[2]}: expected {kind}, got {self.cur[0]}')
        return self.pop()

    def expect_ident(self):
        if self.cur[0] != 'ident':
            fail(f'line {self.cur[2]}: expected a name, got {self.cur[0]}')
        return self.pop()[1]

    def parse_type(self):
        if self.match('bool'):
            return 'bool'
        if self.match('int'):
            self.expect('[')
            width = self.expect('num')[1]
            self.expect(']')
            if width != 32:
                fail(f'line {self.cur[2]}: only int[32] is supported')
            return 'i32'
        if self.match('uint'):
            self.expect('[')
            width = self.expect('num')[1]
            self.expect(']')
            if width != 32:
                fail(f'line {self.cur[2]}: only uint[32] is supported')
            return 'u32'
        if self.match('float'):
            self.expect('[')
            width = self.expect('num')[1]
            self.expect(']')
            if width != 32:
                fail(f'line {self.cur[2]}: only float[32] is supported')
            return 'f32'
        fail(f'line {self.cur[2]}: expected a type, got {self.cur[0]}')

    def parse_ret(self):
        # A return type is a single type, or a flattened tuple (T1, T2, ...).
        if self.match('('):
            tys = [self.parse_type()]
            while self.match(','):
                tys.append(self.parse_type())
            self.expect(')')
            if len(tys) < 2:
                fail('a parenthesized return type needs two or more values')
            return tuple(tys)
        return self.parse_type()

    def parse_block(self):
        self.expect('{')
        stmts = []
        while self.cur[0] != '}':
            if self.cur[0] == 'eof':
                fail(f'line {self.cur[2]}: unclosed block')
            stmts.append(self.parse_stmt())
        self.pop()
        return stmts

    def parse_func(self):
        name = self.expect_ident()
        self.expect('(')
        params = []
        if not self.match(')'):
            while True:
                ty = self.parse_type()
                params.append((ty, self.expect_ident()))
                if self.match(','):
                    continue
                self.expect(')')
                break
        ret = self.parse_ret() if self.match('->') else None
        body = self.parse_block()
        return (name, params, ret, body)

    def parse_stmt(self):
        if self.match('if'):
            self.expect('(')
            cond = self.parse_expr()
            self.expect(')')
            then = self.parse_block()
            els = self.parse_block() if self.match('else') else []
            return ('if', cond, then, els)
        if self.match('while'):
            self.expect('(')
            cond = self.parse_expr()
            self.expect(')')
            return ('while', cond, self.parse_block())
        if self.match('return'):
            if self.match(';'):
                return ('return', None)
            values = [self.parse_expr()]
            while self.match(','):
                values.append(self.parse_expr())
            self.expect(';')
            if len(values) == 1:
                return ('return', values[0])
            return ('return', ('tuple', values))
        if self.match('break'):
            self.expect(';')
            return ('break',)
        if self.match('continue'):
            self.expect(';')
            return ('continue',)
        if self.cur[0] in ('int', 'uint', 'bool', 'float'):
            ty = self.parse_type()
            name = self.expect_ident()
            self.expect('=')
            expr = self.parse_expr()
            self.expect(';')
            return ('let', ty, name, expr)
        if self.cur[0] == 'ident' and self.tokens[self.i + 1][0] == ',':
            names = [self.pop()[1]]
            while self.match(','):
                names.append(self.expect_ident())
            self.expect('=')
            expr = self.parse_expr()
            self.expect(';')
            return ('set_multi', names, expr)
        if self.cur[0] == 'ident' and self.tokens[self.i + 1][0] == '=':
            name = self.pop()[1]
            self.pop()
            expr = self.parse_expr()
            self.expect(';')
            return ('set', name, expr)
        expr = self.parse_expr()
        self.expect(';')
        return ('expr', expr)

    def parse_expr(self, min_prec=0):
        left = self.parse_unary()
        while self.cur[0] in BIN_PREC and BIN_PREC[self.cur[0]] >= min_prec:
            op = self.pop()[0]
            right = self.parse_expr(BIN_PREC[op] + 1)
            left = ('bin', op, left, right)
        return left

    def parse_unary(self):
        if self.match('!'):
            return ('not', self.parse_unary())
        if self.match('~'):
            return ('bitnot', self.parse_unary())
        if self.match('-'):
            return ('neg', self.parse_unary())
        if self.match('+'):
            return ('pos', self.parse_unary())
        return self.parse_primary()

    def parse_primary(self):
        if self.match('('):
            if self.match('if'):
                cond = self.parse_expr()
                self.expect('{')
                yes = self.parse_expr()
                self.expect('}')
                self.expect('else')
                self.expect('{')
                no = self.parse_expr()
                self.expect('}')
                self.expect(')')
                return ('ifexpr', cond, yes, no)
            expr = self.parse_expr()
            self.expect(')')
            return expr
        if self.cur[0] in ('int', 'uint', 'float') and self.tokens[self.i + 1][0] == '[':
            ty = self.parse_type()
            self.expect('(')
            expr = self.parse_expr()
            self.expect(')')
            return ('cast', ty, expr)
        if self.match('true'):
            return ('bool', True)
        if self.match('false'):
            return ('bool', False)
        if self.cur[0] == 'ident':
            name = self.pop()[1]
            if self.match('('):
                args = []
                if not self.match(')'):
                    while True:
                        args.append(self.parse_expr())
                        if self.match(','):
                            continue
                        self.expect(')')
                        break
                return ('call', name, args)
            return ('var', name)
        if self.cur[0] == 'num':
            return ('num', self.pop()[1])
        if self.cur[0] == 'real':
            return ('real', self.pop()[1])
        fail(f'line {self.cur[2]}: expected an expression, got {self.cur[0]}')

    def parse_program(self):
        funcs = []
        tops = []
        while self.cur[0] != 'eof':
            if self.cur[0] == 'ident' and self.cur[1] == 'OPENQASM':
                self.pop()
                if self.cur[0] in ('num', 'real'):
                    self.pop()
                self.expect(';')
                continue
            if self.match('def'):
                funcs.append(self.parse_func())
                continue
            if self.match('output'):
                ty = self.parse_type()
                name = self.expect_ident()
                self.expect(';')
                tops.append(('output', ty, name))
                continue
            tops.append(self.parse_stmt())
        return funcs, tops


COMPARE = {
    '==': lambda a, b: a == b,
    '!=': lambda a, b: a != b,
    '<': lambda a, b: a < b,
    '<=': lambda a, b: a <= b,
    '>': lambda a, b: a > b,
    '>=': lambda a, b: a >= b,
}


def float_div(a, b):
    if b == 0.0:
        fail('division by zero')
    return f32(a / b)


def float_mod(a, b):
    if b == 0.0:
        fail('division by zero')
    return f32(math.fmod(a, b))


FLOAT_OPS = {
    '+': lambda a, b: f32(a + b),
    '-': lambda a, b: f32(a - b),
    '*': lambda a, b: f32(a * b),
    '/': float_div,
    '%': float_mod,
}

INT_OPS = {
    '+': lambda a, b: a + b,
    '-': lambda a, b: a - b,
    '*': lambda a, b: a * b,
    '/': idiv,
    '%': imod,
    '&': lambda a, b: a & b,
    '|': lambda a, b: a | b,
    '^': lambda a, b: a ^ b,
    '<<': lambda a, b: a << (b & 31),
    '>>': lambda a, b: a >> (b & 31),
}

NARROW = {'i32': as_i32, 'u32': as_u32}

DYN = 'dyn'
TOP = 'top'


class Tagged:
    __slots__ = ('kind', 'n')

    def __init__(self, kind, n):
        self.kind = kind
        self.n = n


def missing_kind(value):
    return AttributeError(f"'{type(value).__name__}' object has no attribute 'kind'")


def kind_of(value):
    if isinstance(value, Tagged):
        return value.kind
    raise missing_kind(value)


def to_int_checked(narrow, target):
    def convert(x):
        if math.isnan(x) or math.isinf(x):
            fail(f'non-finite float to {target}')
        return narrow(int(x))
    return convert


def converter(source, target):
    if source is None:
        fail('missing value')
    if isinstance(source, tuple):
        if source == target:
            return None
        raise missing_kind(())
    if source == target:
        return None
    if target in ('i32', 'u32'):
        if source in ('i32', 'u32', 'raw'):
            return NARROW[target]
        if source == 'f32':
            return to_int_checked(NARROW[target], 'int' if target == 'i32' else 'uint')
        fail(f"cannot convert {source} to {'int[32]' if target == 'i32' else 'uint[32]'}")
    if target == 'f32':
        if source == 'bool':
            fail('cannot convert bool to float[32]')
        return lambda x: f32(x)
    if target == 'bool':
        fail(f'cannot convert {source} to bool')
    fail(f'unknown type {target}')


def raising(error, *before):
    def run(env):
        for fn in before:
            fn(env)
        raise error
    return run


def failing(message, *before):
    return raising(QasmError(message), *before)


def runtime_converter(source, target):
    try:
        return converter(source, target)
    except Exception as exc:
        def raise_it(x):
            raise exc
        return raise_it


def dyn_coerce(value, target):
    if value is None:
        fail('missing value')
    kind = kind_of(value)
    convert = converter(kind, target)
    return value.n if convert is None else convert(value.n)


def constant(value):
    fn = lambda env: value
    fn.constant = value
    return fn


def coerced(kind, fn, target):
    if kind == DYN:
        return lambda env: dyn_coerce(fn(env), target)
    try:
        convert = converter(kind, target)
    except Exception as exc:
        return raising(exc, fn)
    if convert is None:
        return fn
    if hasattr(fn, 'constant'):
        try:
            return constant(convert(fn.constant))
        except Exception:
            pass
    return lambda env: convert(fn(env))


def tagger(kind, fn):
    if kind == DYN or kind is None or isinstance(kind, tuple):
        return fn
    return lambda env: Tagged(kind, fn(env))


def need_bool(value):
    kind = kind_of(value)
    if kind != 'bool':
        fail(f'expected bool, got {kind}')
    return value.n


def bool_test(kind, fn):
    if kind == 'bool':
        return fn
    if kind == DYN or kind is None or isinstance(kind, tuple):
        return lambda env: need_bool(fn(env))
    return failing(f'expected bool, got {kind}', fn)


def static_scalar(kind):
    return kind in ('i32', 'u32', 'f32', 'bool', 'raw')


def static_unify(ka, kb):
    if ka == kb and ka != 'raw':
        return ka
    if ka == 'f32' or kb == 'f32':
        converter(ka, 'f32')
        converter(kb, 'f32')
        return 'f32'
    if ka == 'bool' or kb == 'bool':
        fail('bool mixed with a number')
    if (ka == 'u32' and kb == 'i32') or (ka == 'i32' and kb == 'u32'):
        fail('mixed signedness')
    if ka == 'u32' or kb == 'u32':
        return 'u32'
    return 'i32'


def dyn_unify(a, b):
    if kind_of(a) == 'f32' or kind_of(b) == 'f32':
        return dyn_coerce(a, 'f32'), dyn_coerce(b, 'f32'), 'f32'
    ka, kb = a.kind, b.kind
    if ka == 'bool' or kb == 'bool':
        if ka == kb:
            return a.n, b.n, 'bool'
        fail('bool mixed with a number')
    if (ka == 'u32' and kb == 'i32') or (ka == 'i32' and kb == 'u32'):
        fail('mixed signedness')
    if ka == 'u32' or kb == 'u32':
        return dyn_coerce(a, 'u32'), dyn_coerce(b, 'u32'), 'u32'
    return dyn_coerce(a, 'i32'), dyn_coerce(b, 'i32'), 'i32'


def dyn_bin(op, a, b):
    x, y, kind = dyn_unify(a, b)
    compare = COMPARE.get(op)
    if compare is not None:
        if kind == 'bool' and op not in ('==', '!='):
            fail(f'{op} on bool')
        return Tagged('bool', compare(x, y))
    if kind == 'bool':
        fail(f'{op} on bool')
    if kind == 'f32':
        float_op = FLOAT_OPS.get(op)
        if float_op is None:
            fail(f'{op} on float[32]')
        return Tagged('f32', float_op(x, y))
    return Tagged(kind, NARROW[kind](INT_OPS[op](x, y)))


def dyn_unary(op, value):
    kind = kind_of(value)
    if op == 'bitnot':
        if kind == 'raw':
            value = Tagged('i32', as_i32(value.n))
            kind = 'i32'
        if kind in ('f32', 'bool'):
            fail(f'complement of {kind}')
        return Tagged(kind, NARROW[kind](~value.n))
    if op == 'neg':
        if kind == 'raw':
            return Tagged('raw', -value.n)
        if kind == 'bool':
            fail('negation of bool')
        if kind == 'f32':
            return Tagged('f32', f32(-value.n))
        return Tagged(kind, NARROW[kind](-value.n))
    if kind == 'bool':
        fail('unary plus of bool')
    return value


def zero_raw(kind):
    if kind == 'bool':
        return False
    if kind == 'f32':
        return 0.0
    if kind in ('i32', 'u32'):
        return 0
    fail(f'unknown type {kind}')


class Machine:
    def __init__(self, funcs):
        self.signatures = {}
        for name, params, ret, body in funcs:
            if name in self.signatures:
                fail(f'duplicate function {name}')
            self.signatures[name] = (params, ret, body)
        self.bodies = {}
        for name, (params, ret, body) in self.signatures.items():
            table = {pname: ty for ty, pname in params}
            self.bodies[name] = self.block(body, table, ret)

    def expr(self, expr, table):
        kind = expr[0]
        if kind == 'num':
            return 'raw', constant(expr[1])
        if kind == 'real':
            try:
                return 'f32', constant(f32(expr[1]))
            except Exception as exc:
                return DYN, raising(exc)
        if kind == 'bool':
            return 'bool', constant(expr[1])
        if kind == 'var':
            return self.var(expr[1], table)
        if kind == 'call':
            return self.call(expr[1], expr[2], table)
        if kind == 'cast':
            source, inner = self.expr(expr[2], table)
            return expr[1], coerced(source, inner, expr[1])
        if kind == 'ifexpr':
            return self.ifexpr(expr, table)
        if kind in ('not', 'bitnot', 'neg', 'pos'):
            return self.unary(kind, expr[1], table)
        if kind == 'bin':
            return self.bin(expr[1], expr[2], expr[3], table)
        return DYN, failing(f'bad expression {kind}')

    def var(self, name, table):
        if name not in table:
            return DYN, failing(f'unbound {name}')

        def run(env):
            try:
                return env[name]
            except KeyError:
                fail(f'unbound {name}')
        return table[name], run

    def unary(self, op, operand, table):
        source, inner = self.expr(operand, table)
        if op == 'not':
            test = bool_test(source, inner)
            return 'bool', lambda env: not test(env)
        if not static_scalar(source):
            tagged = tagger(source, inner)
            return DYN, lambda env: dyn_unary(op, tagged(env))
        if op == 'bitnot':
            if source == 'raw':
                inner = coerced('raw', inner, 'i32')
                source = 'i32'
            if source in ('f32', 'bool'):
                return DYN, failing(f'complement of {source}', inner)
            narrow = NARROW[source]
            return source, lambda env: narrow(~inner(env))
        if op == 'neg':
            if source == 'raw':
                return 'raw', lambda env: -inner(env)
            if source == 'bool':
                return DYN, failing('negation of bool', inner)
            if source == 'f32':
                return 'f32', lambda env: f32(-inner(env))
            narrow = NARROW[source]
            return source, lambda env: narrow(-inner(env))
        if source == 'bool':
            return DYN, failing('unary plus of bool', inner)
        return source, inner

    def ifexpr(self, expr, table):
        cond_kind, cond = self.expr(expr[1], table)
        test = bool_test(cond_kind, cond)
        yes_kind, yes = self.expr(expr[2], table)
        no_kind, no = self.expr(expr[3], table)
        if yes_kind == no_kind and yes_kind != DYN:
            def run(env):
                if test(env):
                    return yes(env)
                return no(env)
            return yes_kind, run
        tagged_yes = tagger(yes_kind, yes)
        tagged_no = tagger(no_kind, no)

        def run_tagged(env):
            if test(env):
                return tagged_yes(env)
            return tagged_no(env)
        return DYN, run_tagged

    def bin(self, op, left_expr, right_expr, table):
        left_kind, left = self.expr(left_expr, table)
        right_kind, right = self.expr(right_expr, table)
        if op in ('&&', '||'):
            left_test = bool_test(left_kind, left)
            right_test = bool_test(right_kind, right)
            if op == '&&':
                return 'bool', lambda env: left_test(env) and right_test(env)
            return 'bool', lambda env: left_test(env) or right_test(env)
        if not (static_scalar(left_kind) and static_scalar(right_kind)):
            tagged_left = tagger(left_kind, left)
            tagged_right = tagger(right_kind, right)
            if op in COMPARE:
                return 'bool', lambda env: dyn_bin(op, tagged_left(env), tagged_right(env)).n
            return DYN, lambda env: dyn_bin(op, tagged_left(env), tagged_right(env))
        try:
            kind = static_unify(left_kind, right_kind)
        except QasmError as exc:
            return ('bool' if op in COMPARE else DYN), raising(exc, left, right)
        left = coerced(left_kind, left, kind)
        right = coerced(right_kind, right, kind)
        compare = COMPARE.get(op)
        if compare is not None:
            if kind == 'bool' and op not in ('==', '!='):
                return 'bool', failing(f'{op} on bool', left, right)
            if hasattr(right, 'constant'):
                c = right.constant
                if op == '==':
                    return 'bool', lambda env: left(env) == c
                if op == '!=':
                    return 'bool', lambda env: left(env) != c
                if op == '<':
                    return 'bool', lambda env: left(env) < c
                return 'bool', lambda env: compare(left(env), c)
            return 'bool', lambda env: compare(left(env), right(env))
        if kind == 'bool':
            return DYN, failing(f'{op} on bool', left, right)
        if kind == 'f32':
            float_op = FLOAT_OPS.get(op)
            if float_op is None:
                return DYN, failing(f'{op} on float[32]', left, right)
            return 'f32', lambda env: float_op(left(env), right(env))
        int_op = INT_OPS[op]
        narrow = NARROW[kind]
        if kind == 'i32' and op in ('+', '-'):
            if hasattr(right, 'constant'):
                c = right.constant if op == '+' else -right.constant
                return kind, lambda env: ((left(env) + c + SIGN32) & MASK32) - SIGN32
            if op == '+':
                return kind, lambda env: ((left(env) + right(env) + SIGN32) & MASK32) - SIGN32
            return kind, lambda env: ((left(env) - right(env) + SIGN32) & MASK32) - SIGN32
        if kind == 'u32' and op in ('+', '-'):
            if op == '+':
                return kind, lambda env: (left(env) + right(env)) & MASK32
            return kind, lambda env: (left(env) - right(env)) & MASK32
        return kind, lambda env: narrow(int_op(left(env), right(env)))

    def call(self, name, args, table):
        if name not in self.signatures:
            return DYN, failing(f'unknown function {name}')
        params, ret, _ = self.signatures[name]
        if len(args) != len(params):
            return DYN, failing(f'{name} expected {len(params)} arguments, got {len(args)}')
        names = [pname for _, pname in params]
        arg_fns = []
        for (ty, _), arg in zip(params, args):
            kind, fn = self.expr(arg, table)
            arg_fns.append(coerced(kind, fn, ty))
        bodies = self.bodies

        def run(env):
            local = {pname: arg(env) for pname, arg in zip(names, arg_fns)}
            sig = bodies[name](local)
            if isinstance(sig, _Ret):
                return sig.value
            if sig is not None:
                fail(f'{name} used break or continue outside a loop')
            if ret is None:
                return None
            fail(f'{name} ended without a return')
        return ret, run

    def block(self, stmts, table, ret):
        fns = [self.stmt(stmt, table, ret) for stmt in stmts]
        if len(fns) == 1:
            return fns[0]

        def run(env):
            for fn in fns:
                sig = fn(env)
                if sig is not None:
                    return sig
            return None
        return run

    def stmt(self, stmt, table, ret):
        kind = stmt[0]
        if kind == 'let':
            ty, name = stmt[1], stmt[2]
            source, inner = self.expr(stmt[3], table)
            fn = coerced(source, inner, ty)
            table[name] = ty

            def run_let(env):
                env[name] = fn(env)
            return run_let
        if kind == 'set':
            name = stmt[1]
            if name not in table:
                return failing(f'assignment to undeclared {name}')
            source, inner = self.expr(stmt[2], table)
            fn = coerced(source, inner, table[name])

            def run_set(env):
                if name not in env:
                    fail(f'assignment to undeclared {name}')
                env[name] = fn(env)
            return run_set
        if kind == 'set_multi':
            return self.set_multi(stmt[1], stmt[2], table)
        if kind == 'expr':
            _, inner = self.expr(stmt[1], table)

            def run_expr(env):
                inner(env)
            return run_expr
        if kind == 'if':
            cond_kind, cond = self.expr(stmt[1], table)
            test = bool_test(cond_kind, cond)
            then = self.block(stmt[2], table, ret)
            els = self.block(stmt[3], table, ret)

            def run_if(env):
                if test(env):
                    return then(env)
                return els(env)
            return run_if
        if kind == 'while':
            cond_kind, cond = self.expr(stmt[1], table)
            test = bool_test(cond_kind, cond)
            body = self.block(stmt[2], table, ret)

            def run_while(env):
                while test(env):
                    sig = body(env)
                    if sig is _BREAK:
                        return None
                    if sig is _CONT or sig is None:
                        continue
                    return sig
                return None
            return run_while
        if kind == 'return':
            return self.return_(stmt[1], table, ret)
        if kind == 'break':
            return lambda env: _BREAK
        if kind == 'continue':
            return lambda env: _CONT
        if kind == 'output':
            ty, name = stmt[1], stmt[2]
            table[name] = ty
            try:
                value = zero_raw(ty)
            except QasmError as exc:
                return raising(exc)

            def run_output(env):
                env[name] = value
            return run_output
        return failing(f'bad statement {kind}')

    def set_multi(self, names, value_expr, table):
        source, inner = self.expr(value_expr, table)
        if source == DYN or source is None:
            def run_checked(env):
                if not isinstance(inner(env), tuple):
                    fail('a destructuring assignment needs a tuple')
            return run_checked
        if not isinstance(source, tuple):
            return failing('a destructuring assignment needs a tuple', inner)
        if len(source) != len(names):
            return failing('tuple arity mismatch', inner)
        converters = [runtime_converter(kind, table[name]) if name in table else None for name, kind in zip(names, source)]

        def run(env):
            values = inner(env)
            for name, convert, item in zip(names, converters, values):
                if name not in env:
                    fail(f'assignment to undeclared {name}')
                env[name] = item if convert is None else convert(item)
        return run

    def return_(self, value, table, ret):
        if value is None:
            result = _Ret(None)
            if ret is not None and ret != TOP:
                return failing('returned no value')
            return lambda env: result
        if value[0] == 'tuple':
            parts = [self.expr(expr, table) for expr in value[1]]
            fns = [fn for _, fn in parts]
            values = lambda env: tuple(fn(env) for fn in fns)
            if ret == TOP:
                return lambda env: _Ret(values(env))
            if ret is None:
                return failing('returned a value from a unit function', values)
            if not isinstance(ret, tuple):
                return raising(missing_kind(()), values)
            if len(ret) != len(parts):
                return failing('tuple return arity mismatch', values)
            checks = [self.retagger(kind, ty) for (kind, _), ty in zip(parts, ret)]

            def run_parts(env):
                raw = values(env)
                return _Ret(tuple(check(item) for check, item in zip(checks, raw)))
            return run_parts
        kind, fn = self.expr(value, table)
        if ret == TOP:
            return lambda env: _Ret(fn(env))
        if ret is None:
            if kind is None:
                def run_unit(env):
                    fn(env)
                    return _Ret(None)
                return run_unit
            if kind == DYN:
                def run_dyn_unit(env):
                    if fn(env) is not None:
                        fail('returned a value from a unit function')
                    return _Ret(None)
                return run_dyn_unit
            return failing('returned a value from a unit function', fn)
        if kind is None:
            return failing('returned no value', fn)
        if isinstance(ret, tuple):
            if kind == DYN:
                def run_dyn_tuple(env):
                    item = fn(env)
                    if item is None:
                        fail('returned no value')
                    fail('tuple return arity mismatch')
                return run_dyn_tuple
            if not isinstance(kind, tuple) or len(kind) != len(ret):
                return failing('tuple return arity mismatch', fn)
            converters = [runtime_converter(source, target) for source, target in zip(kind, ret)]
            if all(convert is None for convert in converters):
                return lambda env: _Ret(fn(env))

            def run_tuple(env):
                values = fn(env)
                return _Ret(tuple(v if c is None else c(v) for c, v in zip(converters, values)))
            return run_tuple
        if kind == DYN:
            def run_dyn(env):
                item = fn(env)
                if item is None:
                    fail('returned no value')
                return _Ret(dyn_coerce(item, ret))
            return run_dyn
        fn = coerced(kind, fn, ret)
        return lambda env: _Ret(fn(env))

    def retagger(self, kind, target):
        if kind == DYN:
            return lambda item: dyn_coerce(item, target)
        convert = runtime_converter(kind, target)
        if convert is None:
            return lambda item: item
        return convert


def run_source(text):
    funcs, tops = Parser(lex(text)).parse_program()
    machine = Machine(funcs)
    table = {}
    env = {}
    for stmt in tops:
        sig = machine.stmt(stmt, table, TOP)(env)
        if sig is not None:
            fail('control transfer at the top level')
    if 'spiral_io' not in env:
        fail('missing spiral_io')
    convert = converter(table['spiral_io'], 'i32')
    io = env['spiral_io']
    return io if convert is None else convert(io)


def main(argv):
    if len(argv) == 2 and argv[1] == '--self-test':
        self_test()
        return 0
    if len(argv) != 2:
        print('qasm error: usage: run.py file.qasm', file=sys.stderr)
        return 1
    try:
        with open(argv[1], encoding='utf-8') as handle:
            text = handle.read()
        code = run_source(text)
    except QasmError as exc:
        print(f'qasm error: {exc}', file=sys.stderr)
        return 1
    except OSError as exc:
        print(f'qasm error: {exc}', file=sys.stderr)
        return 1
    except Exception as exc:
        print(f'qasm error: {type(exc).__name__}: {exc}', file=sys.stderr)
        return 1
    return code


def check(name, src, expect):
    got = run_source(src)
    if got != expect:
        fail(f'self-test {name}: got {got}, expected {expect}')


def self_test():
    check('add', '''OPENQASM 3.0;
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 6;
    int[32] v1 = 0;
    v1 = 7;
    int[32] v2 = 0;
    v2 = (v0 + v1);
    return v2;
}
output int[32] spiral_io;
spiral_io = spiral_main();
''', 13)
    check('bitwise', '''OPENQASM 3.0;
def spiral_main() -> int[32] {
    int[32] v0 = 43;
    int[32] v1 = 15;
    int[32] v2 = 2;
    int[32] v3 = 5;
    int[32] v4 = (v0 & v1);
    int[32] v5 = (v0 | v1);
    int[32] v6 = (v0 ^ v1);
    int[32] v7 = (~(v0));
    int[32] v8 = (v7 & 255);
    int[32] v9 = (1 << v3);
    int[32] v10 = (168 >> v2);
    int[32] v11 = (v4 - 11);
    int[32] v12 = (v10 + v11);
    int[32] v13 = (v5 - 47);
    int[32] v14 = (v12 + v13);
    int[32] v15 = (v6 - 36);
    int[32] v16 = (v14 + v15);
    int[32] v17 = (v8 - 212);
    int[32] v18 = (v16 + v17);
    int[32] v19 = (v9 - 32);
    int[32] v20 = (v18 + v19);
    return v20;
}
output int[32] spiral_io;
spiral_io = spiral_main();
''', 42)
    check('udiv', '''OPENQASM 3.0;
def sp_method0(uint[32] p0) -> bool {
    uint[32] v0 = p0;
    uint[32] v1 = (v0 + 5);
    uint[32] v2 = (v1 % 4);
    return (v2 == 0);
}
def spiral_main() -> int[32] {
    uint[32] v0 = 7;
    bool v1 = sp_method0(v0);
    if (v1) { return 0; } else { return 1; }
}
output int[32] spiral_io;
spiral_io = spiral_main();
''', 0)
    check('float', '''OPENQASM 3.0;
def sp_method0(float[32] p0, float[32] p1) -> float[32] {
    float[32] v0 = p0;
    float[32] v1 = p1;
    float[32] v2 = (v0 * v1);
    float[32] v3 = (v2 + 0.5);
    return v3;
}
def spiral_main() -> int[32] {
    float[32] v0 = 1.5;
    float[32] v1 = 2.0;
    float[32] v2 = sp_method0(v0, v1);
    bool v3 = (v2 >= 3.5);
    if (v3) { return 0; } else { return 1; }
}
output int[32] spiral_io;
spiral_io = spiral_main();
''', 0)
    check('neg', '''OPENQASM 3.0;
def spiral_main() -> int[32] {
    int[32] v0 = 3;
    int[32] v2 = (-(v0));
    bool v3 = (v2 <= 0);
    if (v3) {
        int[32] v5 = (v0 + (3 * 2));
        bool v6 = (v5 >= 9);
        if (v6) { return 0; } else { return 1; }
    } else { return 1; }
}
output int[32] spiral_io;
spiral_io = spiral_main();
''', 0)
    check('div', '''OPENQASM 3.0;
def spiral_main() -> int[32] {
    int[32] v0 = (-5);
    int[32] v1 = (v0 / 2);
    int[32] v2 = (v0 % 2);
    int[32] v3 = ((v1 + 2) * 10);
    return (v3 + (v2 + 1));
}
output int[32] spiral_io;
spiral_io = spiral_main();
''', 0)
    check('imin', '''OPENQASM 3.0;
def spiral_main() -> int[32] {
    int[32] v0 = (-2147483648);
    int[32] v1 = (-(v0));
    if ((v0 == v1)) { return 0; } else { return 1; }
}
output int[32] spiral_io;
spiral_io = spiral_main();
''', 0)
    check('ushr', '''OPENQASM 3.0;
def spiral_main() -> int[32] {
    uint[32] v0 = 4294967295;
    uint[32] v1 = (v0 >> 1);
    if ((v1 == 2147483647)) { return 0; } else { return 1; }
}
output int[32] spiral_io;
spiral_io = spiral_main();
''', 0)
    check('ashr', '''OPENQASM 3.0;
def spiral_main() -> int[32] {
    int[32] v0 = (-8);
    int[32] v1 = (v0 >> 1);
    if ((v1 == (-4))) { return 0; } else { return 1; }
}
output int[32] spiral_io;
spiral_io = spiral_main();
''', 0)
    check('shl', '''OPENQASM 3.0;
def spiral_main() -> int[32] {
    int[32] v0 = (1 << 31);
    if ((v0 == (-2147483648))) { return 0; } else { return 1; }
}
output int[32] spiral_io;
spiral_io = spiral_main();
''', 0)
    check('ifexpr', '''OPENQASM 3.0;
def spiral_main() -> int[32] {
    bool v0 = true;
    int[32] v1 = (if v0 { 1 } else { 0 });
    return (v1 - 1);
}
output int[32] spiral_io;
spiral_io = spiral_main();
''', 0)
    check('while', '''OPENQASM 3.0;
def sp_method0(int[32] p0) -> bool {
    int[32] v0 = p0;
    return (v0 < 10);
}
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    int[32] v1 = 0;
    while (true) {
        if (!(sp_method0(v0))) { break; }
        int[32] v3 = (v1 + v0);
        v1 = v3;
        int[32] v4 = (v0 + 1);
        v0 = v4;
    }
    return (v1 - 45);
}
output int[32] spiral_io;
spiral_io = spiral_main();
''', 0)
    check('tail', '''OPENQASM 3.0;
def sp_method1(int[32] p0, int[32] p1) -> int[32] {
    int[32] v0 = p0;
    int[32] v1 = p1;
    while (true) {
        int[32] v2 = (v0 - 1);
        int[32] v3 = (v1 + v0);
        bool v4 = (v2 == 0);
        if (v4) { return v3; } else {
            int[32] t319_2 = v2;
            int[32] t353_3 = v3;
            v0 = t319_2;
            v1 = t353_3;
            continue;
        }
    }
    return 0;
}
def spiral_main() -> int[32] {
    return (sp_method1(10, 0) - 55);
}
output int[32] spiral_io;
spiral_io = spiral_main();
''', 0)
    check('tuple_pair', '''OPENQASM 3.0;
def make(int[32] p0, int[32] p1) -> (int[32], int[32]) {
    int[32] v0 = p0;
    int[32] v1 = p1;
    return v0, v1;
}
def sum2(int[32] p0, int[32] p1) -> int[32] {
    int[32] v0 = p0;
    int[32] v1 = p1;
    return (v0 + v1);
}
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    int[32] v1 = 0;
    v0, v1 = make(1, 2);
    return (sum2(v0, v1) - 3);
}
output int[32] spiral_io;
spiral_io = spiral_main();
''', 0)
    check('tuple_nested', '''OPENQASM 3.0;
def make(int[32] p0, uint[32] p1, float[32] p2) -> (int[32], uint[32], float[32]) {
    int[32] v0 = p0;
    uint[32] v1 = p1;
    float[32] v2 = p2;
    return v0, v1, v2;
}
def take(int[32] p0, uint[32] p1, float[32] p2) -> int[32] {
    int[32] v0 = p0;
    uint[32] v1 = p1;
    float[32] v2 = p2;
    if ((v0 == 2) && (v1 == 3) && (v2 == 1.5)) { return 0; } else { return 1; }
}
def spiral_main() -> int[32] {
    int[32] a = 0;
    uint[32] b = 0;
    float[32] c = 0.0;
    a, b, c = make(2, 3, 1.5);
    return take(a, b, c);
}
output int[32] spiral_io;
spiral_io = spiral_main();
''', 0)
    check('tuple_tail', '''OPENQASM 3.0;
def step(int[32] p0, int[32] p1, int[32] p2, int[32] p3) -> (int[32], int[32], int[32]) {
    int[32] v0 = p0;
    int[32] v1 = p1;
    int[32] v2 = p2;
    int[32] v3 = p3;
    while (true) {
        bool v4 = (v0 == 0);
        if (v4) { return v1, v2, v3; } else {
            int[32] n0 = (v0 - 1);
            int[32] n1 = (v1 + 1);
            int[32] n2 = (v2 + 2);
            int[32] n3 = (v3 + 3);
            v0 = n0;
            v1 = n1;
            v2 = n2;
            v3 = n3;
            continue;
        }
    }
    return 0, 0, 0;
}
def read(int[32] p0, int[32] p1, int[32] p2) -> int[32] {
    int[32] v0 = p0;
    int[32] v1 = p1;
    int[32] v2 = p2;
    if ((v0 == 3) && (v1 == 6) && (v2 == 9)) { return 0; } else { return 1; }
}
def spiral_main() -> int[32] {
    int[32] a = 0;
    int[32] b = 0;
    int[32] c = 0;
    a, b, c = step(3, 0, 0, 0);
    return read(a, b, c);
}
output int[32] spiral_io;
spiral_io = spiral_main();
''', 0)
    import time
    src = '''OPENQASM 3.0;
def sp_method1(int[32] p0) -> int[32] {
    int[32] v0 = p0;
    while (true) {
        int[32] v1 = (v0 - 1);
        bool v2 = (v1 == 0);
        if (v2) { return 0; } else {
            int[32] t238_1 = v1;
            v0 = t238_1;
            continue;
        }
    }
    return 0;
}
def spiral_main() -> int[32] {
    return sp_method1(1000000);
}
output int[32] spiral_io;
spiral_io = spiral_main();
'''
    started = time.perf_counter()
    check('million', src, 0)
    elapsed = time.perf_counter() - started
    if elapsed > 30:
        fail(f'self-test million took {elapsed:.1f}s')
    print(f'openqasm self-test ok ({elapsed:.2f}s for 1000000)')


if __name__ == '__main__':
    sys.exit(main(sys.argv))
