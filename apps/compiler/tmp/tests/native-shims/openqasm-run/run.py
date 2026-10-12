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


class Val:
    __slots__ = ('kind', 'n')

    def __init__(self, kind, n):
        self.kind = kind
        self.n = n


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


def wrap(kind, n):
    if kind == 'i32':
        return as_i32(n)
    if kind == 'u32':
        return as_u32(n)
    fail(f'wrap of {kind}')


def coerce(val, kind):
    if val is None:
        fail('missing value')
    if val.kind == kind:
        return val
    if kind == 'i32':
        if val.kind in ('i32', 'u32', 'raw'):
            return Val('i32', as_i32(val.n))
        if val.kind == 'f32':
            if math.isnan(val.n) or math.isinf(val.n):
                fail('non-finite float to int')
            return Val('i32', as_i32(int(val.n)))
        fail(f'cannot convert {val.kind} to int[32]')
    if kind == 'u32':
        if val.kind in ('i32', 'u32', 'raw'):
            return Val('u32', as_u32(val.n))
        if val.kind == 'f32':
            if math.isnan(val.n) or math.isinf(val.n):
                fail('non-finite float to uint')
            return Val('u32', as_u32(int(val.n)))
        fail(f'cannot convert {val.kind} to uint[32]')
    if kind == 'f32':
        if val.kind == 'bool':
            fail('cannot convert bool to float[32]')
        return Val('f32', f32(val.n))
    if kind == 'bool':
        fail(f'cannot convert {val.kind} to bool')
    fail(f'unknown type {kind}')


def need_bool(val):
    if val.kind != 'bool':
        fail(f'expected bool, got {val.kind}')
    return val.n


def zero(kind):
    if kind == 'bool':
        return Val('bool', False)
    if kind == 'f32':
        return Val('f32', 0.0)
    if kind == 'u32':
        return Val('u32', 0)
    if kind == 'i32':
        return Val('i32', 0)
    fail(f'unknown type {kind}')


def coerce_ret(value, ret):
    # A return type is either None (unit), a kind string, or a tuple of kinds.
    if ret is None:
        if value is not None:
            fail('returned a value from a unit function')
        return None
    if isinstance(ret, tuple):
        if value is None:
            fail('returned no value')
        if not isinstance(value, tuple) or len(value) != len(ret):
            fail('tuple return arity mismatch')
        return tuple(coerce(v, t) for v, t in zip(value, ret))
    if value is None:
        fail('returned no value')
    return coerce(value, ret)


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


def unify(a, b):
    if a.kind == 'f32' or b.kind == 'f32':
        return coerce(a, 'f32'), coerce(b, 'f32'), 'f32'
    if a.kind == 'bool' or b.kind == 'bool':
        if a.kind == b.kind:
            return a, b, 'bool'
        fail('bool mixed with a number')
    if (a.kind == 'u32' and b.kind == 'i32') or (a.kind == 'i32' and b.kind == 'u32'):
        fail('mixed signedness')
    if a.kind == 'u32' or b.kind == 'u32':
        return coerce(a, 'u32'), coerce(b, 'u32'), 'u32'
    return coerce(a, 'i32'), coerce(b, 'i32'), 'i32'


