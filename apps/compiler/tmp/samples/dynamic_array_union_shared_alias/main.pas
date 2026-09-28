program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TArray0 = array of LongInt;
  TUS0 = record tag: LongInt; c1_0: TArray0; end;
function method0(v0: TUS0): LongInt; forward;
function method1(v0: TUS0): LongInt; forward;
function US0_0: TUS0;
begin
  Result.tag := 0; 
end;
function US0_1(a0: TArray0): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function method0(v0: TUS0): LongInt;
var
  v1: TArray0;
  v2: LongInt;
  v3: LongInt;
begin
  case v0.tag of
      0: begin // Empty
          Result := 0;
      end;
      1: begin // Values
          v1 := v0.c1_0;
          v2 := v1[0];
          v3 := v2 + 1;
          v1[0] := v3;
          Result := 0;
      end;
  end;
end;
function method1(v0: TUS0): LongInt;
var
  v1: TArray0;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
begin
  case v0.tag of
      0: begin // Empty
          Result := 0;
      end;
      1: begin // Values
          v1 := v0.c1_0;
          v2 := LongInt(Length(v1));
          v3 := v1[0];
          v4 := v2 + v3;
          v5 := v1[1];
          v6 := v4 + v5;
          Result := v6;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TArray0;
  tmp2: TArray0;
  v2: TUS0;
  v3: LongInt;
  v4: TUS0;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
begin
  v0 := 2;
  tmp2 := nil;
  SetLength(tmp2, v0);
  v1 := tmp2;
  v1[0] := 4;
  v1[1] := 5;
  v2 := US0_1(v1);
  v3 := method0(v2);
  v4 := US0_1(v1);
  v5 := method1(v4);
  v6 := v5 + v3;
  v7 := v6 - 12;
  Result := v7;
end;
begin
  Halt(SpiralMain);
end.
