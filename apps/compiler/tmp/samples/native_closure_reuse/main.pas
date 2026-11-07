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
  Tf_c0 = class(TFun0) v0: LongInt; v1: LongInt; function Invoke(v2: LongInt): LongInt; override; end;
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
function ClosureCreate0(v0: LongInt; v1: LongInt): TFun0; forward;
function Tf_c0.Invoke(v2: LongInt): LongInt;
var
  v3: LongInt;
  v4: LongInt;
begin
  v3 := v0 + v1;
  v4 := v3 + v2;
  Result := v4;
  SpiralRelease(Self);
end;
function ClosureCreate0(v0: LongInt; v1: LongInt): TFun0;
var c: Tf_c0;
begin
  c := Tf_c0.Create; c.v0 := v0; c.v1 := v1;
  Result := c;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: TFun0;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
begin
  v0 := 1;
  v1 := 2;
  v2 := ClosureCreate0(v0, v1);
  SpiralRetain(v2);
  v3 := v2.Invoke(10);
  SpiralRetain(v2);
  v4 := v2.Invoke(20);
  SpiralRetain(v2);
  v5 := v2.Invoke(3);
  SpiralRelease(v2);
  v6 := v3 + v4;
  v7 := v6 + v5;
  Result := v7;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
