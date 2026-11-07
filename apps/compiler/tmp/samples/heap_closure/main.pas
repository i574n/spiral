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
  Tf_c0 = class(TFun0) v0: LongInt; function Invoke(v1: LongInt): LongInt; override; end;
  THeap0 = record l0: TFun0; end;
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
function Tf_c0.Invoke(v1: LongInt): LongInt;
var
  v2: LongInt;
begin
  v2 := v1 + v0;
  Result := v2;
  SpiralRelease(Self);
end;
function ClosureCreate0(v0: LongInt): TFun0;
var c: Tf_c0;
begin
  c := Tf_c0.Create; c.v0 := v0;
  Result := c;
end;
function HeapCreate0(a0: TFun0): THeap0;
begin
  Result.l0 := a0;
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
  v1: TFun0;
  v2: THeap0;
  v3: TFun0;
  v4: LongInt;
  v5: Boolean;
begin
  v0 := 3;
  v1 := ClosureCreate0(v0);
  SpiralRetain(v1);
  v2 := HeapCreate0(v1);
  SpiralRelease(v1);
  v3 := v2.l0;
  SpiralRetain(v3);
  SpiralRetain(v3);
  SpiralRelease_THeap0(v2);
  v4 := v3.Invoke(4);
  SpiralRelease(v3);
  v5 := v4 = 7;
  if v5 then begin
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
