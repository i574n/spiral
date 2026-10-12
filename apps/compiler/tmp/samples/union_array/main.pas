program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TArray0 = array of LongInt;
  TUS0 = record tag: LongInt; c1_0: TArray0; end;
function US0_Missing: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Held(a0: TArray0): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TArray0;
  tmp2: TArray0;
  v2: LongInt;
  v3: Boolean;
  v6: TUS0;
  v7: TArray0;
  v8: LongInt;
  v9: Boolean;
begin
  v0 := 2;
  tmp2 := nil;
  SetLength(tmp2, v0);
  v1 := tmp2;
  v2 := 7;
  v1[0] := v2;
  v3 := True;
  if v3 then begin
      v6 := US0_Held(v1);
  end else begin
      v6 := US0_Missing;
  end;
  case v6.tag of
      1: begin
          v7 := v6.c1_0;
          v8 := v7[0];
          v9 := v8 = 7;
          if v9 then begin
              Result := 0;
          end else begin
              Result := 1;
          end;
      end;
      0: begin
          Result := 1;
      end;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
