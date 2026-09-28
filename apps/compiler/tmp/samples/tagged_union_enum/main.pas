program SpiralGenerated;
{$mode delphi}{$H+}
uses SysUtils, Math;
type
  TUS0 = record tag: LongInt;  end;
function method0(v0: TUS0): LongInt; forward;
function US0_0: TUS0;
begin
  Result.tag := 0; 
end;
function US0_1: TUS0;
begin
  Result.tag := 1; 
end;
function US0_2: TUS0;
begin
  Result.tag := 2; 
end;
function US0_3: TUS0;
begin
  Result.tag := 3; 
end;
function method0(v0: TUS0): LongInt;
begin
  case v0.tag of
      0: begin // Cold
          Result := 1;
      end;
      3: begin // Done
          Result := 4;
      end;
      2: begin // Hot
          Result := 3;
      end;
      1: begin // Warm
          Result := 2;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: Boolean;
  v10: TUS0;
  v3: Boolean;
  v5: Boolean;
  v11: LongInt;
  v12: LongInt;
begin
  v0 := 3;
  v1 := v0 = 0;
  if v1 then begin
      v10 := US0_0;
  end else begin
      v3 := v0 = 1;
      if v3 then begin
          v10 := US0_1;
      end else begin
          v5 := v0 = 2;
          if v5 then begin
              v10 := US0_2;
          end else begin
              v10 := US0_3;
          end;
      end;
  end;
  v11 := method0(v10);
  v12 := v11 - 4;
  Result := v12;
end;
begin
  Halt(SpiralMain);
end.
