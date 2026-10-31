program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TTuple0 = record f0: AnsiString; f1: AnsiString; end;
function method0(v0: LongInt): TTuple0; forward;
function TupleCreate0(f0: AnsiString; f1: AnsiString): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1;
end;
function method0(v0: LongInt): TTuple0;
var
  v1: Boolean;
  v2: AnsiString;
  v3: AnsiString;
  v4: AnsiString;
begin
  v1 := v0 = 0;
  if v1 then begin
      v2 := 'no';
      Result := TupleCreate0(v2, v2);
  end else begin
      v3 := 'hi';
      v4 := 'yo';
      Result := TupleCreate0(v3, v4);
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: AnsiString;
  v2: AnsiString;
  tmp3: TTuple0;
  v3: Boolean;
  v5: Boolean;
  v4: Boolean;
begin
  v0 := 7;
  tmp3 := method0(v0);
  v1 := tmp3.f0;
  v2 := tmp3.f1;
  v3 := v1 = 'hi';
  if v3 then begin
      v4 := v2 = 'yo';
      v5 := v4;
  end else begin
      v5 := False;
  end;
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
