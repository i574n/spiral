program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUS0 = record tag: LongInt;  end;
function US0_North: TUS0;
begin
  Result.tag := 0; 
end;
function US0_East: TUS0;
begin
  Result.tag := 1; 
end;
function US0_South: TUS0;
begin
  Result.tag := 2; 
end;
function US0_West: TUS0;
begin
  Result.tag := 3; 
end;
function SpiralMain: LongInt;
var
  v0: TUS0;
  v8: TUS0;
  v16: TUS0;
  v17: TUS0;
  v18: Boolean;
  tmp5: LongInt;
  v19: LongInt;
  v21: LongInt;
  v23: LongInt;
  v24: LongInt;
  v25: LongInt;
  v27: LongInt;
  v28: LongInt;
  v29: LongInt;
  v30: LongInt;
begin
  v0 := US0_North;
  case v0.tag of
      1: begin
          v8 := US0_South;
      end;
      0: begin
          v8 := US0_East;
      end;
      2: begin
          v8 := US0_West;
      end;
      3: begin
          v8 := US0_North;
      end;
  end;
  case v8.tag of
      1: begin
          v16 := US0_South;
      end;
      0: begin
          v16 := US0_East;
      end;
      2: begin
          v16 := US0_West;
      end;
      3: begin
          v16 := US0_North;
      end;
  end;
  v17 := US0_South;
  if (v16.tag = v17.tag) then tmp5 := v16.tag else tmp5 := -1;
  case tmp5 of
      1: begin
          v18 := True;
      end;
      0: begin
          v18 := True;
      end;
      2: begin
          v18 := True;
      end;
      3: begin
          v18 := True;
      end;
      else begin
          v18 := False;
      end;
  end;
  if v18 then begin
      v19 := 100;
  end else begin
      v19 := 0;
  end;
  case v0.tag of
      1: begin
          v21 := 2;
      end;
      0: begin
          v21 := 1;
      end;
      else begin
          v21 := 7;
      end;
  end;
  case v8.tag of
      1: begin
          v23 := 2;
      end;
      0: begin
          v23 := 1;
      end;
      else begin
          v23 := 7;
      end;
  end;
  v24 := v23 * 3;
  v25 := v21 + v24;
  case v16.tag of
      1: begin
          v27 := 2;
      end;
      0: begin
          v27 := 1;
      end;
      else begin
          v27 := 7;
      end;
  end;
  v28 := v27 * 9;
  v29 := v25 + v28;
  v30 := v29 + v19;
  Result := v30;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
