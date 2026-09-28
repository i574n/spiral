program SpiralGenerated;
{$mode delphi}{$H+}
uses SysUtils, Math;
type
  TUH0 = class;
  TUH0 = class tag: LongInt; c1_0: LongInt; c1_1: TUH0; end;
function method2(v0: LongInt): TUH0; forward;
function method1(v0: LongInt): TUH0; forward;
function method0: TUH0; forward;
function UH0_0: TUH0;
begin
  Result := TUH0.Create; Result.tag := 0; 
end;
function UH0_1(a0: LongInt; a1: TUH0): TUH0;
begin
  Result := TUH0.Create; Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1;
end;
function method2(v0: LongInt): TUH0;
var
  v1: LongInt;
  v2: Boolean;
  v3: TUH0;
begin
  v1 := v0 - 1;
  v2 := v1 = 0;
  if v2 then begin
      v3 := UH0_0;
      Result := UH0_1(7, v3);
  end else begin
      Result := method1(v1);
  end;
end;
function method1(v0: LongInt): TUH0;
var
  v1: LongInt;
  v2: Boolean;
  v3: TUH0;
begin
  v1 := v0 - 1;
  v2 := v1 = 0;
  if v2 then begin
      v3 := UH0_0;
      Result := UH0_1(11, v3);
  end else begin
      Result := method2(v1);
  end;
end;
function method0: TUH0;
var
  v0: LongInt;
  v1: Boolean;
  v2: TUH0;
begin
  v0 := 1000000;
  v1 := v0 = 0;
  if v1 then begin
      v2 := UH0_0;
      Result := UH0_1(7, v2);
  end else begin
      Result := method1(v0);
  end;
end;
function SpiralMain: LongInt;
var
  v0: TUH0;
  v1: LongInt;
  v2: TUH0;
  v3: Boolean;
begin
  v0 := method0;
  case v0.tag of
      1: begin // Box
          v1 := v0.c1_0;
          v2 := v0.c1_1;
          v3 := v1 = 7;
          if v3 then begin
              Result := 0;
          end else begin
              Result := 3;
          end;
      end;
      0: begin // Empty
          Result := 1;
      end;
  end;
end;
begin
  Halt(SpiralMain);
end.
