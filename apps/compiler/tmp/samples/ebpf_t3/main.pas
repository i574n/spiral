program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TTuple0 = record f0: LongInt; f1: LongInt; f2: LongInt; end;
function method2(v0: LongInt; v1: LongInt; v2: LongInt; v3: LongInt): TTuple0; forward;
function method1(v0: LongInt): TTuple0; forward;
function method0(v0: LongInt): LongInt; forward;
function TupleCreate0(f0: LongInt; f1: LongInt; f2: LongInt): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1; Result.f2 := f2;
end;
function method2(v0: LongInt; v1: LongInt; v2: LongInt; v3: LongInt): TTuple0;
var
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: Boolean;
begin
  while True do begin
      v4 := v0 - 1;
      v5 := v1 + 1;
      v6 := v2 + 2;
      v7 := v3 + 3;
      v8 := v4 = 0;
      if v8 then begin
          Result := TupleCreate0(v5, v6, v7);
          Exit;
      end else begin
          v0 := v4;
          v1 := v5;
          v2 := v6;
          v3 := v7;
          Continue;
      end;
  end;
end;
function method1(v0: LongInt): TTuple0;
var
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
  v4: Boolean;
begin
  v1 := 0;
  v2 := 0;
  v3 := 0;
  v4 := v0 = 0;
  if v4 then begin
      Result := TupleCreate0(v1, v2, v3);
  end else begin
      Result := method2(v0, v1, v2, v3);
  end;
end;
function method0(v0: LongInt): LongInt;
var
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
  tmp3: TTuple0;
  v4: Boolean;
  v6: Boolean;
  v5: Boolean;
  v8: Boolean;
  v7: Boolean;
begin
  tmp3 := method1(v0);
  v1 := tmp3.f0;
  v2 := tmp3.f1;
  v3 := tmp3.f2;
  v4 := v1 = 3;
  if v4 then begin
      v5 := v2 = 6;
      v6 := v5;
  end else begin
      v6 := False;
  end;
  if v6 then begin
      v7 := v3 = 9;
      v8 := v7;
  end else begin
      v8 := False;
  end;
  if v8 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
begin
  v0 := 3;
  Result := method0(v0);
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
