program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TSpiralRc = class refc: LongInt; procedure DropFields; virtual; end;
  TMut0 = class;
  TFun0 = class;
  TMut0 = class(TSpiralRc) l0: LongInt; end;
  TFun0 = class(TSpiralRc)
    function Invoke(a0: LongInt): TMut0; virtual; abstract;
  end;
  Tf_c0 = class(TFun0) v0: TMut0; function Invoke(v1: LongInt): TMut0; override; end;
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
function ClosureCreate0(v0: TMut0): TFun0; forward;
function MutCreate0(a0: LongInt): TMut0;
begin
  Result := TMut0.Create; Result.l0 := a0;
end;
function Tf_c0.Invoke(v1: LongInt): TMut0;
begin
  Result := v0;
end;
function ClosureCreate0(v0: TMut0): TFun0;
var c: Tf_c0;
begin
  c := Tf_c0.Create; c.v0 := v0;
  Result := c;
end;
function SpiralMain: LongInt;
var
  v0: TMut0;
  v1: TFun0;
  v2: TMut0;
  v3: LongInt;
  v4: Boolean;
begin
  v0 := MutCreate0(1);
  v1 := ClosureCreate0(v0);
  v2 := v1.Invoke(1);
  v2.l0 := 7;
  v3 := v2.l0;
  v4 := v3 = 7;
  if v4 then begin
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
