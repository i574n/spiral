program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TSpiralRc = class refc: LongInt; procedure DropFields; virtual; end;
  TMut0 = class;
  TMut0 = class(TSpiralRc) l0: LongInt; end;
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
procedure method0(v0: TMut0); forward;
procedure method1(v0: TMut0); forward;
procedure method2(v0: TMut0); forward;
function MutCreate0(a0: LongInt): TMut0;
begin
  Result := TMut0.Create; Result.l0 := a0;
end;
procedure method0(v0: TMut0);
var
  v1: LongInt;
  v2: LongInt;
begin
  v1 := v0.l0;
  v2 := v1 + 5;
  v0.l0 := v2;
end;
procedure method1(v0: TMut0);
begin
end;
procedure method2(v0: TMut0);
var
  v1: LongInt;
  v2: LongInt;
begin
  v1 := v0.l0;
  v2 := v1 + 7;
  v0.l0 := v2;
end;
function SpiralMain: LongInt;
var
  v0: TMut0;
  v1: LongInt;
  v2: LongInt;
begin
  v0 := MutCreate0(0);
  method0(v0);
  method1(v0);
  method2(v0);
  v1 := v0.l0;
  v2 := v1 - 12;
  Result := v2;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
