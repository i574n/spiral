program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TTuple0 = record f0: LongInt; f1: LongInt; end;
function loop_0(v0: LongInt; v1: LongInt; v2: LongInt; v3: LongInt): TTuple0; forward;
function TupleCreate0(f0: LongInt; f1: LongInt): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1;
end;
function loop_0(v0: LongInt; v1: LongInt; v2: LongInt; v3: LongInt): TTuple0;
var
  v4: Boolean;
  v5: LongInt;
  v6: LongInt;
  tmp3: LongInt;
  tmp4: LongInt;
  tmp5: LongInt;
  tmp6: LongInt;
begin
  while True do begin
      v4 := v1 >= v0;
      if v4 then begin
          Result := TupleCreate0(v2, v3);
          Exit;
      end else begin
          v5 := v1 + 1;
          v6 := v2 + 1;
          tmp3 := v0;
          tmp4 := v5;
          tmp5 := v6;
          tmp6 := v3;
          v0 := tmp3;
          v1 := tmp4;
          v2 := tmp5;
          v3 := tmp6;
          Continue;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  tmp6: TTuple0;
  v6: LongInt;
begin
  v0 := 5;
  v1 := 0;
  v2 := 1;
  v3 := 2;
  tmp6 := loop_0(v0, v1, v2, v3);
  v4 := tmp6.f0;
  v5 := tmp6.f1;
  v6 := v4 + v5;
  Result := v6;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
