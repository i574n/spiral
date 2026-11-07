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
function SpiralKeep(o: TSpiralRc): TSpiralRc;
begin
  SpiralRetain(o); Result := o;
end;
function method0(v0: TMut0): TMut0; forward;
function MutCreate0(a0: LongInt): TMut0;
begin
  Result := TMut0.Create; Result.l0 := a0;
end;
function method0(v0: TMut0): TMut0;
begin
  Result := v0;
end;
function SpiralMain: LongInt;
var
  v0: TMut0;
  v1: TMut0;
  v2: LongInt;
  v3: Boolean;
begin
  v0 := MutCreate0(1);
  SpiralRetain(v0);
  v1 := method0(v0);
  SpiralRelease(v0);
  v1.l0 := 7;
  v2 := v1.l0;
  SpiralRelease(v1);
  v3 := v2 = 7;
  if v3 then begin
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
