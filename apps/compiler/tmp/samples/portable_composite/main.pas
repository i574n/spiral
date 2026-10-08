program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TTuple0 = record f0: Boolean; f1: Single; f2: LongInt; end;
  TTuple1 = record f0: LongInt; f1: LongInt; f2: Boolean; end;
function method5(v0: LongInt; v1: LongInt): LongInt; forward;
function method4(v0: LongInt): LongInt; forward;
function method6(v0: LongWord): Boolean; forward;
function method3(v0: LongInt): LongInt; forward;
function method7(v0: AnsiString): Boolean; forward;
function method2(v0: LongInt): LongInt; forward;
function method8(v0: Single): TTuple0; forward;
function method9(v0: Boolean; v1: Single; v2: LongInt): LongInt; forward;
function method1(v0: LongInt): LongInt; forward;
function method10(v0: LongInt): TTuple1; forward;
function method11(v0: LongInt; v1: LongInt; v2: Boolean): LongInt; forward;
function method0(v0: LongInt): LongInt; forward;
function method5(v0: LongInt; v1: LongInt): LongInt;
var
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
begin
  v2 := v0 * v1;
  v3 := v2 + 5;
  v4 := v3 div 3;
  Result := v4;
end;
function method4(v0: LongInt): LongInt;
var
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
begin
  v1 := 4;
  v2 := 4;
  v3 := method5(v1, v2);
  v4 := v0 + v3;
  v5 := v4 - 7;
  Result := v5;
end;
function method6(v0: LongWord): Boolean;
var
  v1: LongWord;
  v2: LongWord;
  v3: Boolean;
begin
  v1 := v0 + 5;
  v2 := v1 mod 4;
  v3 := v2 = 0;
  Result := v3;
end;
function method3(v0: LongInt): LongInt;
var
  v1: LongWord;
  v2: Boolean;
begin
  v1 := 7;
  v2 := method6(v1);
  if v2 then begin
      Result := method4(v0);
  end else begin
      Result := 1;
  end;
end;
function method7(v0: AnsiString): Boolean;
begin
  Result := True;
end;
function method2(v0: LongInt): LongInt;
var
  v1: AnsiString;
  v2: Boolean;
begin
  v1 := 'spiral';
  v2 := method7(v1);
  if v2 then begin
      Result := method3(v0);
  end else begin
      Result := 1;
  end;
end;
function TupleCreate0(f0: Boolean; f1: Single; f2: LongInt): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1; Result.f2 := f2;
end;
function method8(v0: Single): TTuple0;
var
  v1: Boolean;
begin
  v1 := v0 >= 3.5;
  Result := TupleCreate0(v1, v0, 7);
end;
function method9(v0: Boolean; v1: Single; v2: LongInt): LongInt;
var
  v3: Boolean;
  v4: LongInt;
begin
  if v0 then begin
      v3 := v1 >= 3.5;
      if v3 then begin
          v4 := v2 - 7;
          Result := v4;
      end else begin
          Result := 1;
      end;
  end else begin
      Result := 2;
  end;
end;
function method1(v0: LongInt): LongInt;
var
  v1: Single;
  v2: Boolean;
  v3: Single;
  v4: LongInt;
  tmp4: TTuple0;
  v5: LongInt;
  v6: LongInt;
begin
  v1 := 4.0;
  tmp4 := method8(v1);
  v2 := tmp4.f0;
  v3 := tmp4.f1;
  v4 := tmp4.f2;
  v5 := method9(v2, v3, v4);
  v6 := v0 + v5;
  Result := method2(v6);
end;
function TupleCreate1(f0: LongInt; f1: LongInt; f2: Boolean): TTuple1;
begin
  Result.f0 := f0; Result.f1 := f1; Result.f2 := f2;
end;
function method10(v0: LongInt): TTuple1;
var
  v1: LongInt;
  v2: Boolean;
begin
  v1 := v0 + 2;
  v2 := v0 > 0;
  Result := TupleCreate1(v0, v1, v2);
end;
function method11(v0: LongInt; v1: LongInt; v2: Boolean): LongInt;
var
  v3: LongInt;
  v4: LongInt;
begin
  if v2 then begin
      v3 := v0 + v1;
      v4 := v3 - 4;
      Result := v4;
  end else begin
      Result := 1;
  end;
end;
function method0(v0: LongInt): LongInt;
var
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
  v4: Boolean;
  tmp4: TTuple1;
  v5: LongInt;
  v6: LongInt;
begin
  v1 := 1;
  tmp4 := method10(v1);
  v2 := tmp4.f0;
  v3 := tmp4.f1;
  v4 := tmp4.f2;
  v5 := method11(v2, v3, v4);
  v6 := v0 + v5;
  Result := method1(v6);
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
begin
  v0 := 0;
  Result := method0(v0);
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