class Machine:
    def __init__(self, funcs):
        self.funcs = {}
        for name, params, ret, body in funcs:
            if name in self.funcs:
                fail(f'duplicate function {name}')
            self.funcs[name] = (params, ret, body)

    def eval_expr(self, expr, env):
        kind = expr[0]
        if kind == 'num':
            return Val('raw', expr[1])
        if kind == 'real':
            return Val('f32', f32(expr[1]))
        if kind == 'bool':
            return Val('bool', expr[1])
        if kind == 'var':
            try:
                return env[expr[1]]
            except KeyError:
                fail(f'unbound {expr[1]}')
        if kind == 'call':
            return self.call(expr[1], expr[2], env)
        if kind == 'cast':
            return coerce(self.eval_expr(expr[2], env), expr[1])
        if kind == 'ifexpr':
            if need_bool(self.eval_expr(expr[1], env)):
                return self.eval_expr(expr[2], env)
            return self.eval_expr(expr[3], env)
        if kind == 'not':
            return Val('bool', not need_bool(self.eval_expr(expr[1], env)))
        if kind == 'bitnot':
            val = self.eval_expr(expr[1], env)
            if val.kind == 'raw':
                val = coerce(val, 'i32')
            if val.kind == 'f32' or val.kind == 'bool':
                fail(f'complement of {val.kind}')
            return Val(val.kind, wrap(val.kind, ~val.n))
        if kind == 'neg':
            val = self.eval_expr(expr[1], env)
            if val.kind == 'raw':
                return Val('raw', -val.n)
            if val.kind == 'bool':
                fail('negation of bool')
            if val.kind == 'f32':
                return Val('f32', f32(-val.n))
            return Val(val.kind, wrap(val.kind, -val.n))
        if kind == 'pos':
            val = self.eval_expr(expr[1], env)
            if val.kind == 'bool':
                fail('unary plus of bool')
            return val
        if kind == 'bin':
            return self.eval_bin(expr[1], expr[2], expr[3], env)
        fail(f'bad expression {kind}')

    def eval_bin(self, op, left, right, env):
        if op == '&&':
            if not need_bool(self.eval_expr(left, env)):
                return Val('bool', False)
            return Val('bool', need_bool(self.eval_expr(right, env)))
        if op == '||':
            if need_bool(self.eval_expr(left, env)):
                return Val('bool', True)
            return Val('bool', need_bool(self.eval_expr(right, env)))
        a, b, kind = unify(self.eval_expr(left, env), self.eval_expr(right, env))
        if op in ('==', '!=', '<', '<=', '>', '>='):
            if kind == 'bool' and op not in ('==', '!='):
                fail(f'{op} on bool')
            return Val('bool', self.compare(op, a.n, b.n))
        if kind == 'bool':
            fail(f'{op} on bool')
        if kind == 'f32':
            return Val('f32', self.float_op(op, a.n, b.n))
        return Val(kind, self.int_op(op, a.n, b.n, kind))

    def compare(self, op, a, b):
        if op == '==':
            return a == b
        if op == '!=':
            return a != b
        if op == '<':
            return a < b
        if op == '<=':
            return a <= b
        if op == '>':
            return a > b
        return a >= b

    def float_op(self, op, a, b):
        if op == '+':
            return f32(a + b)
        if op == '-':
            return f32(a - b)
        if op == '*':
            return f32(a * b)
        if op == '/':
            if b == 0.0:
                fail('division by zero')
            return f32(a / b)
        if op == '%':
            if b == 0.0:
                fail('division by zero')
            return f32(math.fmod(a, b))
        fail(f'{op} on float[32]')

    def int_op(self, op, a, b, kind):
        if op == '+':
            return wrap(kind, a + b)
        if op == '-':
            return wrap(kind, a - b)
        if op == '*':
            return wrap(kind, a * b)
        if op == '/':
            return wrap(kind, idiv(a, b))
        if op == '%':
            return wrap(kind, imod(a, b))
        if op == '&':
            return wrap(kind, a & b)
        if op == '|':
            return wrap(kind, a | b)
        if op == '^':
            return wrap(kind, a ^ b)
        count = b & 31
        if op == '<<':
            return wrap(kind, a << count)
        if op == '>>':
            return wrap(kind, a >> count)
        fail(f'{op} on {kind}')

    def call(self, name, args, env):
        try:
            params, ret, body = self.funcs[name]
        except KeyError:
            fail(f'unknown function {name}')
        if len(args) != len(params):
            fail(f'{name} expected {len(params)} arguments, got {len(args)}')
        local = {}
        for (ty, pname), arg in zip(params, args):
            local[pname] = coerce(self.eval_expr(arg, env), ty)
        sig = self.exec_stmts(body, local)
        if isinstance(sig, _Ret):
            return coerce_ret(sig.value, ret)
        if sig is not None:
            fail(f'{name} used break or continue outside a loop')
        if ret is None:
            return None
        fail(f'{name} ended without a return')

    def exec_stmts(self, stmts, env):
        for stmt in stmts:
            sig = self.exec_stmt(stmt, env)
            if sig is not None:
                return sig
        return None

    def exec_stmt(self, stmt, env):
        kind = stmt[0]
        if kind == 'let':
            env[stmt[2]] = coerce(self.eval_expr(stmt[3], env), stmt[1])
            return None
        if kind == 'set':
            name = stmt[1]
            try:
                current = env[name]
            except KeyError:
                fail(f'assignment to undeclared {name}')
            env[name] = coerce(self.eval_expr(stmt[2], env), current.kind)
            return None
        if kind == 'set_multi':
            value = self.eval_expr(stmt[2], env)
            if not isinstance(value, tuple):
                fail('a destructuring assignment needs a tuple')
            names = stmt[1]
            if len(value) != len(names):
                fail('tuple arity mismatch')
            for name, item in zip(names, value):
                try:
                    current = env[name]
                except KeyError:
                    fail(f'assignment to undeclared {name}')
                env[name] = coerce(item, current.kind)
            return None
        if kind == 'expr':
            self.eval_expr(stmt[1], env)
            return None
        if kind == 'if':
            branch = stmt[2] if need_bool(self.eval_expr(stmt[1], env)) else stmt[3]
            return self.exec_stmts(branch, env)
        if kind == 'while':
            while need_bool(self.eval_expr(stmt[1], env)):
                sig = self.exec_stmts(stmt[2], env)
                if sig is _BREAK:
                    return None
                if sig is _CONT or sig is None:
                    continue
                return sig
            return None
        if kind == 'return':
            if stmt[1] is None:
                return _Ret(None)
            if stmt[1][0] == 'tuple':
                return _Ret(tuple(self.eval_expr(e, env) for e in stmt[1][1]))
            return _Ret(self.eval_expr(stmt[1], env))
        if kind == 'break':
            return _BREAK
        if kind == 'continue':
            return _CONT
        if kind == 'output':
            env[stmt[2]] = zero(stmt[1])
            return None
        fail(f'bad statement {kind}')


def run_source(text):
    funcs, tops = Parser(lex(text)).parse_program()
    machine = Machine(funcs)
    env = {}
    for stmt in tops:
        sig = machine.exec_stmt(stmt, env)
        if sig is not None:
            fail('control transfer at the top level')
    try:
        io = env['spiral_io']
    except KeyError:
        fail('missing spiral_io')
    if io.kind != 'i32':
        io = coerce(io, 'i32')
    return io.n


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
