program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TTuple0 = record f0: AnsiString; f1: AnsiString; f2: LongInt; end;
function run_0(v0: LongInt; v1: AnsiString; v2: AnsiString; v3: LongInt): TTuple0; forward;
function TupleCreate0(f0: AnsiString; f1: AnsiString; f2: LongInt): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1; Result.f2 := f2;
end;
function run_0(v0: LongInt; v1: AnsiString; v2: AnsiString; v3: LongInt): TTuple0;
var
  v4: Boolean;
  v11: AnsiString;
  v12: AnsiString;
  v13: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: AnsiString;
  v8: AnsiString;
  v9: AnsiString;
  v10: LongInt;
  tmp10: TTuple0;
begin
  v4 := v0 <= 0;
  if v4 then begin
      v11 := v1;
      v12 := v2;
      v13 := v3;
  end else begin
      v5 := v0 - 1;
      v6 := v3 + 1;
      v7 := 'y';
      tmp10 := run_0(v5, v2, v7, v6);
      v8 := tmp10.f0;
      v9 := tmp10.f1;
      v10 := tmp10.f2;
      v11 := v8;
      v12 := v9;
      v13 := v10;
  end;
  Result := TupleCreate0(v11, v12, v13);
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: AnsiString;
  v2: LongInt;
  v3: AnsiString;
  v4: AnsiString;
  v5: LongInt;
  tmp6: TTuple0;
  v6: LongInt;
begin
  v0 := 5;
  v1 := '';
  v2 := 0;
  tmp6 := run_0(v0, v1, v1, v2);
  v3 := tmp6.f0;
  v4 := tmp6.f1;
  v5 := tmp6.f2;
  v6 := v5 - 5;
  Result := v6;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
