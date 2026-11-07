program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TSpiralRc = class refc: LongInt; procedure DropFields; virtual; end;
  TFun0 = class;
  TFun0 = class(TSpiralRc)
    function Invoke(a0: LongInt): LongInt; virtual; abstract;
  end;
  Tadd_c0 = class(TFun0) v0: LongInt; function Invoke(v1: LongInt): LongInt; override; end;
  THeap0 = record l0: TFun0; l1: LongInt; end;
procedure TSpiralRc.DropFields;
begin
end;
procedure SpiralRetain(o: TSpiralRc);
begin
  if o <> nil then Inc(o.refc);
end;
procedure SpiralRelease(o: TSpiralRc);
begin
  if o <> nil then begin Dec(o.refc); if o.refc < 0 then begin o.DropFields; o.Free; end; end;
end;
function SpiralKeep(o: TSpiralRc): TSpiralRc;
begin
  SpiralRetain(o); Result := o;
end;
function ClosureCreate0(v0: LongInt): TFun0; forward;
procedure SpiralRetain_THeap0(const x: THeap0); forward;
procedure SpiralRelease_THeap0(const x: THeap0); forward;
function SpiralKeep_THeap0(const x: THeap0): THeap0; forward;
function Tadd_c0.Invoke(v1: LongInt): LongInt;
var
  v2: LongInt;
begin
  v2 := v1 + v0;
  Result := v2;
  SpiralRelease(Self);
end;
function ClosureCreate0(v0: LongInt): TFun0;
var c: Tadd_c0;
begin
  c := Tadd_c0.Create; c.v0 := v0;
  Result := c;
end;
function HeapCreate0(a0: TFun0; a1: LongInt): THeap0;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
procedure SpiralRetain_THeap0(const x: THeap0);
begin
  SpiralRetain(x.l0);
end;
procedure SpiralRelease_THeap0(const x: THeap0);
begin
  SpiralRelease(x.l0);
end;
function SpiralKeep_THeap0(const x: THeap0): THeap0;
begin
  SpiralRetain_THeap0(x); Result := x;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: TFun0;
  v3: THeap0;
  v4: TFun0;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: Boolean;
begin
  v0 := 3;
  v1 := 4;
  v2 := ClosureCreate0(v0);
  SpiralRetain(v2);
  v3 := HeapCreate0(v2, v1);
  SpiralRelease(v2);
  v4 := v3.l0;
  v5 := v3.l1;
  SpiralRetain(v4);
  SpiralRetain(v4);
  SpiralRelease_THeap0(v3);
  v6 := v4.Invoke(0);
  SpiralRelease(v4);
  v7 := v6 + v5;
  v8 := v7 = 7;
  if v8 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
