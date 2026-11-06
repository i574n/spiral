program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TSpiralRc = class refc: LongInt; procedure DropFields; virtual; end;
  TFun0 = class;
  THeap0 = record l0: LongInt; end;
  TFun0 = class(TSpiralRc)
    function Invoke(a0: LongInt): THeap0; virtual; abstract;
  end;
  Tf_c0 = class(TFun0) v0: THeap0; function Invoke(v1: LongInt): THeap0; override; end;
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
function ClosureCreate0(v0: THeap0): TFun0; forward;
function HeapCreate0(a0: LongInt): THeap0;
begin
  Result.l0 := a0;
end;
function Tf_c0.Invoke(v1: LongInt): THeap0;
begin
  Result := v0;
  SpiralRelease(Self);
end;
function ClosureCreate0(v0: THeap0): TFun0;
var c: Tf_c0;
begin
  c := Tf_c0.Create; c.v0 := v0;
  Result := c;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: THeap0;
  v2: TFun0;
  v3: THeap0;
  v4: LongInt;
  v5: Boolean;
begin
  v0 := 7;
  v1 := HeapCreate0(v0);
  v2 := ClosureCreate0(v1);
  SpiralRetain(v2);
  v3 := v2.Invoke(1);
  SpiralRelease(v2);
  v4 := v3.l0;
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
