program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUH0 = class;
  TUH0 = class tag: LongInt; c1_0: LongInt; c1_1: TUH0; c1_2: TUH0; end;
function method0(v0: TUH0): LongInt; forward;
function UH0_0: TUH0;
begin
  Result := TUH0.Create; Result.tag := 0; 
end;
function UH0_1(a0: LongInt; a1: TUH0; a2: TUH0): TUH0;
begin
  Result := TUH0.Create; Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1; Result.c1_2 := a2;
end;
function method0(v0: TUH0): LongInt;
var
  v1: LongInt;
  v2: TUH0;
  v3: TUH0;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
begin
  case v0.tag of
      0: begin // Leaf
          Result := 0;
      end;
      1: begin // Node
          v1 := v0.c1_0;
          v2 := v0.c1_1;
          v3 := v0.c1_2;
          v4 := method0(v2);
          v5 := method0(v3);
          v6 := v4 + v5;
          v7 := v1 + v6;
          Result := v7;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: TUH0;
  v1: LongInt;
  v2: TUH0;
  v3: LongInt;
  v4: TUH0;
  v5: LongInt;
  v6: LongInt;
begin
  v0 := UH0_0;
  v1 := 2;
  v2 := UH0_1(v1, v0, v0);
  v3 := 1;
  v4 := UH0_1(v3, v2, v2);
  v5 := method0(v4);
  v6 := v5 - 5;
  Result := v6;
end;
begin
  Halt(SpiralMain);
end.
