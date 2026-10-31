program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TMut0 = class;
  TMut0 = class l0: LongInt; l1: AnsiString; end;
function method0(v0: LongInt; v1: AnsiString): TMut0; forward;
function MutCreate0(a0: LongInt; a1: AnsiString): TMut0;
begin
  Result := TMut0.Create; Result.l0 := a0; Result.l1 := a1;
end;
function method0(v0: LongInt; v1: AnsiString): TMut0;
begin
  Result := MutCreate0(v0, v1);
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: AnsiString;
  v2: TMut0;
  v3: LongInt;
  v4: AnsiString;
  v5: LongInt;
  v6: AnsiString;
  v7: Boolean;
  v9: Boolean;
  v8: Boolean;
begin
  v0 := 3;
  v1 := 'no';
  v2 := method0(v0, v1);
  v3 := 7;
  v4 := 'hi';
  v2.l0 := v3;
  v2.l1 := v4;
  v5 := v2.l0;
  v6 := v2.l1;
  v7 := v5 = 7;
  if v7 then begin
      v8 := v6 = 'hi';
      v9 := v8;
  end else begin
      v9 := False;
  end;
  if v9 then begin
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
