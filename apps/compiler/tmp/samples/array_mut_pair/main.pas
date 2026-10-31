program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TMut0 = class;
  TMut0 = class l0: LongInt; l1: AnsiString; end;
  TArray0 = array of TMut0;
function MutCreate0(a0: LongInt; a1: AnsiString): TMut0;
begin
  Result := TMut0.Create; Result.l0 := a0; Result.l1 := a1;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: AnsiString;
  v2: TMut0;
  v3: TArray0;
  tmp4: TArray0;
  v4: TMut0;
  v5: LongInt;
  v6: AnsiString;
  v7: LongInt;
  v8: AnsiString;
  v9: Boolean;
  v11: Boolean;
  v10: Boolean;
begin
  v0 := 3;
  v1 := 'no';
  v2 := MutCreate0(v0, v1);
  tmp4 := nil;
  SetLength(tmp4, 1);
  v3 := tmp4;
  v3[0] := v2;
  v4 := v3[0];
  v5 := 7;
  v6 := 'hi';
  v4.l0 := v5;
  v4.l1 := v6;
  v7 := v4.l0;
  v8 := v4.l1;
  v9 := v7 = 7;
  if v9 then begin
      v10 := v8 = 'hi';
      v11 := v10;
  end else begin
      v11 := False;
  end;
  if v11 then begin
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
